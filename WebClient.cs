using Newtonsoft.Json;
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


    public string ProcessRequest(Notification notification)
    {
        string stringResponse = null;

        try
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(notification);
                sw.Write(json);
            }
            

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream stream = response.GetResponseStream();

                using (var streamReader = new StreamReader(stream))
                {
                    stringResponse = streamReader.ReadToEnd();
                }
            }

            if (string.IsNullOrEmpty(stringResponse))
            {
                Console.WriteLine("Response is NULL");
            }
            else
            {
                Console.WriteLine("Response: {0}", stringResponse);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            stringResponse = ex.Message;
        }

        return stringResponse;
    }
}
