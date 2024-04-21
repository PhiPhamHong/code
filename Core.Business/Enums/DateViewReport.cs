using System;
using Core.Attributes;
using Core.Extensions;
namespace Core.Business.Enums
{
    public enum DateViewReport : byte
    {
        [FieldInfo(Name = "Xem theo tháng")] ViewByMonth = 0,
        [FieldInfo(Name = "Xem theo quý")] ViewByQuarter = 1
    }

    public static class DateViewReportExtension
    {
        public static FromTo<DateTime> GetRangeDate(this DateViewReport view, int month, int quarter, int year)
        {
            switch(view)
            {
                case DateViewReport.ViewByMonth: return year.GetRangeDateInMonth(month);
                default: return year.GetRangeDateInQuarter(quarter);
            }
        }
    }
}