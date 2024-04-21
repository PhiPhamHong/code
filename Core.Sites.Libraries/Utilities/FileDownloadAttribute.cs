using Core.Attributes;

namespace Core.Sites.Libraries.Utilities
{
    public class FileDownloadAttribute : MethodInfoAttribute
    {
        public MimeType MimeType { set; get; }
    }
}
