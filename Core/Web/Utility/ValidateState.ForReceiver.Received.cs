using Core.Utility;
using System;

namespace Core.Web.Utility
{
    public partial class ValidateState<TEnum, TEntity,TKey, TValidateStateMessage, TProviderValidateState>
    {
        public partial class ForReceiver : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        {
            public class Received : ForReceiver
            {
                public override TEnum ForState(TProviderValidateState providerState) => providerState.StateReceived;

                protected override void OnValidate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new)
                {
                    if (old == null) throw new Exception(Singleton<TValidateStateMessage>.Inst.M52);
                    if (old.Sender != @new.Sender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M53);
                    if (@new.Receiver == 0) throw new Exception(Singleton<TValidateStateMessage>.Inst.M76);

                    if (old.State.Equals(providerState.StateTemp)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M54);
                    else if (old.State.Equals(providerState.StateSending)) { }
                    else if (old.State.Equals(providerState.StateReceived)) { } // Receiver đã nhận rồi, vẫn có thể lưu lại được thông tin.
                    else if (old.State.Equals(providerState.StateRejected)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M55);
                    else if (old.State.Equals(providerState.StateDoing)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M82);
                    else if (old.State.Equals(providerState.StateDone)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M56);

                    providerState.OnValidateReceived(old, @new);
                }
            }
        }
    }
}
