using Core.Utility.Sockets.Crypts;
using System;
using System.Collections.Generic;
using Core.Extensions;
namespace Core.Utility.Sockets
{
    public abstract class Protocol
    {
        public abstract IEnumerable<byte[]> Split(byte[] data); // Phân tách bản tin nhận được khi thiết bị gửi
        public abstract bool ValidChecksum(byte[] packet);
        public abstract IProtocolContent CreateProtocolContent(byte[] packet);
        public abstract byte[] CreatePacket(ICommandInfo commandInfo, ICrypter crypter, string sessionKey);
    }

    public interface IProtocolContent
    {
        ICrypter Crypter { set; get; }
        string SessionKey { set; get; }

        short Id { get; }
        byte[] Code { get; }
        DateTime Date { get; }

        void Deserialize(ICommandInfo commandInfo);
    }

    // Ví dụ cái Protocol cũ của staxi
    // Tôi luôn tôn trọng lịch sử
    public class StaxiProtocol : Protocol
    {
        private static byte[] HeaderIndicator = { Convert.ToByte('$'), Convert.ToByte('D'), Convert.ToByte('A'), Convert.ToByte('T'), Convert.ToByte('A') };
        public override byte[] CreatePacket(ICommandInfo commandInfo, ICrypter crypter, string sessionKey)
        {
            var data = commandInfo.Serialize();

            // Thực hiện mã hóa data
            var pair = crypter.Crypt(sessionKey, data);
            var messageCode = BitConverter.GetBytes(pair.T1);

            var dataCrypted = pair.T2 ?? new byte[0];
            return MessageProtocol.GenerateMessage(commandInfo.CommandType, messageCode, dataCrypted);            
        }

        public override IProtocolContent CreateProtocolContent(byte[] packet) { return new Content(packet); }
        public override IEnumerable<byte[]> Split(byte[] data) { return data.Split(HeaderIndicator); }
        public override bool ValidChecksum(byte[] packet)
        {
            if (packet.Length < 24) return false;
            int tmpCheckSum = 0;
            for (int i = 0; i < packet.Length - 1; i++) tmpCheckSum += packet[i];
            tmpCheckSum = tmpCheckSum & 0xFF;
            if (tmpCheckSum != packet[packet.Length - 1]) return false;
            return true;
        }

        public class Content : IProtocolContent
        {
            public Content(byte[] packet)
            {
                Id = BinaryLibrary.GetShortFromBytes(packet[17], packet[18]);
                Code = MessageProtocol.GetMsgCodeFromMessage(packet);
                Date = MessageProtocol.GetDateTimeFromLong(packet, 9);
                dataCryted = MessageProtocol.GetDataContentFromMessage(packet);
            }

            private byte[] dataCryted = null;

            public byte[] Code { protected set; get; }
            public ICrypter Crypter { set; get; }
            public DateTime Date { protected set; get; }
            public short Id { protected set; get; }
            public string SessionKey { set; get; }

            public void Deserialize(ICommandInfo commandInfo)
            {
                var data = Crypter.DeCrypt(SessionKey, Code, dataCryted) ?? new byte[0];
                ObjectExtension.Deserialize(data, commandInfo);
            }
        }
    }
}