using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

namespace RuRuServer.Extensions;

public static class CryptoExtensions
{
    public static string Sign(this string text)
    {
        Console.WriteLine(" ");
        string certPath = "C:\\Certs\\digitalspb\\digitalspb.pfx";
        var certificate = new X509Certificate2(certPath, "letmein", X509KeyStorageFlags.Exportable);
        var rsa = certificate.GetRSAPrivateKey();
        RSACryptoServiceProvider rsp = new RSACryptoServiceProvider();
        rsp.ImportParameters(rsa.ExportParameters(true));
        byte[] data = Encoding.UTF8.GetBytes(text);
        byte[] signatureBytes = rsp.SignData(data, "SHA1");
        //bool isValid = rsp.VerifyData(data, "SHA1", signatureBytes);
        string signature = Convert.ToBase64String(signatureBytes);

        // replace URL unsafe characters with safe ones
        return signature.Replace('+', '-').Replace('/', '_').Replace("=", ",");
    }
}