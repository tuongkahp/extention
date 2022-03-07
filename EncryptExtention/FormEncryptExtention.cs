using EncryptExtention;
using QRCoder;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Extentions
{
    public partial class FormEncryptExtention : Form
    {
        private readonly string _txtKeyPlaceHolder;

        public FormEncryptExtention()
        {
            InitializeComponent();
            _txtKeyPlaceHolder = "Use another aes encrypt key";
        }

        private void FormEncryptExtention_Load(object sender, EventArgs e)
        {
            lblResult.Text = "";
            txtKey.Text = _txtKeyPlaceHolder;
            txtKey.ForeColor = Color.Silver;
            txtInput.Select();
            txtOutput.MaxLength = int.MaxValue;
            txtInput.MaxLength = int.MaxValue;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            var output = "";

            if (rdbAES.Checked)
            {
                output = AesHelper.Encrypt(txtInput.Text, GetKey());
            }
            else if (rdb3Des.Checked)
            {
                if (ckbIsCBCMode.Checked)
                {
                    output = DesSecurity.IRIS_encrypt(GetKey(), txtInput.Text);
                }
                else
                {
                    output = TrippleDesHelper.Encrypt(txtInput.Text, GetKey());
                }
            }
            else if (rdbMd5.Checked)
            {
                output = Md5Helper.Md5(txtInput.Text);
            }
            else if (rdbRsaAes.Checked)
            {
                output = RsaAes.ProcessDataEncryption(txtInput.Text);
            }

            if (string.IsNullOrEmpty(output))
            {
                lblResult.Text = "Invalid Data";
                return;
            }

            txtOutput.Text = output;
            lbOutputLength.Text = txtOutput.Text.Length.ToString();
            Clipboard.SetText(output);
            lblResult.Text = "Output copied to clipboad";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            var output = "";

            if (rdbAES.Checked)
            {
                output = AesHelper.Decrypt(txtInput.Text, GetKey());
            }
            else if (rdb3Des.Checked)
            {
                if (ckbIsCBCMode.Checked)
                {
                    output = DesSecurity.IRIS_decrypt(GetKey(), txtInput.Text);
                }
                else
                {
                    output = TrippleDesHelper.Decrypt(txtInput.Text, GetKey());
                }
            }
            else if (rdbRsaAes.Checked)
            {
                output = RsaAes.ProcessDataDecryption(txtInput.Text);
            }

            if (string.IsNullOrEmpty(output))
            {
                lblResult.Text = "Invalid Data";
                return;
            }

            txtOutput.Text = output;
            lbOutputLength.Text = txtOutput.Text.Length.ToString();
            Clipboard.SetText(output);
            lblResult.Text = "Output copied to clipboad";

            renderQrCode(txtOutput.Text);
        }

        private void FormEncryptExtention_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtKey_Enter(object sender, EventArgs e)
        {
            if (txtKey.Text == _txtKeyPlaceHolder)
            {
                txtKey.Text = "";
                txtKey.ForeColor = Color.Black;
            }
        }

        private void txtKey_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                txtKey.Text = _txtKeyPlaceHolder;
                txtKey.ForeColor = Color.Silver;
            }
        }

        public string GetKey()
        {
            if (string.IsNullOrEmpty(txtKey.Text) || txtKey.Text == _txtKeyPlaceHolder)
            {
                return null;
            }

            return txtKey.Text;
        }

        private void btnStringLength_Click(object sender, EventArgs e)
        {
            txtOutput.Text = txtInput.Text.Length.ToString();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            lbInputLength.Text = txtInput.Text.Length.ToString();
            if (picQr.Image != null) picQr.Image = null;
        }

        private void cbkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkShowPass.Checked) txtKey.PasswordChar = '\0';
            else txtKey.PasswordChar = '*';
        }

        private void renderQrCode(string str)
        {
            // Create qrcode
            var qrGenerator = new QRCodeGenerator();
            var qrCode = new QRCode(qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q));
            //QRCodeGenerator.ECCLevel.Q là mức chịu lỗi 25%; .L là 7%; .M là 15% và .H là trên 25%
            picQr.Image = qrCode.GetGraphic(10, Color.Black, Color.White, false);
            qrGenerator.Dispose();
            qrCode.Dispose();
        }
    }
}