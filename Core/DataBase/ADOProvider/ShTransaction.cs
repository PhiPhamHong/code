using System;
using System.Linq;
namespace Core.DataBase.ADOProvider
{
    public class ShTransaction
    {
        private static readonly object objSave = new object();

        public static void Do<T1>(Action<T1> action) where T1 : IDataBaseService, new()
        {
            lock (objSave)
            {
                var t1 = new T1();
                OnService(() => action(t1), t1);
            }
        }

        public static void OnService(Action action, params IDataBaseService[] services)
        {
            bool success = false;
            try
            {
                services.ToList().ForEach(s => s.BeginTransaction());
                action();
                success = true;
            }
            catch (Rollback) { }
            finally
            {
                services.ToList().ForEach(s => s.Commit(success));
            }
        }

        public class Rollback : Exception
        {

        }
    }
}
