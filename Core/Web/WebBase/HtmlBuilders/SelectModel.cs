using Core.DataBase.ADOProvider;
using System.Linq;
using System.Collections.Generic;
using Core.Reflectors;
using Core.Extensions;
using System;
using System.Text;
using Core.Utility.Language;
using System.Reflection;
using Core.Utility;

namespace Core.Web.WebBase.HtmlBuilders
{
    public abstract class SelectModel<T, TChain> : Select<T, TChain>, IAjax, ISelectCan
        where TChain : SelectModel<T, TChain>
        where T : ModelBase, new()
    {
        protected override List<T> GetData() => DbTable<T>.GetAllToList();

        public void GetDataAjax()
        {
            BuildParamFromQuery();

            this.SetData("ListItem", DoGetDataAjax());
            var typeT = typeof(T);

            var dvf = typeT.GetListPairPropertyAttribute<DataValueFieldAttribute>().FirstOrDefault();
            if (dvf != null) this.SetData("DataValueField", dvf);

            var dtf = typeT.GetListPairPropertyAttribute<DataTextFieldAttribute>().FirstOrDefault();
            if (dtf != null) this.SetData("DataTextField", dtf);
        }

        protected virtual List<T> DoGetDataAjax() => GetData();

        public override string ToString()
        {
            if ((canAdd || canEdit || menuItems.Count > 0) && ManageModulePermission != null)
            {
                Data("module-manage", ManageModulePermission.GetType().Name);
                if(ManageModulePermission.Is<IManageModule>())
                {
                    Data("table-key", ManageModulePermission.As<IManageModule>().GetTableFieldKeyName());
                    Data("table-entity-name", GetTableEntityName());
                }
            }

            return base.ToString();
        }

        protected virtual string GetTableEntityName()
        {
            if (ManageModulePermission == null) return string.Empty;
            return ManageModulePermission.As<IManageModule>().GetTableEntityName();
        }

        protected override string Key
        {
            get { return base.Key + DataAjax.JoinString(d => d.Value); }
        }
        
        public void Searching()
        {
            BuildParamFromQuery();
            this.SetData("Items", DoGetDataAjax());
        }

        protected bool canAdd { set; get; }
        protected bool canEdit { set; get; }

        private IManageModulePermission manageModulePermission = null;
        protected IManageModulePermission ManageModulePermission
        {
            get
            {
                if (manageModulePermission == null)
                    manageModulePermission = GetManageModule();
                return manageModulePermission;
            }
        }

        protected virtual IManageModulePermission GetManageModule() { return null; }

        /// <summary>
        /// Show dropdownlist extension: Add, Edit
        /// </summary>
        /// <param name="canAdd"></param>
        /// <param name="canEdit"></param>
        /// <returns></returns>
        public TChain Can(bool canAdd = true, bool canEdit = true)
        {
            return Chain(t => t.CanHelper(canAdd, canEdit));
        }

        sealed protected override void StartElement(StringBuilder html)
        {
            if (canAdd)
            {
                try { canAdd = ManageModulePermission == null || ManageModulePermission.CanAdd; }
                catch { canAdd = false; }
            }

            if (canEdit)
            {
                try { canEdit = ManageModulePermission == null || ManageModulePermission.CanEdit; }
                catch { canEdit = false; }
            }

            if (canAdd || canEdit || menuItems.Count > 0)
            {
                html.Append("<div class='input-group vi-input-select'>");
            }
        }

        private class MenuItem
        {
            public string Text { set; get; }
            public string Icon { set; get; }
            public string Method { set; get; }
            public string CssColor { set; get; }
        }

        private List<MenuItem> menuItems = new List<MenuItem>();
        public TChain AddMenuItem(string text, string method, string icon = "", string cssColor = "")
        {
            return Chain(t => t.menuItems.Add(new MenuItem { Text = text, Icon = icon, Method = method }));
        }

        sealed protected override void EndElement(StringBuilder html)
        {
            if (canAdd || canEdit || menuItems.Count > 0)
            {
                html.Append("   <span class='input-group-addon label-primary' style='border-left: 0px;border-color:#0081c5' data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>");
                html.Append("       <i class='fa fa-plus'></i>");
                html.Append("   </span>");
                html.Append("   <ul class='dropdown-menu' style='left:unset;right:0px'>");

                if (canAdd) html.Append("   <li><a data-input-cmd='Add'><i class='fa fa-plus-square text-green'></i><span class='text-green'>" + LanguageHelper.GetLabel("Thêm mới") + "</span></a></li>");
                if (canEdit) html.Append("   <li><a data-input-cmd='Edit'><i class='fas fa-edit text-blue'></i><span class='text-blue'>" + LanguageHelper.GetLabel("Chỉnh sửa") + "</span></a></li>");
                html.Append("   <li><a data-input-cmd='Refresh'><i class='fas fa-sync-alt text-red'></i><span class='text-red'>" + LanguageHelper.GetLabel("Làm mới") + "</span></a></li>");

                menuItems.ForEach(mi => 
                {
                    html.Append("   <li><a data-input-cmd='" + mi.Method + "'><i class='" + mi.Icon + " text-blue'></i><span class='" + mi.CssColor + "'>" + LanguageHelper.GetLabel(mi.Text) + "</span></a></li>");
                });

                html.Append("    </ul>");
                html.Append("</div>");
            }
        }

        void ISelectCan.Can(bool canAdd, bool canEdit)
        {
            CanHelper(canAdd, canEdit);
        }

        private void CanHelper(bool canAdd = true, bool canEdit = true)
        {
            this.canAdd = canAdd;
            this.canEdit = canEdit;
        }
    }

    public interface ISelectCan
    {
        void Can(bool canAdd = true, bool canEdit = true);
    }
}