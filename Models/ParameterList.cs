using System.Xml.Serialization;

namespace RuRuServer.Models
{
    [Serializable]
    [XmlRoot(ElementName = "ArrayOfParameter", Namespace = "", IsNullable = true)]
    public class ParameterList
    {
        [XmlElement("Parameter")]
        public List<ParameterItem> ParameterItems { get; set; } = new();
    }

    public class ParameterItem
    {
        public string? Name { get; set; }
        public int Value { get; set; }
    }
}
