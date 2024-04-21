using System;
using System.Linq;
using Core.Attributes;
using Core.Extensions;
namespace Core.Sites.Libraries.Business
{
    public class ModuleAttribute : ClassInfoAttribute
    {
        public string Path { set; get; }
        public string Control { set; get; }
        public string DefaultRoot { set; get; }
        public bool HasDashBoard { set; get; }
        public string DashBoardControl { set; get; }
        public string Icon { set; get; }

        public static implicit operator PathItem(ModuleAttribute m)
        {
            var paths = m.Type.FullName.Replace(m.AssemblyName, string.Empty).TrimStart('.').Split('.');

            return new PathItem
            {
                Name = m.Type.Name,
                Path = m.GetPath(paths), // 
                HasDashBoard = m.HasDashBoard,
                DefaultRoot = m.GetDefaultRoot(paths), //
                DashBoardControl = m.DashBoardControl,
                Icon = m.Icon
            };
        }

        protected virtual string GetPath(string[] paths)
        {
            return paths.Skip(2).Take(paths.Length - 3).JoinString(s => s, "/");
        }

        protected virtual string GetDefaultRoot(string[] paths)
        {
            return paths.Take(2).JoinString(s => s, "/");
        }
    }
}