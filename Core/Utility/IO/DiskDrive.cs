using System.IO;
using System.Text;
using System.Web;
using Core.Extensions;
namespace Core.Utility.IO
{
    public class DiskDrive
    {
        /// <summary>
        /// Đọc nội dung file ra string
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string LoadFile(string filePath)
        {
            // Mở file để đọc
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Thực hiện đọc file
        /// Bắt đầu từ vị trí nào cho đến hết file
        /// Nhưng chỉ lấy đến đoạn nào có kết thúc là end
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="position"></param>
        /// <param name="end"></param>
        /// <param name="bufferSize"></param>
        /// <returns></returns>
        public FileIndex ReadBlock(string filePath, int position, string end, int bufferSize = 524288) // 4096000 //0x10000//524288
        {
            // ShKeyValue<int, byte[]> data = null;

            byte[] value = new byte[bufferSize];
            int key = 0;


            // Thực hiện đọc file
            using (var fsr = new FileStreamReader(filePath))
            {
                // fsr.BufferSize = bufferSize;
                //data = fsr.Read(position);
                fsr.Read(position, bufferSize, ref key, ref value);
            }

            // 
            if (key == 0) return null;
            var indexOfEnd = value.LastIndexOf(key, end);
            if (indexOfEnd <= 0) return null;

            // 
            return new FileIndex
            {
                Index = position + indexOfEnd,
                Content = Encoding.UTF8.GetString(value, 0, indexOfEnd)
            };
        }

        /// <summary>
        /// Thực hiện đọc cho đến hết file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public FileIndex ReadToEndFrom(string filePath, int position)
        {
            Pair<int, byte[]> data = null;

            // Thực hiện đọc đến hết file
            using (var fsr = new FileStreamReader(filePath))
            {
                data = fsr.ReadToEndFrom(position);
            }

            if (data == null) return null;

            // 
            return new FileIndex
            {
                Index = data.T1,
                Content = Encoding.UTF8.GetString(data.T2)
            };
        }
    }

    public class FileIndex
    {
        public string Content { set; get; }
        public int Index { set; get; }

        public int CompanyId { set; get; }
    }

    /// <summary>
    /// Mở rộng phương thức cho string
    /// </summary>
    public static class StringExtender
    {
        /// <summary>
        /// Server.MapPath
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ServerMapPath(this string filePath)
        {
            return HttpContext.Current.Server.MapPath("~{0}".Frmat(filePath));
        }

        /// <summary>
        /// Lấy ra nội dung file, MapPath trên web
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileContent(this string filePath)
        {
            return DiskDrive.LoadFile(filePath.ServerMapPath());
        }
    }
}
