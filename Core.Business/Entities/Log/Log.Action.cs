using Core.Attributes;
using Core.Business.Mappers;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.Log
{
    [TableInfo(TableName = "[LOG.Action]", Name="Log hoạt động")]
    public class Log : MainDb.Entity<Log>, IReportSummary
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)]
        public int LogID { set; get; }

        [Field]
        public int UserId { set; get; }

        [Field]
        public int CompanyId { set; get; }

        [Field(Name = "Địa chỉ IP")]
        public string Ip { set; get; }

        [Field(Name = "Thời gian")]
        public DateTime DateInsert { set; get; }

        [Field(Name = "Mô tả")]
        public string Description { set; get; }

        [Field]
        public string Content { set; get; }

        #endregion

        [PropertyInfo(Name = "Stt")]
        public int Row { set; get; }

        [PropertyInfo(Name = "Tên nhân viên")]
        public string FullName { set; get; }

        public int Total { set; get; }

        public string TitleSummary { set; get; }

        public class DataSource : DataSource<Log>.ReportSummary<Log>, ICompanyNeedValidate
        {
            [DateMapper(Name = "Từ ngày")] public DateTime StartTime { set; get; }
            [DateMapper(Name = "Đến ngày")] public DateTime EndTime { set; get; }

            public int CompanyId { set; get; }
            public int UserId { set; get; }
            public string Keyword { get; set; }

            public override List<Log> GetEntities() => Inst.ExeStoreToList("sp_LogAction_Total", Keyword, UserId, CompanyId, StartTime, EndTime, Start, Length, FieldOrder, Dir);
            public override Log GetDataSummary() => Inst.ExeStoreToFirst("sp_LogAction_Total_Summary", Keyword, UserId, CompanyId, StartTime, EndTime);
        }
        public static List<Log> GetData(string keyword,int UserId, int CompanyId, DateTime from, DateTime to, int start, int length, string fieldOrder, string dir)
        {
            return Inst.ExeStoreToList("sp_LogAction_Total", keyword, UserId, CompanyId, from, to, start, length, fieldOrder, dir);
        }

        public static Log GetSummary(string keyword,int UserId, int CompanyId, DateTime from, DateTime to)
        {
            return Inst.ExeStoreToFirst("sp_LogAction_Total_Summary",keyword, UserId, CompanyId, from, to);
        }

        public Log GetByLogId(int logId) => logId == 0 ? null : ExeStoreToFirst("sp_LogAction_GetByLogId", logId);
    }
}
