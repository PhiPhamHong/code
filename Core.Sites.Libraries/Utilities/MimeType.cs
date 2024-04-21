using Core.Attributes;

namespace Core.Sites.Libraries.Utilities
{
    public enum MimeType
    {
        [MimeTypeInfo(Name = "pdf", Type = "application/pdf")] Pdf = 0,
        [MimeTypeInfo(Name = "xls", Type = "application/vnd.ms-excel")] Excel97To2003 = 1,
        [MimeTypeInfo(Name = "zip", Type = "application/octet-stream ")] Zip = 2,
        [MimeTypeInfo(Name = "doc", Type = "application/msword")] Doc = 3,
        [MimeTypeInfo(Name = "docx", Type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document")] Docx = 4
    }

    public class MimeTypeInfoAttribute : FieldInfoAttribute
    {
        public string Type { set; get; }
    }
}
