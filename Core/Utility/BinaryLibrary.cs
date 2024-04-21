using System;
using System.Collections.Generic;
using Core.Extensions;
namespace Core.Utility
{
    public class BinaryLibrary
    {
        public static int GetInt32(byte[] inputData, int index)
        {
            return inputData[index] + inputData[index + 1] * 256 + inputData[index + 2] * 65536 + inputData[index + 3] * 16777216;
        }
        public static long GetLong(byte[] inputData, int index)
        {
            return BitConverter.ToInt64(inputData, index);
        }

        public static void PushShortIntoBytesArray(byte[] src, short value, int offset)
        {
            src[offset] = (byte)(value & 0xff);
            src[offset + 1] = (byte)((value & 0xff00) >> 8);
        }

        public static byte[] GetBytesFromShort(short value)
        {
            return new byte[] { (byte)(value & 0xff), (byte)((value & 0xff00) >> 8) };
        }

        public static short GetShortFromBytes(byte firstByte, byte secondByte)
        {
            return (short)(((secondByte << 8) & 0xff00) | (firstByte & 0xff));
        }

        public static void PushIntToArray(byte[] dest, int value, int offset)
        {
            byte[] valueArr = BitConverter.GetBytes(value);
            PushArrayInToArray(valueArr, dest, offset);
        }
        public static void PushArrayInToArray(byte[] src, byte[] dest, int offset)
        {
            for (int i = 0; i < src.Length; i++)
            {
                dest[offset + i] = src[i];
            }
        }
    }

    public class MessageProtocol
    {
        private static byte[] HeaderIndicator = { Convert.ToByte('$'), Convert.ToByte('D'), Convert.ToByte('A'), Convert.ToByte('T'), Convert.ToByte('A') };

        /// <summary>
        /// Tạo ra bản tin
        /// </summary>
        public static byte[] GenerateMessage(Int16 MessageID, byte[] messageCode, byte[] data)
        {
            // Độ dài bản tin
            int length = 24 + data.Length;
            // Khởi tạo mảng byte
            byte[] msg = new byte[length];

            BinaryLibrary.PushArrayInToArray(HeaderIndicator, msg, 0);  // Header 
            BinaryLibrary.PushArrayInToArray(messageCode, msg, 5);      // MessageCode 4byte
            // TimeStamp
            long timeStamp = DateTime.Now.GetLongFromDateTime();
            byte[] longBytes = BitConverter.GetBytes(timeStamp);
            BinaryLibrary.PushArrayInToArray(longBytes, msg, 9);

            BinaryLibrary.PushShortIntoBytesArray(msg, MessageID, 17);  // ID bản tin            
            BinaryLibrary.PushIntToArray(msg, data.Length, 19);         // độ dài bản tin       => 23 nội dung bản tin phải từ 24     
            BinaryLibrary.PushArrayInToArray(data, msg, 23);            // Nội dung bản tin            
            PushCheckSum(ref msg);                                      // Tính checksum
            return msg;
        }

        public static IEnumerable<byte[]> Split(byte[] data)
        {
            return data.Split(HeaderIndicator);
        }

        private static void PushCheckSum(ref byte[] byteArr)
        {
            int checkSum = 0;
            for (int i = 0; i < byteArr.Length - 1; i++)
            {
                checkSum += byteArr[i];
            }
            byteArr[byteArr.Length - 1] = (byte)(checkSum & 0xFF);
        }

        public static bool ValidChecksum(byte[] listData)
        {
            if (listData.Length < 24) return false;

            int tmpCheckSum = 0;
            for (int i = 0; i < listData.Length - 1; i++)
            {
                tmpCheckSum += listData[i];
            }

            tmpCheckSum = tmpCheckSum & 0xFF;

            if (tmpCheckSum != listData[listData.Length - 1])
                return false;

            return true;
        }

        /// <summary>
        /// Lấy phần nội dung bản tin
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] GetDataContentFromMessage(byte[] msg)
        {
            byte[] data = new byte[msg.Length - 24];
            for (int i = 23; i < msg.Length - 1; i++)
            {
                data[i - 23] = msg[i];
            }
            return data;
        }

        /// <summary>
        /// Lấy phần nội dung bản tinr
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] GetMsgCodeFromMessage(byte[] msg)
        {
            byte[] data = new byte[4];
            for (int i = 5; i <= 8; i++)
            {
                data[i - 5] = msg[i];
            }
            return data;
        }

        public static DateTime GetDateTimeFromLong(byte[] msg, int index)
        {
            return BinaryLibrary.GetLong(msg, index).GetDateTimeFromLong();
        }
    }
}
