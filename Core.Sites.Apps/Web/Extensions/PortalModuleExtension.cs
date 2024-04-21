using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Linq.Expressions;
using Core.Extensions;
namespace Core.Sites.Apps.Web.Extensions
{
    public static partial class PortalModuleExtension
    {
        public static FormGroup<TEntity> Input<TEntity, TInput>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> nameEx = null, Action<TInput> ac = null)
            where TEntity : class, new()
            where TInput : class, IInputBase<TInput>, new()
        {
            TInput ci = null;
            var fg = module.FormGroup.Col(col).With<TInput>(ip => ci = ip);
            if (nameEx != null) ci.Name(nameEx);
            ac?.Invoke(ci);
            return fg;
        }
        public static FormGroup<TEntity> Input<TEntity, TInput>(this PortalModule<TEntity> module, float col, Action<TInput> ac = null)
            where TEntity : class, new()
            where TInput : class, IInputBase<TInput>, new()
        {
            return module.Input(col, null, ac);
        }

        public static FormGroup<Empty> Input<TInput>(this PortalModule module, float col, string name = "", Action<TInput> ac = null)
            where TInput : class, IInputBase<TInput>, new()
        {
            TInput ci = null;
            var fg = module.FormGroup.Col(col).With<TInput>(ip => ci = ip);
            if (name.IsNotNull()) ci.Name(name);
            ac?.Invoke(ci);
            return fg;
        }
        public static FormGroup<Empty> Input<TInput>(this PortalModule module, float col, Action<TInput> ac = null)
            where TInput : class, IInputBase<TInput>, new()
        {
            return module.Input(col, string.Empty, ac);
        }
        
        public static FormGroup<TEntity> Select<TEntity, TInput>(this PortalModule<TEntity> module, float col, Expression<Func<TEntity, object>> nameEx = null, Action<TInput> ac = null)
            where TEntity : class, new()
            where TInput : class, ISelectBase<TInput>, new()
        {
            return module.Input<TEntity, TInput>(col, nameEx, ip =>
            {
                ip.Width("100%");
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<TEntity> Select<TEntity, TInput>(this PortalModule<TEntity> module, float col, Action<TInput> ac = null)
                    where TEntity : class, new()
                    where TInput : class, ISelectBase<TInput>, new()
        {
            return module.Select(col, null, ac);
        }

        public static FormGroup<Empty> Select<TInput>(this PortalModule module, float col, string name = "", Action<TInput> ac = null)
            where TInput : class, ISelectBase<TInput>, new()
        {
            return module.Input<TInput>(col, name, ip =>
            {
                ip.Width("100%");
                ac?.Invoke(ip);
            });
        }
        public static FormGroup<Empty> Select<TEntity, TInput>(this PortalModule module, float col, Action<TInput> ac = null)
                    where TEntity : class, new()
                    where TInput : class, ISelectBase<TInput>, new()
        {
            return module.Select(col, string.Empty, ac);
        }
    }
}