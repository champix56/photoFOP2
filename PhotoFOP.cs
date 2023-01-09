namespace photoFOP2
{
    public partial class PhotoFOP : Form
    {
        protected Config config;
        public PhotoFOP()
        {
            InitializeComponent();
            initializeDataGridView();
            initializeComboBackgroundImages();
            this.config = new Config();
            initializeConfig();
        }
        private void initializeConfig()
        {
            this.config.load();
            nud_row.Value = this.config.rows;
            nud_col.Value = this.config.cols;
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

        private void button4_Click(object sender, EventArgs e)
        {
            XSL_OUTPUT_TYPE outputType = XSL_OUTPUT_TYPE.AWT;
            switch (comboBox1.SelectedItem)
            {
                case "AWT": outputType = XSL_OUTPUT_TYPE.AWT; break;
                case "HTML": outputType = XSL_OUTPUT_TYPE.HTML; break;
                case "PDF": outputType = XSL_OUTPUT_TYPE.PDF; break;
                case "XMLDEBUG": outputType = XSL_OUTPUT_TYPE.XMLDEBUG; break;
            }
            FOPActionner fopAction = new FOPActionner(this.config.fopPath);
            fopAction.Execute(outputPath.Text, "", comboBox1.Text, outputType);
        }


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
            dataGridView1.Rows.Add(img, fileName);
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
                    this.BackgroundImage = null;
                    this.config.backImage = null;
                    item = null;
                }
                item = System.IO.Directory.GetCurrentDirectory() + "\\Ressources\\images\\" + ((ComboBox)sender).SelectedItem.ToString();
            }
            else
            {
                item = ((TextBox)sender).Text;

            }
            if(item==null)return; 
            Image image = Image.FromFile(item);
            this.BackgroundImage = image;
            this.config.backImage.href = item.Substring(item.LastIndexOf('\\'));
            this.config.backImage.path = item.Substring(0,item.LastIndexOf('\\'));
            this.config.save();
        }
        private void enregistrerConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config.save(saveFileDialog1.FileName);
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

        private void button5_Click(object sender, EventArgs e)
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
            this.config.save();
        }
    }
}