using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers
{
    public class XMLHelper
    {
        public T Deserialize<T>(string rootElement, string xmlInput)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootElement);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            StringReader reader = new StringReader(xmlInput);
            T commonDtos = (T)serializer.Deserialize(reader);
            return commonDtos;
        }
    }
}
