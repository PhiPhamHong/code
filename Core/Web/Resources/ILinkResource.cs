using System;
namespace Core.Web.Resources
{
    public interface ILinkResource
    {
        string Path { get; }
        string Site { get; }
        string Content { get; }
    }
}
