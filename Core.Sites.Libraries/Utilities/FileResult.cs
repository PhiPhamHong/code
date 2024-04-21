using System;
using System.IO;
namespace Core.Sites.Libraries.Utilities
{
    public class FileResult
    {
        public Stream Stream { set; get; }
        public string FileName { set; get; }
        public Action End { set; get; }
    }
}
