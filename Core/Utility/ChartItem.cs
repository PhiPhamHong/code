using System.Linq;
using System.Collections.Generic;
using Core.Extensions;
using System;

namespace Core.Utility
{
    public class ChartItem<TLabelX>
    {
        public TLabelX LabelX { set; get; }
    }
    public class ChartItem<TLabelX, TValueY> : ChartItem<TLabelX>
    {
        public TValueY ValueY { set; get; }
    }

    public static class ChartItemExtension
    {
        public static List<TChartItem> FormatMonthYear<TChartItem>(this List<TChartItem> data, int month, int year, Action<TChartItem, TChartItem> action) where TChartItem : ChartItem<int>, new()
        {
            var dataReturn = GetEmpty<TChartItem>(month, year);
            dataReturn.SJoin(data, d => d.LabelX, s => s.LabelX, (dr, s) => action(dr, s));
            return dataReturn;
        }
        public static List<TChartItem> GetEmpty<TChartItem>(int month, int year) where TChartItem : ChartItem<int>, new()
        {
            var range = year.GetRangeDateInMonth(month);
            var dataReturn = range.From.RangeTo(range.To).Select(r => new TChartItem { LabelX = r.Day }).ToList();
            return dataReturn;
        }
        public static List<ChartItem<int, TValueY>> FormatMonthYear<TValueY>(this List<ChartItem<int, TValueY>> data, int month, int year)
        {
            return data.FormatMonthYear(month, year, (dr, s) => dr.ValueY = s.ValueY);
        }

        public static List<TChartItem> FormatYear<TChartItem>(this List<TChartItem> data, Action<TChartItem, TChartItem> action) where TChartItem : ChartItem<int>, new()
        {
            var dataReturn = GetEmpty<TChartItem>();
            dataReturn.SJoin(data, d => d.LabelX, s => s.LabelX, (dr, s) => action(dr, s));
            return dataReturn;
        }
        public static List<TChartItem> GetEmpty<TChartItem>() where TChartItem : ChartItem<int>, new()
        {
            return Enumerable.Range(1, 12).Select(r => new TChartItem { LabelX = r }).ToList();
        }
        public static List<ChartItem<int, TValueY>> FormatYear<TValueY>(this List<ChartItem<int, TValueY>> data)
        {
            return data.FormatYear((dr, s) => dr.ValueY = s.ValueY);
        }
    }
}
