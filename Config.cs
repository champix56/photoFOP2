using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoFOP2
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("config")]
    public class Config
    {

        public static readonly string configFileName = "config.fxm";
        [System.Xml.Serialization.XmlElement("fopPath")]
        public string fopPath { get; set; }
        [System.Xml.Serialization.XmlElement("width")]
        public decimal dimensionPapierX { get; set; }
        [System.Xml.Serialization.XmlElement("height")]
        public decimal dimensionPapierY { get; set; }
        [System.Xml.Serialization.XmlElement("defaultUnit")]
        public string defaultUnit { get; set; }
        [System.Xml.Serialization.XmlElement("titleEachPages")]
        public bool titleEachPage { get; set; }
        [System.Xml.Serialization.XmlElement("footerEachPages")]
        public bool footerEachPage { get; set; }
        [System.Xml.Serialization.XmlElement("intercal")]
        public bool intercalaire { get; set; }
        [System.Xml.Serialization.XmlElement("withFileName")]
        public bool withFileName{ get; set; }
        [System.Xml.Serialization.XmlElement("cols")]
        public int cols{ get; set; }
        [System.Xml.Serialization.XmlElement("rows")]
        public int rows{ get; set; }
        [System.Xml.Serialization.XmlElement("backImage")]
        public ImageXML backImage{ get; set; }
        public Config()
        {
            fopPath = System.IO.Directory.GetCurrentDirectory() + "\\Ressources\\FOP1.0\\fop.bat";
            dimensionPapierX = 210.0M;
            dimensionPapierY = 297.0M;
            defaultUnit = "mm";
            titleEachPage = true;
            intercalaire = true;
            withFileName = true;
            footerEachPage = true;
            rows = 1;
            cols = 1;
            backImage = new ImageXML(); ;
        }
        public void save()
        {
            save(configFileName);
        }
        public void save(string filename)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            // Create an XmlTextWriter using a FileStream.
            Stream fs = new FileStream(filename, FileMode.Create);
            System.Xml.XmlWriter writer =
            new System.Xml.XmlTextWriter(fs, Encoding.Unicode);
            // Serialize using the XmlTextWriter.
            x.Serialize(writer, this);
        }
        public void load()
        {
            load(configFileName);
        }
        public bool load(string filename)
        {
            if (!System.IO.File.Exists(filename)) { return false; }
            try
            {
                // Create an instance of the XmlSerializer.
                System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(this.GetType());

                // Declare an object variable of the type to be deserialized.
                Config config;
                using (Stream reader = new FileStream(filename, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    config = (Config)serializer.Deserialize(reader);
                    this.fopPath = config.fopPath;
                    this.defaultUnit = config.defaultUnit;
                    this.dimensionPapierY = config.dimensionPapierY;
                    this.dimensionPapierX = config.dimensionPapierX;
                    titleEachPage = config.titleEachPage;
                    intercalaire = config.intercalaire;
                    withFileName = config.withFileName;
                    footerEachPage = config.footerEachPage;
                    this.rows = config.rows;
                    cols = config.cols;
                    this.backImage.href = config.backImage.href;
                    this.backImage.path= config.backImage.path;
                }
            }catch(Exception e) { System.Console.Out.Write(e.StackTrace); return false; }
            return true;
        }
    }
}
