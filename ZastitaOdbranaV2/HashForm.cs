using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacijaProjekat
{
    public partial class HashForm : Form
    {
        public HashForm()
        {
            InitializeComponent();
        }

        private void btnIzaberiFajl_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            DialogResult result = file.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblLoc.Text = file.FileName;
            }
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblLoc.Text) || !File.Exists(lblLoc.Text))
            {
                MessageBox.Show("Izaberite validan fajl.");
                return;
            }

            SHA1Impl sha1 = new SHA1Impl();

            using (FileStream fs = new FileStream(lblLoc.Text, FileMode.Open, FileAccess.Read))
            {
                byte[] hash = (sha1.ComputeHash(fs));

                textBox1.Text = BitConverter
                    .ToString(hash)
                    .Replace("-", "")
                    .ToLower();
            }
        }
    }
}
