using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Core.Extensions;
using Core.Forms.Converters;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Định nghĩa danh sách các Port nghe ngóng Accept Connection
    /// Các Port được ngăn cách nhau bởi dấu , hoặc dải cổng thì là ..
    /// Ví dụ: 1001,1002,1005>1010 =>
    /// Các cổng lắng nghe connection đến là 1001,1002,1005,1006,1007,1008,1009,1010
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ConnectionAcceptPort
    {
        private List<int> ports = new List<int>();
        [TypeConverter(typeof(ListConverter))]
        public List<int> Ports { get { return ports; } }

        public static implicit operator ConnectionAcceptPort(string ports)
        {
            var cap = new ConnectionAcceptPort();
            cap.ports = ports.Split(',').Where(p => p.IsNotNull()).SelectMany(p => GetPorts(p)).ToList();
            return cap;
        }

        private static IEnumerable<int> GetPorts(string ports)
        {
            var rangePort = ports.Split('>');
            if (rangePort.Length == 1) yield return Convert.ToInt32(ports);

            else
            {
                var start = Convert.ToInt32(rangePort[0]);
                var end = Convert.ToInt32(rangePort[1]);
                var range = Enumerable.Range(start, end - start);

                foreach (var port in range) yield return port;
            }
        }

        public override string ToString()
        {
            return Ports.JoinString(p => p);
        }
    }

    public static class ConnectionAcceptPortExtension
    {
        /// <summary>
        /// Từ dải cổng => sinh ra một list các worker để nghe ngóng nhận connection
        /// TWorkerLisener: Có thể là worker nghe ngóng DriverClient, OperatiorClient hoặc CustomerClient
        /// TConnection: Có thể là DriverClient, OperatiorClient hoặc CustomerClient
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TConnection">Loại connection khi nghe ngóng nhận được</typeparam>
        /// <typeparam name="TWorkerLisener">Loại WorkerLisener</typeparam>
        /// <param name="cap">Dải cổng</param>
        /// <returns></returns>
        public static IEnumerable<TWorkerLisener> CreateWorkers<TKey, TConnection, TWorkerLisener>(this ConnectionAcceptPort cap, List<ManageConnection<TKey, TConnection>> manageClients)
            where TConnection : Connection, TConnectionKey<TKey>, IConnectionWithManager<TConnection>, new()
            where TWorkerLisener : IConnectionAcceptLisener<TConnection, TKey>, new()
        {
            return cap.Ports.Select(port =>
            {
                var workerLisenser = new TWorkerLisener { Port = port };
                workerLisenser.ManageConnection = new ManageConnection<TKey, TConnection> { Port = port };
                manageClients.Add(workerLisenser.ManageConnection);
                return workerLisenser;
            });
        }
    }
}
