using Core.Attributes;
namespace Core.Business.Enums
{
    public enum DayOfWeek : byte
    {
        [FieldInfo(Name = "Chủ nhật")] Sunday = 0,
        [FieldInfo(Name = "Thứ 2")] Monday = 1,
        [FieldInfo(Name = "Thứ 3")] Tuesday = 2,
        [FieldInfo(Name = "Thứ 4")] Wednesday = 3,
        [FieldInfo(Name = "Thứ 5")] Thursday = 4,
        [FieldInfo(Name = "Thứ 6")] Friday = 5,
        [FieldInfo(Name = "Thứ 7")] Saturday = 6,
    }
}
