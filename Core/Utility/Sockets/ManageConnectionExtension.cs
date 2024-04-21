using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Utility.Sockets
{
    public static class ManageConnectionExtension
    {
        /// <summary>
        /// Thực hiện đăng nhập cho một connection.
        /// Center có thể có một mảng ManageConnection để quản lý các Connection theo nhóm
        /// Vì vậy việc login (hay đưa connection vào quản lý) cũng cần phải cho mỗi một connection thì KeyConnection cũng phải là duy nhất.
        /// => Cũng phải tìm lại connection cũ theo KeyConnection để thực hiện remove đi trước.
        /// </summary>
        /// <typeparam name="TKey">Kiểu dữ liệu của KeyConnection</typeparam>
        /// <typeparam name="TConnection">Connection</typeparam>
        /// <typeparam name="TManageConnection">ManageConnection</typeparam>
        /// <param name="manageConnections">Một mảng các ManageConnection</param>
        /// <param name="connection">Connection cần thực hiện login</param>
        /// <param name="oldnew">Sự kiện nếu tồn tại Connection theo KeyConnection được bắn ra</param>
        public static void DoLogin<TKey, TConnection>(this List<ManageConnection<TKey, TConnection>> manageConnections, TConnection connection, Action<TConnection, TConnection> oldnew)
            where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
        {
            // Tìm connection theo key
            // Cần phải tìm trong nhiều ManageConnection, vì không biết với key đó thì connection nằm ở đâu
            var oldOther = manageConnections.Select(mc => mc.FindByKey(connection.KeyConnection)).FirstOrDefault();

            // Nếu là trong cùng một ManageConnection thì thực hiện login luôn
            if (oldOther == null || oldOther.ManageConnection.Port == connection.ManageConnection.Port)
                connection.ManageConnection.Login(connection, oldnew);

            // Ngược lại, nếu khác ManageConnection thì phải logout ở ManageConnection trước
            // Sau đó mới thực hiện login trong ManageConnection mới
            else
            {
                oldOther.ManageConnection.Logout(oldOther, false);
                connection.ManageConnection.Login(connection);
                if (oldnew != null) oldnew(oldOther, connection);
            }

            if (oldOther != null) oldOther.Dispose();
        }

        public static void Stop<TKey, TConnection>(this List<ManageConnection<TKey, TConnection>> manageConnections)
            where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
        {
            if (manageConnections == null) return;
            manageConnections.ForEach(manage => manage.Stop());
        }

        /// <summary>
        /// Tìm một Connection theo KeyConnection trong danh sách ManageConnection
        /// Connection nằm dải rác ở các ManageConnection
        /// Vì vậy việc tìm Connection cũng phải duyệt qua từng ManageConnection cho đến khi nào tìm được thì thôi
        /// </summary>        
        /// <param name="manageConnections">Danh sách các ManageConnection</param>
        public static TConnection FindByKey<TKey, TConnection>(this List<ManageConnection<TKey, TConnection>> manageConnections, TKey key)
            where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
        {
            return manageConnections.Select(mc => mc.FindByKey(key)).FirstOrDefault();
        }

        public static TConnection Find<TKey, TConnection>(this List<ManageConnection<TKey, TConnection>> manageConnections, Func<TConnection, bool> predicate)
            where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
        {
            return manageConnections.Select(mc => mc.Logins.Select(c => c.Value).FirstOrDefault(predicate)).FirstOrDefault();
        }

        public static bool OnConnection<TKey, TConnection>(this List<ManageConnection<TKey, TConnection>> manageConnections, TKey key, Action<TConnection> action)
            where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
        {
            var connection = manageConnections.FindByKey(key);
            if (connection == null) return false;
            action(connection);
            return true;
        }

        /// <summary>
        /// Lấy ra danh sách tất cả những connection lái xe mà đã thực hiện đăng nhập thành công
        /// </summary>
        public static IEnumerable<TConnection> AllLogins<TKey, TConnection>(this List<ManageConnection<TKey, TConnection>> manageConnections)
            where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
        {
            return manageConnections.SelectMany(mc => mc.Logins.Select(c => c.Value));
        }

        /// <summary>
        /// Lấy ra tất cả các connection (cả đăng nhập lẫn chưa đăng nhập) 
        /// </summary>        
        public static IEnumerable<TConnection> AllConnections<TKey, TConnection>(this List<ManageConnection<TKey, TConnection>> manageConnections)
            where TConnection : Connection, IConnectionWithManager<TConnection>, TConnectionKey<TKey>, new()
        {
            return manageConnections.SelectMany(mc => mc.All.Select(c => c.Value));
        }
    }
}
