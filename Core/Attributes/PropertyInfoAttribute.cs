using Core.Extensions;
using Core.Utility;
using System;
namespace Core.Attributes
{
    public class PropertyInfoAttribute : Attribute
    {
        public Type TypeRef { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Position Position { set; get; }
    }
    public enum Position : byte
    {
        [Position(Position = "auto")] Auto = 0,
        [Position(Position = "bottom")] Bottom = 1,
        [Position(Position = "right")] Right = 2,
        [Position(Position = "top")] Top = 3,
        [Position(Position = "left")] Left = 4
    }

    public class PositionAttribute : FieldInfoAttribute
    {
        public string Position { set; get; }
    }

    public class PropertyMapperAttribute : PropertyInfoAttribute
    {
        public PropertyMapperAttribute()
        {

        }

        public PropertyMapperAttribute(Type typeMapper) => TypeMapper = typeMapper;

        private Type TypeMapper { set; get; }
        public string DoMap(object value)
        {
            if (TypeMapper == null) return Convert.ToString(value);
            return TypeMapper.CreateInstance<PropertyMapper>().DoMap(value);
        }
    }

    /// <summary>
    /// Thực hiện Mapper dữ liệu cho thuộc tính tìm kiếm của báo cáo
    /// </summary>
    public abstract class PropertyMapper
    {
        public abstract string DoMap(object value);
    }

    public abstract class PropertyMapper<T> : PropertyMapper
    {
        sealed public override string DoMap(object value) => Map(value.To<T>());

        protected abstract string Map(T value);
    }

    public abstract class PropertyMapperEnum<T> : PropertyMapper
    {
        public override string DoMap(object value) => EnumHelper<T, FieldInfoAttribute>.Inst.GetAttribute((T)value).Name;
    }
}
