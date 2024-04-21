using Core.Utility;
using System;

namespace Core.Web.Utility
{
    public partial class ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
    {
        public partial class ForReceiver : ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        {
            public class Done : ForReceiver
            {
                public override TEnum ForState(TProviderValidateState providerState) => providerState.StateDone;
                protected override void OnValidate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new)
                {
                    if (old == null) throw new Exception(Singleton<TValidateStateMessage>.Inst.M46);
                    if (@new.Receiver != providerState.CurrentUserId) throw new Exception(Singleton<TValidateStateMessage>.Inst.M47);
                    if (@new.Sender != old.Sender) throw new Exception(Singleton<TValidateStateMessage>.Inst.M48);

                    if (old.State.Equals(providerState.StateTemp)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M49);
                    else if (old.State.Equals(providerState.StateSending)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M50);
                    else if (old.State.Equals(providerState.StateRejected)) throw new Exception(Singleton<TValidateStateMessage>.Inst.M51);
                    else if (old.State.Equals(providerState.StateDone)) { }     // Cập nhật lại khi đang hoàn phiếu
                    else if (old.State.Equals(providerState.StateReceived)) { } // Hoàn thành phiếu khi đang nhận xử lý
                }
            }
        }
    }
}
