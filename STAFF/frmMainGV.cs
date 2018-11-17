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
namespace STAFF
{
    public partial class frmMainGV : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db;
        public frmMainGV()
        {
            InitializeComponent();
            db = new DatabaseDataContext();

        }
        private void loadNV()
        {
            // HeThong.Func.PhanQuyen.phanQuyenBarManager(this,HeThong.Common.User, barManager1);
            gcMain.DataSource = (from a in db.NhanViens
                                 where a.IsGV.Equals(true)
                                select new
                                {
                                    a.ID,
                                    a.MaNV,
                                    a.TenNV,
                                    a.Tuoi,
                                    GioiTinh=((bool)a.GioiTinh)?"Nam":"Nữ",
                                    a.DiaChi,
                                    Khoa=(from b in db.Khoas where b.ID==a.IDKhoa select b.TenKhoa).Single(),
                                    a.SDT
                                }).ToList();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadNV();
        }

        private void btnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadNV();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmAddGiangVien();
            f.ID = null;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
                loadNV();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = (int?)gvMain.GetFocusedRowCellValue("ID");
            if (id == null)
            {
                MessageBox.Show("Bạn chưa chọn vào hàng cần sửa, vui lòng chọn.");
                return;
            }
            var f = new frmAddGiangVien();
            f.ID = id;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
                loadNV();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvMain.GetFocusedRowCellValue("ID") == null)
            {
                Thongbao.Hoi("Mời bạn chọn hàng cần xóa.");
            }
            else
            {
                int id_tmp = (int)gvMain.GetFocusedRowCellValue("ID");
                DialogResult f = Thongbao._CauHoi();
                if (f == DialogResult.Yes)
                {
                    var delete = (from a in db.NhanViens where a.ID == (int)id_tmp select a).Single();
                    db.NhanViens.DeleteOnSubmit(delete);
                    try { db.SubmitChanges(); }
                    catch (Exception) {
                        HeThong.Thongbao.Loi("Xóa không thành công. Vui lòng thử lại !");
                    }
                    loadNV();
                }
            }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            
        }
    }
}
