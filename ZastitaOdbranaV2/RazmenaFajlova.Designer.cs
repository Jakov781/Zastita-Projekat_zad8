namespace ZastitaInformacijaProjekat
{
    partial class RazmenaFajlova
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
            txtPosaljiIP = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPosaljiPort = new TextBox();
            btnOdaberiFajl = new Button();
            lblIzabranFajl = new Label();
            btnPosalji = new Button();
            btnZapocniOsluskivanje = new Button();
            txtPrimalacPort = new TextBox();
            label3 = new Label();
            btnPrekiniOsluskivanje = new Button();
            lblStatusOsluskivanja = new Label();
            lblStatusSlanja = new Label();
            txtKljuc = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtPosaljiIP
            // 
            txtPosaljiIP.Location = new Point(47, 67);
            txtPosaljiIP.Margin = new Padding(4, 3, 4, 3);
            txtPosaljiIP.Name = "txtPosaljiIP";
            txtPosaljiIP.Size = new Size(116, 23);
            txtPosaljiIP.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 48);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Posalji ip";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 119);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 2;
            label2.Text = "Port posalji";
            // 
            // txtPosaljiPort
            // 
            txtPosaljiPort.Location = new Point(47, 138);
            txtPosaljiPort.Margin = new Padding(4, 3, 4, 3);
            txtPosaljiPort.Name = "txtPosaljiPort";
            txtPosaljiPort.Size = new Size(116, 23);
            txtPosaljiPort.TabIndex = 3;
            txtPosaljiPort.Text = "5050";
            // 
            // btnOdaberiFajl
            // 
            btnOdaberiFajl.Location = new Point(47, 219);
            btnOdaberiFajl.Margin = new Padding(4, 3, 4, 3);
            btnOdaberiFajl.Name = "btnOdaberiFajl";
            btnOdaberiFajl.Size = new Size(102, 27);
            btnOdaberiFajl.TabIndex = 4;
            btnOdaberiFajl.Text = "Odaberi fajl";
            btnOdaberiFajl.UseVisualStyleBackColor = true;
            btnOdaberiFajl.Click += btnOdaberiFajl_Click;
            // 
            // lblIzabranFajl
            // 
            lblIzabranFajl.AutoSize = true;
            lblIzabranFajl.Location = new Point(50, 254);
            lblIzabranFajl.Margin = new Padding(4, 0, 4, 0);
            lblIzabranFajl.Name = "lblIzabranFajl";
            lblIzabranFajl.Size = new Size(0, 15);
            lblIzabranFajl.TabIndex = 5;
            // 
            // btnPosalji
            // 
            btnPosalji.Location = new Point(47, 297);
            btnPosalji.Margin = new Padding(4, 3, 4, 3);
            btnPosalji.Name = "btnPosalji";
            btnPosalji.Size = new Size(117, 77);
            btnPosalji.TabIndex = 6;
            btnPosalji.Text = "Posalji";
            btnPosalji.UseVisualStyleBackColor = true;
            btnPosalji.Click += btnPosalji_Click;
            // 
            // btnZapocniOsluskivanje
            // 
            btnZapocniOsluskivanje.Location = new Point(410, 168);
            btnZapocniOsluskivanje.Margin = new Padding(4, 3, 4, 3);
            btnZapocniOsluskivanje.Name = "btnZapocniOsluskivanje";
            btnZapocniOsluskivanje.Size = new Size(102, 77);
            btnZapocniOsluskivanje.TabIndex = 7;
            btnZapocniOsluskivanje.Text = "Zapocni osluskivanje";
            btnZapocniOsluskivanje.UseVisualStyleBackColor = true;
            btnZapocniOsluskivanje.Click += btnZapocniOsluskivanje_Click;
            // 
            // txtPrimalacPort
            // 
            txtPrimalacPort.Location = new Point(457, 111);
            txtPrimalacPort.Margin = new Padding(4, 3, 4, 3);
            txtPrimalacPort.Name = "txtPrimalacPort";
            txtPrimalacPort.Size = new Size(116, 23);
            txtPrimalacPort.TabIndex = 8;
            txtPrimalacPort.Text = "5050";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(476, 67);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 9;
            label3.Text = "Port primaoca";
            // 
            // btnPrekiniOsluskivanje
            // 
            btnPrekiniOsluskivanje.Location = new Point(539, 168);
            btnPrekiniOsluskivanje.Margin = new Padding(4, 3, 4, 3);
            btnPrekiniOsluskivanje.Name = "btnPrekiniOsluskivanje";
            btnPrekiniOsluskivanje.Size = new Size(102, 77);
            btnPrekiniOsluskivanje.TabIndex = 10;
            btnPrekiniOsluskivanje.Text = "Prekini osluskivanje";
            btnPrekiniOsluskivanje.UseVisualStyleBackColor = true;
            btnPrekiniOsluskivanje.Click += btnPrekiniOsluskivanje_Click;
            // 
            // lblStatusOsluskivanja
            // 
            lblStatusOsluskivanja.AutoSize = true;
            lblStatusOsluskivanja.Location = new Point(378, 441);
            lblStatusOsluskivanja.Margin = new Padding(4, 0, 4, 0);
            lblStatusOsluskivanja.Name = "lblStatusOsluskivanja";
            lblStatusOsluskivanja.Size = new Size(0, 15);
            lblStatusOsluskivanja.TabIndex = 11;
            // 
            // lblStatusSlanja
            // 
            lblStatusSlanja.AutoSize = true;
            lblStatusSlanja.Location = new Point(47, 441);
            lblStatusSlanja.Margin = new Padding(4, 0, 4, 0);
            lblStatusSlanja.Name = "lblStatusSlanja";
            lblStatusSlanja.Size = new Size(0, 15);
            lblStatusSlanja.TabIndex = 12;
            // 
            // txtKljuc
            // 
            txtKljuc.Location = new Point(261, 433);
            txtKljuc.Margin = new Padding(4, 3, 4, 3);
            txtKljuc.Name = "txtKljuc";
            txtKljuc.Size = new Size(116, 23);
            txtKljuc.TabIndex = 13;
            txtKljuc.Text = "DefaultKey123456";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(258, 396);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 14;
            label4.Text = "Kljuc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(476, 31);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 15;
            label5.Text = "Osluskivanje";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 10);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 16;
            label6.Text = "Slanje";
            // 
            // RazmenaFajlova
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 539);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtKljuc);
            Controls.Add(lblStatusSlanja);
            Controls.Add(lblStatusOsluskivanja);
            Controls.Add(btnPrekiniOsluskivanje);
            Controls.Add(label3);
            Controls.Add(txtPrimalacPort);
            Controls.Add(btnZapocniOsluskivanje);
            Controls.Add(btnPosalji);
            Controls.Add(lblIzabranFajl);
            Controls.Add(btnOdaberiFajl);
            Controls.Add(txtPosaljiPort);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPosaljiIP);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RazmenaFajlova";
            Text = "File Transfer";
            Load += RazmenaFajlova_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPosaljiIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPosaljiPort;
        private System.Windows.Forms.Button btnOdaberiFajl;
        private System.Windows.Forms.Label lblIzabranFajl;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.Button btnZapocniOsluskivanje;
        private System.Windows.Forms.TextBox txtPrimalacPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrekiniOsluskivanje;
        private System.Windows.Forms.Label lblStatusOsluskivanja;
        private System.Windows.Forms.Label lblStatusSlanja;
        private System.Windows.Forms.TextBox txtKljuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}