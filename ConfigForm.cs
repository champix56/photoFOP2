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

        private Config _config;
        public Config config { get { return this._config; } set { this._config = value; } }
        
        public ConfigForm()
        {
            InitializeComponent();
            this.config = new Config();

            initializeDatas();
        }
        public void setConfigClass(ref Config config)
        {
            this.config = config;
            initializeDatas();

        }
        private void initializeDatas()
        {
            this.fopPathInput.Text = this.config.fopPath;
            this.nud_height.Value = this.config.dimensionPapierY;
            this.nud_width.Value = this.config.dimensionPapierX;
            this.cb_unit.SelectedItem= this.config.defaultUnit;
            this.ch_footerEachPage.Checked = this.config.footerEachPage;
            this.ch_intercalaire.Checked = this.config.intercalaire;
            this.ch_titleEachPage.Checked = this.config.titleEachPage;
            this.nud_back_dpi.Value = this.config.backDPI;
            ch_isolatePages.Checked = config.isolateImagesOnPages;
            radioButton2.Checked = !config.extendBack;

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
                this.fopPathInput.Text = path;
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            config.fopPath = this.fopPathInput.Text;
            config.backDPI = (UInt32)this.nud_back_dpi.Value;
            config.dimensionPapierX = nud_width.Value;
            config.dimensionPapierY = nud_height.Value;
            config.defaultUnit = cb_unit.SelectedItem!=null? cb_unit.SelectedItem.ToString():"mm";
            config.isolateImagesOnPages = ch_isolatePages.Checked;
            config.footerEachPage = ch_footerEachPage.Checked;
            config.intercalaire = ch_intercalaire.Checked;
            config.titleEachPage= ch_titleEachPage.Checked;

            config.extendBack=r_extendback.Checked;
            
            this.config.save();
            this.Close();
        }
    }
}
