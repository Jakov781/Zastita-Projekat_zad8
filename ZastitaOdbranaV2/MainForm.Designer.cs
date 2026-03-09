namespace ZastitaInformacijaProjekat
{
    partial class MainForm
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
            encryptFileBtn = new Button();
            button1 = new Button();
            btnWatchFolder = new Button();
            btnSaveTarget = new Button();
            lblWatch = new Label();
            lblSave = new Label();
            btnStartWatcher = new Button();
            txtKey = new TextBox();
            btnGenerateKey = new Button();
            label1 = new Label();
            btnSHA1 = new Button();
            btnPosaljiFajl = new Button();
            SuspendLayout();
            // 
            // encryptFileBtn
            // 
            encryptFileBtn.Location = new Point(14, 14);
            encryptFileBtn.Margin = new Padding(4, 3, 4, 3);
            encryptFileBtn.Name = "encryptFileBtn";
            encryptFileBtn.Size = new Size(131, 51);
            encryptFileBtn.TabIndex = 0;
            encryptFileBtn.Text = "Encrypt file RC6+OFB";
            encryptFileBtn.UseVisualStyleBackColor = true;
            encryptFileBtn.Click += encryptFileBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(14, 90);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(131, 51);
            button1.TabIndex = 1;
            button1.Text = "Encrypt Text bifid";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnWatchFolder
            // 
            btnWatchFolder.Location = new Point(14, 241);
            btnWatchFolder.Margin = new Padding(4, 3, 4, 3);
            btnWatchFolder.Name = "btnWatchFolder";
            btnWatchFolder.Size = new Size(131, 27);
            btnWatchFolder.TabIndex = 2;
            btnWatchFolder.Text = "Watch folder";
            btnWatchFolder.UseVisualStyleBackColor = true;
            btnWatchFolder.Click += btnWatchFolder_Click;
            // 
            // btnSaveTarget
            // 
            btnSaveTarget.Location = new Point(14, 321);
            btnSaveTarget.Margin = new Padding(4, 3, 4, 3);
            btnSaveTarget.Name = "btnSaveTarget";
            btnSaveTarget.Size = new Size(131, 27);
            btnSaveTarget.TabIndex = 3;
            btnSaveTarget.Text = "Save target";
            btnSaveTarget.UseVisualStyleBackColor = true;
            btnSaveTarget.Click += btnSaveTarget_Click;
            // 
            // lblWatch
            // 
            lblWatch.AutoSize = true;
            lblWatch.Location = new Point(10, 286);
            lblWatch.Margin = new Padding(4, 0, 4, 0);
            lblWatch.Name = "lblWatch";
            lblWatch.Size = new Size(44, 15);
            lblWatch.TabIndex = 4;
            lblWatch.Text = "Watch:";
            // 
            // lblSave
            // 
            lblSave.AutoSize = true;
            lblSave.Location = new Point(18, 375);
            lblSave.Margin = new Padding(4, 0, 4, 0);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size(31, 15);
            lblSave.TabIndex = 5;
            lblSave.Text = "Save";
            // 
            // btnStartWatcher
            // 
            btnStartWatcher.Location = new Point(15, 407);
            btnStartWatcher.Margin = new Padding(4, 3, 4, 3);
            btnStartWatcher.Name = "btnStartWatcher";
            btnStartWatcher.Size = new Size(130, 27);
            btnStartWatcher.TabIndex = 6;
            btnStartWatcher.Text = "Start watcher";
            btnStartWatcher.UseVisualStyleBackColor = true;
            btnStartWatcher.Click += btnStartWatcher_Click;
            // 
            // txtKey
            // 
            txtKey.Location = new Point(216, 243);
            txtKey.Margin = new Padding(4, 3, 4, 3);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(156, 23);
            txtKey.TabIndex = 7;
            // 
            // btnGenerateKey
            // 
            btnGenerateKey.Location = new Point(255, 286);
            btnGenerateKey.Margin = new Padding(4, 3, 4, 3);
            btnGenerateKey.Name = "btnGenerateKey";
            btnGenerateKey.Size = new Size(117, 27);
            btnGenerateKey.TabIndex = 8;
            btnGenerateKey.Text = "Generate key";
            btnGenerateKey.UseVisualStyleBackColor = true;
            btnGenerateKey.Click += btnGenerateKey_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 215);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 9;
            label1.Text = "Key";
            // 
            // btnSHA1
            // 
            btnSHA1.Location = new Point(241, 14);
            btnSHA1.Margin = new Padding(4, 3, 4, 3);
            btnSHA1.Name = "btnSHA1";
            btnSHA1.Size = new Size(131, 51);
            btnSHA1.TabIndex = 10;
            btnSHA1.Text = "SHA1";
            btnSHA1.UseVisualStyleBackColor = true;
            btnSHA1.Click += btnSHA1_Click;
            // 
            // btnPosaljiFajl
            // 
            btnPosaljiFajl.Location = new Point(241, 90);
            btnPosaljiFajl.Margin = new Padding(4, 3, 4, 3);
            btnPosaljiFajl.Name = "btnPosaljiFajl";
            btnPosaljiFajl.Size = new Size(131, 51);
            btnPosaljiFajl.TabIndex = 11;
            btnPosaljiFajl.Text = "Posalji/Primi fajl";
            btnPosaljiFajl.UseVisualStyleBackColor = true;
            btnPosaljiFajl.Click += btnPosaljiFajl_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 450);
            Controls.Add(btnPosaljiFajl);
            Controls.Add(btnSHA1);
            Controls.Add(label1);
            Controls.Add(btnGenerateKey);
            Controls.Add(txtKey);
            Controls.Add(btnStartWatcher);
            Controls.Add(lblSave);
            Controls.Add(lblWatch);
            Controls.Add(btnSaveTarget);
            Controls.Add(btnWatchFolder);
            Controls.Add(button1);
            Controls.Add(encryptFileBtn);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptFileBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWatchFolder;
        private System.Windows.Forms.Button btnSaveTarget;
        private System.Windows.Forms.Label lblWatch;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Button btnStartWatcher;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSHA1;
        private System.Windows.Forms.Button btnPosaljiFajl;
    }
}

