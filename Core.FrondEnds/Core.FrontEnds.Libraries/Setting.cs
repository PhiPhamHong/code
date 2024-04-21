using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Core.Extensions;
namespace Core.FrontEnds.Libraries
{
    public partial class Setting
    {
        public static string SaveFolder = "FeSaveFolder".GetSetting().WhenNull(() => "Thumb");
        public static bool IsSaveThumb = "FeIsSaveThumb".GetSetting().WhenNull(() => "1").To<bool>();
        public static string ServerImage = "FeServerImage".GetSetting().WhenNull(() => "/");
        public static string Project = "FeProject".GetSetting().WhenNull(() => "localhost");        
        public static string Extension = "FeExtension".GetSetting().WhenNull(() => string.Empty);
        public static string StaticDomain = "FeStaticDomain".GetSetting().WhenNull(() => "");
        public static string DomainName = "FeDomainName".GetSetting().WhenNull(() => "");
        public static string Version = "FeVersion".GetSetting().WhenNull(() => DateTime.Now.ToString("ddMMyyyymmhhss"));
        public static bool UseNewsIdInUrl = "FeUseNewsIdInUrl".GetSetting().WhenEmpty(() => "0").To<bool>();
        public static int CurrentCompanyId = "CompanyId".GetSetting().WhenNull(() => "1").To<int>();


        private static List<Assembly> assemblies = null;
        public static List<Assembly> Assemblies
        {
            get
            {
                if (assemblies == null)
                {
                    try
                    {
                        var cc = "FeWebAssemblies".GetSetting().WhenNull(() => string.Empty).Split(',').Where(a => a.IsNotNull()).ToList();
                        assemblies = cc.Select(a =>
                        {
                            try { return Assembly.Load(a); }
                            catch { return null; }
                        }).Where(a => a != null).ToList();
                    }
                    catch { }
                }
                return assemblies;
            }
        }
    }
}