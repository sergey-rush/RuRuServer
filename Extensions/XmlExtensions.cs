using System.Xml.Serialization;
using System.Xml;

namespace RuRuServer.Extensions;

public static class XmlExtensions
{
    public static T? FromXml<T>(this string xmlString)
    {
        T? returnValue = default(T);

        XmlSerializer serial = new XmlSerializer(typeof(T));
        using StringReader reader = new StringReader(xmlString);
        object? result = serial.Deserialize(reader);
        if (result is T output)
        {
            returnValue = output;
        }
        return returnValue;
    }

    public static string ToXml<T>(this T value)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("\t");
            settings.OmitXmlDeclaration = false;
            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(writer, value);
            }

            return stringWriter.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while calling ToXml method", ex);
        }
    }
}