using System;
using System.IO;
using System.IO.Compression;

namespace Core.Utility
{
    public interface ICompressor
    {
        string Compress(byte[] bytes);
        byte[] Decompress(string value);
    }

    public class Compressor : ICompressor
    {
        public string Compress(byte[] bytes)
        {
            byte[] compressedBytes;
            using (var uncompressedStream = new MemoryStream(bytes))
            {
                using (var compressedStream = new MemoryStream())
                {
                    // setting the leaveOpen parameter to true to ensure that compressedStream will not be closed when compressorStream is disposed
                    // this allows compressorStream to close and flush its buffers to compressedStream and guarantees that compressedStream.ToArray() can be called afterward
                    // although MSDN documentation states that ToArray() can be called on a closed MemoryStream, I don't want to rely on that very odd behavior should it ever change
                    using (var compressorStream = new DeflateStream(compressedStream, CompressionLevel.Fastest, true))
                    {
                        uncompressedStream.CopyTo(compressorStream);
                    }

                    // call compressedStream.ToArray() after the enclosing DeflateStream has closed and flushed its buffer to compressedStream
                    compressedBytes = compressedStream.ToArray();
                }
            }
            return Convert.ToBase64String(compressedBytes);
        }

        public byte[] Decompress(string value)
        {
            byte[] decompressedBytes;

            var compressedStream = new MemoryStream(Convert.FromBase64String(value));
            using (var decompressorStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
            {
                using (var decompressedStream = new MemoryStream())
                {
                    decompressorStream.CopyTo(decompressedStream);

                    decompressedBytes = decompressedStream.ToArray();
                }
            }
            return decompressedBytes;
        }
    }

    public class CompressorBase64 : ICompressor
    {
        public string Compress(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public byte[] Decompress(string value)
        {
            return Convert.FromBase64String(value);
        }
    }
}