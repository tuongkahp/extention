using System;
using System.Security.Cryptography;
using System.Text;

namespace Extentions
{
    public static class TrippleDesHelper
    {
        private const string desDefaultKey = "b10a2a4a3d1733da";

        public static string Encrypt(string input, string key = null, CipherMode cipherMode = CipherMode.ECB)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (string.IsNullOrEmpty(key))
            {
                key = desDefaultKey;
            }

            try
            {
                var cipher = new TripleDESCryptoServiceProvider();
                cipher.Key = Encoding.ASCII.GetBytes(key);
                cipher.Mode = cipherMode;
                cipher.Padding = PaddingMode.PKCS7;
                byte[] data = Encoding.ASCII.GetBytes(input);
                return Convert.ToBase64String(cipher.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
            }
            catch
            {
                return null;
            }
        }

        public static string Decrypt(string input, string key = null, CipherMode cipherMode = CipherMode.ECB)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (string.IsNullOrEmpty(key))
            {
                key = desDefaultKey;
            }

            try
            {
                var data = Convert.FromBase64String(input);
                var tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = cipherMode;
                tripleDES.Padding = PaddingMode.PKCS7;
                return Encoding.UTF8.GetString(tripleDES.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
            }
            catch
            {
                return null;
            }
        }
    }
}