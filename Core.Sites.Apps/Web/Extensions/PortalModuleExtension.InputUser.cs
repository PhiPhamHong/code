using Core.Sites.Apps.Web.Inputs;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Linq.Expressions;
using Core.Extensions;
namespace Core.Sites.Apps.Web.Extensions
{
    public static partial class PortalModuleExtension
    {
        public static FormGroup<TEntity> InputUser<TEntity>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> nameEx, Action<UserInput> ac = null) where TEntity : class, new()
        {
            return module.Select<TEntity, UserInput>(col, nameEx, ip =>
            {
                //ip.UseDefault(false);
                if (nameEx == null) ip.Name("UserId");
                if (ac != null) ac(ip);
            });
        }
        public static FormGroup<TEntity> InputUser<TEntity>(this PortalModule<TEntity> module, float col, Action<UserInput> ac = null) where TEntity : class, new()
        {
            return module.InputUser(col, null, ac);
        }

        public static FormGroup<Empty> InputUser(this PortalModule module, float col, string name, Action<UserInput> ac = null)
        {
            return module.Select<UserInput>(col, name, ip =>
            {
                //ip.UseDefault(false);
                if (name.IsNull()) ip.Name("UserId");
                if (ac != null) ac(ip);
            });
        }
        public static FormGroup<Empty> InputUser(this PortalModule module, float col, Action<UserInput> ac = null)
        {
            return module.InputUser(col, string.Empty, ac);
        }
    }
}