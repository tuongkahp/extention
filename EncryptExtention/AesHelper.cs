using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Extentions
{
    public static class AesHelper
    {
        private const string aesDefaultKey = "F5DD5994F77155CA9F71356BFEF72";
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Encrypt(string data, string key = null)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            if (string.IsNullOrEmpty(key))
            {
                key = aesDefaultKey;
            }

            try
            {
                var aesCryptoProvider = new AesCryptoServiceProvider();
                var sha256hasher = new SHA256Managed();

                aesCryptoProvider.KeySize = 256;
                aesCryptoProvider.BlockSize = 128;
                aesCryptoProvider.Padding = PaddingMode.PKCS7;
                aesCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
                aesCryptoProvider.Key = sha256hasher.ComputeHash(Encoding.UTF8.GetBytes(key));
                byte[] byteData = Encoding.UTF8.GetBytes(data.Trim());

                return Convert.ToBase64String(aesCryptoProvider.CreateEncryptor().TransformFinalBlock(byteData, 0, byteData.Length));
            }
            catch
            {
                return null;
            }
        }

        public static string Decrypt(string data, string key = null)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            if (string.IsNullOrEmpty(key))
            {
                key = aesDefaultKey;
            }

            try
            {
                var aesCryptoProvider = new AesCryptoServiceProvider();
                var sha256hasher = new SHA256Managed();

                aesCryptoProvider.KeySize = 256;
                aesCryptoProvider.BlockSize = 128;
                aesCryptoProvider.Padding = PaddingMode.PKCS7;
                aesCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
                aesCryptoProvider.Key = sha256hasher.ComputeHash(Encoding.UTF8.GetBytes(key));

                byte[] byteData = Convert.FromBase64String(data.Trim());

                return Encoding.UTF8.GetString(aesCryptoProvider.CreateDecryptor().TransformFinalBlock(byteData, 0, byteData.Length));
            }
            catch
            {
                return null;
            }
        }

        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            if (data is null)
            {
                return null;
            }

            if (key is null)
            {
                return null;
            }

            try
            {
                var aesCryptoProvider = new AesCryptoServiceProvider();
                aesCryptoProvider.Padding = PaddingMode.PKCS7;
                aesCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
                aesCryptoProvider.Key = key;
                return aesCryptoProvider.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
            }
            catch
            {
                return null;
            }
        }

        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            if (data is null)
            {
                return null;
            }

            if (key is null)
            {
                return null;
            }

            try
            {
                var aesCryptoProvider = new AesCryptoServiceProvider();
                aesCryptoProvider.Padding = PaddingMode.PKCS7;
                aesCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
                aesCryptoProvider.Key = key;
                return aesCryptoProvider.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
            }
            catch
            {
                return null;
            }
        }

        public static string Encrypt2(string data, string key, string iv)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            if (string.IsNullOrEmpty(key))
            {
                key = aesDefaultKey;
            }

            try
            {
                var aesCryptoProvider = new AesCryptoServiceProvider();
                aesCryptoProvider.IV = Encoding.UTF8.GetBytes(iv);
                aesCryptoProvider.Padding = PaddingMode.PKCS7;
                aesCryptoProvider.FeedbackSize = 128;
                aesCryptoProvider.Mode = CipherMode.CBC; //CBC, CFB
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);
                byte[] byteData = Encoding.UTF8.GetBytes(data.Trim());

                return Convert.ToBase64String(aesCryptoProvider.CreateEncryptor().TransformFinalBlock(byteData, 0, byteData.Length));
            }
            catch
            {
                return null;
            }
        }

        public static string Decrypt2(string data, string key, string iv)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            if (string.IsNullOrEmpty(key))
            {
                key = aesDefaultKey;
            }

            try
            {
                var aesCryptoProvider = new AesCryptoServiceProvider();
                var sha256hasher = new SHA256Managed();

                aesCryptoProvider.IV = Encoding.UTF8.GetBytes(iv);
                aesCryptoProvider.Padding = PaddingMode.PKCS7;
                aesCryptoProvider.FeedbackSize = 128;
                aesCryptoProvider.Mode = CipherMode.CBC; //CBC, CFB
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);

                byte[] byteData = Convert.FromBase64String(data.Trim());

                return Encoding.UTF8.GetString(aesCryptoProvider.CreateDecryptor().TransformFinalBlock(byteData, 0, byteData.Length));
            }
            catch
            {
                return null;
            }
        }

        public static string DecryptStringAES(string encryptedValue, string key, string iv)
        {
            var Keybytes = Encoding.UTF8.GetBytes(key);
            var Iv = Encoding.UTF8.GetBytes(iv);
            //DECRYPT FROM CRIPTOJS
            var encrypted = Convert.FromBase64String(encryptedValue);
            var decryptedFromJavascript = DecryptStringFromBytes(encrypted, Keybytes, Iv);
            return decryptedFromJavascript;
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                return "";
            }

            if (key == null || key.Length <= 0)
            {
                return "";
            }

            if (iv == null || iv.Length <= 0)
            {
                return "";
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = "";
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static KeyIvViewModel GetRandomKey()
        {
            var key = new KeyIvViewModel();

            key.key = new string(Enumerable.Repeat(chars, 16)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

            key.iv = new string(Enumerable.Repeat(chars, 16)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

            return key;
        }
    }

    public class KeyIvViewModel
    {
        public string key { get; set; }
        public string iv { get; set; }
    }
}