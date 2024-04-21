using Core.Attributes;
using System;
using Core.Extensions;

namespace Core.FrontEnds.Libraries.Portal
{
    public class ModuleAttribute : ClassInfoAttribute
    {
        public string GetPath()
        {
            var paths = Type.FullName.Replace(AssemblyName, string.Empty).TrimStart('.').Split('.');
            return "~/" + paths.JoinString(p => p, "/") + ".ascx";
        }
    }
}