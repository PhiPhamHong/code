using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Extensions;
using System.Linq;
using Core.Utility.Language;
using Core.Reflectors;
using System.Reflection;
using Core.Utility;
using Core.Attributes;

namespace Core.Web.WebBase.HtmlBuilders
{
    public interface ISelectBase<TChain> : IInputBase<TChain>, IHtml where TChain : IHtml
    {
        TChain Width(string width);
    }
   
    public abstract class Select<T, TChain> : InputBase<T, TChain>, ISelectBase<TChain>, IAjax, IInputWithFormGroupFireStart where TChain : Select<T, TChain>
    {
        public virtual void StartWithParent() { }
        protected string Query { set; get; } = string.Empty;

        protected void BuildParamFromQuery()
        {
            Query = this.Query<string>("query");
            if (Query.IsNull()) Query = string.Empty;
            var qAlias = this.Query<string>("alias");
            if (qAlias.IsNotNull()) alias = qAlias.Split(';').Where(a => a.IsNotNull())
                                                             .Select(a => a.Split(':'))
                                                             .Where(a => a.Length == 2)
                                                             .Select(a => new AliasField { FromField = a[0], ToField = a[1] }).ToList();

            ReflectTypeListPropertyNonePublicWithAttribute<SelectDataAttribute>.Inst[GetType()].ForEach(ps =>
            {
                var findAlias = alias.FirstOrDefault(a => a.FromField == ps.T2.Name);
                var value = this.Query<string>(findAlias == null ? ps.T2.Name : findAlias.ToField);
                SetValueFrom(ps, value);
            });
        }

        private void SetValueFrom(Pair<PropertyInfo, SelectDataAttribute> ps, object value)
        {
            if (ps.T2.NeedBuildValue) ps.T1.SetValue(this, ps.T2.BuildValue(value.ConvertToType(ps.T1.PropertyType)));
            else ps.T1.SetValue(this, value.ConvertToType(ps.T1.PropertyType));
        }

        public void ParseValueFrom(object obj)
        {
            var dic = obj.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(obj));
            if (dic.ContainsKey("Query")) Query = Convert.ToString(dic["Query"]);

            ReflectTypeListPropertyNonePublicWithAttribute<SelectDataAttribute>.Inst[GetType()].ForEach(ps =>
            {
                var findAlias = alias.FirstOrDefault(a => a.FromField == ps.T2.Name);
                var name = findAlias == null ? ps.T2.Name : findAlias.ToField;

                if (!dic.ContainsKey(name)) return;
                var value = dic[name];
                SetValueFrom(ps, value);
            });
        }

        protected virtual void BeforeGetData()
        {
            ReflectTypeListPropertyNonePublicWithAttribute<SelectDataAttribute>.Inst[GetType()].ForEach(p =>
            {
                if (p.T2.NeedBuildValue)
                    p.T1.SetValue(this, dataAjax[p.T2.Name] = p.T2.BuildValue(p.T1.GetValue(this)));
            });
        }
        protected virtual Type GetTypeOfT() { return typeof(T); }

        protected abstract List<T> GetData();
        protected virtual T GetOneWhenSelectAjax() { return default; }

        #region Các thuộc tính của đối tượng
        private string dataValueField = string.Empty; public TChain DataValueField<TMember>(Expression<Func<T, TMember>> ex) { return Chain(t => t.dataValueField = ex.GetName()); }
        private string id = string.Empty; public TChain Id(string id) { return Chain(t => t.id = id); }
        private string cssClass = string.Empty; public TChain CssClass(string cssClass) { return Chain(t => t.cssClass = cssClass); }
        private string dataTextField = string.Empty; public TChain DataTextField<TMember>(Expression<Func<T, TMember>> ex) { return Chain(t => t.dataTextField = ex.GetName()); }
        private string textDefault = string.Empty; public TChain TextDefault(string textDefault) { return Chain(t => t.textDefault = textDefault); }
        private string valueDefault = string.Empty; public TChain ValueDefault(string valueDefault) { return Chain(t => t.valueDefault = valueDefault); }
        private string width = "100%"; public TChain Width(string width) { return Chain(t => t.width = width); }
        private bool disableSearch = false; public TChain DisableSearch(bool disableSearch) { return Chain(t => t.disableSearch = disableSearch); }
        protected object[] value = null; public TChain Value(params object[] value) { return Chain(t => t.value = value); }
        protected bool isEmpty = false; public TChain IsEmpty(bool isEmpty = true) { return Chain(t => t.isEmpty = isEmpty); }
        protected bool multiple = false; public TChain Multiple(bool multiple = true) { return Chain(t => t.multiple = multiple); }
        public TChain MaxSelection(int max) { return Chain(t => t.Data("maximumSelectionLength", max)); }

        public TChain PlaceholderMultiple(string plc) { return Chain(t => t.Data("placeholder_text_multiple", plc)); }
        protected bool useDefault = true; public TChain UseDefault(bool useDefault = true) { return Chain(t => t.useDefault = useDefault); }
        #endregion

        public class AliasField
        {
            public string FromField { set; get; }
            public string ToField { set; get; }

            public override string ToString()
            {
                return $"{FromField}.{ToField}";
            }
        }

        private List<AliasField> alias = new List<AliasField>();
        public TChain Alias(string fromField, string toField)
        {
            return Chain(t => t.alias.Add(new AliasField { FromField = fromField, ToField = toField }));
        }

        public override string ToString()
        {
            var type = GetType();
            var assembly = type.Assembly.FullName.Split(',')[0];
            var fullName = type.FullName;
            Data("type-action", fullName.Replace($"{assembly}.", string.Empty));
            Data("assembly", assembly);

            Data("select-type", "select2");
            DataAjax.ForEach(d => 
            {
                var findAlias = alias.FirstOrDefault(a => a.FromField == d.Key);
                var key = findAlias == null ? d.Key : findAlias.ToField;
                if (d.Value == null) Data(key, string.Empty);
                else Data(key, d.Value);
            });
            Data("data-ajax", DataAjax.JoinString(d => 
            {
                var findAlias = alias.FirstOrDefault(a => a.FromField == d.Key);
                return findAlias == null ? d.Key : findAlias.ToField;
            }));

            Data("alias", alias.JoinString(a => a.FromField + ":" + a.ToField, ";"));

            Init();

            var typeT = GetTypeOfT(); // typeof(T);
            var html = new StringBuilder();

            BeforeGetData();

            List<T> data = null;
            if (isEmpty) data = new List<T> { };
            else
            {
                if (Select2Ajax) data = Context.Get(Key, () => 
                {
                    var one = GetOneWhenSelectAjax();
                    if (Equals(one, default(T))) return new List<T> { };
                    else return new List<T> { one };
                });
                else data = Context.Get(Key, () => GetData());
            }

            if (dataValueField.IsNull())
            {
                var dvf = typeT.GetListPairPropertyAttribute<DataValueFieldAttribute>().FirstOrDefault();
                if (dvf != null)
                {
                    dataValueField = dvf.T1.Name;
                    if(valueDefault.IsNull()) valueDefault = dvf.T2.Default;
                }
            }

            // Tìm xem property nào đóng vai trò là text
            if (dataTextField.IsNull())
            {
                var dtf = typeT.GetListPairPropertyAttribute<DataTextFieldAttribute>().FirstOrDefault();
                if (dtf != null)
                {
                    dataTextField = dtf.T1.Name;
                    if(textDefault.IsNull()) textDefault = dtf.T2.Default;
                }
                Data("text-field", dataTextField);
            }

            Data("value-default", valueDefault);
            Data("text-default", LanguageHelper.GetLabel(textDefault));

            StartElement(html);

            html.AppendFormat("<select data-use-default='{3}' name='{0}' data-width='{1}' data-disable-search='{2}' ", name, width, disableSearch, useDefault);
            if (id.IsNotNull()) html.AppendFormat("id='{0}' ", id);
            if (cssClass.IsNotNull()) html.AppendFormat("class='{0}' ", cssClass);
            if (style.IsNotNull()) html.AppendFormat("style='{0}' ", style);
            if (multiple) html.Append("multiple='multiple' ");

            if (!enable) html.Append("disabled='disabled' ");

            if (!useFireChange)
                Data("fire-change", null);

            html.Append(GetDataAttribute());
            html.Append(">");

            if (useDefault && textDefault.IsNotNull() && !multiple) html.AppendFormat("<option value='{0}'>{1}</option>", valueDefault, LanguageHelper.GetLabel(textDefault));

            // danh sách các giá trị của select
            string[] values = value == null ? new string[] { } : value.Where(v => v != null).Select(v => v.ToString()).ToArray();

            if (BuildOptionAttribute == null)
            {
                html.Append(data.Select(t =>
                {
                    var val = t.Eval(dataValueField).ToString();
                    return "<option " + (values.Contains(val) ? "selected='selected'" : string.Empty) + " value='" + val + "'>" + t.Eval(dataTextField) + "</option>";
                }).JoinString(t => t, string.Empty));
            }
            else
            {
                html.Append(data.Select(t =>
                {
                    var val = t.Eval(dataValueField).ToString();
                    return "<option "+ BuildOptionAttribute(t) + " " + (values.Contains(val) ? "selected='selected'" : string.Empty) + " value='" + val + "'>" + t.Eval(dataTextField) + "</option>";
                }).JoinString(t => t, string.Empty));
            }
            html.Append("</select>");

            EndElement(html);

            return html.ToString();
        }

        protected virtual void StartElement(StringBuilder html) { }
        protected virtual void EndElement(StringBuilder html) { }

        protected virtual string Key
        {
            get { return "Select_" + typeof(T).FullName + "_" + alias.JoinString(a => a, "_"); }
        }

        public event Func<T, object> BuildOptionAttribute = null;

        public TChain Select2(bool ajax = true)
        {
            //Chain(t => t.Data("select-type", "select2"));
            return S2UseAjax(ajax);
        } // Nếu không có thì vẫn mặc định là dùng Chosen

        protected bool Select2Ajax { get; private set; } = false;

        public TChain S2UseAjax(bool ajax = true) 
        {
            Select2Ajax = ajax;
            return Chain(t => t.Data("select2-use-ajax", ajax)); 
        }
        protected void SetFireChange(string name) { Data("fire-change", name); }

        private bool useFireChange = true;
        public TChain UseFireChange(bool useFireChange) { return Chain(t => t.useFireChange = useFireChange); }

        private Dictionary<string, object> dataAjax = null;
        protected Dictionary<string, object> DataAjax
        {
            get
            {
                if (dataAjax == null)
                {
                    dataAjax = new Dictionary<string, object>();
                    ReflectTypeListPropertyNonePublicWithAttribute<SelectDataAttribute>.Inst[GetType()].ForEach(p =>
                    {
                        if (p.T2.NeedBuildValue)
                        {
                            p.T1.SetValue(this, dataAjax[p.T2.Name] = p.T2.BuildValue(p.T1.GetValue(this)));
                        }
                        else
                        {
                            if (!p.T1.PropertyType.IsEnum) dataAjax[p.T2.Name] = p.T1.GetValue(this);
                            else
                            {
                                dataAjax[p.T2.Name] = Convert.ChangeType(p.T1.GetValue(this), Enum.GetUnderlyingType(p.T1.PropertyType));
                            }
                        }
                    });
                }
                return dataAjax;
            }
        }
    }

    public class DataValueFieldAttribute : Attribute 
    {
        public string Default { set; get; }
    }
    public class DataTextFieldAttribute : Attribute 
    {
        public string Default { set; get; }
    }
    public class SelectDataAttribute : Attribute 
    {
        public SelectDataAttribute(string name)
        {
            Name = name;
        }
        public string Name { private set; get; }
        public virtual bool NeedBuildValue { get { return false; } }
        public virtual object BuildValue(object value) { return value; }
    }
    public class SelectFireFieldAttribute : ClassInfoAttribute
    {
        public string FireField { set; get; }
    }
}