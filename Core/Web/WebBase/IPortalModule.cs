//using Autofac;
using Core.Extensions;
using Core.Utility;
using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.CompilerServices;
//using Autofac.Configuration;

namespace Core.Web.WebBase
{
    public interface IViPortalModule : IAjax
    {
        NameValueCollection CoreQuery { set; get; }
    }

    public interface ILicense 
    {
        IViPortalModule CreateModule_App(string query);
        void LoadModuleByControl_App();
        void LoadScriptByModule_App();
        string Lic { set; }
    }
    public interface ILicenseFactory
    {
        ILicense Get();
    }
    
}
