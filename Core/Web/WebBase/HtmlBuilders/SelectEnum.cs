using System.Collections.Generic;
using Core.Attributes;
using Core.Utility;
using System.Linq;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public abstract class SelectEnum<TEnum, TChain> : SelectEnum<TEnum, FieldInfoAttribute, TChain>
        where TChain : SelectEnum<TEnum, TChain>
    {

    }

    public abstract class SelectEnum<TEnum, TFieldInfoAttribute, TChain> : Select<TFieldInfoAttribute, TChain>, IAjax
        where TChain : SelectEnum<TEnum, TFieldInfoAttribute, TChain>
        where TFieldInfoAttribute : FieldInfoAttribute
    {
        protected override List<TFieldInfoAttribute> GetData()
        {
            var data = EnumHelper<TEnum>.Inst.GetAttributes<TFieldInfoAttribute>();
            if (exclude == null) return data;
            return data.Where(item => !exclude.Contains((TEnum)item.RawValue)).ToList();
        }

        public override string ToString()
        {
            UseDefault(false);
            DataTextField(fi => fi.Name);
            DataValueField(fi => fi.RawValue);
            DisableSearch(true);
            return base.ToString();
        }

        private TEnum[] exclude = null;
        public TChain Exclude(params TEnum[] values)
        {
            return Chain(t => t.exclude = values);
        }

        protected override string Key
        {
            get { return "Select_" + typeof(TEnum).FullName + (exclude == null ? string.Empty : exclude.JoinString(s => s)); }
        }

        public void GetDataAjax()
        {
            BuildParamFromQuery();

            this.SetData("ListItem", DoGetDataAjax());

            this.SetData("DataValueField", new { T1 = new { Name = "id" } });
            this.SetData("DataTextField", new { T1 = new { Name = "text" } });

            //var typeT = typeof(T);

            //var dvf = typeT.GetListPairPropertyAttribute<DataValueFieldAttribute>().FirstOrDefault();
            //if (dvf != null) this.SetData("DataValueField", dvf);

            //var dtf = typeT.GetListPairPropertyAttribute<DataTextFieldAttribute>().FirstOrDefault();
            //if (dtf != null) this.SetData("DataTextField", dtf);
        }

        protected virtual List<TFieldInfoAttribute> DoGetDataAjax()
        {
            return GetData();
        }
    }
}