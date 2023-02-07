using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace photoFOP2
{
    public partial class PhotoFOP : Form
    {
        protected Config config;
        protected ImageXML couvImg;
        protected ImageXML couv4Img;

        public PhotoFOP()
        {
            InitializeComponent();
            this.config = new Config();
            initializeConfig();
            initializeDataGridView();
            initializeComboBackgroundImages();
            initializeComboXSL();

        }
        private void initializeConfig()
        {
            this.config.load();
            nud_row.Value = this.config.rows;
            nud_col.Value = this.config.cols;
            ch_4couv.Checked = config.couv4eme;
            ch_couv.Checked = config.couv;
            ch_intercal.Checked = config.intercalaire;
        }
        protected void initializeDataGridView()
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "image";
            img.Width = 400;
            dataGridView1.Columns.Add(img);
            dataGridView1.Columns.Add("col_fichier", "fichier");
            dataGridView1.Columns.Add("col_commentaire", "commentaire");
            dataGridView1.AllowUserToAddRows = false;
        }
        protected void initializeComboBackgroundImages()
        {
            string current = System.IO.Directory.GetCurrentDirectory();
            IEnumerable<string> ressources = System.IO.Directory.EnumerateFiles(current + "\\Ressources\\images");
            foreach (string ressource in ressources)
            {
                string extension = ressource.Substring(ressource.LastIndexOf('.'));
                string fileName = ressource.Substring(ressource.LastIndexOf('\\') + 1);
                // fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
                backImageComboBox.Items.Add(fileName);

            }
            backImageComboBox.SelectedIndex = ressources.Count() > 1 ? 1 : 0;
            backImageComboBox_SelectedIndexChanged(backImageComboBox, new EventArgs());
        }
        private void initializeComboXSL()
        {
            string current = System.IO.Directory.GetCurrentDirectory();
            IEnumerable<string> ressources = System.IO.Directory.EnumerateFiles(current + "\\Ressources\\xsl");
            foreach (string ressource in ressources)
            {
                string fileName = ressource.Substring(ressource.LastIndexOf('\\') + 1);
                // fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
                cb_embed_xsl.Items.Add(fileName);

            }
            cb_embed_xsl.SelectedIndex = 0;
            rb_xsl_embed.Checked = true;


        }
        private void b_addDirectory_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = this.folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string folder = this.folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    addFile(file);
                }
            }
        }

        private void quiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm configF = new ConfigForm();
            configF.setConfigClass(ref this.config);
            configF.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                string filename = saveFileDialog1.FileName;
                outputPath.Text = filename;

            }
        }

        /* private void button4_Click(object sender, EventArgs e)
         {
             XSL_OUTPUT_TYPE outputType = XSL_OUTPUT_TYPE.AWT;
             switch (comboBox1.SelectedItem)
             {
                 case "AWT": outputType = XSL_OUTPUT_TYPE.AWT; break;
                 case "HTML": outputType = XSL_OUTPUT_TYPE.HTML; break;
                 case "PDF": outputType = XSL_OUTPUT_TYPE.PDF; break;
                 case "XMLDEBUG": outputType = XSL_OUTPUT_TYPE.XMLDEBUG; break;
             }
             FOPActionner fopAction = new FOPActionner(this.config);
             fopAction.Execute(outputPath.Text, "", comboBox1.Text, outputType);
         }*/


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "image files(.jpg,.bmp,*.tif,*.tiff,*.jpeg,*.bmp,*.png)|*.jpg,*.bmp,*.tif,*.tiff,*.jpeg,*.bmp,*.png|All Files (*.*)|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                addFile(filename);
            }
        }
        protected void addFile(string fileName)
        {
            string ext = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLowerInvariant();
            if (ext != "jpg" && ext != "jpeg" && ext != "gif" & ext != "png" & ext != "tif" && ext != "bmp")
            {
                return;
            }
            Bitmap img = Tools.ResizeImage(Image.FromFile(fileName), 300);
            dataGridView1.Rows.Add(img, fileName, "");
            dataGridView1.Rows[dataGridView1.RowCount - 1].Height = img.Height + 40;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "image files(*.jpg,*.bmp,*.tif,*.tiff,*.jpeg,*.bmp,*.png)|*.jpg,*.bmp,*.tif,*.tiff,*.jpeg,*.bmp,*.png|All Files (*.*)|*.*";

            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                backgroundFileNameTextInput.Text = openFileDialog1.FileName;
                this.rb_background_imported.Checked = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void backImageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rb_background_embed.Checked = true;
        }
        private void backGroundImageChange(object sender, EventArgs e)
        {
            if (config == null) return;
            string item = null;
            if (sender.GetType().Name == "ComboBox")
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    item = null;
                }
                else
                {
                    item = System.IO.Directory.GetCurrentDirectory() + "\\Ressources\\images\\" + ((ComboBox)sender).SelectedItem.ToString();
                }
            }
            else
            {
                item = ((TextBox)sender).Text;

            }
            if (item == null || !System.IO.File.Exists(item))
            {
                this.BackgroundImage = null;
                this.config.backImageNoAlpha = null;
                this.config.backImageAlpha = null;
                return;
            }

            
            /*this.config.backImage.href = item.Substring(item.LastIndexOf('\\')+1);
            this.config.backImage.path = item.Substring(0,item.LastIndexOf('\\')+1);
            */
            BackImageTreatment bi = new BackImageTreatment(
               item,
               System.IO.Directory.GetCurrentDirectory() + "outimg",
               (int)(config.dimensionPapierX),
               (int)(config.dimensionPapierY),
               ref config
               );
            bi.createRatioImage();
            if (this.config.backImageNoAlpha == null)
            {
                this.config.backImageNoAlpha = new ImageXML();
                this.config.backImageAlpha = new ImageXML();
                this.BackgroundImage = null;
                this.config.save();
                return;
            }
            if (this.BackgroundImage != null) this.BackgroundImage.Dispose();// = null;


            System.IO.File.Copy(
                config.backImageAlpha.getFullPath(),
                System.IO.Directory.GetCurrentDirectory() + "\\TEMP\\windowBack.png", true);
            try
            {
                PhotoFOP_Resize(sender, e);
            }catch(Exception ex) { 
                Console.WriteLine(ex.ToString());
            }

            this.config.save();
        }
        private void enregistrerConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config.save();
        }
        private void enregistrerConfigSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "photofop config Files (.fxm)|*.fxm|XML Files (.xml)|*.xml|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                config.save(saveFileDialog1.FileName);
            }
        }

        private void chargerConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "photofop config Files (.fxm)|*.fxm|XML Files (.xml)|*.xml|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                config.load(openFileDialog1.FileName);
            }
        }
        private void xsl_file_change(object sender, EventArgs e)
        {
            string selectedItemString = "";
            if ((sender.GetType().Name == "ComboBox" && ((ComboBox)sender).Name == "cb_embed_xsl") || (sender.GetType().Name == "RadioButton" && ((RadioButton)sender).Name == "rb_xsl_embed" && ((RadioButton)sender).Checked == true))
            {
                selectedItemString = cb_embed_xsl.SelectedItem.ToString();
                config.xslFile = System.IO.Directory.GetCurrentDirectory() + "\\ressources\\xsl\\" + selectedItemString;
                if (!rb_xsl_embed.Checked)
                {
                    rb_xsl_embed.Checked = true;
                }

            }
            else
            {
                config.xslFile = t_xsl_imported.Text;
                selectedItemString = config.xslFile.Substring(config.xslFile.LastIndexOf('\\'));
                if (!rb_xsl_imported.Checked)
                {
                    rb_xsl_imported.Checked = true;
                }
            }
            cb_outputMethod.Items.Clear();
            if (selectedItemString.ToUpper().Contains("FO"))
            {
                cb_outputMethod.Items.Add("PDF");
                cb_outputMethod.Items.Add("AWT");
                cb_outputMethod.Items.Add("RTF");
                cb_outputMethod.Items.Add("XMLDEBUG");
            }
            else if (selectedItemString.ToUpper().Contains("HTML"))
            {
                cb_outputMethod.Items.Add("HTML");
                cb_outputMethod.Items.Add("XMLDEBUG");
            }
            else
            {
                cb_outputMethod.Items.Add("HTML");
                cb_outputMethod.Items.Add("AWT");
                cb_outputMethod.Items.Add("PDF");
                cb_outputMethod.Items.Add("RTF");
                cb_outputMethod.Items.Add("XMLDEBUG");
            }
            cb_outputMethod.SelectedIndex = 0;
            config.save();
        }
        private void b_findXSL_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "photofop Transformation Files (.fxs)|*.fxs|XSL Files (*.xsl,*.xslt)|*.xsl,*.xslt|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                config.load(openFileDialog1.FileName);
            }
        }

        private void nud_col_ValueChanged(object sender, EventArgs e)
        {
            this.config.cols = (int)nud_col.Value;
        }
        private void nud_row_ValueChanged(object sender, EventArgs e)
        {
            this.config.rows = (int)nud_row.Value;
        }

        private void executeTransfoButton_Click(object sender, EventArgs e)
        {
            if (outputPath.Text == "")
            {
                outputPath.BackColor = System.Drawing.Color.IndianRed;
                return;
            }
            this.config.save();

            //gestion image de fond


            PhotoFOPXML pXML = new PhotoFOPXML();
            pXML.setConfig(config);
            pXML.setDatas(dataGridView1.Rows);
            string xmlpath = System.IO.Directory.GetCurrentDirectory() + "\\output.xml";
            pXML.getXML(xmlpath);
            string outfile = "";
            switch (config.outputType)
            {
                case "PDF":
                case "RTF":
                    FOPActionner fop = new FOPActionner(config);
                    fop.Execute(System.IO.Directory.GetCurrentDirectory() + "\\output.xml", config.outputpath, config.outputType, ref outfile);
                    break;
                case "HTML":
                case "XMLDEBUG":
                    XslTransform transform = new XslTransform();
                    transform.Load(config.xslFile);
                    transform.Transform(xmlpath, config.outputpath);
                    outfile = config.outputpath;
                    break;

            }

            /* if (config.outputType != "XMLDEBUG")
             {
                 System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\" + bi.BackFileAlpha);
                 System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\" + bi.BackFileNoAlpha);
             }*/
            if (ch_openOnEnd.Checked)
            {
                /* try
                 {
                     //System.Diagnostics.Process.Start(@outfile);
                     string appPath = Path.GetDirectoryName(Application.ExecutablePath);


                     System.Diagnostics.Process.Start(appPath + "\\"+outfile);
                 }
                 catch(Exception ex) { 
                     Console.WriteLine(ex.StackTrace); 
                 }*/

            }
        }

        private void cb_xsl_SelectedIndexChanged(object sender, EventArgs e)
        {
            rb_xsl_embed.Checked = true;
        }

        private void outputPath_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "") { ((TextBox)sender).BackColor = System.Drawing.Color.IndianRed; return; }
            else { ((TextBox)sender).BackColor = System.Drawing.SystemColors.Window; }
            config.outputpath = ((TextBox)sender).Text;
        }

        private void t_xsl_imported_TextChanged(object sender, EventArgs e)
        {
            rb_xsl_imported.Checked = true;
        }

        private void rb_xsl_imported_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rb_xsl_embed_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void cb_outputMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.outputType = cb_outputMethod.SelectedItem.ToString();
        }

        private void ch_couv_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                tabControl2.TabPages.Remove(tab_couv);
            }
            else { tabControl2.TabPages.Add(tab_couv); }

        }

        private void ch_4couv_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                tabControl2.TabPages.Remove(tab_4emeCouv);
            }
            else { tabControl2.TabPages.Add(tab_4emeCouv); }
        }

        private void ch_intercal_CheckedChanged(object sender, EventArgs e)
        {
            config.intercalaire = ((CheckBox)sender).Checked;
        }

        private void load_couv_image_clicked(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                couvImg = new ImageXML(path.Substring(0, path.LastIndexOf('\\') + 1), path.Substring(path.LastIndexOf('\\') + 1), "");
                l_couv_image.Image = new Bitmap(Image.FromFile(openFileDialog1.FileName), new Size(l_couv_image.Width, l_couv_image.Height));
            }
        }

        private void load_4couv_image_clicked(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                couv4Img = new ImageXML(path.Substring(0, path.LastIndexOf('\\') + 1), path.Substring(path.LastIndexOf('\\') + 1), "");
                l_4couv_image.Image = new Bitmap(Image.FromFile(openFileDialog1.FileName), new Size(l_4couv_image.Width, l_4couv_image.Height));
            }
        }

        private void tab_option_Click(object sender, EventArgs e)
        {

        }

        private void PhotoFOP_Resize(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\TEMP\\windowBack.png"))
            {
                Image image = new Bitmap(Image.FromFile(
                                System.IO.Directory.GetCurrentDirectory() + "\\TEMP\\windowBack.png"
                                ), this.Size);
                this.BackgroundImage = image;
            }
        }
    }
}