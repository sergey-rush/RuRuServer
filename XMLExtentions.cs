using System.Xml;
using System.Xml.Serialization;

namespace RuRuServer;
public static class XMLExtensions
{
    public static string ToXML<T>(this T value)
    {
        if (value == null)
        {
            return string.Empty;
        }
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using var writer = XmlWriter.Create(stringWriter);
            xmlSerializer.Serialize(writer, value);
            return stringWriter.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred ToXML: {ex.Message}");
        }
        return string.Empty;
    }

    public static T? FromXML<T>(this string value)
    {
        T? output = default(T);
        if (string.IsNullOrEmpty(value))
        {
            return output;
        }

        
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            output = (T?)xmlSerializer.Deserialize(new StringReader(value));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred FromXML: {ex.Message}");
        }

        return output;
    }
}