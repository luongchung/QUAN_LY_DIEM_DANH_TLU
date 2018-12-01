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
    public partial class frmQuanLyLopMonHoc : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db;
        public frmQuanLyLopMonHoc()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
        


        }
     
        private void loadNV()
        {
            //HeThong.Func.PhanQuyen.phanQuyenBarManager(this,HeThong.Common.User, barManager1);
            gcMain.DataSource = (from a in db.LopMonHocs
                                 select new
                                 {
                                     a.ID,
                                     a.MaLopMonHoc,
                                     TenMonHoc = a.TenLopMonHoc,
                                     GiangVien = (from b in db.NhanViens where b.ID.Equals(a.IDGiangVien) select b.TenNV).Single(),
                                     KetThuc = a.IsKT
                                }
                                ).ToList();
            var id = (int?)gvMain.GetFocusedRowCellValue("ID");
            if (id == null) return;
            loadThongTin(id);
            loadDanhSachLopHoc(id);
            loadDanhSachSinhVien(id);
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
            var f = new frmAddLopMonHoc();
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
                Thongbao.Hoi("Bạn chưa chọn vào hàng cần sửa, vui lòng chọn.");
                return;
            }
            var f = new frmAddLopMonHoc();
            f.ID = id;
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                loadNV();
                loadThongTin(id);
            }
                
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
                    catch (Exception) { Thongbao.Hoi("Xóa không thành công, vui lòng kiểm tra lại."); }
                    loadNV();
                }
            }
        }

        private void gcMain_Click(object sender, EventArgs e)
        {

        }

        private void gvMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var id = (int?)gvMain.GetFocusedRowCellValue("ID");
            if (id == null)return;
            loadThongTin(id);
            loadDanhSachLopHoc(id);
            loadDanhSachSinhVien(id);
        }
        private void loadDanhSachLopHoc(int? _id)
        {
            gcBuoiHoc.DataSource = (from a in db.BuoiHocs
                                    where a.IDLopMonHoc.Equals(_id)
                                    select new
                                    {
                                        a.ID,
                                        a.TenBuoiHoc,
                                        TietHoc=(from t1 in db.ThoiGianTietHocs where t1.ID==a.IDTietBatDau select "Từ tiết "+t1.TenTiet).Single().ToString()+
                                                         (from t2 in db.ThoiGianTietHocs where t2.ID == a.IDTietKetThuc select "-->"+t2.TenTiet).Single().ToString()
                                                         ,
                                        a.NgayHoc,
                                        a.GhiChu,
                                        DiaDiem = (from b in db.DiaDiemHocs where b.ID.Equals(a.IDDiaDiem) select b.TenDiaDiem).SingleOrDefault()
                                    }).ToList();
        }
        private void loadDanhSachSinhVien(int? _id)
        {
            gcSinhVienLop.DataSource = (from a in db.SinhVien_LopMonHocs
                                        join sv in db.SinhViens on a.IDSinhVien equals sv.ID
                                        where a.IDLopMonHoc.Equals(_id)
                                        select new
                                        {
                                            sv.ID,
                                            sv.TenSV,
                                            sv.MSV,
                                            TenKhoa=(from b in db.Khoas where b.ID.Equals(sv.IDKhoa) select b.TenKhoa).Single()       
                                        }).ToList();
        }
        private void loadThongTin(int? id)
        {
            var obj = (from k in db.LopMonHocs
                       where id == k.ID
                       select new
                       {
                           k.ID,
                           k.GhiChu,
                           k.IDGiangVien,
                           k.IsKT,
                           k.MaLopMonHoc,
                           k.NhanVien,
                           k.SinhVien_LopMonHocs,
                           k.SoTinChi,
                           k.TenLopMonHoc,
                           k.TongSoTiet
                       }).Single();
            txtManLopMonHoc.Text = obj.MaLopMonHoc;
            txtTenLopMonHoc.Text = obj.TenLopMonHoc;
            txtTongSoTiet.Text = obj.TongSoTiet.ToString();
            txtSTC.Text = obj.SoTinChi.ToString();
            txtGhiChu.Text = obj.GhiChu;
            txtGiangVien.Text = (from a in db.NhanViens where a.ID.Equals(obj.IDGiangVien) select a.TenNV).SingleOrDefault();
        }

        private void gvBuoiHoc_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void gvSinhVienLop_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if(e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
    }
}
