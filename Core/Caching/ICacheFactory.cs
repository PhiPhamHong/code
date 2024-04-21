namespace Core.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICacheFactory
    {
        /// <summary>
        /// 
        /// </summary>
        ICacheProvider Provider { get; }
    }
}
