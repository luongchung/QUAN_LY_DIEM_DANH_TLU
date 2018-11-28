﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HeThong;

namespace DIADIEM_LOPMONHOC
{
    public partial class frmQLSVLopMonHoc : DevExpress.XtraEditors.XtraForm
    {
        private int? IDLop=null;
        DatabaseDataContext db;
        public frmQLSVLopMonHoc()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            //sự kiện thay đổi giá trị lớp môn học
            lueDSLop.EditValueChanged += LueDSLop_EditValueChanged;

        }
       

        private void LueDSLop_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lEdit = sender as LookUpEdit;
            IDLop = (int)lEdit.EditValue;
            LoadSVfromLop();
        }
        private void LoadSVfromLop()
        {
            if (IDLop == null) return;
            gcMain.DataSource = (from sv in db.SinhViens
                                 join tmp in db.SinhVien_LopMonHocs on sv.ID equals tmp.IDSinhVien
                                 where tmp.IDLopMonHoc.Equals(IDLop)
                                 select new
                                 {
                                     sv.ID,
                                     sv.MSV,
                                     sv.TenSV,
                                     TenKhoa = (from a in db.Khoas where a.ID == sv.IDKhoa select a.TenKhoa).Single()
                                }).ToList();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lueDSLop.DataSource = (from a in db.LopMonHocs
                                   where a.IsKT == false
                                   select new
                                   {
                                       a.ID,
                                       MaLop=a.MaLopMonHoc,
                                       TenLop=a.TenLopMonHoc
                                   }).ToList();
            LoadSVfromLop();
        }

        private void btnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new frmAddTG();
            //f.ID = null;
            //f.ShowDialog();
            //if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            //    loadNV();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var id = (int?)gvMain.GetFocusedRowCellValue("ID");
            //if (id == null)
            //{
            //    MessageBox.Show("Bạn chưa chọn vào hàng cần sửa, vui lòng chọn.");
            //    return;
            //}
            //var f = new frmAddTG();
            //f.ID = id;
            //f.ShowDialog();
            //if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            //    loadNV();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gvMain.GetFocusedRowCellValue("ID") == null)
            //{
            //    Thongbao.Hoi("Mời bạn chọn hàng cần xóa.");
            //}
            //else
            //{
            //    int id_tmp = (int)gvMain.GetFocusedRowCellValue("ID");
            //    DialogResult f = Thongbao._CauHoi();
            //    if (f == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        var delete = (from a in db.ThoiGianTietHocs where a.ID == (int)id_tmp select a).Single();
            //        db.ThoiGianTietHocs.DeleteOnSubmit(delete);
            //        try { db.SubmitChanges(); }
            //        catch (Exception) { MessageBox.Show("Xóa không thành công, vui lòng kiểm tra lại."); }
            //        loadNV();
            //    }
            //}
        }

 
    }
}