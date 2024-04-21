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
        public static FormGroup<TEntity> InputCompany<TEntity>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> nameEx, Action<CompanyInput> ac = null) where TEntity : class, new()
        {
            return module.Select<TEntity, CompanyInput>(col, nameEx, ip =>
            {
                ip.UseDefault(false);
                if (nameEx == null) ip.Name("CompanyId");
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<TEntity> InputCompany<TEntity>(this PortalModule<TEntity> module, float col, Action<CompanyInput> ac = null) where TEntity : class, new()
        {
            return module.InputCompany(col, null, ac);
        }

        public static FormGroup<Empty> InputCompany(this PortalModule module, float col, string name, Action<CompanyInput> ac = null) 
        {
            return module.Select<CompanyInput>(col, name, ip =>
            {
                ip.UseDefault(false);
                if (name.IsNotNull()) ip.Name("CompanyId");
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<Empty> InputCompany(this PortalModule module, float col, Action<CompanyInput> ac = null)
        {
            return module.InputCompany(col, string.Empty, ac);
        }
    }
}