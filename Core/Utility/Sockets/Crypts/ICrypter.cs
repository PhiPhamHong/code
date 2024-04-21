namespace Core.Utility.Sockets.Crypts
{
    public interface ICrypter
    {
        /// <summary>
        /// Tạo SessionKey
        /// </summary>
        string CreateSessionKey(byte[] messageCode);

        /// <summary>
        /// Thực hiện mã hóa
        /// </summary>
        /// <returns></returns>
        Pair<int, byte[]> Crypt(string sessionKey, byte[] data);

        /// <summary>
        /// Thực hiện giải mã
        /// </summary>
        byte[] DeCrypt(string sessionKey, byte[] messageCode, byte[] data);
    }
}
