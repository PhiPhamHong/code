using Core.Attributes;
namespace Core.Web.WebBase
{
    /// <summary>
    /// Bound method
    /// </summary>
    public abstract class AjaxBoundRequestAttribute : MethodInfoAttribute
    {
        /// <summary>
        /// Trước khi gọi phương thức
        /// </summary>
        public abstract void Before();

        /// <summary>
        /// Sau khi gọi phương thức
        /// </summary>
        public abstract void After();
    }
}
