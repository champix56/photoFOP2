using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace photoFOP2
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("config")]
    public class LowConfig
    {


        [System.Xml.Serialization.XmlElement("outputType")]
        public string outputType{ get; set; }

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
        public bool withFileName { get; set; }
        [System.Xml.Serialization.XmlElement("cols")]
        public int cols { get; set; }
        [System.Xml.Serialization.XmlElement("rows")]
        public int rows { get; set; }
        [System.Xml.Serialization.XmlElement("backImageNoAlpha")]
        public ImageXML backImageNoAlpha { get; set; }
        [System.Xml.Serialization.XmlElement("backImageAlpha")]
        public ImageXML backImageAlpha { get; set; }
        public LowConfig()
        {
            dimensionPapierX = 210.0M;
            dimensionPapierY = 297.0M;
            defaultUnit = "mm";
            titleEachPage = true;
            intercalaire = true;
            withFileName = true;
            footerEachPage = true;
            rows = 1;
            cols = 1;
            backImageAlpha = new ImageXML();
            backImageNoAlpha = new ImageXML();
            
        }
        public void writeXMLConfig(XmlWriter writer)
        {
            writer.WriteStartElement("config");
            writer.WriteElementString("cols", cols.ToString());
            writer.WriteElementString("rows", rows.ToString());
            writer.WriteElementString("footerEachPages", footerEachPage.ToString());
            writer.WriteElementString("titleEachPages", titleEachPage.ToString());
            writer.WriteElementString("intercal", intercalaire.ToString());
            writer.WriteElementString("defaultUnit", defaultUnit.ToString());
            writer.WriteElementString("height", this.dimensionPapierY.ToString("#.0").Replace(',','.'));
            writer.WriteElementString("width", this.dimensionPapierX.ToString("#.0").Replace(',', '.'));
            writer.WriteElementString("outputType", this.outputType);
            writer.WriteStartElement("backgroundAlpha");
            backImageAlpha.writeXmlElement(writer);
            writer.WriteEndElement();
            writer.WriteStartElement("backgroundNoAlpha");
            backImageNoAlpha.writeXmlElement(writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("Lconfig")]
    public class Config : LowConfig
    {

        public static readonly string configFileName = "config.fxm";

        [System.Xml.Serialization.XmlElement("fopPath")]
        public string fopPath { get; set; }
        [System.Xml.Serialization.XmlElement("xslFile")]
        public string xslFile { get; set; }
        [System.Xml.Serialization.XmlElement("withConfig")]
        public bool withConfig { get; set; }
        [System.Xml.Serialization.XmlElement("withIsolation")]
        public bool isolateImagesOnPages { get; set; }
        [System.Xml.Serialization.XmlElement("backDPI")]

        public UInt32 backDPI { get; set; }
        [System.Xml.Serialization.XmlElement("outputPath")]

        public string outputpath { get; set; }
        [System.Xml.Serialization.XmlElement("extendBack")]
        public bool extendBack { get; set; }

        public Config() : base()
        {
            fopPath = System.IO.Directory.GetCurrentDirectory() + "\\Ressources\\FOP1.0\\fop.bat";
            withConfig = true;
            isolateImagesOnPages = false;
            extendBack = true;
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
            fs.Close();
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
                    this.backImageNoAlpha.href = config.backImageNoAlpha.href;
                    this.backImageAlpha.path= config.backImageAlpha.path;
                    this.isolateImagesOnPages  = config.isolateImagesOnPages;
                    this.xslFile = config.xslFile;
                    this.backDPI = config.backDPI;
                    extendBack=config.extendBack;
                    outputpath=config.outputpath;
                    outputType=config.outputType;
                    reader.Close();
                }
            }catch(Exception e) { System.Console.Out.Write(e.StackTrace); return false; }
            return true;
        }
        
    }
}
