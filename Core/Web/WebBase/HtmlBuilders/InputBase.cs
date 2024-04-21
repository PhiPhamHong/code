using System;
using System.Linq.Expressions;
using Core.Attributes;
using Core.Extensions;
using Core.Utility.Language;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class InputBase<T, TChain> : Html<TChain>, IInputBase<TChain>, IInputBase where TChain : InputBase<T, TChain>
    {
        #region properties
        protected string inputCss = "form-control";
        public TChain InputCss(string inputCss) { return Chain(t => t.inputCss += " " + inputCss); }

        protected bool enable = true;
        public TChain Enable(bool enable) { return Chain(t => t.enable = enable); }

        protected string placeholder = "";
        public TChain PlaceHolder(string placeholder) { return Chain(t => t.placeholder = placeholder); }
        public TChain PlaceHolder(object placeholder) { return PlaceHolder(placeholder.ToString()); }

        protected string name = string.Empty;
        public TChain Name(string name) { return Chain(t => t.name = name); }

        protected LambdaExpression expressionName = null;
        public TChain Name<TEntity>(Expression<Func<TEntity, object>> ex) { return Chain(t => t.expressionName = ex); }
        public TChain Name(Expression<Func<T, object>> ex) { return Name<T>(ex); }
        public TChain Name(LambdaExpression ex) { return Chain(t => t.expressionName = ex); }

        protected string style = string.Empty;
        public TChain Style(string style) { return Chain(t => t.style += style + ";"); }
        protected object[] value = null; public TChain Value(params object[] value) { return Chain(t => t.value = value); }
        public TChain TabIndex(int tabIndex) { return Chain(t => t.Data("tab-index", tabIndex)); }
        #endregion
        public IFormGroup FormGroup { set; get; }
        protected void Init()
        {
            if (expressionName != null)
            {
                var member = expressionName.GetMemberInfo();
                var field = member.GetAttribute<PropertyInfoAttribute>();
                if (name.IsNull()) name = member.Name;
                if (placeholder.IsNull())
                    placeholder = field != null && field.Name.IsNotNull() ? field.Name : name;
            }

            if (placeholder.IsNotNull())
                placeholder = LanguageHelper.GetLabel(placeholder);
        }

        void IInputBase.Name(LambdaExpression ex) { expressionName = ex; }
        void IInputBase.Name(string name) { this.name = name; }

        void IInputBase.Enable(bool enable)
        {
            this.enable = enable;
        }
    }

    public interface IInputBase<TChain> : IHtml where TChain : IHtml
    {
        TChain Name(LambdaExpression ex);
        TChain Name(string name);
    }

    public interface IInputBase
    {
        void Name(LambdaExpression ex);
        void Name(string name);
        void Enable(bool enable);
    }
}
