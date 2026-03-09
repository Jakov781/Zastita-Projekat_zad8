namespace ZastitaInformacijaProjekat
{
    partial class EncryptTextForm
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
            txtUnos = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            txtIzlaz = new RichTextBox();
            btnEncrypt = new Button();
            btnnDecrypt = new Button();
            txtKey = new TextBox();
            btnGenerateKey = new Button();
            numSpace = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numSpace).BeginInit();
            SuspendLayout();
            // 
            // txtUnos
            // 
            txtUnos.Location = new Point(14, 38);
            txtUnos.Margin = new Padding(4, 3, 4, 3);
            txtUnos.Name = "txtUnos";
            txtUnos.Size = new Size(443, 214);
            txtUnos.TabIndex = 0;
            txtUnos.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 1;
            label1.Text = "Ulaz";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 295);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Izlaz";
            // 
            // txtIzlaz
            // 
            txtIzlaz.Location = new Point(14, 314);
            txtIzlaz.Margin = new Padding(4, 3, 4, 3);
            txtIzlaz.Name = "txtIzlaz";
            txtIzlaz.Size = new Size(443, 214);
            txtIzlaz.TabIndex = 3;
            txtIzlaz.Text = "";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(519, 384);
            btnEncrypt.Margin = new Padding(4, 3, 4, 3);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(173, 27);
            btnEncrypt.TabIndex = 4;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnnDecrypt
            // 
            btnnDecrypt.Location = new Point(519, 460);
            btnnDecrypt.Margin = new Padding(4, 3, 4, 3);
            btnnDecrypt.Name = "btnnDecrypt";
            btnnDecrypt.Size = new Size(173, 27);
            btnnDecrypt.TabIndex = 5;
            btnnDecrypt.Text = "Decrypt";
            btnnDecrypt.UseVisualStyleBackColor = true;
            btnnDecrypt.Click += btnnDecrypt_Click;
            // 
            // txtKey
            // 
            txtKey.Location = new Point(519, 54);
            txtKey.Margin = new Padding(4, 3, 4, 3);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(269, 23);
            txtKey.TabIndex = 6;
            // 
            // btnGenerateKey
            // 
            btnGenerateKey.Location = new Point(519, 100);
            btnGenerateKey.Margin = new Padding(4, 3, 4, 3);
            btnGenerateKey.Name = "btnGenerateKey";
            btnGenerateKey.Size = new Size(173, 27);
            btnGenerateKey.TabIndex = 7;
            btnGenerateKey.Text = "Generate key";
            btnGenerateKey.UseVisualStyleBackColor = true;
            btnGenerateKey.Click += btnGenerateKey_Click;
            // 
            // numSpace
            // 
            numSpace.Location = new Point(519, 175);
            numSpace.Margin = new Padding(4, 3, 4, 3);
            numSpace.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numSpace.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSpace.Name = "numSpace";
            numSpace.Size = new Size(140, 23);
            numSpace.TabIndex = 8;
            numSpace.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(519, 30);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 9;
            label3.Text = "Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(517, 153);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 10;
            label4.Text = "Space";
            // 
            // EncryptTextForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 594);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numSpace);
            Controls.Add(btnGenerateKey);
            Controls.Add(txtKey);
            Controls.Add(btnnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(txtIzlaz);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUnos);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EncryptTextForm";
            Text = "Encrypt Text (Bifid)";
            ((System.ComponentModel.ISupportInitialize)numSpace).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtUnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtIzlaz;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnnDecrypt;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.NumericUpDown numSpace;
        private Label label3;
        private Label label4;
    }
}