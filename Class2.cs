using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoFOP2
{
    internal enum XSL_OUTPUT_TYPE
    {
        HTML = 0,
        PDF = 1,
        AWT = 2,
        XMLDEBUG = 3,
    }
    internal enum FOP_EXECUTION_ERRORS
    {
        NO_FOP_PATH = -1,
        NO_FOP_OUTPUT_TYPE = -2,
        NO_FOP_OUTPUT_PATH = -3,
        EXECUTED = 1,
    }
    internal class FOPActionner
    {
        string path = "";
        string lastOutput = "";
        public FOPActionner(string path)
        {
            this.path = path;
        }
        public FOP_EXECUTION_ERRORS Execute(string xmlPath, string xslPath, string outputPath, XSL_OUTPUT_TYPE outputType)
        {
            if (this.path.Length > 0)
            {
                return FOP_EXECUTION_ERRORS.NO_FOP_PATH;
            }
            string argumentStr = "";
            switch (outputType)
            {
                case XSL_OUTPUT_TYPE.PDF: argumentStr += "-pdf " + outputPath+".pdf"; return FOP_EXECUTION_ERRORS.EXECUTED;
                case XSL_OUTPUT_TYPE.HTML: argumentStr += "-foout " + outputPath+".html"; return FOP_EXECUTION_ERRORS.EXECUTED;
                case XSL_OUTPUT_TYPE.XMLDEBUG: argumentStr += "-foout " + outputPath+".xml"; return FOP_EXECUTION_ERRORS.EXECUTED;
                case XSL_OUTPUT_TYPE.AWT: argumentStr += "-awt "; return FOP_EXECUTION_ERRORS.EXECUTED;
            }
            /*System.Diagnostics.Process.Start(this.path,argumentStr+" -xml " +xmlPath+" -xsl "+xslPath) ;   * */

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            startInfo.FileName = this.path;
            startInfo.Arguments = argumentStr + " -xml " + xmlPath + " -xsl " + xslPath;
            process.StartInfo = startInfo;
            process.Start();

            return FOP_EXECUTION_ERRORS.EXECUTED;
        }
    }
}
