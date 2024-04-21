using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Linq.Expressions;

namespace Core.Sites.Apps.Web.Extensions
{
    public static partial class PortalModuleExtension
    {
        public static FormGroup<TEntity> InputText<TEntity>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> ex, string placeHolder, Action<FormGroup<TEntity>.InputInForm> ac = null) where TEntity : class, new()
        {
            return module.Input<TEntity, FormGroup<TEntity>.InputInForm>(col, ex, ip =>
            {
                //ip.PlaceHolder("Nhập từ khóa tìm kiếm");
                ip.PlaceHolder(placeHolder);
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<TEntity> InputText<TEntity>(this PortalModule<TEntity> module, float col, string placeHolder, Action<FormGroup<TEntity>.InputInForm> ac = null) where TEntity : class, new()
        {
            return module.InputText(col, null, placeHolder, ac);
        }

        public static FormGroup<Empty> InputText(this PortalModule module, float col, string name, string placeHolder, Action<FormGroup<Empty>.InputInForm> ac = null)
        {
            return module.Input<FormGroup<Empty>.InputInForm>(col, name, ip =>
            {
                //ip.PlaceHolder("Nhập từ khóa tìm kiếm");
                ip.PlaceHolder(placeHolder);
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<Empty> InputText(this PortalModule module, float col, string placeHolder, Action<FormGroup<Empty>.InputInForm> ac = null)
        {
            return module.InputText(col, string.Empty, placeHolder, ac);
        }

        public static FormGroup<TEntity> InputKeyword<TEntity>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> ex, Action<FormGroup<TEntity>.InputInForm> ac = null) where TEntity : class, new()
        {
            return module.InputText(col, ex, "Nhập từ khóa tìm kiếm");
        }
        public static FormGroup<TEntity> InputKeyword<TEntity>(this PortalModule<TEntity> module, float col, Action<FormGroup<TEntity>.InputInForm> ac = null) where TEntity : class, new()
        {
            return module.InputKeyword(col, null, ac);
        }
        public static FormGroup<Empty> InputKeyword<TEntity>(this PortalModule module, float col, string name, Action<FormGroup<TEntity>.InputInForm> ac = null) where TEntity : class, new()
        {
            return module.InputText(col, name, "Nhập từ khóa tìm kiếm");
        }
    }
}