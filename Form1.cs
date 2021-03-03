using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace Square_Code_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = KareKodOlustur(textBox1.Text);
        }

        private Image KareKodOlustur(string veri)
        {
            MessagingToolkit.QRCode.Codec.QRCodeEncoder qe = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            qe.QRCodeVersion = 4;
            System.Drawing.Bitmap bm = qe.Encode(veri);
            return bm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string veri = KareKodOku(pictureBox1.Image);
            label2.Text = veri;
        }

        private string KareKodOku(Image img)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            string metin = decoder.Decode(new QRCodeBitmapImage(img as Bitmap));
            return metin;
        }
    }
}
