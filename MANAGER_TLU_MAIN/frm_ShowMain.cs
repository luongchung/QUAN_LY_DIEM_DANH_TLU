using HeThong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;

namespace AppMain
{
    public partial class frm_ShowMain : Form
    {
      //  private int? ID_tmp=null;
        DatabaseDataContext db;
        public frm_ShowMain()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
        }

        private void frm_ShowMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }


        private void loadData()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 800,
                Height = 800,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;



            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write("ID:18567987  FB:17247234723"));
            imgBarcode.Image = result;
        }

        private void frm_ShowMain_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void gvLoai_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
