using Core.Attributes;

namespace Core.Business.Enums
{
    public enum Gender : byte
    {
        [FieldInfo(Name = "Nam")] Male = 0,
        [FieldInfo(Name = "Nữ")] Female = 1,
        [FieldInfo(Name = "Khác")] Unknown = 3
    }
}
