namespace ZastitaInformacijaProjekat
{
    partial class HashForm
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
            textBox1 = new TextBox();
            btnIzaberiFajl = new Button();
            btnHash = new Button();
            lblLoc = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 105);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(317, 23);
            textBox1.TabIndex = 0;
            // 
            // btnIzaberiFajl
            // 
            btnIzaberiFajl.Location = new Point(50, 44);
            btnIzaberiFajl.Margin = new Padding(4, 3, 4, 3);
            btnIzaberiFajl.Name = "btnIzaberiFajl";
            btnIzaberiFajl.Size = new Size(88, 27);
            btnIzaberiFajl.TabIndex = 1;
            btnIzaberiFajl.Text = "Izaberite fajl";
            btnIzaberiFajl.UseVisualStyleBackColor = true;
            btnIzaberiFajl.Click += btnIzaberiFajl_Click;
            // 
            // btnHash
            // 
            btnHash.Location = new Point(50, 162);
            btnHash.Margin = new Padding(4, 3, 4, 3);
            btnHash.Name = "btnHash";
            btnHash.Size = new Size(88, 27);
            btnHash.TabIndex = 2;
            btnHash.Text = "Hash";
            btnHash.UseVisualStyleBackColor = true;
            btnHash.Click += btnHash_Click;
            // 
            // lblLoc
            // 
            lblLoc.AutoSize = true;
            lblLoc.Location = new Point(145, 50);
            lblLoc.Margin = new Padding(4, 0, 4, 0);
            lblLoc.Name = "lblLoc";
            lblLoc.Size = new Size(0, 15);
            lblLoc.TabIndex = 3;
            // 
            // HashForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 515);
            Controls.Add(lblLoc);
            Controls.Add(btnHash);
            Controls.Add(btnIzaberiFajl);
            Controls.Add(textBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "HashForm";
            Text = "SHA-1 Hash";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnIzaberiFajl;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Label lblLoc;
    }
}