using Core.Attributes;
namespace Core.Business.Enums
{
    public enum PeriodNotify : byte
    {
        [FieldInfo(Name = "Theo tuần")] ByWeek = 0,
        [FieldInfo(Name = "Theo tháng")] ByMonth = 1
    }
}
