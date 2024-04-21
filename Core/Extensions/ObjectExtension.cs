using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.ComponentModel;

using System.Web.UI;
using System.Data;
using Newtonsoft.Json;

using Core.Utility;
using Core.Utility.MsgSerialize;
using Core.Types;
using Core.Attributes;
using Core.Attributes.Validators;
using System.Reflection.Emit;
namespace Core.Extensions
{
    public static partial class ObjectExtension
    {
        public static T To<T>(this object obj, T @default)
        {
            // Nếu bằng null thì return default
            if (obj == null) return @default;

            // Lấy ra Converter của T
            var convert = SqlTypeDescriptor.Inst.GetConverter(typeof(T));

            // Thực hiện Convert
            return convert.CanConvertFrom(obj.GetType()) ? (T)convert.ConvertFrom(obj) : @default;
        }

        public static object To(this object obj, Type type)
        {
            if (obj.IsNull()) return type.GetDefault();
            var convert = SqlTypeDescriptor.Inst.GetConverter(type);
            return convert.CanConvertFrom(obj.GetType()) ? convert.ConvertFrom(obj) : type.GetDefault();
        }

        public static T To<T>(this object obj) { return obj.To<T>(default(T)); }
        public static ValidatorMessage Validate(this object obj, Dictionary<string, object> values, bool validateFullProperties)
        {
            var type = obj.GetType();

            // Danh sách property có chứa attribute thực hiện validate
            var prs = obj.GetType().GetListPairPropertyListAttribute<ValidatorAttribute>();

            // Bắt buộc phải validate hết dù trường đó ko post lên
            if (validateFullProperties)
                prs.FindNewItems(values, p => p.T1.Name, v => v.Key).ToList().ForEach(p => values[p.T1.Name] = null);

            // Join để thực hiện validate key trùng với tên property
            var list = values.Join(prs, v => v.Key, p => p.T1.Name, (v, p) => new { V = v, P = p }).ToList();

            for (var i = 0; i < list.Count; i++)
            {
                var vm = DoValidate(list[i].P, list[i].V.Value, values, type); // Thực hiện validate với property đang xét
                if (vm != null) return vm;
            }

            // Message thực hiện validate
            return ValidatorMessage.GetDefault();
        }
        public static ValidatorMessage Validate(this object obj, NameValueCollection values, bool validateFullProperties) => obj.Validate(values.ToDic(), validateFullProperties);
        private static ValidatorMessage DoValidate(Pair<PropertyInfo, List<ValidatorAttribute>> pr, object value, Dictionary<string, object> data, Type typeObject)
        { 
            // Property quy định alias tên thuộc tính
            var pif = pr.T1.GetAttribute<PropertyInfoAttribute>();

            // Tên alias
            var name = pif == null ? pr.T1.Name : pif.Name;

            // sắp xếp thứ tự các validator
            var list = pr.T2.OrderBy(v => v.Stt).ToList();

            // Duyệt qua các validator của property
            for (var j = 0; j < list.Count; j++)
            {
                var validator = list[j];

                // Thiết lập giá trị cần thực hiện validate
                validator.SetData(value, name);
                validator.Data = data;
                validator.ObjectType = typeObject;

                // Thực hiện valiate
                if (!validator.Validate()) return new ValidatorMessage
                {
                    Status = ValidatorStatus.InValid,
                    Message = validator.GetMessage(),
                    FieldName = pr.T1.Name
                };
            }
            return null;
        }
        public static ValidatorMessage Validate(this object obj, bool validateFullProperties)
        {
            // Danh sách property có chứa attribute thực hiện validate
            var prs = obj.GetType().GetListPairPropertyListAttribute<ValidatorAttribute>();
            return obj.Validate(prs.ToDictionary(p => p.T1.Name, p => p.T1.GetValue(obj)), validateFullProperties);
        }
        public static bool Is<T>(this object obj) { return obj is T; }
        public static List<object> CastToList(this object obj)
        {
            if (obj.Is<string>()) return null;
            if (obj.Is<IListSource>()) return obj.As<IListSource>().GetList().Cast<object>().ToList(); // Nếu là IListSource 
            if (obj.Is<IEnumerable>()) return obj.As<IEnumerable>().Cast<object>().ToList(); // Nếu là IEnumerable thì lấy object
            return null; // mặc định là return null
        }
        public static bool IsNull(this object obj) { return obj == null; }
        public static bool IsNotNull(this object obj) { return obj != null; }
        public static T As<T>(this object obj) { return obj.IsNull() ? default(T) : (T)obj; }
        public static void Parse(this object obj, NameValueCollection values, bool ignoreCase) { obj.Parse(values.ToDic(), ignoreCase); }
        public static void Parse(this object obj, DataRow dr, bool ignoreCase)
        {
            var dic = new Dictionary<string, object>(); // Dùng dic để lưu các giá trị
            dr.Table.Columns.Cast<DataColumn>().ToList().ForEach(c => dic[c.ColumnName] = dr[c]); // Duyệt qua từng Column
            obj.Parse(dic, ignoreCase);
        }
        public static void Parse(this object obj, Dictionary<string, object> dic, bool ignoreCase)
        {
            // Không phân biệt hoa thường ở tên property
            if (ignoreCase) obj.Parse(dic, p => p.Name.ToLower(), name => name.ToLower());

            // Có phân biệt hoa thường ở tên property
            else obj.Parse(dic, p => p.Name, name => name);
        }
        private static void Parse(this object obj, Dictionary<string, object> dic, Func<PropertyInfo, string> getPropertyName, Func<string,string> getKeyName)
        {
            // TypeOfObject
            var type = obj.GetType();

            // danh sách Property của obj
            var pis = type.GetListProperties().Where(p => p.CanWrite);

            // Join tìm thuộc tính phù hợp để điền giá trị
            pis.Join(dic, p => getPropertyName(p), d => getKeyName(d.Key), (p, d) => 
            {
                p.SetValue(obj, d.Value.ConvertToType(p.PropertyType));
                return false;
            }).Count();
        }

        public static object ConvertToType(this object obj, Type type)
        {
            // Lấy ra Converter phù hợp
            var converter = SqlTypeDescriptor.Inst.GetConverter(type);
            var ctype = converter.GetType();

            // Nếu convert được thì gán giá trị bằng giá trị được convert

            if (ctype.Name == typeof(EnumConverter).Name && (obj.IsNull() || obj.ToString().IsNull()))
            {
                return System.Enum.GetValues(type).GetValue(0);
            }
            else if (converter.CanConvertFrom(obj.IsNull() ? typeof(DBNull) : obj.GetType())) return converter.ConvertFrom(obj);
            else if (obj.IsNotNull() && obj != DBNull.Value)
            {
                if (ctype.Name == typeof(EnumConverter).Name)
                {
                    return converter.ConvertFrom(obj.ToString());
                }
                else if (ctype.Name == typeof(NullableConverter).Name)
                {
                    if ((converter as NullableConverter).UnderlyingType.IsEnum)
                        return System.Enum.ToObject((converter as NullableConverter).UnderlyingType, obj);
                }
            }

            return type.GetDefault();
        }

        /// <summary>
        /// Hàm thiết lập giá trị cho propertyName của đối tượng mà không có validate
        /// Chỉ dùng khi chắc chắn propertyName là có và value là giá trị gán được
        /// </summary>
        public static void SetValueToProperty(this object obj, string propertyName, object value) { obj.GetType().GetProperty(propertyName).SetValue(obj, value, null); }

        public static T WhenNull<T>(this T t, Func<T> action) { return t.IsNull() ? action() : t; }
        public static T WhenValue<T>(this T t, T when, Func<T> action) { return t.Equals(when) ? action() : t; }
        public static TResult WhenNotNull<T, TResult>(this T t, Func<T, TResult> action) { return t.IsNotNull() ? action(t) : default(TResult); }
        public static object Eval(this object obj, string member) { return DataBinder.Eval(obj, member); }
        public static object GetPropertyValue(this object obj, string propertyName)
        {   
            if (obj.IsNull()) return null;
            var pi = obj.GetType().GetProperty(propertyName);
            return pi.IsNull() ? null : pi.GetValue(obj, null);
        }
        public static string ToJson(this object obj) { return JsonConvert.SerializeObject(obj); }
        public static string ToJson2(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public static T JsonToObject<T>(this string json)
        {
            if (json.IsNull()) return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void Deserialize<T>(this byte[] bytes, T t) where T : class
        {
            var length = bytes.Length;
            var i = 0;

            TypePropertyIndex.Inst[t.GetType()].ForEach(p =>
            {
                if (i >= length) return;

                var provider = SerializeLibrary.GetByTypeCode(p.T1.PropertyType);
                var value = provider.Deserialize(bytes, p.T1.PropertyType, p.T2, ref i);
                p.T1.SetValue(t, value);
            });
        }
        public static byte[] Serialize<T>(this T t) // where T : class
        {
            return TypePropertyIndex.Inst[t.GetType()].SelectMany(p =>
            {
                var provider = SerializeLibrary.GetByTypeCode(p.T1.PropertyType);
                return provider.Serialize(p.T1.GetValue(t, null), p.T1.PropertyType, p.T2);
            }).ToArray();
        }

        public static string SerializeFormatString<T>(this T t)
        {
            return TypePropertyIndex.Inst[t.GetType()].JoinString(p => SerializeLibrary.GetByTypeCode(p.T1.PropertyType).SerializeToString(p.T1.GetValue(t, null), p.T1.PropertyType, p.T2), "_");
        }

        public static byte[] SerializeAnyType(this object t, Type type, TypeCode typeCode = TypeCode.Empty)
        {
            var provider = SerializeLibrary.GetByTypeCode(type);
            return provider.Serialize(t, type, typeCode == TypeCode.Empty ? null : new PropertyIndexAttribute { TypeCode = typeCode });
        }
        public static string SerializeToString<T>(this T t) where T : class, new()
        {
            return Convert.ToBase64String(t.Serialize());
        }
        public static string SerializeToString<T>(this T t, byte[] extend) where T : class, new()
        {
            return Convert.ToBase64String(t.Serialize().Concat(extend).ToArray());            
        }
        public static T Deserialize<T>(this string content) where T : class, new()
        {
            var bytes = Convert.FromBase64String(content);
            var t = new T();
            bytes.Deserialize(t);
            return t;
        }
        public static bool IsNull<T>(this Nullable<T> value) where T : struct
        {
            return value == null || object.Equals(value, default(T));
        }
        public static Dictionary<string, object> GetDictionary(this object obj)
        {
            if (obj == null) return null;
            return obj.GetType().GetProperties().Where(p => p.GetAttribute<PropertyInfoAttribute>() != null).ToDictionary(p => p.Name, p => p.GetValue(obj));
        }

        //private static ModuleBuilder moduleBuilder = null;
        //public static ModuleBuilder ModuleBuilder
        //{
        //    get 
        //    { 
        //        if(moduleBuilder == null)
        //        {
        //            var aName = typeof(ObjectExtension).GetType().Assembly.GetName();
        //            var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndCollect);
        //            moduleBuilder = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
        //        }
        //        return moduleBuilder; 
        //    }
        //}

        //public static Type NewType(this object t, string name, List<Pair<string, Type>> properties)
        //{
        //    var tb = ModuleBuilder.DefineType(name, TypeAttributes.Public);
        //    properties.ForEach(property =>
        //    {
        //        var field = tb.DefineField("m_" + property.T1, property.T2, FieldAttributes.Private);
        //        var propertyBuilder = tb.DefineProperty(property.T1, System.Reflection.PropertyAttributes.HasDefault, property.T2, null);
        //        var getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
        //        var mbGetAccessor = tb.DefineMethod("get_" + property.T1, getSetAttr, property.T2, Type.EmptyTypes);

        //        var getIL = mbGetAccessor.GetILGenerator();
        //        getIL.Emit(OpCodes.Ldarg_0);
        //        getIL.Emit(OpCodes.Ldfld, field);
        //        getIL.Emit(OpCodes.Ret);

        //        var mbSetAccessor = tb.DefineMethod("set_" + property.T1, getSetAttr, null, new Type[] { property.T2 });

        //        var setIL = mbSetAccessor.GetILGenerator();
        //        setIL.Emit(OpCodes.Ldarg_0);
        //        setIL.Emit(OpCodes.Ldarg_1);
        //        setIL.Emit(OpCodes.Stfld, field);
        //        setIL.Emit(OpCodes.Ret);

        //        propertyBuilder.SetGetMethod(mbGetAccessor);
        //        propertyBuilder.SetSetMethod(mbSetAccessor);
        //    });

        //    return tb.CreateType();
        //}

        public static string FormatMoney(this decimal? money)
        {
            return money == null ? "0 đ" : money.Value.FormatMoney();
        }
        public static string FormatMoney(this decimal money)
        {
            return money.ToString("###,### đ");
        }

        public static string FormatNumber(this decimal? num)
        {
            return num == null ? "" : num.Value.ToString("###,###");
        }

        public static string FormatNumber(this decimal num)
        {
            return num.ToString("###,###");
        }
    }
}