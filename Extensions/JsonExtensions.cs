using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RuRuServer.Extensions;

public static class JsonExtensions
{
    public static string ToJson(this object? value)
    {
        if (value == null)
        {
            return string.Empty;
        }
        try
        {

            return JsonConvert.SerializeObject(value);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("An error occurred ToJson", ex);
        }
    }

    public static T? FromJson<T>(this string value)
    {
        T? output = default(T);
        if (string.IsNullOrEmpty(value))
        {
            return output;
        }

        try
        {
            output = JsonConvert.DeserializeObject<T>(value);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception("An error occurred FromJson", ex);
        }

        return output;
        
    }
}
