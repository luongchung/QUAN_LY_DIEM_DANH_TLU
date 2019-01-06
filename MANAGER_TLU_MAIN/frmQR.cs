using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using HeThong;

namespace MANAGER_TLU_MAIN
{
    public partial class frmQR : DevExpress.XtraEditors.XtraForm
    {
        public String chuoi { get; set; }
        public frmQR()
        {
            InitializeComponent();
        }

        private void frmQR_Load(object sender, EventArgs e)
        {
            loadQR();
        }
        private void loadQR()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = this.Width,
                Height = this.Height,
            };
            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(chuoi));
            imgBarcode.Image = result;
        }
    }
}
