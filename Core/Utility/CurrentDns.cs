using System.Net;
using System.Net.Sockets;

namespace Core.Utility
{
    public class CurrentDns : Singleton<CurrentDns>
    {
        /// <summary>
        /// Lấy địa IP hiện thời của máy đang chạy
        /// </summary>
        /// <returns></returns>
        public string GetAddress()
        {
            // First get the host name of local machine.
            var strHostName = Dns.GetHostName();

            // Then using host name, get the IP address list..
            var ipEntry = Dns.GetHostEntry(strHostName);
            var addr = ipEntry.AddressList;

            // Copy của Phú, chưa hiểu lắm :D
            string selectedAddress = string.Empty;
            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i].AddressFamily != AddressFamily.InterNetworkV6)
                {
                    if ((!IPAddress.IsLoopback(addr[i])) || (addr[i].ToString() == "127.0.0.1"))
                    {
                        selectedAddress = addr[i].ToString();
                        break;
                    }
                }
            }

            return selectedAddress;
        }
    }
}
