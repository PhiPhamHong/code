using System;
using System.Collections.Generic;
namespace Core.Extensions
{
    public static class DateTimeExtension
    {
        public static TimeSpan? DoTryParseToTimeSpan(this string data)
        {
            TimeSpan tss;
            if (TimeSpan.TryParse(data, out tss)) return tss;
            else return null;
        }
        public static IEnumerable<DateTime> RangeTo(this DateTime from, DateTime to)
        {
            var totalDays = (to - from).TotalDays;

            yield return from;

            for (int i = 1; i <= totalDays; i++)
                yield return from.AddDays(i);
        }
        private static DateTime MinTime = new DateTime(1970, 1, 1, 0, 0, 0);
        public static double GetTotalMilliseconds(this DateTime date) { return (date - MinTime).TotalMilliseconds; }
        public static DateTime ToDateTime(this double milliseconds) { return MinTime.AddMilliseconds(milliseconds); }

        public static FromTo<DateTime> GetRangeDateInWeek(this DateTime date)
        {
            var dow = (int)date.DayOfWeek;
            if (dow == 0) dow = 7;

            return new FromTo<DateTime>
            {
                From = date.AddDays(1 - dow).Date,
                To = date.AddDays(7 - dow).Date.AddDays(1).AddSeconds(-1)
            };
        }
        public static FromTo<DateTime> GetRangeDateInMonth(this DateTime date) { return date.Year.GetRangeDateInMonth(date.Month); }
        public static DateTime EndMonth(this DateTime date) { return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddSeconds(-1); }
        public static DateTime StartMonth(this DateTime date) { return new DateTime(date.Year, date.Month, 1); }
        public static int GetQuarter(this DateTime date) { return (int)Math.Ceiling((decimal)date.Month / 3); }

        public static FromTo<DateTime> GetRangeDateInMonth(this int year, int month)
        {
            return new FromTo<DateTime>
            {
                From = new DateTime(year, month, 1),
                To = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1)
            };
        }
        public static FromTo<DateTime> GetRangeDateInYear(this int year)
        {
            return new FromTo<DateTime>
            {
                From = new DateTime(year, 1, 1),
                To = new DateTime(year, 1, 1).AddYears(1).AddSeconds(-1)
            };
        }
        public static FromTo<DateTime> GetRangeDateInQuarter(this int year, int quarter)
        {
            var startMonth = (quarter - 1) * 3 + 1;
            var endMonth = quarter * 3;
            return new FromTo<DateTime>
            {
                From = new DateTime(year, startMonth, 1),
                To = new DateTime(year, endMonth, 1).AddMonths(1).AddSeconds(-1)
            };
        }

        private static long ticksBase = DateTime.Parse("01/01/1970 00:00:00").Ticks;

        public static long GetLongFromDateTime(this DateTime time)
        {
            long ticks = time.Ticks - ticksBase;
            ticks /= 10000000; //Convert windows ticks to seconds
            return long.Parse(ticks.ToString());
        }
        public static DateTime GetDateTimeFromLong(this long timeValue) { return new DateTime((timeValue * 10000000) + ticksBase); }

        private static Random random = new Random();

        public static long CreateIdFromDateTime(this DateTime time)
        {
            return Convert.ToInt64(time.ToString("ddMMyyHHmmss") + random.Next(1000, 9999));
        }
        public static string RangeDateShortcut(this DateTime? fr, DateTime? tto)
        {
            if (fr == null || tto == null) return string.Empty;

            var from = fr.Value.Date;
            var to = tto.Value.Date;
            if (from.Month == to.Month && from.Year == to.Year)
            {
                var days = to.Day - from.Day;
                var d = days.FormatNumberFirstZezo("D");
                var n = (days - 1).FormatNumberFirstZezo("N");

                var values = new List<object> { };
                if (d.IsNotNull()) values.Add(d);
                if (n.IsNotNull()) values.Add(n);
                if (values.Count != 0) values.Add("- ");
                values.Add("Từ ngày:");
                values.Add(from.Day);
                values.Add("-");
                values.Add(to.ToString("dd/MM/yyyy"));

                return values.JoinString(v => v, " ");
            }

            return "Từ ngày: " + from.ToString("dd/MM/yyyy") + " - " + to.ToString("dd/MM/yyyy");
        }

        public static string ConverDateToddMMYY(this DateTime? time)
        {
            var date = (DateTime)time;
            var day = date.Day.ToString();
            if (date.Day < 9)
            {
                day = "0" + day;
            }
            var a = (day + GetMonth(date).ToUpper() + date.Year.ToString().Substring(2, 2));
            return a;
        }

        public static string ConvertAge(this DateTime? time, int PersonType)
        {
            string a = "0";
            var date = (DateTime)time;
            switch (PersonType)
            {
                case 1: //Trẻ em
                    a = (((DateTime.Now - date).Days) / 365).ToString();
                    break;
                case 2: // Em bé
                    a = (((DateTime.Now - date).Days) / 31).ToString();
                    break;
            }
            return a;
        }

        public static bool IsDate(this string date)
        {
            try
            {
                if (date != null && date.Trim().IsNotNull()) date.To<DateTime>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private const string Jan = "Jan"; private const string JAN = "JAN";
        private const string Feb = "Feb"; private const string FEB = "FEB";
        private const string Mar = "Mar"; private const string MAR = "MAR";
        private const string Apr = "Apr"; private const string APR = "APR";
        private const string May = "May"; private const string MAY = "MAY";
        private const string Jun = "Jun"; private const string JUN = "JUN";
        private const string Jul = "Jul"; private const string JUL = "JUL";
        private const string Aug = "Aug"; private const string AUG = "AUG";
        private const string Sep = "Sep"; private const string SEP = "SEP";
        private const string Oct = "Oct"; private const string OCT = "OCT";
        private const string Nov = "Nov"; private const string NOV = "NOV";
        private const string Dec = "Dec"; private const string DEC = "DEC";

        public static int GetMonth(this string month)
        {
            switch (month)
            {
                case Jan:
                case JAN: return 1;
                case Feb:
                case FEB: return 2;
                case Mar:
                case MAR: return 3;
                case Apr:
                case APR: return 4;
                case May:
                case MAY: return 5;
                case Jun:
                case JUN: return 6;
                case Jul:
                case JUL: return 7;
                case Aug:
                case AUG: return 8;
                case Sep:
                case SEP: return 9;
                case Oct:
                case OCT: return 10;
                case Nov:
                case NOV: return 11;
                case Dec:
                case DEC: return 12;
                default: return 0;
            }
        }
        public static string GetMonth(this DateTime date)
        {
            switch (date.Month)
            {
                case 1: return Jan;
                case 2: return Feb;
                case 3: return Mar;
                case 4: return Apr;
                case 5: return May;
                case 6: return Jun;
                case 7: return Jul;
                case 8: return Aug;
                case 9: return Sep;
                case 10: return Oct;
                case 11: return Nov;
                default: return Dec;
            }
        }
        public static string Format(this DateTime? date, string format)
        {
            if (date == null) return string.Empty;
            return date.Value.ToString(format);
        }

        public static DateTime DateFromVNA(this string dateStr) // dateStr = 29JUL18 
        {
            var day = dateStr.Substring(0, 2).To<int>();
            var month = dateStr.Substring(2, 3).GetMonth();
            var year = dateStr.Substring(5, 2).To<int>() + 2000;
            return new DateTime(year, month, day);
        }

        public static string DateFor1B(this DateTime date)
        {
            return date.Day.AddZezo() + date.GetMonth().ToUpper() + date.Year;
        }
        public static string AddZero(int obj)
        {
            return obj < 10 ? "0" + obj : obj.ToString();
        }
    }

    public class FromTo<T>
    {
        public T From { set; get; }
        public T To { set; get; }
    }
    
}
