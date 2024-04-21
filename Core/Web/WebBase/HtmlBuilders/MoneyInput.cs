using System;
using System.Linq.Expressions;
using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class MoneyInput<T, TChain> : InputBase<T, TChain> where TChain : MoneyInput<T, TChain>
    {
        private float? colLabel = 3;
        public TChain ColLabel(float colLabel) { return Chain(t => t.colLabel = colLabel); }

        private string idLabel = string.Empty;
        public TChain IdLabel(string idLabel) { return Chain(t => t.idLabel = idLabel); }

        #region Currency
        private float? colCurrency = 3;
        public TChain ColCurrency(float colCurrency) { return Chain(t => t.colCurrency = colCurrency); }

        private LambdaExpression expressionCurrency = null;
        public TChain Currency<TMember>(Expression<Func<T, TMember>> expressionCurrency) { return Chain(t => t.expressionCurrency = expressionCurrency); }
        public TChain Currency<TMember>(Expression<Func<T, TMember>> expressionCurrency, float colCurrency)
        {
            this.colCurrency = colCurrency;
            return Chain(t => t.expressionCurrency = expressionCurrency);
        }


        private string nameCurrency = string.Empty;
        public TChain Currency(string nameCurrency) { return Chain(t => t.nameCurrency = nameCurrency); }
        public TChain Currency(string nameCurrency, float colCurrency)
        {
            this.colCurrency = colCurrency;
            return Chain(t => t.nameCurrency = nameCurrency);
        }
        #endregion

        #region Rate
        private float? colRate = 3;
        public TChain ColRate(float colRate) { return Chain(t => t.colRate = colRate); }

        private LambdaExpression expressionRate = null;
        public TChain Rate<TMember>(Expression<Func<T, TMember>> expressionRate) { return Chain(t => t.expressionRate = expressionRate); }
        public TChain Rate<TMember>(Expression<Func<T, TMember>> expressionRate, float colRate)
        {
            this.colRate = colRate;
            return Chain(t => t.expressionRate = expressionRate);
        }

        private string nameRate = string.Empty;
        public TChain Rate(string nameRate) { return Chain(t => t.nameRate = nameRate); }
        public TChain Rate(string nameRate, float colRate)
        {
            this.colRate = colRate;
            return Chain(t => t.nameRate = nameRate);
        }

        private Action<InputNumeric<T, InputNumeric<T>>> onInputRate = null;
        public TChain OnInputRate(Action<InputNumeric<T, InputNumeric<T>>> onInputRate) { return Chain(t => t.onInputRate = onInputRate); }
        #endregion

        #region Money
        private float? colMoney = 3;
        public TChain ColMoney(float colMoney) { return Chain(t => t.colMoney = colMoney); }

        private LambdaExpression expressionMoney = null;
        public TChain Money<TMember>(Expression<Func<T, TMember>> expressionMoney) { return Chain(t => t.expressionMoney = expressionMoney); }
        public TChain Money<TMember>(Expression<Func<T, TMember>> expressionMoney, float colMoney)
        {
            this.colMoney = colMoney;
            return Chain(t => t.expressionMoney = expressionMoney);
        }

        private string nameMoney = string.Empty;
        public TChain Money(string nameMoney) { return Chain(t => t.nameMoney = nameMoney); }
        public TChain Money(string nameMoney, float colMoney)
        {
            this.colMoney = colMoney;
            return Chain(t => t.nameMoney = nameMoney);
        }

        private Action<InputNumeric<T, InputNumeric<T>>> onInputMoney = null;
        public TChain OnInputMoney(Action<InputNumeric<T, InputNumeric<T>>> onInputMoney) { return Chain(t => t.onInputMoney = onInputMoney); }

        private string dependencyDate = string.Empty;
        public TChain DependencyDate(string dependencyDate) { return Chain(t => t.dependencyDate = dependencyDate); }
        #endregion

        public override string ToString()
        {
            var html = new StringBuilder();

            html.Append("<div class='row' data-input='money-input' data-date='" + dependencyDate + "'>");

            // Nhập loại tiền
            if (colCurrency > 0)
            {
                html.Append("<div data-input-element='currency' class='col-sm-" + colCurrency.ToString().Replace(".", "-") + "'>");
                var selectCurrency = "Core.Sites.Apps.Web.Inputs.CurrencyInput,Core.Sites.Apps".CreateInstance<IInputBase>(); 
                if (nameCurrency.IsNotNull()) selectCurrency.Name(nameCurrency);
                else if (expressionCurrency.IsNotNull()) selectCurrency.Name(expressionCurrency);
                selectCurrency.As<ISelectCan>().Can();
                selectCurrency.Enable(true);
                html.Append(selectCurrency.ToString());
                html.Append("</div>");
            }

            // Input tỷ giá
            if (colRate > 0)
            {
                html.Append("<div data-input-element='rate' class='col-sm-" + colRate.ToString().Replace(".", "-") + "' style='padding-left:0px'>");
                var inputRate = new InputNumeric<T>().Style("width:100%;border-left:0px");
                inputRate.Enable(false);
                inputRate.Digits(0);
                inputRate.DigitsOptional(false);
                inputRate.Max(999999);
                if (nameRate.IsNotNull()) inputRate.Name(nameRate);
                else if (expressionRate.IsNotNull()) inputRate.Name(expressionRate);
                if (onInputRate != null) onInputRate(inputRate);
                html.Append(inputRate.ToString());
                html.Append("</div>");
            }

            // Input tiền
            if (colMoney > 0)
            {
                html.Append("<div data-input-element='money' class='col-sm-" + colMoney.ToString().Replace(".", "-") + "' style='padding-left:0px'>");
                var inputMoney = new InputNumeric<T>().Style("width:100%;border-left:0px");
                inputMoney.Enable(enable);
                inputMoney.Digits(0);
                inputMoney.DigitsOptional(false);
                inputMoney.Max(999999999);
                if (nameMoney.IsNotNull()) inputMoney.Name(nameMoney);
                else if (expressionMoney.IsNotNull()) inputMoney.Name(expressionMoney);
                if (onInputMoney != null) onInputMoney(inputMoney);
                html.Append(inputMoney.ToString());
                html.Append("</div>");
            }

            // Label quy đổi
            if (colLabel > 0)
            {
                html.Append("<label data-label='show-change' class='control-label col-sm-" + colLabel.ToString().Replace(".", "-") + "' style='padding-left:0px; font-size: 12px; font-weight: normal; padding-left: 0px;'>");
                html.Append("<span id='" + idLabel + "'></span>");
                html.Append("</label>");
            }

            html.Append("</div>");

            return html.ToString();
        }
    }
}