using System;
using System.Xml.Serialization;
using Core.Extensions;
namespace Core.Sites.Libraries.Business
{
    [Serializable]
    public class PathItem
    {
        [XmlAttribute("name")] public string Name { set; get; }
        [XmlAttribute("path")] public string Path { set; get; }
        [XmlAttribute("control")] public string Control { set; get; }
        [XmlAttribute("root")] public string DefaultRoot { set; get; }
        [XmlAttribute("dashboard")] public bool HasDashBoard { set; get; }
        [XmlAttribute("dashboard-control")] public string DashBoardControl { set; get; }
        [XmlAttribute("icon")] public string Icon { set; get; }
        [XmlIgnore] public Type Type { set; get; }
        public string GetPathControl() => "~/{0}/{1}/{2}.ascx".Frmat(BuildPathRoot(), Path, BuildPathControl());
        public string GetDashBoardConfig() => "~/{0}/{1}/{2}Config.ascx".Frmat(BuildPathRoot(), Path, BuildPathDashBoard());
        public string GetDrashBoard() => "~/{0}/{1}/{2}.ascx".Frmat(BuildPathRoot(), Path, BuildPathDashBoard());
        private string BuildPathRoot() => DefaultRoot.IsNull() ? "Web/Modules" : DefaultRoot;
        private string BuildPathControl() => Control.IsNull() ? Name : Control;
        private string BuildPathDashBoard() => DashBoardControl.IsNull() ? BuildPathControl() + "DashBoard" : DashBoardControl;
    }
}