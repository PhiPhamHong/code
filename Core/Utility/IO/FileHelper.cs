using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Core.Extensions;
namespace Core.Utility.IO
{
    public class FileHelper
    {
        private static object objWrite = true;

        /// <summary>
        /// Ghi một nội dung ra file
        /// Kiểm tra xem thư mục đã có chưa, thư mục chưa có thì tạo thư mục
        /// Kiểm tra file đã tồn tại chưa, chưa tồn tại thì tạo file
        /// </summary>
        /// <param name="pathWrite"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool WriteFile(string pathWrite, string content)
        {
            var result = false;

            lock (objWrite)
            {
                // Tạo thư mục nếu như thư mục chưa tồn tại
                var folder = Path.GetDirectoryName(pathWrite);
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                // Tạo file nếu như file chưa tồn tại
                if (!File.Exists(pathWrite))
                    using (var fs = new FileStream(pathWrite, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)) fs.Close();

                // Thực hiện ghi file
                using (var sw = new StreamWriter(pathWrite, true, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(content);
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logType">Tiêu đề Log</param>
        /// <param name="content">Nội dung</param>
        /// <param name="folder">Thư mục</param>
        /// <param name="logFileName">Tên file</param>
        /// <param name="isWeb">True: Cho web, False: cho ứng dụng</param>
        public static void WriteLog(string logType, string content, string folder, string logFileName = "", bool isWeb = false)
        {
            try
            {
                var time = DateTime.Now;
                var path = Path.Combine(string.Format(folder + @"\{0:dd-MM-yyyy}\", time));

                if (isWeb)
                    path = HostingEnvironment.MapPath("~/" + path);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var file = path + (logFileName.IsNull() ? time.ToString("HH-mm") : logFileName) + ".txt";
                WriteFile(file, time.ToString("HH-mm-ss") + ": " + logType + " - " + content);
            }
            catch { }
        }

        public static void WriteLog(string log, string content, bool isWeb = false)
        {
            WriteLog(log, content, "Error", string.Empty, isWeb);
        }

        /// <summary>
        /// Ghi Log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="ex"></param>
        public static void WriteLog(string log, Exception ex, bool isWeb = false)
        {
            WriteLog(log, ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + "----------------------------" + Environment.NewLine, isWeb);
        }

        /// <summary>
        /// Tạo mơi file rỗng
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateEmptyFile(string filePath)
        {
            lock (objWrite)
            {
                if (!File.Exists(filePath))
                {
                    using (var strLocal = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                        strLocal.Close();
                }
                else File.WriteAllText(filePath, string.Empty);
            }
        }
    }
}
