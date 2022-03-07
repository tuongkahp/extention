using Extentions;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptExtention
{
    public class RsaAes
    {
        public static string ProcessDataEncryption(string data)
        {
            var requestModel = new RequestModel();

            try
            {
                var keyIvViewModel = AesHelper.GetRandomKey();
                requestModel.ObjKey = RSAHandler.Encrypt(JsonHelper.Serialize(keyIvViewModel));
                requestModel.Data = AesHelper.Encrypt2(data, keyIvViewModel.key, keyIvViewModel.iv);

                return JsonHelper.Serialize(requestModel);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                return null;
            }
        }

        public static string ProcessDataDecryption(string data)
        {
            try
            {
                var requestModel = JsonHelper.Deserialize<RequestModel>(data);
                var requestDecrypt = RSAHandler.Decrypt(requestModel.ObjKey);
                var requestInput = JsonHelper.Deserialize<KeyIvViewModel>(requestDecrypt);

                if (requestInput == null)
                {
                    return null;
                }

                return AesHelper.DecryptStringAES(requestModel.Data, requestInput.key, requestInput.iv);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                return null;
            }
        }
    }

    public class RSAHandler
    {
        public static string Encrypt(string text)
        {
            var _publicKey = GetPublicKeyFromPemFileAsync(@".\RsaAesKeys\posvendor.pub.pem");

            try
            {
                var encryptedBytes = _publicKey.Encrypt(Encoding.UTF8.GetBytes(text), false);
                return Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception ex)
            {
                var err = ex.StackTrace;
                throw new Exception("fail");
            }
        }

        public static string Decrypt(string encrypted)
        {
            var _privateKey = GetPrivateKeyFromPemFileAsync(@".\RsaAesKeys\posvendor.key.pem");
            var decryptedBytes = _privateKey.Decrypt(Convert.FromBase64String(encrypted), false);
            return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
        }

        private static RSACryptoServiceProvider GetPrivateKeyFromPemFileAsync(string filePath)
        {
            using TextReader privateKeyTextReader = new StringReader(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath)));
            AsymmetricCipherKeyPair readKeyPair = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)readKeyPair.Private);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);
            return csp;
        }

        private static RSACryptoServiceProvider GetPublicKeyFromPemFileAsync(string filePath)
        {
            using TextReader publicKeyTextReader = new StringReader(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath)));
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)new PemReader(publicKeyTextReader).ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParam);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);
            return csp;
        }
    }

    public class RequestModel
    {
        public string ObjKey { get; set; }
        public string Data { get; set; }
    }
}
