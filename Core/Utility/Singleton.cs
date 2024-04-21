namespace Core.Utility
{
    /// <summary>
    /// Đối tượng dùng để khởi tạo một Instance cho các đối tượng khác
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : new()
    {
        private static T t = new T();
        public static T Inst
        {
            get { return t; }
        }

        public static T New
        {
            get { return new T(); }
        }
    }
}
