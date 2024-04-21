using System;
using System.Collections.Generic;
namespace Core.Extensions
{
    public static class ArrayExtender
    {
        public static T[] SubArray<T>(this T[] array, int start, int length)
        {
            var copy = new T[length];
            Array.Copy(array, start, copy, 0, length);
            return copy;
        }

        public static void AppendTo<T>(this T[] bytes, ref T[] array)
        {
            var oldLength = array.Length;
            Array.Resize(ref array, oldLength + bytes.Length);
            Array.Copy(bytes, 0, array, oldLength, bytes.Length);
        }

        public static int IndexOfListByte(this byte[] bytes, byte[] pattern, int startIndex)
        {
            if (pattern.Length > bytes.Length - 1) return -1;

            for (int i = startIndex; i < bytes.Length; i++)
            {
                if (pattern[0] == bytes[i] && bytes.Length - i >= pattern.Length)
                {
                    bool ismatch = true;
                    for (int j = 1; j < pattern.Length; j++)
                    {
                        if (bytes[i + j] != pattern[j])
                        {
                            ismatch = false;
                            break;
                        }
                    }
                    if (ismatch)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static IEnumerable<byte[]> Split(this byte[] data, byte[] headerIndicator)
        {
            int startIndex = 0;

            while (true)
            {
                int header = data.IndexOfListByte(headerIndicator, startIndex);
                if (header == -1) break;

                int nextHeader = data.IndexOfListByte(headerIndicator, header + headerIndicator.Length);
                if (nextHeader == -1)
                {
                    yield return data.SubArray(header, data.Length - header);
                    break;
                }

                if (header >= 0 && nextHeader > 0)
                {
                    yield return data.SubArray(header, nextHeader - header);
                }

                if (nextHeader < header) break;
                startIndex = nextHeader;
            }
        }
    }
}
