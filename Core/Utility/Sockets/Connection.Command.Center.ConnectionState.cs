using Core.Forms;

namespace Core.Utility.Sockets
{
    public abstract class Connection<TCommand, TConnection, TCenter, TState> : Connection<TCommand, TConnection, TCenter>
        where TCommand : Command<TConnection>
        where TConnection : Connection
        where TCenter : ICenter
        where TState : ConnectionState, new()
    {
        protected override ConnectionState CreateConnectionState()
        {
            return new TState();
        }

        new public TState State
        {
            set { base.State = value; }
            get { return base.State as TState; }
        }
    }
}