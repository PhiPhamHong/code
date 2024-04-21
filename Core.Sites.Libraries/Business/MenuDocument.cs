using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;

using Core.Utility.Xml;
using Core.Extensions;
using System.Configuration;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Business
{
    [Serializable]
    [XmlRoot("root")]
    public class MenuDocument : ConfigBase
    {
        public List<PathItem> Modules => PortalContext.PathImageForMenuConfig;

        [XmlArray("menus"), XmlArrayItem("menu")] public List<MenuTop> Menus { set; get; }

        public override string GetPath() => HttpContext.Current.Server.MapPath("~/Settings/Projects/" + AppSetting.Project + "/Menu.config");
        public static MenuDocument LoadHelper(SessionType sessionType)
        {
            var menuConfig = AppSetting.MenuConfig;
            MenuDocument md = null;
            if (menuConfig.Count >= 0) md = LoadHelper(menuConfig[0], sessionType);

            for(var i = 1; i < menuConfig.Count; i++)
            {
                var md_i = LoadHelper(menuConfig[i], sessionType);
                if (md_i.Menus != null)
                    md.Menus.AddRange(md_i.Menus);
            }

            return md;
        }

        public static MenuDocument LoadHelper(string menu, SessionType sessionType)
        {
            var md = ReadConfig<MenuDocument>.Load(HttpContext.Current.Server.MapPath("~/Settings/Projects/" + AppSetting.Project + "/Menu/" + menu + ".config"));
            md.Menus = md.Menus.Where(m => m.SessionType == SessionType.Unknown || m.SessionType == sessionType).ToList();
            return md;
        }

        public static MenuDocument Load(SessionType sessionType)
        {
            var menuDocument = LoadHelper(sessionType);
            var all = menuDocument.Menus.Cast<MenuItem>().Union(menuDocument.Menus.SelectMany(m => m.Groups.SelectMany(g => g.MenuItems)));
            EnumerableExtension.SJoin(all, menuDocument.Modules, m => m.Module, md => md.Name, (m, md) => m.ModulePath = md);
            return menuDocument;
        }
        public static List<MenuItem> MenuItemHasDashBoard(MenuDocument md, SessionType session)
        {
            var all = md.Menus.Where(mt => mt.SessionType == SessionType.Unknown || mt.SessionType == session)
                              .Cast<MenuItem>()
                              .Union(md.Menus.SelectMany(m => m.Groups.SelectMany(g => g.MenuItems))).ToList();
            EnumerableExtension.SJoin(all, md.Modules, m => m.Module, mdi => mdi.Name, (m, mdi) => m.ModulePath = mdi);
            return all.Where(mi => mi.DashBoard && mi.ModulePath.HasDashBoard).ToList();
        }
        public static MenuDocument Load(List<int> permissions, SessionType sessionType, bool removeHide = true)
        {
            var menuDocument = LoadHelper(sessionType);
            menuDocument.RemoveMenuItemHasNotPermission(permissions);
            if (removeHide) menuDocument.RemoveMenuItemHide();
            return menuDocument;
        }
        public static MenuDocument LoadForAssignPermission(SessionType sessionType)
        {
            return LoadHelper(sessionType);
        }
        public static MenuDocument LoadForAssignPermission(List<int> permissions, SessionType sessionType)
        {
            var menuDocument = LoadHelper(sessionType);
            menuDocument.RemoveMenuItemWithPermission0();
            menuDocument.RemoveMenuItemHasNotPermission(permissions);
            return menuDocument;
        }
    }

    public static class MenuDocumentExtension
    {
        public static void RemoveMenuItemWithPermission0(this MenuDocument menuDocument)
        {
            menuDocument.Menus.Cast<MenuItem>().Union(menuDocument.Menus.SelectMany(m => m.Groups.SelectMany(g => g.MenuItems)))
                .Where(mi => mi.Pers.Length == 1 && mi.Pers.Contains(0) && mi.Permissions.IsNull()).Select(mi => mi.CanAccess = true).Count();
            menuDocument.RemoveMenuItem(mi => mi.CanAccess);
            menuDocument.RemoveMenuTop(mi => mi.CanAccess);
        }

        public static void RemoveMenuItemHasNotPermission(this MenuDocument menuDocument, List<int> permissions)
        {
            var all = menuDocument.Menus.Cast<MenuItem>().Union(menuDocument.Menus.SelectMany(m => m.Groups.SelectMany(g => g.MenuItems)));
            all.Where(m => permissions.Contains(m.Pers)).ForEach(m => m.CanAccess = true);

            menuDocument.RemoveMenuItem(mi => !mi.CanAccess);
            menuDocument.RemoveMenuTop(mi => !mi.CanAccess || (mi.HideWhenNoItem && mi.Groups.Count == 0));
        }

        /// <summary>
        /// Loại bỏ menu bị ẩn
        /// </summary>
        public static void RemoveMenuItemHide(this MenuDocument menuDocument)
        {
            menuDocument.Menus.Cast<MenuItem>().Union(menuDocument.Menus.SelectMany(m => m.Groups.SelectMany(g => g.MenuItems)))
                .Where(mi => mi.Hide).Select(mi => mi.CanAccess = false).Count();
            menuDocument.RemoveMenuItem(mi => !mi.CanAccess);
            menuDocument.RemoveMenuTop(mi => !mi.CanAccess || (mi.HideWhenNoItem && mi.Groups.Count == 0));
        }

        public static void RemoveMenuItem(this MenuDocument menuDocument, Func<MenuItem, bool> predicate)
        {
            menuDocument.Menus.ForEach(mt =>
            {
                mt.Groups.ForEach(g => g.MenuItems.Where(predicate).ToList().ForEach(mi => g.MenuItems.Remove(mi)));
                mt.Groups.Where(g => g.MenuItems.Count == 0).ToList().ForEach(g => mt.Groups.Remove(g));
            });
        }

        public static void RemoveMenuTop(this MenuDocument menuDocument, Func<MenuTop, bool> predicate)
        {
            menuDocument.Menus.Where(predicate).Where(m => m.Groups.Count == 0).ToList().ForEach(m => menuDocument.Menus.Remove(m));
        }
    }
}