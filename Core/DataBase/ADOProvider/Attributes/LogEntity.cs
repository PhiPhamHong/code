using System.Collections.Generic;
using Core.Reflectors;
using Core.Extensions;
using System;
using Core.Attributes;
using Core.Utility;
namespace Core.DataBase.ADOProvider.Attributes
{
    public class LogEntity
    {
        public ActionLog Action { set; get; }
        public string Name { set; get; } // Tên của Entity. Ví dụ Entity: Trạng thái đơn hàng

        public string ExtendData { set; get; }   // Dữ liệu mở rộng của Entity
        public string NameConcrete { set; get; } // Một giá trị cụ thể của Entity. Ví dụ: Đã hoàn thành
        public int? KeyConcrete { set; get; }
        public string TypeConrete { set; get; }

        private List<LogEntityDetail> details = new List<LogEntityDetail>();
        public List<LogEntityDetail> Details
        {
            get { return details; }
        }

        public string Title
        {
            get { return EnumHelper<ActionLog, FieldInfoAttribute>.Inst.GetAttribute(Action).Name; }
        }

        public static LogEntity LogEntityChange<TModel>(TModel @new, TModel old) where TModel : ModelBase
        {
            var log = new LogEntity { Name = @new.GetEntityName(), Action = (old != null ? ActionLog.Edit : ActionLog.AddNew) };
            BuilLog(log, @new);

            if (old != null)
            {
                var properties = ReflectTypeListFieldLogChange.Inst[@new.GetType()];
                properties.ForEach(p =>
                {
                    if (!p.T2.LogWhenChange) return;
                    if (p.T2.Name.IsNull()) return;

                    var newValue = p.T1.GetValue(@new);
                    var oldValue = p.T1.GetValue(old);

                    var helper = p.T1.PropertyType == typeof(string) ? StringCheckEqual : DefaultCheckEqual;

                    if (!helper.CheckDifferent(newValue, oldValue))
                    {
                        var detail = new LogEntityDetail { Field = p.T1.Name, Name = p.T2.Name, OldValue = oldValue, NewValue = newValue, TypeRef = p.T2.TypeRef == null ? string.Empty : p.T2.TypeRef.GetTypeNameWithAssembly() };
                        if (detail.TypeRef.IsNull() && p.T1.PropertyType.IsEnum)
                            detail.TypeRef = p.T1.PropertyType.GetTypeNameWithAssembly();
                        log.Details.Add(detail);
                    }
                });
            }
            return log;
        }
        public static LogEntity LogEntityDelete<TModel>(TModel deleted) where TModel : ModelBase
        {
            var log = new LogEntity { Name = deleted.GetEntityName(), Action = ActionLog.Delete };
            BuilLog(log, deleted);
            return log;
        }

        private static void BuilLog<TModel>(LogEntity log, TModel model) where TModel : ModelBase
        {
            if (model.Is<IEntityForLogShowName>()) log.NameConcrete = model.As<IEntityForLogShowName>().Name;
            if (model.Is<IEntityForLogDataExtend>()) log.ExtendData = model.As<IEntityForLogDataExtend>().ExtendData.ToJson2();
            if (model.Is<IEntityForLogShowNameByRef>())
            {
                log.KeyConcrete = model.As<IEntityForLogShowNameByRef>().NameKey;
                log.TypeConrete = model.As<IEntityForLogShowNameByRef>().TypeNameKey.GetTypeNameWithAssembly();
            }
        }

        public class CheckEqualHelper
        {
            public virtual bool CheckDifferent(object value1, object value2)
            {
                if (value1 == null && value2 == null) return true;
                if (value1 == null && value2 != null) return false;
                if (value1 != null && value2 == null) return false;
                return value1.Equals(value2);
            }
        }
        public class CheckStringEqualHelper : CheckEqualHelper
        {
            public override bool CheckDifferent(object value1, object value2)
            {
                var s1 = Convert.ToString(value1);
                var s2 = Convert.ToString(value2);
                return s1.Equals(s2);
            }
        }

        private static CheckEqualHelper DefaultCheckEqual = new CheckEqualHelper();
        private static CheckEqualHelper StringCheckEqual = new CheckStringEqualHelper();

        public enum ActionLog : byte
        {
            [FieldInfo(Name = "Thêm mới")] AddNew = 0,
            [FieldInfo(Name = "Chỉnh sửa")] Edit = 1,
            [FieldInfo(Name = "Xóa")] Delete = 2,
            [FieldInfo(Name = "Chạy tool dữ liệu")] RunTool = 3
        }
    }
}
