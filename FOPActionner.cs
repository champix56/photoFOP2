using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoFOP2
{
    /*internal enum XSL_OUTPUT_TYPE
    {
        HTML = 0,
        PDF = 1,
        AWT = 2,
        XMLDEBUG = 3,
    }*/
    internal enum FOP_EXECUTION_ERRORS
    {
        NO_FOP_PATH = -1,
        NO_FOP_OUTPUT_TYPE = -2,
        NO_FOP_OUTPUT_PATH = -3,
        EXECUTED = 1,
    }
    internal class XMLAlbumSerializer
    {


    }
    internal class FOPActionner
    {

        string lastOutput = "";
        Config config;
        public FOPActionner(Config config)
        {
            this.config = config;
        }
        public FOP_EXECUTION_ERRORS Execute(string xmlPath, string outputPath, string outputType,ref string outputFileWithExt)
        {
            FOP_EXECUTION_ERRORS error=Execute(xmlPath,outputPath,outputType);

            switch (outputType)
            {
                case "PDF":outputFileWithExt= outputPath + ".pdf";break;
                case "RTF":outputFileWithExt= outputPath + ".rtf";break;
                case "HTML":outputFileWithExt= outputPath + ".html";break;
                case "XMLDEBUG":outputFileWithExt= outputPath + ".xml";break;
            }
            return error;

        }
        public FOP_EXECUTION_ERRORS Execute(string xmlPath, string outputPath, string outputType)
        {
            if (this.config.fopPath.Length <= 0)
            {
                return FOP_EXECUTION_ERRORS.NO_FOP_PATH;
            }
            string argumentStr = "";
            switch (outputType)
            {
                case "PDF": argumentStr += "-pdf " + outputPath + ".pdf"; break; //return FOP_EXECUTION_ERRORS.EXECUTED;
                case "RTF": argumentStr += "-rtf " + outputPath + ".rtf"; break; //return FOP_EXECUTION_ERRORS.EXECUTED;
                case "HTML": argumentStr += "-foout " + outputPath + ".html"; break;// return FOP_EXECUTION_ERRORS.EXECUTED;
                case "XMLDEBUG": argumentStr += "-foout " + outputPath + ".xml"; break;// return FOP_EXECUTION_ERRORS.EXECUTED;
                case "AWT": argumentStr += "-awt "; break;//return FOP_EXECUTION_ERRORS.EXECUTED;
            }
            /*System.Diagnostics.Process.Start(this.path,argumentStr+" -xml " +xmlPath+" -xsl "+xslPath) ;   * */

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            startInfo.FileName = this.config.fopPath;
            startInfo.Arguments = argumentStr + " -xml \"" + xmlPath + "\" -xsl \"" + config.xslFile + "\"";

            string output = "";

            process.StartInfo = startInfo;

            /*process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            */
            // process.StartInfo.ErrorDialog = true;
            //process.Start()

            // redirect the output
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            StringBuilder sb = new StringBuilder();
            StringBuilder sberr = new StringBuilder();
            // hookup the eventhandlers to capture the data that is received
            process.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
            process.ErrorDataReceived += (sender, args) => sberr.AppendLine(args.Data);

            // direct start
            process.StartInfo.UseShellExecute = false;

            process.Start();
            // start our event pumps
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            // until we are done
            process.WaitForExit();

            System.Console.Write(sberr.ToString());

            if (outputType != "XMLDEBUG") { System.IO.File.Delete(xmlPath);}
            //process.WaitForExit();
            return FOP_EXECUTION_ERRORS.EXECUTED;
        }
    }
}
