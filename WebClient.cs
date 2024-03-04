using Newtonsoft.Json;
using RuRuServer.Base;
using RuRuServer.Models;
using System.Net;
using System.Net.Cache;

namespace RuRuServer;

public class WebClient
{
    private string contentType = "application/json";
    private string url = "http://localhost:53902/SubscriptionNotificationHandler.ashx";

    public WebClient(string url, string contentType)
    {
        this.url = url;
        this.contentType = contentType;
    }

    public string ProcessRequest(HttpMethod method, string input)
    {
        //ServicePointManager.Expect100Continue = true;
        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.ContentType = request.Accept = contentType;
            request.UserAgent = "+https://i-free.com/;";
            request.AllowAutoRedirect = true;
            request.Timeout = 60000;
            request.Method = method.ToString();

            if (!string.IsNullOrEmpty(input))
            {
                using var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(input);
            }

            using var httpResponse = (HttpWebResponse)request.GetResponse();
            var stream = httpResponse.GetResponseStream();
            using var streamReader = new StreamReader(stream);
            string response = streamReader.ReadToEnd();
            return response;
        }
        catch (WebException we)
        {
            return we.Message;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }


    //public DataModel ProcessRequest(DataModel model, HttpMethod method)
    //{
    //    try
    //    {
    //        var request = WebRequest.Create(url);
    //        request.Method = method.ToString();
    //        request.ContentType = "application/json";
    //        using (var sw = new StreamWriter(request.GetRequestStream()))
    //        {
    //            sw.Write(model.Input);
    //        }

    //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    //        {
    //            Stream stream = response.GetResponseStream();

    //            using (var streamReader = new StreamReader(stream))
    //            {
    //                model.Output = streamReader.ReadToEnd();
    //            }
    //        }

    //        if (string.IsNullOrEmpty(model.Output))
    //        {
    //            Console.WriteLine("Response is NULL");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Response: {0}", model.Output);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex);
    //        model.Output = ex.Message;
    //    }

    //    return model;
    //}
}
