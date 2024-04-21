using System;
using System.Linq.Expressions;
using System.Text;
using Core.Extensions;
using Keys = Core.Utility.Key;
using System.Collections.Generic;
using Core.Attributes;
using Core.Utility.Language;
using Core.Utility;
namespace Core.Web.WebBase.HtmlBuilders
{
    public abstract class Table<T, TChain> : Html<TChain> where TChain : Table<T, TChain>
    {
        #region properties
        protected string id = ""; public TChain Id(string id) { return Chain(t => t.id = id); }
        //protected string width = "100%";
        protected string width = "";
        public TChain Width(string width) { return Chain(t => t.width = width); }
        protected string key = ""; public TChain Key(string key) { return Chain(t => t.key = key); }
        protected Expression<Func<T, object>> expressionKey = null; public TChain Key(Expression<Func<T, object>> ex) { return Chain(t => t.expressionKey = ex); }
        protected List<Column> columns = new List<Column>(); public TChain Col(Action<Column> column) { return Chain(t => { var c = new Column(); c.Table = this; column(c); columns.Add(c); }); }
        protected List<RowColspan> rowColspans = new List<RowColspan>(); public TChain RowColspans(Action<RowColspan> action) { return Chain(t => { var r = new RowColspan(); r.Table = this; action(r); rowColspans.Add(r); }); }
        protected List<BarButton> bars = new List<BarButton>(); public TChain Bar(Action<BarButton> bar) { return Chain(t => { var b = new BarButton(); b.Table = this; bar(b); bars.Add(b); }); }
        protected int permissionAdd = 0; public TChain PermissionAdd(int permissionAdd) { return Chain(t => t.permissionAdd = permissionAdd); }
        protected string entityName = string.Empty; public TChain EntityName(string entityName) { return Chain(t => t.entityName = entityName); }
        public TChain ScrollX(bool scrollX) { return Chain(t => t.Data("scrollX", scrollX)); }
        protected bool exportExcel = true; public TChain ExportExcel(bool exportExcel = true) { return Chain(t => t.exportExcel = exportExcel); }
        protected int defaultSort = -1; protected string defaultSortDir = "asc";
        public TChain DefaultSort(int col) { return Chain(t => { t.defaultSort = col; t.defaultSortDir = "asc"; }); }
        public TChain DefaultSortDesc(int col) { return Chain(t => { t.defaultSort = col; t.defaultSortDir = "desc"; }); }
        #endregion

        public virtual bool HasPermission(params int[] permission) { return true; }

        public override string ToString()
        {
            var html = new StringBuilder();

            if (exportExcel)
            {
                var bar = new BarButton { Table = this };
                bar.Icon("fas fa-cloud-download-alt");
                bar.Text("Xuất excel"); 
                bar.Func("ExportExcel");
                bar.Keydown(Keys.f3);
                bar.CssBg("bg-maroon");
                bars.Add(bar);
            }

            html.Append("<div><div class='corver-module-grid'><i class='fas fa-spinner fa-spin fa-2x'></i></div><table style='display:none' ");
            //html.Append("<div><div class='corver-module-grid'></div><table style='display:none' ");

            if (id.IsNull()) id = "table_" + Singleton<Random>.Inst.Next(1, 10000);

            if (id.IsNotNull()) html.AppendFormat("id='{0}' ", id);
            if (width.IsNotNull()) html.AppendFormat("width='{0}' ", width);
            if (entityName.IsNotNull()) html.AppendFormat("data-entity-name='{0}' ", LanguageHelper.GetLabel(entityName));

            if (defaultSort >= 0)
            {
                //html.AppendFormat("data-order='[[{0},\"{1}\"]]' ", defaultSort, defaultSortDir);
                html.AppendFormat("data-order-col='{0}' ", defaultSort);
                html.AppendFormat("data-order-col-dir='{0}' ", defaultSortDir);
            }

            if (expressionKey != null)
            {
                var member = expressionKey.GetMemberInfo();
                if (key.IsNull()) key = member.Name;
            }
            if (key.IsNotNull()) html.AppendFormat("data-key='{0}' ", key);
            html.Append(GetDataAttribute());

            html.Append(">");
            html.Append("<thead>");

            rowColspans.ForEach(r => html.Append(r));

            html.Append("<tr data-column-real='true'>");
            //columns.ForEach(c => 
            //{
                
            //    html.Append(c);
            //});

            for(var i = 0; i < columns.Count;i++)
            {
                var c = columns[i];
                c.Data("root-index", i);
                html.Append(c);
            }

            html.Append("</tr>");

            html.Append("<tr data-type='buttons' style='display:none' ");
            html.AppendFormat("data-button-add='{0}' ", HasPermission(permissionAdd));
            html.Append(">");
            bars.ForEach(b => html.Append(b));
            html.Append("</tr>");

            html.Append("</thead>");
            html.Append("</table></div>");

            return html.ToString();
        }

        public class RowColspan : Html<RowColspan>
        {
            public Table<T, TChain> Table { set; get; }
            private List<ColumnColspan> columns = new List<ColumnColspan>();

            public RowColspan Col(Action<ColumnColspan> action) { return Chain(t => { var col = new ColumnColspan(); action(col); columns.Add(col); }); }

            public override string ToString()
            {
                if (columns.Count != 0)
                {
                    var html = new StringBuilder();
                    html.Append("<tr data-row-colspan='true'>");
                    columns.ForEach(c => html.Append(c));
                    html.Append("</tr>");
                    return html.ToString();
                }
                return string.Empty;
            }
        }

        public class ColumnColspan : Html<ColumnColspan>
        {
            public ColumnColspan Name(string name) 
            {
                //if (name.IsNull()) return this;
                return Chain(t => t.Data("Name", name.IsNull() ? name : LanguageHelper.GetLabel(name)));
            }
            private int colspan = 1; public ColumnColspan Colspan(int colspan) { return Chain(t => t.colspan = colspan); }
            public override string ToString()
            {
                var html = new StringBuilder();
                html.Append("<th class='text-center' ");
                html.AppendFormat("colspan={0} ", colspan);
                html.Append(">");
                html.Append(this.data["Name"]);
                html.Append("</th>");
                return html.ToString();
            }
        }

        public class Column : Html<Column>
        {
            public Table<T, TChain> Table { set; get; }

            #region properties
            protected bool show = true;
            public Column Show(bool show = true) { return Chain(t => t.show = show); }

            public Column Sum(bool sum = true) 
            {
                if (sum) return Data("summary", "sum");
                return this;
            }
            public Column SumTitle(bool sum = true) 
            {
                if (sum) return Data("summary-title", "TitleSummary"); ;
                return this;
            }
            public Column ReportWidth(int width) { return Data("report-width", width); }

            protected string field = string.Empty;
            public Column Field(string field) { return Chain(t => t.field = field); }
            protected LambdaExpression expressionField = null;
            public Column Field(Expression<Func<T, object>> ex) { return Chain(t => t.expressionField = ex); }
            public Column For(Expression<Func<T, object>> ex, int maxWidth = 0, bool? order = null)
            {
                Field(ex);
                if (maxWidth != 0) FormatSpanDot(maxWidth);
                if (order != null) Order(order.Value);
                return this;
            }
            public Column ForDate(Expression<Func<T, object>> ex, int maxWidth = 0, bool? order = null)
            {
                For(ex, maxWidth, order);
                FormatDate();
                return this;
            }
            public Column ForDateTime(Expression<Func<T, object>> ex, int maxWidth = 0, bool? order = null)
            {
                For(ex, maxWidth, order);
                FormatDateTime();
                return this;
            }
            public Column ForMoney(Expression<Func<T, object>> ex, int maxWidth = 0, bool? order = null)
            {
                For(ex, maxWidth, order);
                FormatMoney();
                return this;
            }

            protected string text = string.Empty;
            public Column Text(string text) { return Chain(t => t.text = text); }

            protected string type = string.Empty;
            public Column TypeButton() { return Chain(t => t.type = "button"); }
            public Column TypeTextEdit(string textEditFunc = "") 
            {
                Data("text-edit-func", textEditFunc);
                return Chain(t => t.type = "text-edit"); 
            }
            public Column TypeCheckbox() { return Chain(t => t.type = "checkbox"); }
            public Column TypeRadio() { return Chain(t => t.type = "radio"); }

            protected string func = string.Empty;
            public Column Func(string func) { return Chain(t => t.func = func); }
            public Column Func(Action func) { return Chain(t => t.func = func.Method.Name); }
            public Column Click(string func)
            {
                Chain(t => t.TypeButton());
                return Func(func);
            }
            public Column Click(Action func)
            {
                Chain(t => t.TypeButton());
                return Func(func);
            }

            protected string method = string.Empty; public Column Method(string method) { return Chain(t => t.method = method); }            
            protected bool showWhenNotPermission = false; public Column Permission(int permission, bool show = false) { return Chain(t => { t.permissions = new int[] { permission }; t.showWhenNotPermission = show; }); }
            protected int[] permissions = null; public Column Permissions(bool show, params int[] permission) { return Chain(t => { t.showWhenNotPermission = show; t.permissions = permission; }); }
            protected bool order = true; public Column Order(bool order) { return Chain(t => t.order = order); }

            protected string @class = string.Empty;
            public Column Class(string @class) { return Chain(t => t.@class = @class); }
            public Column TextCenter() { return Chain(t => t.@class = "text-center"); }
            public Column TextRight() { return Chain(t => t.@class = "text-right"); }

            protected string textTrue = string.Empty;
            protected string iconTrue = string.Empty;
            public Column WhenTrue(string textTrue, string iconTrue = "") { return Chain(t => { t.textTrue = textTrue; t.iconTrue = iconTrue; }); }

            protected string textFalse = string.Empty;
            protected string iconFalse = string.Empty;
            public Column WhenFalse(string textFalse, string iconFalse = "") { return Chain(t => { t.textFalse = textFalse; t.iconFalse = iconFalse; }); }

            protected string style = string.Empty; public Column Style(string style) { return Chain(t => t.style = style); }
            protected string icon = string.Empty; public Column Icon(string icon) { return Chain(t => t.icon = icon); }
            protected string confirm = string.Empty; public Column Confirm(string confirm) { return Chain(t => t.confirm = confirm); }
            protected bool autoConfirm = false; public Column Confirm() { return Chain(t => t.autoConfirm = true); }

            protected string createdCell = string.Empty; public Column CreatedCell(string createdCell) { return Chain(t => t.createdCell = createdCell); }
            public Column LinkTarget(string target) { return Data("target", target); }
            public Column LinkTargetBlank() { return LinkTarget("_blank"); }
            public Column LinkFormSearch() { return Data("form-search", "true"); }

            protected string url = string.Empty;
            public Column Url(string url) { return Chain(t => t.url = url); }

            protected List<string> urlParams = new List<string>(); public Column UrlParam(Expression<Func<T, object>> ex) { return Chain(t => urlParams.Add(ex.GetMemberInfo().Name)); }

            protected string format = string.Empty;
            public Column FormatMoney() { TextRight(); return Chain(t => t.format = "money"); }
            public Column FormatMoney2() { TextRight(); return Chain(t => t.format = "money2"); }
            public Column FormatDate() { TextCenter(); return Chain(t => t.format = "date"); }
            public Column FormatTime() { TextCenter(); return Chain(t => t.format = "time"); }
            public Column FormatDateTime() { TextCenter(); return Chain(t => t.format = "date-time"); }
            public Column FormatSpan() { return Chain(t => t.format = "span"); }
            public Column FormatSpanDot(int width) 
            { 
                Data("span-class", "dotdot").Data("span-width", (width - 10) + "px");
                Style($"width:{width}px");
                return FormatSpan(); 
            }
            public Column FormatImage(string width, string height, string classCss) {
                return Chain(t => {
                    t.format = "image";
                    if (width.IsNotNull()) t.Data("image-width", width);
                    if (height.IsNotNull()) t.Data("image-height", height);
                    if (classCss.IsNotNull()) t.Data("image-class", classCss);
                });
            }
            #endregion

            public override string ToString()
            {
                if (!show) return string.Empty;
                bool hasPermission = true;

                if (permissions != null)
                {
                    hasPermission = Table.HasPermission(permissions);
                    if (!hasPermission && !showWhenNotPermission) return string.Empty;
                }
                var html = new StringBuilder();

                html.Append("<th ");
                if (expressionField != null)
                {
                    var member = expressionField.GetMemberInfo();
                    var fieldAttr = member.GetAttribute<PropertyInfoAttribute>();
                    if (field.IsNull()) field = member.Name;
                    
                    if (text.IsNull()) text = fieldAttr != null && fieldAttr.Name.IsNotNull() ? fieldAttr.Name : field;
                    if (text.IsNull()) text = field;
                }

                if (text.IsNotNull())
                {
                    html.AppendFormat("data-root-text='{0}' ", text);
                    text = LanguageHelper.GetLabel(text);
                }

                if (field.IsNotNull()) html.AppendFormat("data-field='{0}' ", field);
                if (type.IsNotNull()) html.AppendFormat("data-type='{0}' ", type);
                if (func.IsNotNull()) html.AppendFormat("data-func='{0}' ", func);
                if (method.IsNotNull()) html.AppendFormat("data-func-method='{0}' ", method);
                if (createdCell.IsNotNull()) html.AppendFormat("data-created-cell='{0}' ", createdCell);
                if (url.IsNotNull()) html.AppendFormat("data-url='{0}' ", url);
                var paramFields = urlParams.JoinString(p => p, ",");
                if (paramFields.IsNotNull()) html.AppendFormat("data-param-url='{0}' ", paramFields);

                html.AppendFormat("data-can='{0}' ", hasPermission);
                html.AppendFormat("data-order='{0}' ", order);
                if (@class.IsNotNull()) html.AppendFormat("data-class='{0}' ", @class);
                if (textTrue.IsNotNull()) html.AppendFormat("data-text-true='{0}' ", LanguageHelper.GetLabel(textTrue));
                if (iconTrue.IsNotNull()) html.AppendFormat("data-icon-true='{0}' ", iconTrue);
                if (textFalse.IsNotNull()) html.AppendFormat("data-text-false='{0}' ", LanguageHelper.GetLabel(textFalse));
                if (iconFalse.IsNotNull()) html.AppendFormat("data-icon-false='{0}' ", iconFalse);
                if (style.IsNotNull()) html.AppendFormat("style='{0}' ", style);
                if (icon.IsNotNull()) html.AppendFormat("data-icon='{0} '", icon);
                if (confirm.IsNotNull()) html.AppendFormat("data-confirm='{0}' ", confirm);
                if (autoConfirm) html.Append("data-auto-confirm='true'");

                if (format.IsNotNull())
                    html.AppendFormat("data-format='true' data-format-type='{0}' ", format);

                html.Append(GetDataAttribute());

                html.Append(">");
                html.Append(text);
                html.Append("</th>");
                return html.ToString();
            }
        }

        public class BarButton : Html<BarButton>
        {
            public Table<T, TChain> Table { set; get; }

            #region properties
            protected string icon = string.Empty; public BarButton Icon(string icon) { return Chain(t => t.icon = icon); }
            protected string func = string.Empty; public BarButton Func(string func) { return Chain(t => t.func = func); }
            protected int[] permission = null; public BarButton Permission(params int[] permission) { return Chain(t => t.permission = permission); }
            protected string text = string.Empty; public BarButton Text(string text) { return Chain(t => t.text = text); }
            public string cssBg = string.Empty; public BarButton CssBg(string cssBg) { return Chain(t => t.cssBg = cssBg); }
            public bool show = true; public BarButton Show(bool show) { return Chain(t => t.show = show); }
            #endregion

            public override string ToString()
            {
                if (!show) return string.Empty;

                var hasPermission = permission == null ? true : Table.HasPermission(permission);

                var html = new StringBuilder();
                html.Append("<th ");

                if (icon.IsNotNull()) html.AppendFormat("data-icon='{0}' ", icon);
                if (func.IsNotNull()) html.AppendFormat("data-func='{0}' ", func);
                if (cssBg.IsNotNull()) html.AppendFormat("data-cssBg='{0}'", cssBg);
                html.AppendFormat("data-can='{0}' ", hasPermission);

                html.Append(GetDataAttribute());

                html.Append(">");
                html.Append(LanguageHelper.GetLabel(text));
                html.Append("</th>");
                return html.ToString();
            }
        }
    }
}