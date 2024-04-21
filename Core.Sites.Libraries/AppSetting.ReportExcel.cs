using Core.Extensions;
using System.Configuration;

namespace Core.Sites.Libraries
{
    public partial class AppSetting
    {
        private static ReportExcelConfig reportExcel = ConfigurationManager.AppSettings["ReportExcel"];
        public static ReportExcelConfig ReportExcel 
        {
            get { return reportExcel; } 
        }

        public class ReportExcelConfig
        {
            public int Y_Title { set; get; }
            public int X_Title { set; get; }
            public int Y_SubTitle { set; get; }
            public int X_SubTitle { set; get; }
            public int StartRow { set; get; }

            public static ReportExcelConfig Default = new ReportExcelConfig { Y_Title = 4, X_Title = 0, Y_SubTitle = 8, X_SubTitle = 0, StartRow = 10 };
            public static implicit operator ReportExcelConfig(string config)
            {
                if (config.IsNull()) return Default;
                var configs = config.Split(',');
                if (configs.Length < 5) return Default;

                return new ReportExcelConfig
                {
                    Y_Title = configs[0].To<int>(),
                    X_Title = configs[1].To<int>(),
                    Y_SubTitle = configs[2].To<int>(),
                    X_SubTitle = configs[3].To<int>(),
                    StartRow = configs[4].To<int>()
                };
            }
        }
    }
}