namespace photoFOP2
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ch_isolatePages = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.nud_back_dpi = new System.Windows.Forms.NumericUpDown();
            this.r_extendback = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ch_intercalaire = new System.Windows.Forms.CheckBox();
            this.ch_footerEachPage = new System.Windows.Forms.CheckBox();
            this.ch_titleEachPage = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_height = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_unit = new System.Windows.Forms.ComboBox();
            this.nud_width = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fopPathInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_back_dpi)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.fopPathInput);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(625, 423);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.ch_isolatePages);
            this.groupBox6.Location = new System.Drawing.Point(10, 226);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(600, 62);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Generation XML";
            // 
            // ch_isolatePages
            // 
            this.ch_isolatePages.AutoSize = true;
            this.ch_isolatePages.Location = new System.Drawing.Point(5, 20);
            this.ch_isolatePages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ch_isolatePages.Name = "ch_isolatePages";
            this.ch_isolatePages.Size = new System.Drawing.Size(170, 19);
            this.ch_isolatePages.TabIndex = 0;
            this.ch_isolatePages.Text = "Isolation XML images/page";
            this.ch_isolatePages.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(10, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(600, 146);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fop construction options";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.nud_back_dpi);
            this.groupBox3.Controls.Add(this.r_extendback);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(260, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(108, 115);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "fond";
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(6, 86);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Repliqué";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // nud_back_dpi
            // 
            this.nud_back_dpi.Location = new System.Drawing.Point(6, 36);
            this.nud_back_dpi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_back_dpi.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.nud_back_dpi.Name = "nud_back_dpi";
            this.nud_back_dpi.Size = new System.Drawing.Size(96, 23);
            this.nud_back_dpi.TabIndex = 8;
            this.nud_back_dpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_back_dpi.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // r_extendback
            // 
            this.r_extendback.AutoSize = true;
            this.r_extendback.Checked = true;
            this.r_extendback.Enabled = false;
            this.r_extendback.Location = new System.Drawing.Point(6, 63);
            this.r_extendback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r_extendback.Name = "r_extendback";
            this.r_extendback.Size = new System.Drawing.Size(62, 19);
            this.r_extendback.TabIndex = 0;
            this.r_extendback.TabStop = true;
            this.r_extendback.Text = "étendu";
            this.r_extendback.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dpi";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.ch_intercalaire);
            this.groupBox4.Controls.Add(this.ch_footerEachPage);
            this.groupBox4.Controls.Add(this.ch_titleEachPage);
            this.groupBox4.Location = new System.Drawing.Point(416, 29);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(178, 107);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "construction pages";
            // 
            // ch_intercalaire
            // 
            this.ch_intercalaire.AutoSize = true;
            this.ch_intercalaire.Location = new System.Drawing.Point(14, 73);
            this.ch_intercalaire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ch_intercalaire.Name = "ch_intercalaire";
            this.ch_intercalaire.Size = new System.Drawing.Size(89, 19);
            this.ch_intercalaire.TabIndex = 2;
            this.ch_intercalaire.Text = "Intercalaires";
            this.ch_intercalaire.UseVisualStyleBackColor = true;
            // 
            // ch_footerEachPage
            // 
            this.ch_footerEachPage.AutoSize = true;
            this.ch_footerEachPage.Location = new System.Drawing.Point(14, 51);
            this.ch_footerEachPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ch_footerEachPage.Name = "ch_footerEachPage";
            this.ch_footerEachPage.Size = new System.Drawing.Size(104, 19);
            this.ch_footerEachPage.TabIndex = 1;
            this.ch_footerEachPage.Text = "pieds de pages";
            this.ch_footerEachPage.UseVisualStyleBackColor = true;
            // 
            // ch_titleEachPage
            // 
            this.ch_titleEachPage.AutoSize = true;
            this.ch_titleEachPage.Location = new System.Drawing.Point(14, 28);
            this.ch_titleEachPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ch_titleEachPage.Name = "ch_titleEachPage";
            this.ch_titleEachPage.Size = new System.Drawing.Size(147, 19);
            this.ch_titleEachPage.TabIndex = 0;
            this.ch_titleEachPage.Text = "titre sur chaques pages";
            this.ch_titleEachPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_height);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_unit);
            this.groupBox1.Controls.Add(this.nud_width);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(201, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensions de papier";
            // 
            // nud_height
            // 
            this.nud_height.DecimalPlaces = 2;
            this.nud_height.Location = new System.Drawing.Point(17, 35);
            this.nud_height.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_height.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_height.Name = "nud_height";
            this.nud_height.Size = new System.Drawing.Size(80, 23);
            this.nud_height.TabIndex = 6;
            this.nud_height.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hauteur";
            // 
            // cb_unit
            // 
            this.cb_unit.FormattingEnabled = true;
            this.cb_unit.Items.AddRange(new object[] {
            "mm",
            "cm",
            "in"});
            this.cb_unit.Location = new System.Drawing.Point(35, 82);
            this.cb_unit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_unit.Name = "cb_unit";
            this.cb_unit.Size = new System.Drawing.Size(133, 23);
            this.cb_unit.TabIndex = 4;
            // 
            // nud_width
            // 
            this.nud_width.DecimalPlaces = 2;
            this.nud_width.Location = new System.Drawing.Point(112, 35);
            this.nud_width.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_width.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_width.Name = "nud_width";
            this.nud_width.Size = new System.Drawing.Size(80, 23);
            this.nud_width.TabIndex = 3;
            this.nud_width.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Unité par défaut";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Largeur";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(520, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "parcourir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fopPathInput
            // 
            this.fopPathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fopPathInput.Location = new System.Drawing.Point(10, 32);
            this.fopPathInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fopPathInput.Name = "fopPathInput";
            this.fopPathInput.Size = new System.Drawing.Size(505, 23);
            this.fopPathInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "FOP Path";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 33);
            this.panel1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(400, 7);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(82, 22);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Enregistrer";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(313, 7);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(82, 22);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Annul.";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(625, 423);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConfigForm";
            this.Text = "Configuration";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_back_dpi)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Panel panel1;
        private Button okButton;
        private Button cancelButton;
        private Button button1;
        private TextBox fopPathInput;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private CheckBox ch_intercalaire;
        private CheckBox ch_footerEachPage;
        private CheckBox ch_titleEachPage;
        private GroupBox groupBox1;
        private NumericUpDown nud_height;
        private Label label4;
        private ComboBox cb_unit;
        private NumericUpDown nud_width;
        private Label label3;
        private Label label2;
        private RadioButton radioButton2;
        private RadioButton r_extendback;
        private GroupBox groupBox6;
        private CheckBox ch_isolatePages;
        private GroupBox groupBox3;
        private NumericUpDown nud_back_dpi;
        private Label label5;
    }
}