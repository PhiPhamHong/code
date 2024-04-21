using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Linq.Expressions;
using Core.Extensions;
namespace Core.Sites.Apps.Web.Extensions
{
    public static partial class PortalModuleExtension
    {
        public static FormGroup<TEntity> InputDate<TEntity>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> ex, string placeHolder, Action<FormGroup<TEntity>.DatePickerInForm> ac = null) where TEntity : class, new()
        {
            return module.Input<TEntity, FormGroup<TEntity>.DatePickerInForm>(col, ex, ip =>
            {   
                ip.PlaceHolder(placeHolder);
                ip.Width("100%");
                if (ac != null) ac(ip);
            });
        }
        public static FormGroup<TEntity> InputDate<TEntity>(this PortalModule<TEntity> module, float col, string placeHolder, Action<FormGroup<TEntity>.DatePickerInForm> ac = null) where TEntity : class, new()
        {
            return module.InputDate(col, null, placeHolder, ac);
        }

        public static FormGroup<Empty> InputDate(this PortalModule module, float col, string name, string placeHolder, Action<FormGroup<Empty>.DatePickerInForm> ac = null)
        {
            return module.Input<FormGroup<Empty>.DatePickerInForm>(col, name, ip =>
            {
                ip.PlaceHolder(placeHolder);
                ip.Width("100%");
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<Empty> InputDate(this PortalModule module, float col, string placeHolder, Action<FormGroup<Empty>.DatePickerInForm> ac = null)
        {
            return module.InputDate(col, string.Empty, placeHolder, ac);
        }

        public static FormGroup<TEntity> InputFromDate<TEntity>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> ex, string placeHolder, Action<FormGroup<TEntity>.DatePickerInForm> ac = null) where TEntity : class, new()
        {
            if (placeHolder.IsNull()) placeHolder = "Từ ngày";
            return module.InputDate(col, placeHolder, ip => 
            {
                if (ex == null) ip.Name("StartTime");
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<TEntity> InputFromDate<TEntity>(this PortalModule<TEntity> module, float col, Action<FormGroup<TEntity>.DatePickerInForm> ac = null) where TEntity : class, new()
        {
            return module.InputFromDate(col, null, string.Empty, ac);
        }

        public static FormGroup<Empty> InputFromDate(this PortalModule module, float col, string name, string placeHolder, Action<FormGroup<Empty>.DatePickerInForm> ac = null)
        {
            if (placeHolder.IsNull()) placeHolder = "Từ ngày";
            return module.InputDate(col, placeHolder, ip =>
            {
                if (name.IsNull()) ip.Name("StartTime");
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<Empty> InputFromDate<TEntity>(this PortalModule module, float col, Action<FormGroup<Empty>.DatePickerInForm> ac = null)
        {
            return module.InputFromDate(col, string.Empty, string.Empty, ac);
        }

        public static FormGroup<TEntity> InputToDate<TEntity>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> ex, string placeHolder, Action<FormGroup<TEntity>.DatePickerInForm> ac = null) where TEntity : class, new()
        {
            if (placeHolder.IsNull()) placeHolder = "Đến ngày";
            return module.InputDate(col, placeHolder, ip =>
            {
                if (ex == null) ip.Name("EndTime");
                ac?.Invoke(ip);
                ip.EndDate();
            });
        }
        public static FormGroup<TEntity> InputToDate<TEntity>(this PortalModule<TEntity> module, float col, Action<FormGroup<TEntity>.DatePickerInForm> ac = null) where TEntity : class, new()
        {
            return module.InputToDate(col, null, string.Empty, ac);
        }

        public static FormGroup<Empty> InputToDate(this PortalModule module, float col, string name, string placeHolder, Action<FormGroup<Empty>.DatePickerInForm> ac = null)
        {
            if (placeHolder.IsNull()) placeHolder = "Đến ngày";
            return module.InputDate(col, placeHolder, ip =>
            {
                if (name.IsNull()) ip.Name("EndTime");
                if (ac != null) ac(ip);
                ip.EndDate();
            });
        }
        public static FormGroup<Empty> InputToDate<TEntity>(this PortalModule module, float col, Action<FormGroup<Empty>.DatePickerInForm> ac = null)
        {
            return module.InputToDate(col, string.Empty, string.Empty, ac);
        }
    }
}