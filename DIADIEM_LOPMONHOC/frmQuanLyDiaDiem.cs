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

namespace DIADIEM_LOPMONHOC
{
    public partial class frmQuanLyDiaDiem : Form
    {
        DatabaseDataContext db;
        public frmQuanLyDiaDiem()
        {
            InitializeComponent();
            db = new DatabaseDataContext();

        }
        private void loadNV()
        {
            //HeThong.Func.PhanQuyen.phanQuyenBarManager(this,HeThong.Common.User, barManager1);
            gcMain.DataSource =(from a in db.Khoas
                                select new
                                {
                                    a.ID,
                                    a.TenKhoa,
                                    a.DiaChi,
                                    a.SDT
                                }
                              ).ToList();
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
            var f = new frmAddDiaDiem();
            f.ID = null;
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
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
            var f = new frmAddDiaDiem();
            f.ID = id;
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
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
                if (f == System.Windows.Forms.DialogResult.Yes)
                {
                    var delete = (from a in db.Khoas where a.ID == (int)id_tmp select a).Single();
                    db.Khoas.DeleteOnSubmit(delete);
                    try { db.SubmitChanges(); }
                    catch (Exception) { MessageBox.Show("Xóa không thành công, vui lòng kiểm tra lại."); }
                    loadNV();
                }
            }
        }
    }
}
