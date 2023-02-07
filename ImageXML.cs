using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace photoFOP2
{
    [Serializable()]
    public class ImageXML
    {
        public ImageXML() { }
        public ImageXML(string path, string href, string comment) {
            this.path = path;
            this.href = href;
            this.comment = comment;
        }
        public string getFullPath()
        {
            return this.path+this.href;
        }
        [System.Xml.Serialization.XmlAttribute("path")]
        public string path{ get; set; }
        [System.Xml.Serialization.XmlAttribute("href")]
        public string href { get; set; }
        [System.Xml.Serialization.XmlText()]
        public string comment{ get; set; }
        public void writeXmlElement(XmlWriter writer)
        {
            writer.WriteStartElement("image");
            writer.WriteAttributeString("path", "file:///" + path.Replace('\\', '/'));
            writer.WriteAttributeString("href", href);
            writer.WriteString(comment);
            writer.WriteEndElement();
        }
    }
}
