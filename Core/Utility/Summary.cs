using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
namespace Core.Utility
{
    public class Summary
    {
        public class Year
        {
            public int Month { set; get; }
            public int Total { set; get; }

            public static List<Year> Get(Func<List<Year>> data)
            {
                var dataReturn = Enumerable.Range(1, 12).Select(r => new Year { Month = r }).ToList();
                EnumerableExtension.SJoin(dataReturn, data(), d => d.Month, s => s.Month, (d, s) => d.Total = s.Total);
                return dataReturn;
            }
            public static List<Year> Get(int year, Func<DateTime, DateTime, List<Year>> data)
            {
                return Get(() => 
                {
                    var fromDate = new DateTime(year, 1, 1);
                    var toDate = fromDate.AddYears(1).AddSeconds(-1);
                    return data(fromDate, toDate);
                });
            }
        }
        public class Month
        {
            public int Day { set; get; }
            public int Total { set; get; }

            public static List<Month> Get(int year, int month, Func<DateTime, DateTime, List<Month>> data)
            {
                var range = year.GetRangeDateInMonth(month);
                var dataReturn = range.From.RangeTo(range.To).Select(r => new Month { Day = r.Day }).ToList();
                EnumerableExtension.SJoin(dataReturn, data(range.From, range.To), d => d.Day, s => s.Day, (d, s) => d.Total = s.Total);
                return dataReturn;
            }
        }
    }
}