using System;
using System.Collections.Concurrent;
using Core.Extensions;
namespace Core.Utility.Sockets
{
    /// <summary>
    /// Đối tượng quản lý một nhóm các TConnection. 
    /// Mỗi một TConnection ngoài ConnectionId thì còn có một Key khác là ConnectionKey (Kế thừa đến interface TConnectionKey<TKey>)
    /// TConnection cũng phải kế thừa đến interface IConnectionWithManager<TConnection> để biết được mình đang chịu sự quản lý của ManageConnection nào
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TConnection"></typeparam>
    public class ManageConnection<TKey, TConnection> : IManageConnection<TConnection>
        where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
    {
        private ConcurrentDictionary<Guid, TConnection> all = new ConcurrentDictionary<Guid, TConnection>();
        /// <summary>
        /// Tất cả các connection được quản lý. 
        /// Lưu trữ theo Dictionary với key là ConnectionId
        /// </summary>
        public ConcurrentDictionary<Guid, TConnection> All
        {
            get { return all; }
        }

        private ConcurrentDictionary<TKey, TConnection> logins = new ConcurrentDictionary<TKey, TConnection>();
        /// <summary>
        /// Tất cả  các connection được login
        /// Lưu trữ theo Dictionary với key là KeyConnection
        /// </summary>
        public ConcurrentDictionary<TKey, TConnection> Logins
        {
            get { return logins; }
        }

        /// <summary>
        /// ManageConnection tạo một TConnection thì làm 2 nhiệm vụ
        /// 1. Khởi tạo và gán cho TConnection này sẽ chịu sự quản lý của nó => new TConnection { ManageConnection = this }
        /// 2. Đưa vào danh sách các TConnection mà nó quản lý với key là ConnectionId
        /// Vì là mới khởi tạo, chưa login nên chưa đưa vào ConcurrentDictionary<TKey, TConnection> logins
        /// </summary>        
        public TConnection NewConnection()
        {
            var connection = new TConnection { ManageConnection = this };
            all.TryAdd(connection.ConnectionId, connection);
            return connection;
        }

        /// <summary>
        /// Thực hiện đưa connection vào danh sách logins. Các bước cần thực hiện khi đưa vào ConcurrentDictionary<TKey, TConnection> logins
        /// 1. Tìm xem key connection cần thực hiện login đã có key login trước đó chưa
        /// Nếu trước đó đã tồn tại rùi 
        /// stop connection cũ và thực hiện remove khỏi ConcurrentDictionary<Guid, TConnection> all
        /// 2. Thay thế bằng connection mới theo KeyConnection vào ConcurrentDictionary<TKey, TConnection> logins
        /// 3. Bắn ra sự kiện oldnew khi có connection cũ để tầng business đối chiếu copy state của connection cũ sang connection mới
        /// </summary>
        public bool Login(TConnection connection, Action<TConnection, TConnection> oldnew = null)
        {
            if (!all.ContainsKey(connection.ConnectionId)) return false;

            TConnection old = null;
            if (logins.TryGetValue(connection.KeyConnection, out old))
            {
                old.Stop();
                all.TryRemove(old.ConnectionId, out old);
            }

            logins[connection.KeyConnection] = connection;

            // Bắn sự kiện nếu có xử lý với connection cũ và connection mới
            if (old != null && oldnew != null) oldnew(old, connection);
            return true;
        }

        /// <summary>
        /// Thực hiện remove connection ra khỏi ConcurrentDictionary<Guid, TConnection> all và ConcurrentDictionary<TKey, TConnection> logins
        /// Nhưng trước khi remove thì Stop mọi hoạt động lắng nghe dữ liệu và gửi đi của connection
        /// </summary>
        /// <param name="connection"></param>
        public void Logout(TConnection connection, bool dispose = true)
        {
            TConnection connectionById = null;
            if (all.ContainsKey(connection.ConnectionId))
            {
                if (connection.ConnectState == ConnectState.OPENNED) connection.Stop();
                all.TryRemove(connection.ConnectionId, out connectionById);
            }

            TConnection connectionByKey = null;
            if (connection.KeyConnection != null && logins.ContainsKey(connection.KeyConnection))
            {
                if (connection.ConnectState == ConnectState.OPENNED) connection.Stop();
                logins.TryRemove(connection.KeyConnection, out connectionByKey);
            }

            connection.OnLogout();
            if (dispose) connection.Dispose();
        }

        /// <summary>
        /// Tìm Connection theo key 
        /// trong ConcurrentDictionary<TKey, TConnection> logins
        /// </summary>
        public TConnection FindByKey(TKey key)
        {
            TConnection connection = null;
            return logins.TryGetValue(key, out connection) ? connection : null;
        }

        /// <summary>
        /// Port của các connection đang kết nối đến
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Stop tất cả các Connection lại => nhưng không thực hiện Logout
        /// </summary>
        public void Stop()
        {
            all.ForEach(client => client.Value.Stop());
        }
    }
}
