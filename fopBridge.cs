using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace photoFOP2
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("photos")]
    public class PhotoFOPXML
    {
        [System.Xml.Serialization.XmlElement("config")]
        Config config;
        [XmlArray("pages")]
        List<ImageXML> images;

        public PhotoFOPXML()
        {

        }
        public void setConfig(Config cfg)
        {
            this.config = cfg;
        }
        public void setDatas(DataGridViewRowCollection rows)
        {
            images = new List<ImageXML>();
            foreach (DataGridViewRow row in rows)
            {
                string filename = row.Cells["col_fichier"].Value.ToString();
                string comment = row.Cells["col_commentaire"].Value.ToString();
                string path = filename.Substring(0, filename.LastIndexOf('\\') + 1);
                //path = "file:///" + path.Replace('\\', '/');
                string href = filename.Substring(filename.LastIndexOf("\\") + 1);
                images.Add(new ImageXML(path, href, comment));
            }
        }

        /*internal void getXML(string fileName)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            // Create an XmlTextWriter using a FileStream.
            Stream fs = new FileStream(fileName, FileMode.Create);
            System.Xml.XmlWriter writer =
            new System.Xml.XmlTextWriter(fs, Encoding.Unicode);
            // Serialize using the XmlTextWriter.
            x.Serialize(writer, this);
            fs.Close();
           // throw new NotImplementedException();
        }*/
        public void getXML(string fileName)
        {

            Stream fs = new FileStream(fileName, FileMode.Create);
            System.Xml.XmlWriter writer =new System.Xml.XmlTextWriter(fs, Encoding.Unicode);
            // writerFs.Setting
            writer.WriteStartElement("photos");

            writer.WriteAttributeString("xmlns:fo", "http://www.w3.org/1999/XSL/Format");
            if (config.withConfig)
            {
                config.writeXMLConfig(writer);
            }

            writer.WriteStartElement("pages");
            if (!config.isolateImagesOnPages)
            {
                foreach (ImageXML img in images)
                {
                    img.writeXmlElement(writer);
                }
            }
            else
            {
                writeImageListWithPageIsolation(writer);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
            // Write the XML and close the writer.
            writer.Close();
            fs.Close();
        }
        private void writeImageListWithPageIsolation(XmlWriter writer)
        {
            int i = 0;
            while (i < images.Count)
            {
                if (i == 0 || i % (config.rows * config.cols) == 0) { writer.WriteStartElement("page"); }
                images[i].writeXmlElement(writer);
                if (i % (config.rows * config.cols) == 3 || i - 1 == images.Count) { writer.WriteEndElement(); }
                i++;
            }
        }
        private void writeImageListNoPageIsolation(XmlWriter writer)
        {

        }
    }
}
