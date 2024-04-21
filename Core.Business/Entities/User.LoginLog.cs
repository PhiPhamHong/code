using Core.Attributes;
using Core.Business.Mappers;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities
{
    public partial class User
    {
        [TableInfo(TableName = "[Users.LoginLogs]")]
        public class LoginLog : LoginLog<LoginLog>
        {
            public class DataSource : DataSource<LoginLog>.ReportSummary<LoginLog>, ICompanyNeedValidate
            {
                [DateMapper(Name = "Từ ngày")] public DateTime StartTime { set; get; }
                [DateMapper(Name = "Đến ngày")] public DateTime EndTime { set; get; }
                public int CompanyId { set; get; }
                public int UserId { set; get; }

                public override List<LoginLog> GetEntities() => Inst.ExeStoreToList("sp_LogLogin_Total", UserId, CompanyId, StartTime, EndTime, Start, Length, FieldOrder, Dir);
                public override LoginLog GetDataSummary() => Inst.ExeStoreToFirst("sp_LogLogin_Total_Summary", UserId, CompanyId, StartTime, EndTime);
            }
        }

        public class LoginLog<TLog> : MainDb.Entity<TLog>, IReportSummary where TLog : ModelBase, IReportSummary, new()
        {
            #region Properties
            [Field(IsKey = true, IsIdentity = true)]
            public int UserLoginLogId { set; get; }
            [Field]
            public int UserId { set; get; }
            [Field(Name = "Tài khoản")]
            public string UserName { set; get; }
            [Field]
            public int CompanyId { set; get; }
            [Field]
            public bool Success { set; get; }
            [Field]
            public string PasswordEncrypt { set; get; }
            [Field(Name = "Mật khẩu")]
            public string Password { set; get; }
            [Field(Name = "Thời gian đăng nhập")]
            public DateTime DateLogin { set; get; }
            [Field(Name = "Ip đăng nhập")]
            public string Ip { set; get; }
            #endregion

            [PropertyInfo(Name = "Stt")]
            public int Row { set; get; }

            public int Total { set; get; }

            public string TitleSummary { set; get; }
            [PropertyInfo(Name = "Trạng thái đăng nhập")] public string Success_Name { get { return Success == true ? "Thành công" : "Thất bại"; } }
        }
    }
}
