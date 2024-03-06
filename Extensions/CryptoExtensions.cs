using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace RuRuServer.Extensions;

public static class CryptoExtensions
{
    public static byte[] Sign(this string text)
    {
        string certPath = "C:\\Certs\\digitalspb\\digitalspb.pfx";
        var certificate = new X509Certificate2(certPath, "letmein", X509KeyStorageFlags.Exportable);
        var rsa = certificate.GetRSAPrivateKey();
        RSACryptoServiceProvider rsp = new RSACryptoServiceProvider();
        rsp.ImportParameters(rsa.ExportParameters(true));
        byte[] data = Encoding.UTF8.GetBytes(text);
        byte[] signatureBytes = rsp.SignData(data, "SHA1");
        //bool isValid = rsp.VerifyData(data, "SHA1", signatureBytes);
        return signatureBytes;
    }
}