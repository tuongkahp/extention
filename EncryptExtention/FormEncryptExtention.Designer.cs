namespace Extentions
{
    partial class FormEncryptExtention
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.rdbMd5 = new System.Windows.Forms.RadioButton();
            this.ckbIsCBCMode = new System.Windows.Forms.CheckBox();
            this.rdbAES = new System.Windows.Forms.RadioButton();
            this.rdb3Des = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOutputLength = new System.Windows.Forms.Label();
            this.lbInputLength = new System.Windows.Forms.Label();
            this.picQr = new System.Windows.Forms.PictureBox();
            this.cbkShowPass = new System.Windows.Forms.CheckBox();
            this.rdbRsaAes = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.group1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(336, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(5, 20);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(326, 131);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(5, 20);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(326, 131);
            this.txtOutput.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Location = new System.Drawing.Point(10, 167);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(336, 154);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(352, 172);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(341, 22);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(352, 198);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(341, 22);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(352, 222);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(39, 15);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(352, 147);
            this.txtKey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(251, 23);
            this.txtKey.TabIndex = 2;
            this.txtKey.Enter += new System.EventHandler(this.txtKey_Enter);
            this.txtKey.Leave += new System.EventHandler(this.txtKey_Leave);
            // 
            // group1
            // 
            this.group1.Controls.Add(this.rdbRsaAes);
            this.group1.Controls.Add(this.rdbMd5);
            this.group1.Controls.Add(this.ckbIsCBCMode);
            this.group1.Controls.Add(this.rdbAES);
            this.group1.Controls.Add(this.rdb3Des);
            this.group1.Location = new System.Drawing.Point(352, 9);
            this.group1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.group1.Name = "group1";
            this.group1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.group1.Size = new System.Drawing.Size(341, 134);
            this.group1.TabIndex = 5;
            this.group1.TabStop = false;
            this.group1.Text = "Encrypt type";
            // 
            // rdbMd5
            // 
            this.rdbMd5.AutoSize = true;
            this.rdbMd5.Location = new System.Drawing.Point(14, 64);
            this.rdbMd5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbMd5.Name = "rdbMd5";
            this.rdbMd5.Size = new System.Drawing.Size(50, 19);
            this.rdbMd5.TabIndex = 3;
            this.rdbMd5.Text = "MD5";
            this.rdbMd5.UseVisualStyleBackColor = true;
            // 
            // ckbIsCBCMode
            // 
            this.ckbIsCBCMode.AutoSize = true;
            this.ckbIsCBCMode.Location = new System.Drawing.Point(96, 43);
            this.ckbIsCBCMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbIsCBCMode.Name = "ckbIsCBCMode";
            this.ckbIsCBCMode.Size = new System.Drawing.Size(83, 19);
            this.ckbIsCBCMode.TabIndex = 1;
            this.ckbIsCBCMode.Text = "CBC mode";
            this.ckbIsCBCMode.UseVisualStyleBackColor = true;
            // 
            // rdbAES
            // 
            this.rdbAES.AutoSize = true;
            this.rdbAES.Checked = true;
            this.rdbAES.Location = new System.Drawing.Point(14, 20);
            this.rdbAES.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbAES.Name = "rdbAES";
            this.rdbAES.Size = new System.Drawing.Size(45, 19);
            this.rdbAES.TabIndex = 0;
            this.rdbAES.TabStop = true;
            this.rdbAES.Text = "AES";
            this.rdbAES.UseVisualStyleBackColor = true;
            // 
            // rdb3Des
            // 
            this.rdb3Des.AutoSize = true;
            this.rdb3Des.Location = new System.Drawing.Point(14, 42);
            this.rdb3Des.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdb3Des.Name = "rdb3Des";
            this.rdb3Des.Size = new System.Drawing.Size(51, 19);
            this.rdb3Des.TabIndex = 0;
            this.rdb3Des.Text = "3DES";
            this.rdb3Des.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 286);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 302);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output length";
            // 
            // lbOutputLength
            // 
            this.lbOutputLength.AutoSize = true;
            this.lbOutputLength.Location = new System.Drawing.Point(448, 302);
            this.lbOutputLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOutputLength.Name = "lbOutputLength";
            this.lbOutputLength.Size = new System.Drawing.Size(13, 15);
            this.lbOutputLength.TabIndex = 8;
            this.lbOutputLength.Text = "0";
            // 
            // lbInputLength
            // 
            this.lbInputLength.AutoSize = true;
            this.lbInputLength.Location = new System.Drawing.Point(448, 286);
            this.lbInputLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbInputLength.Name = "lbInputLength";
            this.lbInputLength.Size = new System.Drawing.Size(13, 15);
            this.lbInputLength.TabIndex = 9;
            this.lbInputLength.Text = "0";
            // 
            // picQr
            // 
            this.picQr.Location = new System.Drawing.Point(575, 224);
            this.picQr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(117, 100);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQr.TabIndex = 10;
            this.picQr.TabStop = false;
            // 
            // cbkShowPass
            // 
            this.cbkShowPass.AutoSize = true;
            this.cbkShowPass.Location = new System.Drawing.Point(612, 148);
            this.cbkShowPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbkShowPass.Name = "cbkShowPass";
            this.cbkShowPass.Size = new System.Drawing.Size(76, 19);
            this.cbkShowPass.TabIndex = 8;
            this.cbkShowPass.Text = "Show key";
            this.cbkShowPass.UseVisualStyleBackColor = true;
            this.cbkShowPass.CheckedChanged += new System.EventHandler(this.cbkShowPass_CheckedChanged);
            // 
            // rdbRsaAes
            // 
            this.rdbRsaAes.AutoSize = true;
            this.rdbRsaAes.Location = new System.Drawing.Point(14, 87);
            this.rdbRsaAes.Margin = new System.Windows.Forms.Padding(2);
            this.rdbRsaAes.Name = "rdbRsaAes";
            this.rdbRsaAes.Size = new System.Drawing.Size(80, 19);
            this.rdbRsaAes.TabIndex = 8;
            this.rdbRsaAes.Text = "RSA + AES";
            this.rdbRsaAes.UseVisualStyleBackColor = true;
            // 
            // FormEncryptExtention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 331);
            this.Controls.Add(this.cbkShowPass);
            this.Controls.Add(this.picQr);
            this.Controls.Add(this.lbInputLength);
            this.Controls.Add(this.lbOutputLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormEncryptExtention";
            this.Text = "Encrypt extention";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEncryptExtention_FormClosing);
            this.Load += new System.EventHandler(this.FormEncryptExtention_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.RadioButton rdbAES;
        private System.Windows.Forms.RadioButton rdb3Des;
        private System.Windows.Forms.CheckBox ckbIsCBCMode;
        private System.Windows.Forms.RadioButton rdbMd5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbOutputLength;
        private System.Windows.Forms.Label lbInputLength;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.CheckBox cbkShowPass;
        private System.Windows.Forms.RadioButton rdbRsaAes;
    }
}

