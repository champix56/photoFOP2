namespace photoFOP2
{
    public partial class PhotoFOP : Form
    {
        protected Config config;
        protected String[] imagesPath;


        public PhotoFOP()
        {
            InitializeComponent();
            initializeDataGridView();
            initializeComboBackgroundImages();
            this.config = new Config();
            this.imagesPath = new String[0];
        }
        protected void initializeDataGridView()
        {
            dataGridView1.Columns.Add("col_image", "image");
            dataGridView1.Columns.Add("col_fichier", "fichier");
        }
        protected void initializeComboBackgroundImages()
        {
            string current = System.IO.Directory.GetCurrentDirectory();
            IEnumerable<string> ressources = System.IO.Directory.EnumerateFiles(current + "\\ressources");
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
            configF.config = this.config;
            configF.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
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
            if (ext != "jpg" && ext != "jpeg" && ext != "gif" & ext != "png" & ext != "tif" && ext != "bmp") { return; }
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            cell.Value = fileName;
            row.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = fileName;
            row.Cells.Add(cell);
            dataGridView1.Rows.Add(row);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
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
            if (sender.GetType().Name == "ComboBox")
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    this.BackgroundImage = null;
                    return;
                }
                string item = ((ComboBox)sender).SelectedItem.ToString();
                Image image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\ressources\\" + item);
                this.BackgroundImage = image;

            }
        }
    }
}