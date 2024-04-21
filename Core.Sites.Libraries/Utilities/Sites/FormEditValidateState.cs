using Core.Web.Utility;
using Core.Web.WebBase;

namespace Core.Sites.Libraries.Utilities.Sites
{
    public abstract class FormEditValidateState<TEnum, TEntity, TKey, TProviderValidateState> : PortalModule<TEntity>, IAjax
        where TEntity : class, IEntityValidateState<TEnum, TKey>, new()
        where TProviderValidateState : ProviderValidateState<TEnum, TEntity, TKey>, new()
    {
        public abstract bool IsSender { get; }
        public abstract bool IsReceiver { get; }

        protected TProviderValidateState ProviderValidateState = new TProviderValidateState { };

        sealed protected override void OnInitData()
        {
            this.SetData("IsSender", IsSender);
            this.SetData("IsReceiver", IsReceiver);

            AfterInitData();
        }

        protected abstract void AfterInitData();

        protected bool CanEditBySender
        {
            get
            {
                return IsSender && (
                    Entity.State.Equals(ProviderValidateState.StateUnknown) ||
                    Entity.State.Equals(ProviderValidateState.StateTemp) ||
                    Entity.State.Equals(ProviderValidateState.StateRejected));
            }
        }
        protected bool CanEditByReceiver
        {
            get
            {
                return IsReceiver && (
                        Entity.State.Equals(ProviderValidateState.StateSending) ||
                        Entity.State.Equals(ProviderValidateState.StateReceived) ||
                        Entity.State.Equals(ProviderValidateState.StateDoing) ||
                        Entity.State.Equals(ProviderValidateState.StateDone));
            }
        }
        protected bool CanEditReceiverId
        {
            get
            {
                if (IsSender)
                {
                    if (Entity.State.Equals(ProviderValidateState.StateUnknown) ||
                       Entity.State.Equals( ProviderValidateState.StateTemp) ||
                       Entity.State.Equals(ProviderValidateState.StateSending) ||
                       Entity.State.Equals(ProviderValidateState.StateRejected)) return true;
                }

                if (IsReceiver)
                {
                    if (Entity.Receiver == 0 ||
                       (
                        Entity.Receiver == ProviderValidateState.CurrentUserId && (Entity.State.Equals(ProviderValidateState.StateSending) ||
                                                                                       Entity.State.Equals(ProviderValidateState.StateReceived))
                       ))
                        return true;
                }

                return false;
            }
        }
    }
}
