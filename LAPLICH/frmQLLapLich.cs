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
namespace LAPLICH
{
    public partial class frmQLLapLich : Form
    {
        DatabaseDataContext db;
        public frmQLLapLich()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            barManager1.SetPopupContextMenu(gcBuoiHoc, popupMenuQLBuoiHoc);
        }

        private void frmQLLapLich_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            gcLopMonHoc.DataSource = (from a in db.LopMonHocs
                                      where a.IsKT == false
                                      select new
                                      {
                                          a.ID,
                                          MaLop = a.MaLopMonHoc,
                                          TenLop = a.TenLopMonHoc,
                                          TenGV = (from b in db.NhanViens where b.ID == a.IDGiangVien select b.TenNV).Single(),
                                          a.TongSoTiet
                                      }).ToList();
        }

        private void gvLopMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var id = (int?)gvLopMonHoc.GetFocusedRowCellValue("ID");
            if (id == null) return;
            loadBuoiHoc();
        }

        private void loadBuoiHoc()
        {
            var id = (int?)gvLopMonHoc.GetFocusedRowCellValue("ID");
            gcBuoiHoc.DataSource = (from a in db.BuoiHocs
                                    where a.IDLopMonHoc.Equals(id)
                                    select new
                                    {
                                        a.ID,
                                        a.TenBuoiHoc,
                                        TietBD = (from t1 in db.ThoiGianTietHocs where t1.ID == a.IDTietBatDau select t1.TenTiet).Single().ToString(),
                                        TietKT = (from t2 in db.ThoiGianTietHocs where t2.ID == a.IDTietKetThuc select t2.TenTiet).Single().ToString(),
                                        a.NgayHoc,
                                        a.GhiChu,
                                        DiaDiem = (from b in db.DiaDiemHocs where b.ID.Equals(a.IDDiaDiem) select b.TenDiaDiem).SingleOrDefault()
                                    }).ToList();
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var idLopMonHoc = (int?)gvLopMonHoc.GetFocusedRowCellValue("ID");
            if (idLopMonHoc == null) return;
            var f = new frmAddLapLich();
            f.ID = null;
            f.IDLopMonHoc = idLopMonHoc;
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                loadBuoiHoc();
        }

        private void btn_Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = (int?)gvBuoiHoc.GetFocusedRowCellValue("ID");
            var idLopMonHoc = (int?)gvLopMonHoc.GetFocusedRowCellValue("ID");
            if (id == null)
            {
                MessageBox.Show("Bạn chưa chọn vào hàng cần sửa, vui lòng chọn.");
                return;
            }
            var f = new frmAddLapLich();
            f.ID = id;
            f.IDLopMonHoc = idLopMonHoc;
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                loadBuoiHoc();
        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (gvBuoiHoc.GetFocusedRowCellValue("ID") == null)
            {
                Thongbao.Hoi("Mời bạn chọn hàng cần xóa.");
            }
            else
            {
                int id_tmp = (int)gvBuoiHoc.GetFocusedRowCellValue("ID");
                DialogResult f = Thongbao._CauHoi();
                if (f == System.Windows.Forms.DialogResult.Yes)
                {
                    var delete = (from a in db.BuoiHocs where a.ID == (int)id_tmp select a).Single();
                    db.BuoiHocs.DeleteOnSubmit(delete);
                    try { db.SubmitChanges(); }
                    catch (Exception) { MessageBox.Show("Xóa không thành công, vui lòng kiểm tra lại."); }
                    loadBuoiHoc();
                }
            }
        }

        private void btnNap1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadBuoiHoc();
        }
    }
}
