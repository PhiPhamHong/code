using Core.Utility;
using System;

namespace Core.Web.Utility
{
    public partial class ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
    {
        public abstract partial class ForSender : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        {
            sealed public override void Validate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new)
            {
                if (!provider.IsSender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M44);
                OnValidate(providerState, provider, old, @new);
            }
            protected abstract void OnValidate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new);
        }
    }
}
