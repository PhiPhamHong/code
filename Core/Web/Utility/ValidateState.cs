using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
namespace Core.Web.Utility
{
    public abstract partial class ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>
        where TEntity : IEntityValidateState<TEnum, TKey>
        where TValidateStateMessage: ValidateStateMessage, new()
        where TProviderValidateState: ProviderValidateState<TEnum, TEntity, TKey>, new()
    {
        public virtual TEnum ForState(TProviderValidateState providerState) { return default; }
        public virtual void Validate(TProviderValidateState providerState, IProviderPermissionValidateState provider, TEntity old, TEntity @new) { }

        private static List<ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>> Validates = new List<ValidateState<TEnum, TEntity, TKey, TValidateStateMessage, TProviderValidateState>>
        {
            new ForSender.Temp { },
            new ForSender.Sending { },

            new ForReceiver.Received { },
            new ForReceiver.Rejected { },
            new ForReceiver.Done { }
        };

        public static void DoValidate(IProviderPermissionValidateState provider, TEntity old, TEntity @new)
        {
            var providerState = new TProviderValidateState { };

            Validates.Where(v => v.ForState(providerState).Equals(@new.State)).ForEach(v => v.Validate(providerState, provider, old, @new));
        }
    }

    public interface IEntityValidateState<TState, TKey>
    {
        TKey Key { get; }
        int Sender { get; }
        int Receiver { get; }
        TState State { get; }
    }

    public abstract class ProviderValidateState<TEnum, TEntity, TKey> where TEntity : IEntityValidateState<TEnum, TKey>
    {
        public abstract int CurrentUserId { get; }

        public abstract TEnum StateUnknown { get; }
        public abstract TEnum StateTemp { get; }
        public abstract TEnum StateSending { get; }
        public abstract TEnum StateReceived { get; }
        public abstract TEnum StateRejected { get; }
        public abstract TEnum StateDone { get; }
        public abstract TEnum StateDoing { get; }

        public virtual void OnValidateRejected(TEntity old, TEntity @new) { }
        public virtual void OnValidateSending(TEntity old, TEntity @new) { }
        public virtual void OnValidateReceived(TEntity old, TEntity @new) { }
    }

    public interface IProviderPermissionValidateState
    {
        bool IsSender { get; }
        bool IsReceiver { get; }
    }
    public abstract class ValidateStateMessage
    {
        public abstract string M44 { get; }
        public abstract string M45 { get; }
        public abstract string M46 { get; }
        public abstract string M47 { get; }
        public abstract string M48 { get; }
        public abstract string M49 { get; }
        public abstract string M50 { get; }
        public abstract string M51 { get; }
        public abstract string M52 { get; }
        public abstract string M53 { get; }
        public abstract string M54 { get; }
        public abstract string M55 { get; }
        public abstract string M56 { get; }
        public abstract string M57 { get; }
        public abstract string M58 { get; }
        public abstract string M59 { get; }
        public abstract string M60 { get; }
        public abstract string M61 { get; }
        public abstract string M62 { get; }
        public abstract string M63 { get; }
        public abstract string M64 { get; }
        public abstract string M65 { get; }
        public abstract string M66 { get; }
        public abstract string M67 { get; }
        public abstract string M68 { get; }
        public abstract string M72 { get; }
        public abstract string M76 { get; }
        public abstract string M81 { get; }
        public abstract string M82 { get; }
    }
}
