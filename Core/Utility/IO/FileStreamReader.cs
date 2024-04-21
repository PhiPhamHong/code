using System;
using System.IO;
namespace Core.Utility.IO
{
    public class FileStreamReader : IDisposable
    {
        /// <summary>
        /// FileStream
        /// </summary>
        private FileStream fs;
        //private BinaryReader br;

        ///// <summary>
        ///// buffer
        ///// </summary>
        //private byte[] buffer = new byte[0x10000];

        ///// <summary>
        ///// Mặc định bufferSize 0x10000
        ///// </summary>
        //private int bufferSize = 0x10000;
        ///// <summary>
        ///// bufferSize
        ///// </summary>
        //public int BufferSize
        //{
        //    get { return bufferSize; }
        //    set
        //    {
        //        bufferSize = value;
        //        // buffer = new byte[bufferSize = value];
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public void Read(int position, int bufferSize, ref int index, ref byte[] bufferData)
        {
            // Thiết lập vị trí cần đọc
            fs.Position = position;

            // Thực hiện đọc
            index = fs.Read(bufferData, 0, bufferSize);

            // index = bufferLength;
            //bufferData =

            //// 
            //return new ShKeyValue<int, byte[]> 
            //{
            //    Key = bufferLength,
            //    Value = buffer
            //};
        }

        /// <summary>
        /// Đọc từ một vị trí xác định cho tới hết
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Pair<int, byte[]> ReadToEndFrom(int position)
        {
            fs.Seek(position, SeekOrigin.Begin);
            var fLength = fs.Length;
            var length = fLength - position;
            if (length <= 0) return null;

            byte[] b = new byte[length];
            fs.Read(b, 0, (int)length);
            // br.Read(b, 0, (int)length);

            return new Pair<int, byte[]>
            {
                T1 = (int)fLength,
                T2 = b
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FileStreamReader(string filePath)
        {
            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //br = new BinaryReader(fs);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (fs != null)
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();
                fs = null;
            }

            //if (br != null)
            //{
            //    br.Close();
            //    br.Dispose();
            //    br = null;
            //}
        }
    }
}
