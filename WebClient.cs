using Newtonsoft.Json;
using RuRuServer.Base;
using RuRuServer.Models;
using System.Net;

namespace RuRuServer;

public class WebClient
{
    private string url = "http://localhost:53902/SubscriptionNotificationHandler.ashx";

    public WebClient(string url)
    {
        this.url = url;
    }


    public DataModel ProcessRequest(DataModel model)
    {
        try
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(model.Input);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream stream = response.GetResponseStream();

                using (var streamReader = new StreamReader(stream))
                {
                    model.Output = streamReader.ReadToEnd();
                }
            }

            if (string.IsNullOrEmpty(model.Output))
            {
                Console.WriteLine("Response is NULL");
            }
            else
            {
                Console.WriteLine("Response: {0}", model.Output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            model.Output = ex.Message;
        }

        return model;
    }
}
