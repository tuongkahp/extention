using System;
using System.Security.Cryptography;
using System.Text;

namespace Extentions
{
    public static class DesSecurity
    {
        public static string IRIS_decrypt(string softpinKey, string encryptedSoftpin)
        {
            return IMedia_decrypt(softpinKey, encryptedSoftpin);
        }

        public static string IRIS_encrypt(string softpinKey, string softpin)
        {
            return IMedia_encrypt(softpinKey, softpin);
        }

        #region IMedia
        public static string IMedia_decrypt(string softpinKey, string encryptedSoftpin)
        {
            var bytKey = GetValidKey(softpinKey);
            TripleDES des = new TripleDESCryptoServiceProvider
            {
                Mode = CipherMode.CBC,
                Key = bytKey,
                Padding = PaddingMode.PKCS7,
                IV = GetValidIV(softpinKey, 8)
            };

            var buffer = Convert.FromBase64String(encryptedSoftpin);
            var re = des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length);
            var str = Encoding.ASCII.GetString(re, 0, re.Length);
            return str;
        }

        public static string IMedia_encrypt(string softpinKey, string softpin)
        {
            var bytKey = GetValidKey(softpinKey);
            TripleDES des = new TripleDESCryptoServiceProvider
            {
                Mode = CipherMode.CBC,
                Key = bytKey,
                Padding = PaddingMode.PKCS7,
                IV = GetValidIV(softpinKey, 8)
            };

            var buffer = Encoding.ASCII.GetBytes(softpin);
            var re = des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length);
            var str = Convert.ToBase64String(re); //Encoding.ASCII.GetString(re, 0, re.Length);
            return str;
        }

        private static byte[] GetValidKey(string key)
        {
            string sTemp;
            if (key.Length > 24)
            {
                sTemp = key.Substring(0, 24);
            }
            else
            {
                sTemp = key;
                while (sTemp.Length != 24) sTemp = sTemp + ' ';
            }

            return Encoding.ASCII.GetBytes(sTemp);
        }

        private static byte[] GetValidIV(string initVector, int validLength)
        {
            string sTemp;
            if (initVector.Length > validLength)
            {
                sTemp = initVector.Substring(0, validLength);
            }
            else
            {
                sTemp = initVector;
                while (sTemp.Length != validLength) sTemp += ' ';
            }
            return Encoding.ASCII.GetBytes(sTemp);
        }

        #endregion
    }
}
