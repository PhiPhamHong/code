using Core.Utility;
using System;

namespace Core.Web.Utility
{
    public partial class ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
    {
        public abstract partial class ForReceiver : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        {
            sealed public override void Validate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new)
            {
                if (!provider.IsReceiver) throw new Exception(Singleton<TValidateStateMessage>.Inst.M45);
                OnValidate(providerState, provider, old, @new);
            }
            protected abstract void OnValidate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new);
        }
    }
}
