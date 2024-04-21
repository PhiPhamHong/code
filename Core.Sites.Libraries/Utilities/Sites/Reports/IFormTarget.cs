using System;
using System.Collections.Generic;
using Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders;
using Core.Reflectors;

namespace Core.Sites.Libraries.Utilities.Sites.Reports
{
    public interface IFormTarget
    {
        string Excel_GetTitle();
        string Excel_GetSubtitle();

        string Excel_FileTemplate { get; }
        bool? Excel_FillTitle { get; }
        int? Excel_Y_Title { get; }
        int? Excel_X_Title { get; }
        int? Excel_Y_SubTitle { get; }
        int? Excel_X_SubTitle { get; }
        int? Excel_StartRow { get; }
        bool? Excel_CreateHeader { get; }
        bool? Excel_BindSummary { get; }
        bool? Excel_UseStyleTemplate { get; }
    }

    public interface IFormGridTarget : IFormTarget
    {
        ColumnConfig ColumnConfig { get; }
    }

    public static class IFormTargetExtension
    {
        public static List<ReportColumnInfoAttribute> GetListReportColumnInfo(this IFormTarget target)
        {
            return ReflectListAttribute<Type, ReportColumnInfoAttribute>.Inst[target.GetType()];
        }
        public static ReportInfoAttribute GetReportInfo(this IFormTarget target)
        {
            return ReflectAttribute<Type, ReportInfoAttribute>.Inst[target.GetType()];
        }
    }
}