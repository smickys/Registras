namespace Registras
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1_klTipas = new System.Windows.Forms.Label();
            this.richTextBox1_explanation = new System.Windows.Forms.RichTextBox();
            this.label1_paaisk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "* Faile nepavyko nuskaityti skyriaus pavadinimo.",
            "* Faile nepavyko nuskaityti duomenų.",
            "* Faile vardas ir pavardė yra surašyti atvirkščiai.",
            "* Faile maksimaliai gali būti 5 lentelės",
            "* String was not recognized as a valid DateTime.",
            "* Index was out of range."});
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(288, 319);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1_klTipas
            // 
            this.label1_klTipas.AutoSize = true;
            this.label1_klTipas.ForeColor = System.Drawing.Color.Maroon;
            this.label1_klTipas.Location = new System.Drawing.Point(12, 22);
            this.label1_klTipas.Name = "label1_klTipas";
            this.label1_klTipas.Size = new System.Drawing.Size(111, 13);
            this.label1_klTipas.TabIndex = 3;
            this.label1_klTipas.Text = "Pasirinkite klaidos tipą";
            // 
            // richTextBox1_explanation
            // 
            this.richTextBox1_explanation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.richTextBox1_explanation.Location = new System.Drawing.Point(332, 38);
            this.richTextBox1_explanation.Name = "richTextBox1_explanation";
            this.richTextBox1_explanation.Size = new System.Drawing.Size(384, 319);
            this.richTextBox1_explanation.TabIndex = 4;
            this.richTextBox1_explanation.Text = "";
            // 
            // label1_paaisk
            // 
            this.label1_paaisk.AutoSize = true;
            this.label1_paaisk.ForeColor = System.Drawing.Color.Maroon;
            this.label1_paaisk.Location = new System.Drawing.Point(329, 22);
            this.label1_paaisk.Name = "label1_paaisk";
            this.label1_paaisk.Size = new System.Drawing.Size(68, 13);
            this.label1_paaisk.TabIndex = 5;
            this.label1_paaisk.Text = "Paaiškinimas";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 382);
            this.Controls.Add(this.label1_paaisk);
            this.Controls.Add(this.richTextBox1_explanation);
            this.Controls.Add(this.label1_klTipas);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1_klTipas;
        private System.Windows.Forms.RichTextBox richTextBox1_explanation;
        private System.Windows.Forms.Label label1_paaisk;
    }
}