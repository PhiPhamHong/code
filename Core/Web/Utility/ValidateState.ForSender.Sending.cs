using Core.Utility;
using System;

namespace Core.Web.Utility
{
    public partial class ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
    {
        public partial class ForSender : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        {
            public class Sending : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
            {
                public override TEnum ForState(TProviderValidateState providerState) => providerState.StateSending;

                public override void Validate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new)
                {
                    if (@new.Sender == 0) throw new Exception(Singleton<TValidateStateMessage>.Inst.M72);

                    if (@new.Key.Equals(default(TKey)) )
                    {
                        if (!provider.IsSender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M44);

                        providerState.OnValidateSending(old, @new);
                        return;
                    }

                    // Nếu Entity gửi cho Receiver, xong Receiver lại muốn gửi cho một người khác.
                    if (provider.IsReceiver && providerState.CurrentUserId == old.Receiver &&
                        (old.State.Equals(providerState.StateSending) ||
                        old.State.Equals(providerState.StateReceived)))
                    {
                        if (old.Receiver == @new.Receiver) throw new Exception(Singleton<TValidateStateMessage>.Inst.M65);
                        providerState.OnValidateSending(old, @new);
                        return;
                    }

                    if (old != null && old.Sender == providerState.CurrentUserId && old.Sender != @new.Sender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M61);
                    if (old != null && @new.Sender == providerState.CurrentUserId && old.Sender != @new.Sender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M62);

                    if (old.State.Equals(providerState.StateTemp)) { }
                    else if (old.State.Equals(providerState.StateSending)) { }
                    else if (old.State.Equals(providerState.StateRejected)) { }
                    else if (old.State.Equals(providerState.StateReceived)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M63);
                    else if (old.State.Equals(providerState.StateDone)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M64);
                    providerState.OnValidateSending(old, @new);
                }
            }
        }
    }
}
