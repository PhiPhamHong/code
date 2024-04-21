using System;
using System.Net.Security;
using System.ServiceModel;
using Core.Attributes;
namespace Core.Utility.WcfManager
{
    /// <summary>
    /// Thông tin về Service
    /// </summary>
    public class ServiceInfoAttribute : ClassInfoAttribute
    {
        private string name = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return name; }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ServiceInfoAttribute(string name)
        {
            this.name = name;
        }

        private string ip = string.Empty;
        /// <summary>
        /// Ip
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private int tcpPort = 3011;
        /// <summary>
        /// Cổng TCP
        /// </summary>
        public int TcpPort
        {
            get { return tcpPort; }
            set { tcpPort = value; }
        }

        private int httpPort = 3002;
        /// <summary>
        /// Cổng Http
        /// </summary>
        public int HttpPort
        {
            get { return httpPort; }
            set { httpPort = value; }
        }

        private ProtectionLevel protectionLevel = ProtectionLevel.EncryptAndSign;
        /// <summary>
        /// 
        /// </summary>
        public ProtectionLevel ProtectionLevel
        {
            get { return protectionLevel; }
            set { protectionLevel = value; }
        }

        private TcpClientCredentialType tcpClientCredentialType = TcpClientCredentialType.Windows;
        /// <summary>
        /// 
        /// </summary>
        public TcpClientCredentialType TcpClientCredentialType
        {
            get { return tcpClientCredentialType; }
            set { tcpClientCredentialType = value; }
        }

        private SecurityMode securityMode = SecurityMode.None;
        /// <summary>
        /// 
        /// </summary>
        public SecurityMode SecurityMode
        {
            get { return securityMode; }
            set { securityMode = value; }
        }

        /// <summary>
        /// class dùng để thiết lập việc validate username password
        /// </summary>
        public Type TypeValidateUserName { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string FindValue { set; get; }
    }
}
