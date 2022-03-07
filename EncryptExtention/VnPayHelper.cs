using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Extentions
{
    public class VnPayHelper
    {
        public static string CreateSignRSA(string data)
        {
            string privateKey = File.ReadAllText("VnPayKey/MBF_VnPay_PrivateKey.xml");
            CspParameters _cpsParameter;
            RSACryptoServiceProvider rsaCryptoIPT;
            _cpsParameter = new CspParameters();
            _cpsParameter.Flags = CspProviderFlags.UseMachineKeyStore;
            rsaCryptoIPT = new RSACryptoServiceProvider(1024, _cpsParameter);

            rsaCryptoIPT.FromXmlString(privateKey);
            return Convert.ToBase64String(rsaCryptoIPT.SignData(new ASCIIEncoding().GetBytes(data), new SHA1CryptoServiceProvider()));
        }
    }
}
