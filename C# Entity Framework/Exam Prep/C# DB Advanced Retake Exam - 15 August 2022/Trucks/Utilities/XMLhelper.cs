using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.Utilities
{
    public class XMLhelper
    {
        public T Deserialize<T>(string rootElement, string xmlInput)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootElement);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            StringReader reader = new StringReader(xmlInput);
            T commonDtos = (T)serializer.Deserialize(reader);
            return commonDtos;
        }

        public string Serialize<T>(string rootElement, T obj)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute(rootElement);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, obj, namespaces);

            return sb.ToString().Trim();
        }
    }
}
