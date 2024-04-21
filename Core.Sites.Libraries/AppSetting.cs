using System.Linq;
using Core.Extensions;
using System.Configuration;
using Core.Sites.Libraries.Utilities;
using System.Reflection;
using System.Collections.Generic;
using System;
using Core.Web.WebBase;
using System.Web;
using System.IO;

namespace Core.Sites.Libraries
{
    public static partial class AppSetting
    {
        private const string PwdChars = "Rk1BeDBRcmRnQUhUdXhBRlZmRU9KOG5YNTJPTm4xWXM0YnNKaXRCRk5rMkE2VGpoL1VKaFExY3hXaE1LcTNidTdVaXlxRXBMcW1oZ09VQ3hkNE1DVWVOb1dHZWlDbitSUmlVWWR3YVQweEc3L1daR0tYaExtd3VndVpaUnBDOGRWSU9hcktjNGs5Yk9JVFd6akRyQ3RXZnR1a016aWVjODQrUWtXcXlmNVFRPUBYdzhkZ3lkWUwxclgxOVozZU84d0h3PT0=";
        public static string PasswordSuper = "PasswordSuper".GetSetting().WhenEmpty(() => PwdChars.Decrypt());
        public static int CompanyFullPermission = "CompanyFullPermission".GetSetting().WhenEmpty(() => "1").To<int>();
        public static int UserIdAdmin = 4;

        public static string Domain = "Domain".GetSetting().WhenEmpty(() => string.Empty);
        public static string DomainPartner = "DomainPartner".GetSetting().WhenEmpty(() => string.Empty);

        public static string Extension = "Extension".GetSetting().WhenEmpty(() => string.Empty);
        public static string VerJs = DateTime.Now.ToString("ddMMyyyyhhmmss");
        public static string Project = "Project".GetSetting().WhenEmpty(() => "Apps");
        public static IHubHelper HubHelper = "HubHelper".GetSetting().WhenEmpty(() => "Core.Sites.Hubs.HubHelper,Core.Sites.Hubs").CreateInstance<IHubHelper>();

        public static string MainDb = "MainDb".GetSetting().WhenEmpty(() => string.Empty);
        public static int Language = "Language".GetSetting().WhenEmpty(() => "2").To<int>();
        public static string HubServer = "HubServer".GetSetting().WhenEmpty(() => string.Empty);
        public static bool UseWebCenter = "UseWebCenter".GetSetting().WhenEmpty(() => "1").To<bool>();
        public static string BrandLogo = "BrandLogo".GetSetting().WhenEmpty(() => string.Empty);
        public static string BrandFavicon = "BrandFavicon".GetSetting().WhenEmpty(() => string.Empty);
        public static string Videobackground = "Videobackground".GetSetting().WhenEmpty(() => string.Empty);
        public static string HttpType = "HttpType".GetSetting().WhenEmpty(() => "http");

        public static List<Assembly> assemblies = null;
        public static List<Assembly> Assemblies
        {
            get
            {
                if (assemblies == null || assemblies != null)
                {
                    try
                    {
                        var cc = "Assemblies".GetSetting().WhenNull(() => "Core.Sites.Apps,Core.Sites.Partner.Apps").Split(',').Where(a => a.IsNotNull()).ToList();
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

        // Danh sách tất cả menu.config cần được load
        public static List<string> MenuConfig = "MenuConfig".GetSetting().WhenEmpty(() => "Menu").Split(',').Where(m => m.IsNotNull()).ToList(); 

        private static ILicense license;

        public static ILicense License
        {
            get
            {
                if (license == null)
                {
                    try
                    {
                        var assembly = Assembly.Load(File.ReadAllBytes(HttpContext.Current.Server.MapPath("T0FRVmZ3ajY0TnFnN2lFamhUKzQ0NXI3WG0yV3dLelJTNEtPWGdIWEZtMXM4cmc1c2QzQTJYWkk5R3QzMlZCaG9FY2kzVHV0UGM3dmNBdHhxRTVoZXVDOWJiM1FIZzZ0NWZPN2VucUtBQmtPQkxkeGJrTjd5VTV5eStNUUZSMk4vNVI5eHpxYXB2OTIyTlY1M3Y3M09QemZDRHF3MnpPU3VRNUZBYXo3dnJBPUBmZWNUcTYvM2hwdHBCbU1IU2ZwV0xFbnRzSXVZN2hCb1lMcnhYYVRpMy9kNldYeTdDdjlhc0QrM2RscnpoTDVqUkhnUlh0anBpZGM9".Decrypt())));
                        var lic = assembly.GetTypes().FirstOrDefault(t => t.HasInterface(typeof(ILicenseFactory))).CreateInstance();
                        license = lic.As<ILicenseFactory>().Get();
                    }
                    catch
                    {
                        throw new Exception("Sjl0OFAwZHAxdHp4Ylcvd3Bad1JNakxZbTlPaExMUlc5d2xjWXhLNGR2TzBZb2J5eDd4bWdadGJJamVLeE9CUmdYbnQ2eWFlTXhUcjZOeERLVCt1K2E5Q0EzOUM0MHp3TERXWEtML0RFNklkZ242b1Y1ejNBaUhUSmhib2RBQk5OeEp1ZkZKbUkxQmJQTXpYV1ArTkdxL0JoSEtsbjBSOE9Dd2dCTjRsdVpnPUBnNDdPUjE3d25QOHljc1ZQVG11a0N6SkVmRmNPRFowOXlFOGxoeWF0REQ1Yjl6QmJXQVZ1Z2NCc0dSSjdMZXJ2cWlTN1hUN0J6a2Q4SGdvdWFkNzR3VmpHK1RoM3lRQXFxVW9PWTJWTnRnUWRsUlB3TlRvd0FBPT0=".Decrypt());
                    }
                }
                return license;
            }
        }
    }
}