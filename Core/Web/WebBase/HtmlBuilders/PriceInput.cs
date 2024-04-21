using System;
using System.Linq.Expressions;
using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class PriceInput<T, TChain> : InputBase<T, TChain> where TChain : PriceInput<T, TChain>
    {
        #region VND
        protected string vnd = string.Empty;
        public TChain Lat(string vnd) { return Chain(t => t.vnd = vnd); }
        protected LambdaExpression expressionVND = null;
        public TChain VND<TEntity>(Expression<Func<TEntity, object>> ex) { return Chain(t => t.expressionVND = ex); }
        public TChain VND(Expression<Func<T, object>> ex) { return VND<T>(ex); }
        public TChain VND(LambdaExpression ex) { return Chain(t => t.expressionVND = ex); }
        protected Action<Input<T, Input<T>>> onInputVND = null;
        public TChain OnInputVND(Action<Input<T, Input<T>>> onInputVND) { return Chain(t => t.onInputVND = onInputVND); }
        protected bool paddingLeftVND = true; public TChain PaddingLeftVND(bool paddingLeftVND = true) { return Chain(t => t.paddingLeftVND = paddingLeftVND); }
        #endregion

        #region USD
        protected string usd = string.Empty;
        public TChain USD(string usd) { return Chain(t => t.usd = usd); }
        protected LambdaExpression expressionUSD = null;
        public TChain USD<TEntity>(Expression<Func<TEntity, object>> ex) { return Chain(t => t.expressionUSD = ex); }
        public TChain USD(Expression<Func<T, object>> ex) { return USD<T>(ex); }
        public TChain USD(LambdaExpression ex) { return Chain(t => t.expressionUSD = ex); }
        protected Action<Input<T, Input<T>>> onInputUSD = null;
        public TChain OnInputUSD(Action<Input<T, Input<T>>> onInputUSD) { return Chain(t => t.onInputUSD = onInputUSD); }
        protected bool paddingRightUSD = true; public TChain PaddingRightUSD(bool paddingRightUSD) { return Chain(t => t.paddingRightUSD = paddingRightUSD); }
        #endregion

        #region JPY
        protected string jpy = string.Empty;
        public TChain JPY(string jpy) { return Chain(t => t.jpy = jpy); }
        protected LambdaExpression expressionJPY = null;
        public TChain JPY<TEntity>(Expression<Func<TEntity, object>> ex) { return Chain(t => t.expressionJPY = ex); }
        public TChain JPY(Expression<Func<T, object>> ex) { return JPY<T>(ex); }
        public TChain JPY(LambdaExpression ex) { return Chain(t => t.expressionJPY = ex); }
        protected Action<Input<T, Input<T>>> onInputJPY = null;
        public TChain OnInputJPY(Action<Input<T, Input<T>>> onInputJPY) { return Chain(t => t.onInputJPY = onInputJPY); }
        protected bool paddingLeftJPY = true; public TChain PaddingLeftJPY(bool paddingLeftJPY) { return Chain(t => t.paddingLeftJPY = paddingLeftJPY); }
        protected bool paddingRightJPY = true; public TChain PaddingRightJPY(bool paddingRightJPY) { return Chain(t => t.paddingRightJPY = paddingRightJPY); }
        #endregion

        public bool rowLine = false;
        public TChain RowLine(bool rowLine) { return Chain(t => t.rowLine = rowLine); }

        private string col = "3";
        public TChain Col(int col) { return Chain(t => t.col = col.ToString()); }
        public TChain Col(float col) { return Chain(t => t.col = col.ToString().Replace(".", "-")); }
        public TChain Col(string col) { return Chain(t => t.col = col); }

        public override string ToString()
        {
            var html = new StringBuilder();
            if (rowLine) html.Append("<div class='row'>");

            if (usd.IsNotNull() || expressionUSD != null)
            {
                var inputUSD = new Input<T>().Style("width:100%").InputCss("").IsNumeric().Enable(enable);
                if (usd.IsNotNull()) inputUSD.Name(usd);
                if (expressionUSD != null) inputUSD.Name(expressionUSD);
                if (onInputUSD != null) onInputUSD(inputUSD);
                html.Append("<div class=\"col-sm-" + col + "\" style=\"" + (paddingRightUSD ? "padding-right: 0px" : string.Empty) + "\"><div class=\"input-group\">"); html.Append(inputUSD.ToString()); html.Append("<div class=\"input-group-addon\"><i class=\"fa fa-dollar\"></i></div></div></div>");
            }

            if (jpy.IsNotNull() || expressionJPY != null)
            {
                var inputJPY = new Input<T>().Style("width:100%").InputCss("").IsNumeric().Enable(enable);
                if (jpy.IsNotNull()) inputJPY.Name(jpy);
                if (expressionJPY != null) inputJPY.Name(expressionJPY);
                if (onInputJPY != null) onInputJPY(inputJPY);
                html.Append("<div class=\"col-sm-" + col + "\" style=\""+ (paddingRightJPY ? "padding-right: 0px" : string.Empty) +";" + (paddingLeftJPY ? "padding-left: 0px" : string.Empty) + "\"><div class=\"input-group\">"); html.Append(inputJPY.ToString()); html.Append("<div class=\"input-group-addon\"><i class=\"fa fa-jpy\"></i></div></div></div>");
            }

            if (vnd.IsNotNull() || expressionVND != null)
            {
                var inputVND = new Input<T>().Style("width:100%").InputCss("").IsNumeric().Enable(enable);
                if (vnd.IsNotNull()) inputVND.Name(vnd);
                if (expressionVND != null) inputVND.Name(expressionVND);
                if (onInputVND != null) onInputVND(inputVND);
                html.Append("<div class=\"col-sm-" + col + "\" style=\"" + (paddingLeftVND ? "padding-left: 0px" : string.Empty) + "\"><div class=\"input-group\">"); html.Append(inputVND.ToString()); html.Append("<div class=\"input-group-addon\"><b>đ</b></div></div></div>");
            }

            if (rowLine) html.Append("</div>");
            return html.ToString();
        }
    }
}