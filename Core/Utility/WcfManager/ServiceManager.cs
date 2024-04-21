using System;
using Core.Extensions;
using Core.Reflectors;
namespace Core.Utility.WcfManager
{
    /// <summary>
    /// ServiceManager
    /// </summary>
    public class ServiceManager : Singleton<ServiceManager>
    {
        /// <summary>
        /// CreateHost
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Host CreateHost<T>(Action<ServiceInfoAttribute> action = null) where T : ServiceBase
        {
            // Lấy ServiceInfoAttribute của T
            var sif = ReflectClassInfo<ServiceInfoAttribute>.Inst[typeof(T)];

            // Nếu Null thì return null
            if (sif.IsNull()) return null;

            // Nếu có action xử lý ServiceInfoAttribute
            if (action.IsNotNull()) action(sif);

            // Tạo Host
            Host host = new Host();

            // Thiết lập thông số cho host
            host.SetServiceInfo(sif);

            // return
            return host;
        }

        /// <summary>
        /// CreateHost
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpPort"></param>
        /// <param name="tcpPort"></param>
        /// <returns></returns>
        public Host CreateHost<T>(int httpPort, int tcpPort, string ip = "") where T : ServiceBase
        {
            return CreateHost<T>(sif =>
            {
                // Ip
                sif.Ip = ip;

                // Nếu có thông tin cổng http thì thiết lập, không thì mặc định
                if (httpPort != 0) sif.HttpPort = httpPort;

                // Nếu có thông tin cổng tcp thì thiết lập, không thì mặc định
                if (tcpPort != 0) sif.TcpPort = tcpPort;
            });
        }
    }
}
