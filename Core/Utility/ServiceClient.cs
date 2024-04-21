using System;
using System.ServiceModel;
namespace Core.Utility
{
    public class ServiceClient<TClient, TInstance> : Singleton<TInstance> 
        where TClient : class, ICommunicationObject, IDisposable, new()
        where TInstance : new()
    {
        private bool isUseOneConnect = false;
        public bool IsUseOneConnect
        {
            get { return isUseOneConnect; }
            set
            {
                TryDispose();
                if (isUseOneConnect = value)
                {
                    GetClient = () => Client;
                    WhenError = NewAndOpen;
                    Finish = client => { };
                }
                else
                {
                    GetClient = CreateNewClient;
                    WhenError = () => { };
                    Finish = TryDispose;
                }
            }
        }

        private Func<TClient> GetClient = null;
        private Action WhenError = null;
        private Action<TClient> Finish = null;

        private void NewAndOpen()
        {
            TryDispose();
            client = CreateNewClient();
            // client.Open();
        }
        public void TryDispose()
        {
            TryDispose(client);
            client = null;
        }
        private static void TryDispose(TClient _client)
        {
            if (_client != null)
            {
                try { _client.Dispose(); }
                catch { }
                finally { _client = null; }
            }
        }

        private TClient client = null;
        private TClient Client
        {
            get
            {
                if (client == null) NewAndOpen();

                else
                {
                    switch (client.State)
                    {
                        case CommunicationState.Closed:
                        case CommunicationState.Closing:
                        case CommunicationState.Faulted:
                            NewAndOpen(); // Khởi tạo connection mới
                            break;
                    }
                }
                return client;
            }
        }

        protected virtual TClient CreateNewClient()
        {
            return new TClient();
        }
        protected virtual TResult Call<TResult>(Func<TClient, TResult> action)
        {
            TClient _client = null;
            try
            {
                _client = GetClient();
                return action(_client);
            }
            catch
            {
                WhenError();
                throw;
            }
            finally
            {
                Finish(_client);
            }
        }

        /// <summary>
        /// Gọi khi phương thức được cung cấp không trả ra loại dữ liệu gì
        /// </summary>
        /// <param name="action"></param>
        protected virtual void Call(Action<TClient> action)
        {
            Call(client => { action(client); return true; });
        }
    }
}