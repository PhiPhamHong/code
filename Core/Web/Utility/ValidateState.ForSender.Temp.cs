using Core.Utility;
using System;

namespace Core.Web.Utility
{
    public partial class ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
    {
        public partial class ForSender : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        {
            public class Temp : ForSender
            {
                public override TEnum ForState(TProviderValidateState providerState) =>providerState.StateTemp;
                protected override void OnValidate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new)
                {
                    if (@new.Key.Equals(default(TKey))) return;

                    if (old.State.Equals(providerState.StateReceived)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M66);
                    else if (old.State.Equals(providerState.StateDone)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M67);
                    else
                    {
                        if (providerState.CurrentUserId != @new.Sender && @new.Sender != old.Sender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M68);
                    }
                }
            }
        }
    }
}