using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacijaProjekat
{
    public partial class MainForm : Form
    {
        CodeFiles cf;
        private FileSystemWatcher watcher;
        private bool fswEnabled = false;
        public MainForm()
        {
            InitializeComponent();
            InitFSW();
            cf = new CodeFiles();
        }

        private void encryptFileBtn_Click(object sender, EventArgs e)
        {
            EncryptFileForm form2 = new EncryptFileForm();

            form2.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EncryptTextForm form2 = new EncryptTextForm();

            form2.ShowDialog();
        }
        private void InitFSW()
        {
            watcher = new FileSystemWatcher();
            watcher.Filter = "*.*";
            watcher.Created += OnFileCreated;
            watcher.EnableRaisingEvents = false;
        }
        private void btnWatchFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lblWatch.Text = dlg.SelectedPath;
                    watcher.Path = dlg.SelectedPath;
                }
            }
        }
        private async void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            if (!fswEnabled) return;

            await Task.Delay(500);

            this.Invoke((MethodInvoker)(async () =>
            {
                File.AppendAllText("Log.txt", $"Otkriven novi fajl {e.Name}    " + DateTime.Now + "\n");
                MessageBox.Show($"Otkriven fajl: {e.Name}");

                try
                {
                    string outputFile = lblSave.Text;

                    byte[] key = KeyUtils.DeriveKey(txtKey.Text, 16);

                    outputFile = await cf.EncodeFileWithHeaderAsync(
                        e.FullPath,
                        outputFile,
                        key
                    );

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }));
        }

        private void btnSaveTarget_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    if(dlg.SelectedPath == lblWatch.Text)
                    {
                        MessageBox.Show("Ne mozete cuvati novi fajl u istom foledru koji gledate.");
                    }
                    else
                    {
                        lblSave.Text = dlg.SelectedPath;
                    }
            }
        }

        private void btnStartWatcher_Click(object sender, EventArgs e)
        {
            try
            {
                if(lblSave.Text == "Save")
                {
                    MessageBox.Show("Unesite putanje");
                    return;
                }
                fswEnabled = !fswEnabled;
                watcher.EnableRaisingEvents = fswEnabled;

                string status = fswEnabled ? "UKLJUČEN" : "ISKLJUČEN";
                MessageBox.Show($"FSW je {status}");
                if (fswEnabled)
                {
                    btnStartWatcher.Text = "Stop watcher";
                    File.AppendAllText("Log.txt", "FSW startovan   " + DateTime.Now + "\n");
                }
                else
                {
                    btnStartWatcher.Text = "Start watcher";
                    File.AppendAllText("Log.txt", "FSW stopiran   " + DateTime.Now + "\n");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            txtKey.Text = KeyUtils.GenerateReadableKey(16);
        }

        private void btnSHA1_Click(object sender, EventArgs e)
        {
            HashForm form = new HashForm();

            form.ShowDialog();
        }

        private void btnPosaljiFajl_Click(object sender, EventArgs e)
        {
            RazmenaFajlova form = new RazmenaFajlova();

            form.ShowDialog();
        }
    }
}
