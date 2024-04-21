using Core.Utility;
using System;

namespace Core.Web.Utility
{
    public partial class ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
    {
        public partial class ForReceiver : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        {
            public class Rejected : ForReceiver
            {
                public override TEnum ForState(TProviderValidateState providerState) => providerState.StateRejected;

                protected override void OnValidate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new)
                {
                    if (old == null) throw new Exception(Singleton<TValidateStateMessage>.Inst.M57);
                    if (old.Sender != @new.Sender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M53);

                    if (old.State.Equals(providerState.StateTemp)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M58);
                    else if (old.State.Equals(providerState.StateSending)) { }
                    else if (old.State.Equals(providerState.StateReceived)) { }
                    else if (old.State.Equals(providerState.StateRejected)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M59);
                    else if (old.State.Equals(providerState.StateDone)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M60);
                    else if (old.State.Equals(providerState.StateDoing)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M81);

                    providerState.OnValidateRejected(old, @new);
                }
            }
        }
    }
}
