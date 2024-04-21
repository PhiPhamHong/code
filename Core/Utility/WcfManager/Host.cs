using System;
using System.IdentityModel.Selectors;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using Core.Extensions;
namespace Core.Utility.WcfManager
{
    /// <summary>
    /// Service Host
    /// </summary>
    public class Host
    {
        /// <summary>
        /// Service Host
        /// </summary>
        private ServiceHost serviceHost = null;
        /// <summary>
        /// Thiết lập Service Host
        /// </summary>
        /// <param name="serviceHost"></param>
        public void SetService(ServiceHost serviceHost)
        {
            this.serviceHost = serviceHost;
        }

        /// <summary>
        /// Lấy ra Service Host
        /// </summary>
        /// <returns></returns>
        public ServiceHost GetService()
        {
            return this.serviceHost;
        }

        /// <summary>
        /// Trạng thái của Host
        /// </summary>
        public CommunicationState State
        {
            get
            {
                return this.serviceHost == null ? CommunicationState.Closed : this.serviceHost.State;
            }
        }

        /// <summary>
        /// Thời gian Timeout khi Close
        /// </summary>
        public TimeSpan CloseTimeout
        {
            get
            {
                return this.serviceHost == null ? TimeSpan.Zero : this.serviceHost.CloseTimeout;
            }
        }

        /// <summary>
        /// Thời gian Timeout khi Open
        /// </summary>
        public TimeSpan OpenTimeout
        {
            get
            {
                return this.serviceHost == null ? TimeSpan.Zero : this.serviceHost.OpenTimeout;
            }
        }

        private string name = string.Empty;
        /// <summary>
        /// Tên Host
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string typeName = string.Empty;
        /// <summary>
        /// Type Name
        /// </summary>
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private string tcpService = string.Empty;
        /// <summary>
        /// Địa chỉ Tcp Service
        /// </summary>
        public string TcpService
        {
            get { return tcpService; }
            set { tcpService = value; }
        }

        private string httpService = string.Empty;
        /// <summary>
        /// Địa chỉ HttpService
        /// </summary>
        public string HttpService
        {
            get { return httpService; }
            set { httpService = value; }
        }

        private ServiceInfoAttribute serviceInfo = null;
        /// <summary>
        /// Thông tin Service
        /// </summary>
        public ServiceInfoAttribute ServiceInfo
        {
            set { serviceInfo = value; }
        }

        /// <summary>
        /// Thiết lập thông tin Service
        /// </summary>
        /// <param name="si"></param>
        public void SetServiceInfo(ServiceInfoAttribute si)
        {
            // Thông tin Host
            this.serviceInfo = si;

            // Tên Service
            this.Name = this.serviceInfo.Name;

            // Type Service
            this.TypeName = this.serviceInfo.TypeName;

            // Lấy ra địa chỉ hiện thời của máy đang chạy
            string ip = si.Ip.WhenEmpty(() => CurrentDns.Inst.GetAddress());

            // Địa chỉ tcpService
            this.TcpService = tcpServiceTemp.Frmat(ip, this.serviceInfo.Name, si.TcpPort);

            // Địa chỉ Http Service
            this.HttpService = httpServiceTemp.Frmat(ip, this.serviceInfo.Name, si.HttpPort);
        }

        /// <summary>
        /// Khởi tạo một service Host
        /// </summary>
        private void Create()
        {
            // Nếu đã tồn tại rồi thì hủy
            if (this.serviceHost != null) this.serviceHost.Abort();

            // TcpBinding
            // The binding is where we can choose what transport layer we want to use. HTTP, TCP ect.            
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.TransactionFlow = false;
            tcpBinding.Security.Transport.ProtectionLevel = this.serviceInfo.ProtectionLevel; //ProtectionLevel.EncryptAndSign;
            tcpBinding.Security.Transport.ClientCredentialType = this.serviceInfo.TcpClientCredentialType; //TcpClientCredentialType.Windows;
            tcpBinding.Security.Mode = this.serviceInfo.SecurityMode; //SecurityMode.None; // <- Very crucial

            tcpBinding.CloseTimeout = tcpBinding.SendTimeout = tcpBinding.ReceiveTimeout = new TimeSpan(0, 3, 0);
            tcpBinding.MaxBufferPoolSize = tcpBinding.MaxReceivedMessageSize = tcpBinding.MaxBufferSize = tcpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;

            // Khởi tạo Service Host
            this.serviceHost = new ServiceHost(this.serviceInfo.Type);

            // Có provider kiểm tra username và password không
            if (this.serviceInfo.TypeValidateUserName != null)
            {
                tcpBinding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
                this.serviceHost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
                this.serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = this.serviceInfo.TypeValidateUserName.CreateInstance<UserNamePasswordValidator>();
                this.serviceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, this.serviceInfo.FindValue);
            }

            this.serviceHost.CloseTimeout = new TimeSpan(0, 3, 0);

            // Add a endpoint
            this.serviceHost.AddServiceEndpoint(this.serviceInfo.Type.GetInterfaces()[0], tcpBinding, this.TcpService);

            // A channel to describe the service. Used with the proxy scvutil.exe tool
            ServiceMetadataBehavior metadataBehavior = this.serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

            // Nếu Null
            if (metadataBehavior == null)
            {
                // This is how I create the proxy object that is generated via the svcutil.exe tool
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetUrl = new Uri(this.HttpService);
                metadataBehavior.HttpGetEnabled = true;
                this.serviceHost.Description.Behaviors.Add(metadataBehavior);
            }

            // if not found ServiceDebugBehavior - add behavior with setting turned on 
            ServiceDebugBehavior debug = this.serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
            if (debug == null) this.serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });

            // make sure setting is turned ON
            else if (!debug.IncludeExceptionDetailInFaults) debug.IncludeExceptionDetailInFaults = true;

            ContractDescription cd = this.serviceHost.Description.Endpoints[0].Contract;
            foreach (var f in cd.Operations)
            {
                DataContractSerializerOperationBehavior serializerBehavior = f.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (serializerBehavior == null)
                {
                    serializerBehavior = new DataContractSerializerOperationBehavior(f);
                    f.Behaviors.Add(serializerBehavior);
                }
                serializerBehavior.MaxItemsInObjectGraph = 2147483647;
            }

            ServiceThrottlingBehavior throttlingBehavior = new ServiceThrottlingBehavior();
            throttlingBehavior.MaxConcurrentCalls = 16;
            throttlingBehavior.MaxConcurrentInstances = Int32.MaxValue;
            throttlingBehavior.MaxConcurrentSessions = 10;
            this.serviceHost.Description.Behaviors.Add(throttlingBehavior);
        }

        // Mấu tcp Service
        private string tcpServiceTemp = "net.tcp://{0}:{2}/{1}";

        // Mẫu http Service
        private string httpServiceTemp = "http://{0}:{2}/{1}";

        /// <summary>
        /// Mở Host
        /// </summary>
        public void Open()
        {
            // Nếu chưa có serviceHost hoặc đã đóng rồi thì tạo service mới và bind lại event
            if (this.serviceHost.IsNull() || this.State == CommunicationState.Closed)
            {
                this.Create();
                this.BindEvent();
            }

            // Mở Host
            this.serviceHost.Open();
        }

        /// <summary>
        /// Hủy bỏ sự kiện
        /// </summary>
        public void ClearEvent()
        {
            if (this.serviceHost.IsNull()) return;
            if (!IsNullChangeState)
            {
                this.serviceHost.Closed -= ChangeState;
                this.serviceHost.Opened -= ChangeState;
                ChangeState = null;
            }
        }

        /// <summary>
        /// Bind sự kiện
        /// </summary>
        public void BindEvent()
        {
            if (this.serviceHost.IsNotNull())
            {
                this.serviceHost.Closed += ChangeState;
                this.serviceHost.Opened += ChangeState;
            }
        }

        /// <summary>
        /// Đóng host -- : Không start dc Service sẽ bị lỗi
        /// </summary>
        public void Close()
        {
            if (this.serviceHost.State != CommunicationState.Closed)
            {
                //try { this.serviceHost.Close(); }
                try { this.serviceHost.Abort(); }
                catch { }
            }
        }

        /// <summary>
        /// Kiểm tra xem sự kiện thay đổi State có hay không
        /// </summary>
        public bool IsNullChangeState
        {
            get { return ChangeState.IsNull(); }
        }

        /// <summary>
        /// Sự kiện thay đổi trạng thái
        /// </summary>
        public EventHandler ChangeState;
    }
}
