using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacijaProjekat
{
    public partial class EncryptFileForm : Form
    {
        CodeFiles cf;
        public EncryptFileForm()
        {
            cf = new CodeFiles();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            DialogResult result = file.ShowDialog();
            if(result == DialogResult.OK)
            {
                txtFile.Text = file.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFileDest.Text = folder.SelectedPath;
            }
        }

        private async void btnSifra_Click(object sender, EventArgs e)
        {
            string input = txtFile.Text;
            string outPut = txtFileDest.Text;
            
            try
            {
                await cf.EncodeFileWithHeaderAsync(input, outPut, KeyUtils.DeriveKey(kljucText.Text, 16));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDesifruj_Click(object sender, EventArgs e)
        {
            string input = txtFile.Text;
            string outPut = txtFileDest.Text;
            try
            {
                await cf.DecodeFileWithHeaderAsync(input, outPut, KeyUtils.DeriveKey(kljucText.Text, 16));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kljucText.Text = cf.SecureRandomString();
        }
        
    }
}
