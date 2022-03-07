using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Extentions
{
    public class NapasHelper
    {
        private const char eol1 = (char)13;
        private const char eol2 = (char)10;

        public static string DecryptCrossCheckFile(string textInput)
        {
            byte[] input = Encoding.ASCII.GetBytes(textInput);
            byte[] data;

            try
            {
                var privateKey = GetBytesFromPEM(File.ReadAllText("MobifonePayKey/Privatekeys.pem"), PemStringType.RsaPrivateKey);

                //Loại bỏ các ký tự xuống dòng vô nghĩa ở đầu file
                int i = 0, s = 0;
                while (((char)input[i] == eol1) || ((char)input[i] == eol2))
                    i++;
                s = i;
                //Tìm đến ký tự xuống dòng để cắt chuỗi
                while ((eol1 != (char)input[i]) && (eol2 != (char)input[i]))
                    i++;
                //Cắt lấy phần khóa phiên được mã hóa và encode
                byte[] base64EncSessionKey = CopyOfRange(input, s, i);
                //Loại bỏ các ký tự xuống dòng vô nghĩa ở giữa file
                while (((char)input[i] == eol1) || ((char)input[i] == eol2))
                    i++;
                int len = input.Length;
                //Loại bỏ các ký tự xuống dòng vô nghĩa ở cuối file
                while (((char)input[len - 1] == eol1) || ((char)input[len - 1] == eol2))
                    len--;

                //Cắt lấy phần dữ liệu đã mã hóa và encode
                byte[] base64EncData = CopyOfRange(input, i, len);
                //Decode base64 khóa và dữ liệu
                byte[] encSessionKey = Convert.FromBase64String(Encoding.ASCII.GetString(base64EncSessionKey));
                byte[] decData = Convert.FromBase64String(Encoding.ASCII.GetString(base64EncData));

                //Giải mã khóa phiên sử dụng private key
                byte[] sessionKeyByte = DecryptRSA(encSessionKey, privateKey);

                //Giải mã dữ liệu sử dụng khóa phiên lấy được trong bước trước
                data = AesHelper.Decrypt(decData, sessionKeyByte);
            }
            catch (Exception ex)
            {
                return "";
            }

            return Encoding.ASCII.GetString(data);
        }

        public static string EncryptCrossCheckFile(string textInput, bool IsNapasPublicKey = false)
        {
            byte[] input = Encoding.ASCII.GetBytes(textInput);

            try
            {
                byte[] certificate;

                if (IsNapasPublicKey)
                {
                    certificate = GetBytesFromPEM(File.ReadAllText("NapasKey/Publickey.cer"), PemStringType.Certificate);
                }
                else
                {
                    certificate = GetBytesFromPEM(File.ReadAllText("MobifonePayKey/Publickey.cer"), PemStringType.Certificate);
                }

                //Sinh khóa phiên ngẫu nhiên sử dụng thuật toán AES-128-EBC
                var sessionKey = CreateAesKey();

                //Mã hóa dữ liệu sử dụng khóa phiên đối xứng AES
                byte[] encData = AesHelper.Encrypt(input, sessionKey);

                //Mã hóa khóa phiên sử dụng thuật toán mã hóa bất đối xứng RSA với public key.
                byte[] encSessionKey = EncryptRSA(sessionKey, certificate);

                //Encode base64 khóa phiên và dữ liệu sau khi được mã hóa
                string base64EncData = Convert.ToBase64String(encData);
                string base64EncSessionKey = Convert.ToBase64String(encSessionKey)
                    .Replace("\n","")
                    .Replace("\r","")
                    .Replace("\r\n","")
                    .Replace("\n\r","");

                return base64EncSessionKey + eol1 + eol2 + base64EncData;
            }
            catch (Exception ex)
            {
            }

            return "";
        }

        public static byte[] CopyOfRange(byte[] src, int start, int end)
        {
            int len = end - start;
            byte[] dest = new byte[len];
            Array.Copy(src, start, dest, 0, len);
            return dest;
        }

        private static byte[] DecryptRSA(byte[] text, byte[] privateKey)
        {
            using (var RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportRSAPrivateKey(privateKey, out _);
                return RSA.Decrypt(text, false);
            }

            throw new Exception("DecryptRSA fail");
        }

        //public static byte[] DecryptAES(byte[] text, byte[] sessionKeyByte)
        //{
        //    var tdes = new AesManaged();
        //    tdes.Key = sessionKeyByte;
        //    tdes.Mode = CipherMode.ECB;
        //    tdes.Padding = PaddingMode.None;
        //    ICryptoTransform crypt = tdes.CreateDecryptor();
        //    byte[] plain = text;
        //    return crypt.TransformFinalBlock(plain, 0, plain.Length);
        //}

        private static byte[] EncryptRSA(byte[] text, byte[] certificate)
        {
            var x509Certificate2 = new X509Certificate2(certificate);
            var publicKey = x509Certificate2.GetPublicKey();

            using (var RSA2 = new RSACryptoServiceProvider())
            {
                RSA2.ImportRSAPublicKey(publicKey, out _);
                return RSA2.Encrypt(text, false);
            }

            throw new Exception("EncryptRSA fail");
        }

        //public static byte[] EncryptAES(byte[] text, byte[] sessionKeyByte)
        //{
        //    var tdes = new AesManaged();
        //    tdes.Key = sessionKeyByte;
        //    tdes.Mode = CipherMode.ECB;
        //    tdes.Padding = PaddingMode.None;
        //    ICryptoTransform crypt = tdes.CreateEncryptor();
        //    byte[] plain = text;
        //    return crypt.TransformFinalBlock(plain, 0, plain.Length);
        //}

        private static byte[] CreateAesKey()
        {
            var crypto = new AesCryptoServiceProvider();
            crypto.KeySize = 128;
            crypto.BlockSize = 128;
            crypto.GenerateKey();
            return crypto.Key;
        }

        public static string Md5(string s)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(s);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes).ToLower().Replace("-", "");
        }

        public static byte[] GetBytesFromPEM(string pemString, PemStringType type)
        {
            string header; string footer;

            switch (type)
            {
                case PemStringType.Certificate:
                    header = "-----BEGIN CERTIFICATE-----";
                    footer = "-----END CERTIFICATE-----";
                    break;
                case PemStringType.RsaPrivateKey:
                    header = "-----BEGIN RSA PRIVATE KEY-----";
                    footer = "-----END RSA PRIVATE KEY-----";
                    break;
                default:
                    return null;
            }

            int start = pemString.IndexOf(header) + header.Length;
            int end = pemString.IndexOf(footer, start) - start;
            return Convert.FromBase64String(pemString.Substring(start, end));
        }

        public static string CheckSumNapas(string input)
        {
            string MaBM = "971032";
            string str = "";
            string strMa = Md5(input);
            string strKQ = strMa;
            MaBM = "5" + MaBM + "5";
            if (int.TryParse(MaBM, out _))
            {
                //Ma bi mat la so
                char[] chars = MaBM.ToCharArray();
                for (int i = 0; i < chars.Length - 1; i++)
                {
                    str = str + strMa.Substring(Convert.ToInt16(chars[i].ToString()), 20 - Convert.ToInt16(chars[i + 1].ToString()));
                }
                strKQ = Md5(str);
            }

            return strKQ;
        }
    }

    public enum PemStringType
    {
        Certificate,
        RsaPrivateKey
    }
}
