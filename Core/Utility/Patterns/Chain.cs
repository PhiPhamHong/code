using Core.Extensions;
namespace Core.Utility.Patterns
{
    /// <summary>
    /// Pattern Chain Generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Chain<T>
    {
        private T handler;
        /// <summary>
        /// Xử lý
        /// </summary>
        public T Handler
        {
            get { return handler; }
            set { handler = value; }
        }

        /// <summary>
        /// Thực hiện Set Handler theo kiểu Generic        
        /// </summary>
        /// <param name="handler"></param>
        public void SetHandler<THandler>() where THandler : T, new()
        {
            // Khởi tạo một Handler mới
            var newHandler = new THandler();

            // Thực hiện Set Handler
            SetHandler(newHandler);
        }

        /// <summary>
        /// Thực hiện Set Handler
        /// </summary>
        /// <param name="handler"></param>
        public void SetHandler(T newHandler)
        {
            // Nếu như Handler phụ hiện thời mà không phải Null, đồng thời lại là Chain<T>
            // Thì cho Handler phụ thiết lập thêm Handler
            if (handler != null && handler.Is<Chain<T>>()) handler.As<Chain<T>>().SetHandler(newHandler);

            // Ngược lại thì thiết lập cho Handler phụ
            else handler = newHandler;
        }
    }
}
