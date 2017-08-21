namespace Registras
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog4 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog6 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2_eDoze = new System.Windows.Forms.Label();
            this.label2_doze = new System.Windows.Forms.Label();
            this.textBox2_eDoze = new System.Windows.Forms.TextBox();
            this.textBox2_doze = new System.Windows.Forms.TextBox();
            this.label2_pranesimas = new System.Windows.Forms.Label();
            this.richTextBox2_badFiles = new System.Windows.Forms.RichTextBox();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.protokolasPath3_label1 = new System.Windows.Forms.Label();
            this.generate3_button3 = new System.Windows.Forms.Button();
            this.imone_comboBox1 = new System.Windows.Forms.ComboBox();
            this.browse3_button3 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1_eDoze = new System.Windows.Forms.Label();
            this.label1_doze = new System.Windows.Forms.Label();
            this.textBox1_eDoze = new System.Windows.Forms.TextBox();
            this.textBox1_doze = new System.Windows.Forms.TextBox();
            this.richTextBox1_badFiles = new System.Windows.Forms.RichTextBox();
            this.label1_pranesimas = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.protokolasPath_label1 = new System.Windows.Forms.Label();
            this.generate_button1 = new System.Windows.Forms.Button();
            this.menesis_comboBox1 = new System.Windows.Forms.ComboBox();
            this.menesis_radioButton6 = new System.Windows.Forms.RadioButton();
            this.ketvirtis4_radioButton5 = new System.Windows.Forms.RadioButton();
            this.ketvirtis3_radioButton4 = new System.Windows.Forms.RadioButton();
            this.ketvirtis2_radioButton3 = new System.Windows.Forms.RadioButton();
            this.ketvirtis1_radioButton2 = new System.Windows.Forms.RadioButton();
            this.metai_radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.browseToolStripMenuItem.Text = "Browse";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.infoToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.helpToolStripMenuItem.Text = "View Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2_eDoze);
            this.tabPage4.Controls.Add(this.label2_doze);
            this.tabPage4.Controls.Add(this.textBox2_eDoze);
            this.tabPage4.Controls.Add(this.textBox2_doze);
            this.tabPage4.Controls.Add(this.label2_pranesimas);
            this.tabPage4.Controls.Add(this.richTextBox2_badFiles);
            this.tabPage4.Controls.Add(this.progressBar3);
            this.tabPage4.Controls.Add(this.protokolasPath3_label1);
            this.tabPage4.Controls.Add(this.generate3_button3);
            this.tabPage4.Controls.Add(this.imone_comboBox1);
            this.tabPage4.Controls.Add(this.browse3_button3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(568, 338);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "2. Ataskaita įmonei";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2_eDoze
            // 
            this.label2_eDoze.AutoSize = true;
            this.label2_eDoze.Location = new System.Drawing.Point(97, 216);
            this.label2_eDoze.Name = "label2_eDoze";
            this.label2_eDoze.Size = new System.Drawing.Size(72, 13);
            this.label2_eDoze.TabIndex = 34;
            this.label2_eDoze.Text = "Efektinė dozė";
            // 
            // label2_doze
            // 
            this.label2_doze.AutoSize = true;
            this.label2_doze.Location = new System.Drawing.Point(16, 217);
            this.label2_doze.Name = "label2_doze";
            this.label2_doze.Size = new System.Drawing.Size(39, 13);
            this.label2_doze.TabIndex = 33;
            this.label2_doze.Text = "Hp(10)";
            // 
            // textBox2_eDoze
            // 
            this.textBox2_eDoze.Location = new System.Drawing.Point(97, 236);
            this.textBox2_eDoze.Name = "textBox2_eDoze";
            this.textBox2_eDoze.Size = new System.Drawing.Size(51, 20);
            this.textBox2_eDoze.TabIndex = 32;
            // 
            // textBox2_doze
            // 
            this.textBox2_doze.Location = new System.Drawing.Point(16, 236);
            this.textBox2_doze.Name = "textBox2_doze";
            this.textBox2_doze.Size = new System.Drawing.Size(51, 20);
            this.textBox2_doze.TabIndex = 31;
            // 
            // label2_pranesimas
            // 
            this.label2_pranesimas.AutoSize = true;
            this.label2_pranesimas.Location = new System.Drawing.Point(203, 304);
            this.label2_pranesimas.Name = "label2_pranesimas";
            this.label2_pranesimas.Size = new System.Drawing.Size(0, 13);
            this.label2_pranesimas.TabIndex = 30;
            // 
            // richTextBox2_badFiles
            // 
            this.richTextBox2_badFiles.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2_badFiles.Location = new System.Drawing.Point(260, 57);
            this.richTextBox2_badFiles.Name = "richTextBox2_badFiles";
            this.richTextBox2_badFiles.ReadOnly = true;
            this.richTextBox2_badFiles.Size = new System.Drawing.Size(302, 238);
            this.richTextBox2_badFiles.TabIndex = 29;
            this.richTextBox2_badFiles.Text = "";
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(97, 299);
            this.progressBar3.MarqueeAnimationSpeed = 0;
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(100, 22);
            this.progressBar3.TabIndex = 28;
            // 
            // protokolasPath3_label1
            // 
            this.protokolasPath3_label1.AutoSize = true;
            this.protokolasPath3_label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.protokolasPath3_label1.Location = new System.Drawing.Point(97, 34);
            this.protokolasPath3_label1.Name = "protokolasPath3_label1";
            this.protokolasPath3_label1.Size = new System.Drawing.Size(106, 13);
            this.protokolasPath3_label1.TabIndex = 26;
            this.protokolasPath3_label1.Text = "Protokolų direktorija: ";
            // 
            // generate3_button3
            // 
            this.generate3_button3.Location = new System.Drawing.Point(16, 299);
            this.generate3_button3.Name = "generate3_button3";
            this.generate3_button3.Size = new System.Drawing.Size(75, 22);
            this.generate3_button3.TabIndex = 13;
            this.generate3_button3.Text = "Generate";
            this.generate3_button3.UseVisualStyleBackColor = true;
            this.generate3_button3.Click += new System.EventHandler(this.generate3_button3_Click);
            // 
            // imone_comboBox1
            // 
            this.imone_comboBox1.FormattingEnabled = true;
            this.imone_comboBox1.Location = new System.Drawing.Point(16, 128);
            this.imone_comboBox1.Name = "imone_comboBox1";
            this.imone_comboBox1.Size = new System.Drawing.Size(238, 21);
            this.imone_comboBox1.TabIndex = 2;
            this.imone_comboBox1.Text = "Įveskite/pasirinkite įmonės pavadinimą";
            this.imone_comboBox1.SelectedIndexChanged += new System.EventHandler(this.imone_comboBox1_SelectedIndexChanged);
            // 
            // browse3_button3
            // 
            this.browse3_button3.Location = new System.Drawing.Point(16, 24);
            this.browse3_button3.Name = "browse3_button3";
            this.browse3_button3.Size = new System.Drawing.Size(75, 23);
            this.browse3_button3.TabIndex = 1;
            this.browse3_button3.Text = "Load";
            this.browse3_button3.UseVisualStyleBackColor = true;
            this.browse3_button3.Click += new System.EventHandler(this.browse3_button3_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1_eDoze);
            this.tabPage1.Controls.Add(this.label1_doze);
            this.tabPage1.Controls.Add(this.textBox1_eDoze);
            this.tabPage1.Controls.Add(this.textBox1_doze);
            this.tabPage1.Controls.Add(this.richTextBox1_badFiles);
            this.tabPage1.Controls.Add(this.label1_pranesimas);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.protokolasPath_label1);
            this.tabPage1.Controls.Add(this.generate_button1);
            this.tabPage1.Controls.Add(this.menesis_comboBox1);
            this.tabPage1.Controls.Add(this.menesis_radioButton6);
            this.tabPage1.Controls.Add(this.ketvirtis4_radioButton5);
            this.tabPage1.Controls.Add(this.ketvirtis3_radioButton4);
            this.tabPage1.Controls.Add(this.ketvirtis2_radioButton3);
            this.tabPage1.Controls.Add(this.ketvirtis1_radioButton2);
            this.tabPage1.Controls.Add(this.metai_radioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Radiacijos centrui";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1_eDoze
            // 
            this.label1_eDoze.AutoSize = true;
            this.label1_eDoze.Location = new System.Drawing.Point(97, 229);
            this.label1_eDoze.Name = "label1_eDoze";
            this.label1_eDoze.Size = new System.Drawing.Size(72, 13);
            this.label1_eDoze.TabIndex = 19;
            this.label1_eDoze.Text = "Efektinė dozė";
            // 
            // label1_doze
            // 
            this.label1_doze.AutoSize = true;
            this.label1_doze.Location = new System.Drawing.Point(16, 230);
            this.label1_doze.Name = "label1_doze";
            this.label1_doze.Size = new System.Drawing.Size(39, 13);
            this.label1_doze.TabIndex = 18;
            this.label1_doze.Text = "Hp(10)";
            // 
            // textBox1_eDoze
            // 
            this.textBox1_eDoze.Location = new System.Drawing.Point(97, 249);
            this.textBox1_eDoze.Name = "textBox1_eDoze";
            this.textBox1_eDoze.Size = new System.Drawing.Size(51, 20);
            this.textBox1_eDoze.TabIndex = 17;
            // 
            // textBox1_doze
            // 
            this.textBox1_doze.Location = new System.Drawing.Point(16, 249);
            this.textBox1_doze.Name = "textBox1_doze";
            this.textBox1_doze.Size = new System.Drawing.Size(51, 20);
            this.textBox1_doze.TabIndex = 16;
            // 
            // richTextBox1_badFiles
            // 
            this.richTextBox1_badFiles.Location = new System.Drawing.Point(232, 39);
            this.richTextBox1_badFiles.Name = "richTextBox1_badFiles";
            this.richTextBox1_badFiles.ReadOnly = true;
            this.richTextBox1_badFiles.Size = new System.Drawing.Size(330, 253);
            this.richTextBox1_badFiles.TabIndex = 15;
            this.richTextBox1_badFiles.Text = "";
            this.richTextBox1_badFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_badFiles_MouseUp);
            // 
            // label1_pranesimas
            // 
            this.label1_pranesimas.AutoSize = true;
            this.label1_pranesimas.Location = new System.Drawing.Point(203, 304);
            this.label1_pranesimas.Name = "label1_pranesimas";
            this.label1_pranesimas.Size = new System.Drawing.Size(0, 13);
            this.label1_pranesimas.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(97, 299);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 13;
            // 
            // protokolasPath_label1
            // 
            this.protokolasPath_label1.AutoSize = true;
            this.protokolasPath_label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.protokolasPath_label1.Location = new System.Drawing.Point(13, 16);
            this.protokolasPath_label1.Name = "protokolasPath_label1";
            this.protokolasPath_label1.Size = new System.Drawing.Size(106, 13);
            this.protokolasPath_label1.TabIndex = 12;
            this.protokolasPath_label1.Text = "Protokolų direktorija: ";
            // 
            // generate_button1
            // 
            this.generate_button1.Location = new System.Drawing.Point(16, 299);
            this.generate_button1.Name = "generate_button1";
            this.generate_button1.Size = new System.Drawing.Size(75, 22);
            this.generate_button1.TabIndex = 9;
            this.generate_button1.Text = "Generate";
            this.generate_button1.UseVisualStyleBackColor = true;
            this.generate_button1.Click += new System.EventHandler(this.generate_button1_Click);
            // 
            // menesis_comboBox1
            // 
            this.menesis_comboBox1.FormattingEnabled = true;
            this.menesis_comboBox1.Items.AddRange(new object[] {
            "Sausis",
            "Vasaris",
            "Kovas",
            "Balandis",
            "Gegužė",
            "Birželis",
            "Liepa",
            "Rugpjūtis",
            "Rugsėjis",
            "Spalis",
            "Lapkritis",
            "Gruodis"});
            this.menesis_comboBox1.Location = new System.Drawing.Point(105, 184);
            this.menesis_comboBox1.Name = "menesis_comboBox1";
            this.menesis_comboBox1.Size = new System.Drawing.Size(121, 21);
            this.menesis_comboBox1.TabIndex = 8;
            this.menesis_comboBox1.Text = "Mėnesis";
            this.menesis_comboBox1.SelectedIndexChanged += new System.EventHandler(this.menesis_comboBox1_SelectedIndexChanged);
            // 
            // menesis_radioButton6
            // 
            this.menesis_radioButton6.AutoSize = true;
            this.menesis_radioButton6.Location = new System.Drawing.Point(16, 185);
            this.menesis_radioButton6.Name = "menesis_radioButton6";
            this.menesis_radioButton6.Size = new System.Drawing.Size(64, 17);
            this.menesis_radioButton6.TabIndex = 7;
            this.menesis_radioButton6.Text = "Mėnesis";
            this.menesis_radioButton6.UseVisualStyleBackColor = true;
            this.menesis_radioButton6.CheckedChanged += new System.EventHandler(this.menesis_radioButton6_CheckedChanged);
            // 
            // ketvirtis4_radioButton5
            // 
            this.ketvirtis4_radioButton5.AutoSize = true;
            this.ketvirtis4_radioButton5.Location = new System.Drawing.Point(16, 161);
            this.ketvirtis4_radioButton5.Name = "ketvirtis4_radioButton5";
            this.ketvirtis4_radioButton5.Size = new System.Drawing.Size(70, 17);
            this.ketvirtis4_radioButton5.TabIndex = 6;
            this.ketvirtis4_radioButton5.Text = "4 ketvirtis";
            this.ketvirtis4_radioButton5.UseVisualStyleBackColor = true;
            this.ketvirtis4_radioButton5.CheckedChanged += new System.EventHandler(this.ketvirtis4_radioButton5_CheckedChanged);
            // 
            // ketvirtis3_radioButton4
            // 
            this.ketvirtis3_radioButton4.AutoSize = true;
            this.ketvirtis3_radioButton4.Location = new System.Drawing.Point(16, 137);
            this.ketvirtis3_radioButton4.Name = "ketvirtis3_radioButton4";
            this.ketvirtis3_radioButton4.Size = new System.Drawing.Size(70, 17);
            this.ketvirtis3_radioButton4.TabIndex = 5;
            this.ketvirtis3_radioButton4.Text = "3 ketvirtis";
            this.ketvirtis3_radioButton4.UseVisualStyleBackColor = true;
            this.ketvirtis3_radioButton4.CheckedChanged += new System.EventHandler(this.ketvirtis3_radioButton4_CheckedChanged);
            // 
            // ketvirtis2_radioButton3
            // 
            this.ketvirtis2_radioButton3.AutoSize = true;
            this.ketvirtis2_radioButton3.Location = new System.Drawing.Point(16, 113);
            this.ketvirtis2_radioButton3.Name = "ketvirtis2_radioButton3";
            this.ketvirtis2_radioButton3.Size = new System.Drawing.Size(70, 17);
            this.ketvirtis2_radioButton3.TabIndex = 4;
            this.ketvirtis2_radioButton3.Text = "2 ketvirtis";
            this.ketvirtis2_radioButton3.UseVisualStyleBackColor = true;
            this.ketvirtis2_radioButton3.CheckedChanged += new System.EventHandler(this.ketvirtis2_radioButton3_CheckedChanged);
            // 
            // ketvirtis1_radioButton2
            // 
            this.ketvirtis1_radioButton2.AutoSize = true;
            this.ketvirtis1_radioButton2.Location = new System.Drawing.Point(16, 89);
            this.ketvirtis1_radioButton2.Name = "ketvirtis1_radioButton2";
            this.ketvirtis1_radioButton2.Size = new System.Drawing.Size(70, 17);
            this.ketvirtis1_radioButton2.TabIndex = 3;
            this.ketvirtis1_radioButton2.Text = "1 ketvirtis";
            this.ketvirtis1_radioButton2.UseVisualStyleBackColor = true;
            this.ketvirtis1_radioButton2.CheckedChanged += new System.EventHandler(this.ketvirtis1_radioButton2_CheckedChanged);
            // 
            // metai_radioButton1
            // 
            this.metai_radioButton1.AutoSize = true;
            this.metai_radioButton1.Location = new System.Drawing.Point(16, 66);
            this.metai_radioButton1.Name = "metai_radioButton1";
            this.metai_radioButton1.Size = new System.Drawing.Size(51, 17);
            this.metai_radioButton1.TabIndex = 2;
            this.metai_radioButton1.Text = "Metai";
            this.metai_radioButton1.UseVisualStyleBackColor = true;
            this.metai_radioButton1.CheckedChanged += new System.EventHandler(this.metai_radioButton1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 364);
            this.tabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 403);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registras";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Label protokolasPath3_label1;
        private System.Windows.Forms.Button generate3_button3;
        private System.Windows.Forms.ComboBox imone_comboBox1;
        private System.Windows.Forms.Button browse3_button3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1_badFiles;
        private System.Windows.Forms.Label label1_pranesimas;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label protokolasPath_label1;
        private System.Windows.Forms.Button generate_button1;
        private System.Windows.Forms.ComboBox menesis_comboBox1;
        private System.Windows.Forms.RadioButton menesis_radioButton6;
        private System.Windows.Forms.RadioButton ketvirtis4_radioButton5;
        private System.Windows.Forms.RadioButton ketvirtis3_radioButton4;
        private System.Windows.Forms.RadioButton ketvirtis2_radioButton3;
        private System.Windows.Forms.RadioButton ketvirtis1_radioButton2;
        private System.Windows.Forms.RadioButton metai_radioButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.RichTextBox richTextBox2_badFiles;
        private System.Windows.Forms.Label label2_pranesimas;
        private System.Windows.Forms.Label label1_eDoze;
        private System.Windows.Forms.Label label1_doze;
        private System.Windows.Forms.TextBox textBox1_eDoze;
        private System.Windows.Forms.TextBox textBox1_doze;
        private System.Windows.Forms.Label label2_eDoze;
        private System.Windows.Forms.Label label2_doze;
        private System.Windows.Forms.TextBox textBox2_eDoze;
        private System.Windows.Forms.TextBox textBox2_doze;
    }
}

