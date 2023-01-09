using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoFOP2
{
    public partial class ConfigForm : Form
    {

        protected Config _config;
        public Config config { get { return this._config; }set { this._config = value; } }
        private string fopPath = "";
        public ConfigForm()
        {
            InitializeComponent();
            this.config = new Config();
        }
        public void setConfigClass(ref Config config)
        {
            this.config = config;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fopBrowseButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();
            DialogResult res = this.openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = this.openFileDialog1.FileName;
                this.fopPath = path;
            }   
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            this._config.fopPath = this.fopPathInput.Text;
        }
    }
}
