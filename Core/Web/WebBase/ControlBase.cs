using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using PageWeb = System.Web.UI.Page;
using Core.Extensions;
using Core.Web.Extensions;
namespace Core.Web.WebBase
{
    public class ControlBase : UserControl
    {
        public T GetParam<T>(string key, T @default = default(T)) { return CurrentContext.Request.Query(key, @default); }
        public T GetParam<T>(string key) { return CurrentContext.Request.Query(key, default(T)); }
        public HttpContext CurrentContext { get { return HttpContext.Current; } }
        public virtual void InitData() { }
        public string Html { get { return this.GetHtml(); } }
        public T Build<T>() where T : new() { return new T(); }
        
        public static ControlBase DoLoad(Type type)
        {
            var page = HttpContext.Current.CurrentHandler as PageWeb;
            if (page == null) page = new PageWeb();

            var assemblyName = type.Assembly.FullName.Split(',')[0]; // AssemblyName
            var cfa = type.GetAttribute<ControlFolderAttribute>();
            var folder = cfa == null ? string.Empty : cfa.Folder;
            if (folder.IsNull())
                return page.LoadControl("/{0}.ascx".Frmat(type.GetTypeName().Replace(".", "/").TrimStart('_'))) as ControlBase;
            else
                return page.LoadControl("/{0}/{1}.ascx".Frmat(folder, type.GetTypeName().Replace(".", "/").TrimStart('_'))) as ControlBase;
        }
        
        public string ControlName
        {
            get { return GetType().BaseType.GetTypeName(); }
        }
        public string ModuleProject => GetType().BaseType.Assembly.FullName.Split(',')[0];
    }

    /// <summary>
    /// Được dùng khi mà triển khai thêm project ngoài project chính đang thực hiện phát triển
    /// </summary>
    public class ControlFolderAttribute : Attribute
    {
        public string Folder { set; get; }
    }

    public class Control<T> where T : ControlBase
    {
        public static T Create() { return ControlBase.DoLoad(typeof(T)) as T; }
    }
}