using System;
using System.Linq.Expressions;
using System.Text;
using Core.Attributes;
using Core.Extensions;
using Core.Utility.Language;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class LatLngInput<T, TChain> : InputBase<T, TChain> where TChain : LatLngInput<T, TChain>
    {
        public LatLngInput()
        {
            Data("type-latlng", "true");
        }

        protected string lat = string.Empty; public TChain Lat(string lat) { return Chain(t => t.lat = lat); }
        protected LambdaExpression expressionLat = null; public TChain Lat<TEntity>(Expression<Func<TEntity, object>> ex) { return Chain(t => t.expressionLat = ex); }
        public TChain Lat(Expression<Func<T, object>> ex) { return Lat<T>(ex); }
        public TChain Lat(LambdaExpression ex) { return Chain(t => t.expressionLat = ex); }

        protected string lng = string.Empty; public TChain Lng(string lng) { return Chain(t => t.lng = lng); }
        protected LambdaExpression expressionLng = null; public TChain Lng<TEntity>(Expression<Func<TEntity, object>> ex) { return Chain(t => t.expressionLng = ex); }
        public TChain Lng(Expression<Func<T, object>> ex) { return Lng<T>(ex); }
        public TChain Lng(LambdaExpression ex) { return Chain(t => t.expressionLng = ex); }

        public override string ToString()
        {
            if (expressionLat != null)
            {
                var member = expressionLat.GetMemberInfo();
                var field = member.GetAttribute<PropertyInfoAttribute>();
                if (lat.IsNull()) lat = member.Name;
            }

            if (expressionLng != null)
            {
                var member = expressionLng.GetMemberInfo();
                var field = member.GetAttribute<PropertyInfoAttribute>();
                if (lng.IsNull()) lng = member.Name;
            }

            var html = new StringBuilder();
            html.Append("<div class=\"input-group \" ");
            html.Append(this.GetDataAttribute());
            html.Append(">");

            html.Append("<input type='text' data-lat='true' style='width:50%' ");
            html.AppendFormat("class = '{0} input-sm' ", inputCss);
            html.Append("placeholder = '"+ LanguageHelper.GetLabel("Vĩ độ") +"' ");
            if (lat.IsNotNull()) html.AppendFormat("name = '{0}' ", lat);
            if (!enable) html.Append("disabled='disabled' ");
            html.Append("/>");

            html.Append("<input type='text' data-lng='true' style='width:50%' ");
            html.AppendFormat("class = '{0} input-sm' ", inputCss);
            html.Append("placeholder = '" + LanguageHelper.GetLabel("Kinh độ") + "' ");
            if (lng.IsNotNull()) html.AppendFormat("name = '{0}' ", lng);
            if (!enable) html.Append("disabled='disabled' ");
            html.Append("/>");

            html.Append("<div class=\"input-group-addon\">");
            html.Append("<i class=\"fa fa-map-marker\"></i>");
            html.Append("</div>");
            html.Append("</div>");
            return html.ToString();
        }
    }
}
