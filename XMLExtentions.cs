using System.Text;
using System.Xml.Serialization;

namespace RuRuServer
{
    public static class XMLExtensions
    {
        public static string ToXML<T>(this T objectInstance)
        {
            var serializer = new XmlSerializer(typeof(T));
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }

        public static T FromXML<T>(this string objectData)
        {
            var serializer = new XmlSerializer(typeof(T));
            using TextReader reader = new StringReader(objectData);
            return (T)serializer.Deserialize(reader);
        }
    }
}
