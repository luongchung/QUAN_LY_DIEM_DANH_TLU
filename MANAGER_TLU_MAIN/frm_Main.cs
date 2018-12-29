using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThong;
using DevExpress.XtraReports.UI;
using Excel = Microsoft.Office.Interop.Excel;

namespace AppMain
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db;
        public NhanVien  User;
        public frm_Main()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            LoadForm(new frm_ShowMain());
            LoadForm(new DIEMDANH.frmQuanLyDiemDanh());

        }
        private void btnPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new HeThong.frmPhanQuyen());
        }
        public void LoadForm(Form frm)
        {
            for (int i = 0; i < pageMain.Pages.Count; i++)
            {
                if (String.Compare(pageMain.Pages[i].Text, frm.Text.ToUpper(), false) != 0)
                    continue;

                pageMain.SelectedPage = pageMain.Pages[i];
                return;
            }
            frm.Text = frm.Text.ToUpper();
            frm.MdiParent = this;
            frm.Show();
        }
        private void btnQLCanHo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new STUDENT.frmQuanLySinhVien());
        }
        private void btnQLNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new STAFF.frmMain());
        }
        private void btnLoaiDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        private void btnThemDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new QL_DichVu.frmaddDV();
            //f.ID = null;
            //f.ShowDialog();
            //if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            //    load();
        }
        private void btnDSDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //LoadForm(new QL_DichVu.frmDV_Main());
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            
            
            //Phân quyền
          //  HeThong.Func.PhanQuyen.phanQuyenRibon(this, Common.User, ribbon);
            //set không cho đóng tab
            HeThong.Common.IsClose = false;
          
         
         
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {


            //var h = Thongbao._CauHoi("Bạn có muốn đóng phần mềm không?");
            //if (h == DialogResult.OK)
            //{
            //    this.Close();
            //}

        }
        private void btnDangXuat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.Common.User = null;
            Application.Restart();
        }
        private void btnKichHoatTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new HeThong.frmKichHoatTK();
            f.ShowDialog();
            //if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            //    load();
        }
        private void btnTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new HeThong.frmThongTinTaiKhoan();
            f.ShowDialog();
        }
        private void btn_DoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new HeThong.frmChagePass();
            f.ShowDialog();
        }
        private void btnKhoiPhucPass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new HeThong.KhoiPhucPass();
            f.ShowDialog();
        }
        private void btnToaHD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //LoadForm(new HoaDon.frmTaoHoaDon());
        }
        private void btnQLHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //LoadForm(new HoaDon.frmQLHoaDon());
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

         
        }
        private void btnTaoBC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
        }
        private void btnQLNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new STAFF.frmMain());
        }
        private void btnShowFormLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //show form login
            fromLogin frm = new HeThong.fromLogin();
            frm.ShowDialog();
            if (frm.DialogResult != DialogResult.OK) { return; }
            Common.User = frm.UsersLogin;
            //Phân quyền
            HeThong.Func.PhanQuyen.phanQuyenRibon(this, Common.User, ribbon);
        }

        private void btnQLGV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new STAFF.frmMainGV());
        }

        private void btnQLKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new KHOA.frmQuanLyKhoa());
        }

        private void btnqlThoigiantiethoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new DIADIEM_LOPMONHOC.frmQuanLyTG());
        }

        private void btnQLDiaDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new DIADIEM_LOPMONHOC.frmQuanLyDiaDiem());
        }

        private void btnNhapSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btnQLLopMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new DIADIEM_LOPMONHOC.frmQuanLyLopMonHoc());
        }

        private void btnQLSVLopMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new DIADIEM_LOPMONHOC.frmQLSVLopMonHoc());
        }

        private void btnQLLapLich_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new LAPLICH.frmQLLapLich());
        }

        private void btnTraCuuLapLich_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new LAPLICH.frmLapLich());
        }

        private void btnConfigAd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ConfigDiaDiem obj = new ConfigDiaDiem();
            obj.ShowDialog();
        }

        private void btnTrangchuDiemDanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new frm_ShowMain());
        }

        private void btnDiemDanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tmp = new DIEMDANH.frmAddDiemDanh();
            tmp.Show();
        }

        private void btnQuanLyDiemDanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new DIEMDANH.frmQuanLyDiemDanh());
        }

     
    }
}
