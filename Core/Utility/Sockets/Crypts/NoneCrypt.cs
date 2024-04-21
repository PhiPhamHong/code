namespace Core.Utility.Sockets.Crypts
{
    public class NoneCrypt : ICrypter
    {
        public string CreateSessionKey(byte[] messageCode)
        {
            return string.Empty;
        }

        public Pair<int, byte[]> Crypt(string sessionKey, byte[] data)
        {
            return new Pair<int, byte[]> { T1 = 1234, T2 = data };
        }

        public byte[] DeCrypt(string sessionKey, byte[] messageCode, byte[] data)
        {
            return data;
        }
    }
}