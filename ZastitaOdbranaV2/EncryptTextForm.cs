using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacijaProjekat
{
    public partial class EncryptTextForm : Form
    {
        CodeFiles cf;
        Bifid bf;
        public EncryptTextForm()
        {
            InitializeComponent();
            cf = new CodeFiles();
            bf = new Bifid();
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            txtKey.Text = cf.SecureRandomString(25);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtIzlaz.Text = bf.EncryptText(txtUnos.Text, txtKey.Text, Convert.ToInt32(numSpace.Value));
        }

        private void btnnDecrypt_Click(object sender, EventArgs e)
        {
            txtIzlaz.Text = bf.DecryptText(txtUnos.Text, txtKey.Text, Convert.ToInt32(numSpace.Value));
        }
    }
}
