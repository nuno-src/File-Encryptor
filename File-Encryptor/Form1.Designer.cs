namespace File_Encryptor
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonBrowseKey = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.radioButtonEncrypt = new System.Windows.Forms.RadioButton();
            this.radioButtonDecrypt = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(105, 201);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(484, 45);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(208, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(381, 20);
            this.textBox2.TabIndex = 6;
            // 
            // buttonBrowseKey
            // 
            this.buttonBrowseKey.Location = new System.Drawing.Point(105, 83);
            this.buttonBrowseKey.Name = "buttonBrowseKey";
            this.buttonBrowseKey.Size = new System.Drawing.Size(97, 23);
            this.buttonBrowseKey.TabIndex = 5;
            this.buttonBrowseKey.Text = "Browse Key File";
            this.buttonBrowseKey.UseVisualStyleBackColor = true;
            this.buttonBrowseKey.Click += new System.EventHandler(this.buttonBrowseKey_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(208, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(381, 20);
            this.textBox1.TabIndex = 4;
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Location = new System.Drawing.Point(105, 43);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(97, 23);
            this.buttonBrowseFile.TabIndex = 3;
            this.buttonBrowseFile.Text = "Browse File";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.buttonBrowseFile_Click);
            // 
            // radioButtonEncrypt
            // 
            this.radioButtonEncrypt.AutoSize = true;
            this.radioButtonEncrypt.Location = new System.Drawing.Point(170, 132);
            this.radioButtonEncrypt.Name = "radioButtonEncrypt";
            this.radioButtonEncrypt.Size = new System.Drawing.Size(61, 17);
            this.radioButtonEncrypt.TabIndex = 7;
            this.radioButtonEncrypt.TabStop = true;
            this.radioButtonEncrypt.Text = "Encrypt";
            this.radioButtonEncrypt.UseVisualStyleBackColor = true;
            this.radioButtonEncrypt.CheckedChanged += new System.EventHandler(this.radioButtonEncrypt_CheckedChanged);
            // 
            // radioButtonDecrypt
            // 
            this.radioButtonDecrypt.AutoSize = true;
            this.radioButtonDecrypt.Location = new System.Drawing.Point(411, 132);
            this.radioButtonDecrypt.Name = "radioButtonDecrypt";
            this.radioButtonDecrypt.Size = new System.Drawing.Size(62, 17);
            this.radioButtonDecrypt.TabIndex = 8;
            this.radioButtonDecrypt.TabStop = true;
            this.radioButtonDecrypt.Text = "Decrypt";
            this.radioButtonDecrypt.UseVisualStyleBackColor = true;
            this.radioButtonDecrypt.CheckedChanged += new System.EventHandler(this.radioButtonDecrypt_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(612, 276);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(772, 395);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.radioButtonDecrypt);
            this.Controls.Add(this.radioButtonEncrypt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonBrowseFile);
            this.Controls.Add(this.buttonBrowseKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonBrowseKey;
        private System.Windows.Forms.RadioButton radioButtonEncrypt;
        private System.Windows.Forms.RadioButton radioButtonDecrypt;
        private System.Windows.Forms.ListBox listBox1;
    }
}

