namespace PictureLockManager
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFolderPath = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnPassphraseSet = new System.Windows.Forms.Button();
            this.tbPassphrase = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 399);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(697, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // tbFolderPath
            // 
            this.tbFolderPath.Location = new System.Drawing.Point(12, 12);
            this.tbFolderPath.Name = "tbFolderPath";
            this.tbFolderPath.Size = new System.Drawing.Size(679, 20);
            this.tbFolderPath.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(760, 97);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.EvtShowImage);
            // 
            // btnPassphraseSet
            // 
            this.btnPassphraseSet.Location = new System.Drawing.Point(12, 557);
            this.btnPassphraseSet.Name = "btnPassphraseSet";
            this.btnPassphraseSet.Size = new System.Drawing.Size(140, 26);
            this.btnPassphraseSet.TabIndex = 4;
            this.btnPassphraseSet.Text = "Set passphrase";
            this.btnPassphraseSet.UseVisualStyleBackColor = true;
            this.btnPassphraseSet.Click += new System.EventHandler(this.BtnPassphraseSet_Click);
            // 
            // tbPassphrase
            // 
            this.tbPassphrase.Location = new System.Drawing.Point(158, 561);
            this.tbPassphrase.Name = "tbPassphrase";
            this.tbPassphrase.Size = new System.Drawing.Size(225, 20);
            this.tbPassphrase.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 613);
            this.Controls.Add(this.tbPassphrase);
            this.Controls.Add(this.btnPassphraseSet);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tbFolderPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "PictureLockManager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbFolderPath;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnPassphraseSet;
        private System.Windows.Forms.TextBox tbPassphrase;
    }
}

