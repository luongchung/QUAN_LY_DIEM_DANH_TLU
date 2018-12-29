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
using Quobject.SocketIoClientDotNet.Client;

namespace AppMain
{
    public partial class frm_ShowMain : Form
    {
        //  private int? ID_tmp=null;
        private string IDPhong;
        DatabaseDataContext db;
        public frm_ShowMain()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            //var socket = IO.Socket("http://localhost:996");
            //socket.On(Socket.EVENT_CONNECT, () =>
            //{
            //    socket.Emit("huhu","Tao là Chung");
            //});
            //socket.On(Socket.EVENT_CONNECT_ERROR, () => {
            //    HeThong.Thongbao.Loi("Server Nodejs không hoạt đông");
            //});
            
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
            IDPhong = HeThong.Common.getIDPhong().ToString();
            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(IDPhong));
            imgBarcode.Image = result;

            txtPhong.Text = (from a in db.DiaDiemHocs where a.ID == int.Parse(IDPhong) select a.TenDiaDiem).Single().ToString();
            lueLopMonHoc.Properties.DataSource = db.getDSLopHocTheoNgay(int.Parse(IDPhong));
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

        private void lueLopMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLopMonHoc.EditValue == null) return;
            lueBuoiHoc.Properties.DataSource = (from a in db.BuoiHocs
                                                where a.IDLopMonHoc == (int)lueLopMonHoc.EditValue
                                                select new
                                                {
                                                    a.ID,
                                                    a.TenBuoiHoc
                                                }).ToList();
        }

        private void btnNap_Click(object sender, EventArgs e)
        {
            if (lueBuoiHoc.EditValue == null) return;
            gcSV.DataSource = db.getSVtheoIDBuoi(int.Parse(lueBuoiHoc.EditValue.ToString()));
        }

        private void gvSV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void imgBarcode_DoubleClick(object sender, EventArgs e)
        {
            var fm =new MANAGER_TLU_MAIN.frmQR();
            fm.ShowDialog();
        }

        private void imgBarcode_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
