using System;
namespace Core.Utility
{
    public class Keygend
    {
        /// <summary>
        /// Ngăn không cho khởi tạo CenterSecurity
        /// </summary>
        private Keygend() { }

        private static Keygend inst = new Keygend();
        /// <summary>
        /// Khởi tạo một instance duy nhất để sử dụng
        /// </summary>
        public static Keygend Inst
        {
            get { return inst; }
        }

        /// <summary>
        /// Private Key
        /// </summary>
        private string privateKey = "<RSAKeyValue><Modulus>uhhwLgXWDxlRuMAvpexfaa3tfu6LUpY+OAlA7OMpefbN6cyT/G2s09MpfU8UlJwcZKtXB2BhJ7EjNDYJ+Sw8Lu5zx4ZRNlwO07xupeMWaVezcv9zut79OEfjc0GAIU2rOxp/wjuM1JFJn0Qd63/pbqOpwZHkmd/I2w873/4M1FM=</Modulus><Exponent>AQAB</Exponent><P>3/jMMWK8QAc137Swb/nuMgemyfd+1MqJFFTxQKMugxrOmO0Wo+fOakAB10JAc3BHATC4B/DGgcouUpqkkBk58Q==</P><Q>1LUN6nPdGYCZkmm/6IZLh3ulzV0z3jQAGu3xarB2kZwknCouerd34yyBfzENIfVqByoCb3qzZJtAxO/IvokOgw==</Q><DP>QcUAyVvSJgc4Bco8qZU+Ikjm7JYWE4yqNmM/ORjyNqOvmW694EHY9pB3OewFmyCUaUASOpq04DYr5ivtOTd/MQ==</DP><DQ>neEVRyRgxAET+/zKGMk1XoaEdn3rdc6bFWHvgwUfvMxs0AzvGt76+X+bTtEVslL6M/8Wd7BXXyFtXb+s/N+2CQ==</DQ><InverseQ>GNziJpJnzfnQtOeG7DBnZg5x8qRCVvoTXt/waKhIcGX1FR3D90E6/wTUB8ra+YyNUvZvyKqzXh8YMPiqg9mv+w==</InverseQ><D>eAN0rSmUYA5rFqPS1sW2zredV2PNtAgyvf6xwVPKlt5k82e89GlisQUYV7jdQ+3dncqmCJrObUOeuXg0PF6bvGrqy28E/ib4Hfsy+SSUMMdqtAooISQGTrOqMTS4IbC1UXyQQ0eZqEr52J4Qj2EDbw8vCxy2irlRtfp6lMSuCOE=</D></RSAKeyValue>";

        /// <summary>
        /// Public Key
        /// </summary>
        private string publicKey = "<RSAKeyValue><Modulus>uhhwLgXWDxlRuMAvpexfaa3tfu6LUpY+OAlA7OMpefbN6cyT/G2s09MpfU8UlJwcZKtXB2BhJ7EjNDYJ+Sw8Lu5zx4ZRNlwO07xupeMWaVezcv9zut79OEfjc0GAIU2rOxp/wjuM1JFJn0Qd63/pbqOpwZHkmd/I2w873/4M1FM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        private int keySize = 1024;

        /// <summary>
        /// Các ký tự được phép của một key
        /// </summary>
        private static string KEYLIB = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        static readonly Random ran = new Random();
        public static string RenderKeyRandom(int length = 20)
        {
            return RenderKeyRandomHelper(KEYLIB, length);
        }

        private static string KEYLIB_New = "abcdefghijklmnopqrstuvwxyz0123456789";
        public static string RenderKeyRandom_New(int length = 10)
        {
            return RenderKeyRandomHelper(KEYLIB_New, length);
        }

        public static string RenderKeyRandomHelper(string lib, int length)
        {
            int len = lib.Length;
            string retKey = string.Empty;
            while (retKey.Length < length) retKey += lib[ran.Next(0, len - 1)];
            return retKey;
        }

        /// <summary>
        /// Thực hiện mã hóa dữ liệu
        /// Trả về ShKeyValue gồm Key = Key đã được mã hóa, Value = data đã được mã hóa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Pair<string, string> AbcXyz(string data)
        {
            // Tạo một chuỗi Key random
            var keyRandom = RenderKeyRandom();

            // 
            return AbcXyz(data, keyRandom);
        }
        public Pair<string, string> AbcXyz(string abcabc, string sss)
        {
            // Thực hiện mã hóa keyRandom
            var keyRandomEnCrypt = Cryptography.EnCryptByRSA(sss, keySize, publicKey);

            // Thực hiện mã hóa dữ liệu
            var dataEnCrypt = Cryptography.EncryptDataByTripleDES(abcabc, sss);

            // return kết quả
            return new Pair<string, string> { T1 = keyRandomEnCrypt, T2 = dataEnCrypt };
        }

        public string Zyxcba(Pair<string, string> data)
        {
            return Zyxcba(data.T1, data.T2);
        }
        public string Zyxcba(string aaa, string bbb)
        {
            // giải mã key 
            var keyRandomDeCrypt = Cryptography.DeCryptByRSA(aaa, keySize, privateKey);

            // Trả ra kết quả giải mã data
            return Cryptography.DecryptDataByTripleDES(bbb, keyRandomDeCrypt);
        }
    }
}
