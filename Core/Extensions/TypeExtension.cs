using System;
using System.Linq;
using Core.Attributes;
using Core.Reflectors;
using System.Reflection;
using Core.Utility;
using System.Collections.Generic;
namespace Core.Extensions
{
    /// <summary>
    /// Phương thức mở rộng cho Type
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Lấy ra danh sách PropertyInfo của một type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetListProperties(this Type type)
        { 
            return ReflectTypeListProperty.Inst[type];
        }

        /// <summary>
        /// Lấy ra thuộc tính mà Public
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertiesPublic(this Type type)
        {
            return ReflectTypeListPropertyPublic.Inst[type];
        }

        /// <summary>
        /// Lấy ra Attribute ClassInfoAttribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TAttribute GetClassInfoAttribute<TAttribute>(this Type type) where TAttribute : ClassInfoAttribute
        {
            return ReflectClassInfo<TAttribute>.Inst[type];
        }

        public static List<Pair<PropertyInfo, TAttribute>> GetListPairPropertyAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return ReflectTypeListPropertyWithAttribute<TAttribute>.Inst[type];
        }

        public static List<Pair<PropertyInfo, List<TAttribute>>> GetListPairPropertyListAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return ReflectTypeListPropertyWithListAttribute<TAttribute>.Inst[type];
        }

        public static object CreateInstance(this Type type, params object[] param)
        {
            return Activator.CreateInstance(type, param);
        }

        public static T CreateInstance<T>(this Type type, params object[] param)
        {
            return (T)type.CreateInstance(param);
        }

        /// <summary>
        /// Kiểm tra xem t1 có phải là t2 hoặc là kế thừa đến t2 hay không
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool CompareType(this Type t1, Type t2)
        {
            while (t1 != null)
            {
                if (t1 == t2) return true;
                t1 = t1.BaseType;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra xem có Interface
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeInterface"></param>
        /// <returns></returns>
        public static bool HasInterface(this Type type, Type typeInterface)
        {
            return type.GetInterfaces().Contains(typeInterface);
        }

        /// <summary>
        /// Kiểm tra xem toCheck có phải là kiểu kế thừa tới generic không
        /// </summary>
        /// <param name="toCheck"></param>
        /// <param name="generic"></param>
        /// <returns></returns>
        public static bool IsGenericTypeOf(this Type toCheck, Type generic)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public static string GetTypeName(this Type type)
        {
            var assemblyName = type.Assembly.FullName.Split(',')[0]; // AssemblyName
            return type.FullName.Replace("{0}.".Frmat(assemblyName), string.Empty);
        }

        public static string GetTypeNameWithAssembly(this Type type)
        {
            var assemblyName = type.Assembly.FullName.Split(',')[0]; // AssemblyName
            return type.FullName + "," + assemblyName;
        }

        public static object GetDefault(this Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }
    }
}