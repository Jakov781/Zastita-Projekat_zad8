namespace ZastitaInformacijaProjekat
{
    partial class EncryptFileForm
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
            button1 = new Button();
            txtFile = new TextBox();
            txtFileDest = new TextBox();
            button2 = new Button();
            btnSifra = new Button();
            btnDesifruj = new Button();
            kljucText = new TextBox();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(58, 96);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(308, 27);
            button1.TabIndex = 0;
            button1.Text = "Izaberite fajl za obradu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtFile
            // 
            txtFile.Location = new Point(58, 48);
            txtFile.Margin = new Padding(4, 3, 4, 3);
            txtFile.Name = "txtFile";
            txtFile.Size = new Size(307, 23);
            txtFile.TabIndex = 1;
            // 
            // txtFileDest
            // 
            txtFileDest.Location = new Point(58, 159);
            txtFileDest.Margin = new Padding(4, 3, 4, 3);
            txtFileDest.Name = "txtFileDest";
            txtFileDest.Size = new Size(307, 23);
            txtFileDest.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(58, 215);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(308, 27);
            button2.TabIndex = 3;
            button2.Text = "Izaberite folder za cuvanje fajla";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnSifra
            // 
            btnSifra.Location = new Point(58, 300);
            btnSifra.Margin = new Padding(4, 3, 4, 3);
            btnSifra.Name = "btnSifra";
            btnSifra.Size = new Size(98, 37);
            btnSifra.TabIndex = 4;
            btnSifra.Text = "Sifruj";
            btnSifra.UseVisualStyleBackColor = true;
            btnSifra.Click += btnSifra_Click;
            // 
            // btnDesifruj
            // 
            btnDesifruj.Location = new Point(268, 300);
            btnDesifruj.Margin = new Padding(4, 3, 4, 3);
            btnDesifruj.Name = "btnDesifruj";
            btnDesifruj.Size = new Size(98, 37);
            btnDesifruj.TabIndex = 5;
            btnDesifruj.Text = "Desifruj";
            btnDesifruj.UseVisualStyleBackColor = true;
            btnDesifruj.Click += btnDesifruj_Click;
            // 
            // kljucText
            // 
            kljucText.Location = new Point(58, 402);
            kljucText.Margin = new Padding(4, 3, 4, 3);
            kljucText.Name = "kljucText";
            kljucText.Size = new Size(172, 23);
            kljucText.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 383);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 7;
            label1.Text = "Tajni kljuc";
            // 
            // button3
            // 
            button3.Location = new Point(58, 427);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(88, 27);
            button3.TabIndex = 8;
            button3.Text = "Generisi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // EncryptFileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 467);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(kljucText);
            Controls.Add(btnDesifruj);
            Controls.Add(btnSifra);
            Controls.Add(button2);
            Controls.Add(txtFileDest);
            Controls.Add(txtFile);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EncryptFileForm";
            Text = " Encrypt File (RC6+OFB)";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtFileDest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSifra;
        private System.Windows.Forms.Button btnDesifruj;
        private System.Windows.Forms.TextBox kljucText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}