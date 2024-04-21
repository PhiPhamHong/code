using System.Collections.Specialized;

namespace Core.Web
{
    public interface IUrlPath
    {
        string Path { get; }
        object Id { get; }
    }
}