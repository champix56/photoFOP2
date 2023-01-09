using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoFOP2
{
    [Serializable]
    public class ImageXML
    {
        public ImageXML() { }
        public string path{ get; set; }
        public string href { get; set; }
    }
}
