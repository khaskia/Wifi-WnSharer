namespace SharingWifi
{
    partial class EditText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditText));
            this.ctlModernBlack1 = new jSkin.ctlModernBlack();
            this.button6 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ctlModernBlack1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlModernBlack1
            // 
            this.ctlModernBlack1.Controls.Add(this.button6);
            this.ctlModernBlack1.Controls.Add(this.richTextBox1);
            this.ctlModernBlack1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlModernBlack1.FixedSingle = false;
            this.ctlModernBlack1.Location = new System.Drawing.Point(0, 0);
            this.ctlModernBlack1.Name = "ctlModernBlack1";
            this.ctlModernBlack1.Size = new System.Drawing.Size(415, 387);
            this.ctlModernBlack1.Stretch = false;
            this.ctlModernBlack1.TabIndex = 0;
            this.ctlModernBlack1.Load += new System.EventHandler(this.ctlModernBlack1_Load);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(265, 327);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(138, 46);
            this.button6.TabIndex = 16;
            this.button6.Text = "Done Editing";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(391, 287);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // EditText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 387);
            this.Controls.Add(this.ctlModernBlack1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditText";
            this.Text = "Edit Wifi Names";
            this.Load += new System.EventHandler(this.EditText_Load);
            this.ctlModernBlack1.ResumeLayout(false);
            this.ctlModernBlack1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private jSkin.ctlModernBlack ctlModernBlack1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button6;
    }
}