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
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace DIADIEM_LOPMONHOC
{
    public partial class frmThemSV : DevExpress.XtraEditors.XtraForm
    {
      /// <summary>
      /// id lớp môn học
      /// </summary>
        public int? ID { get; set; }
        private DatabaseDataContext db;
        public frmThemSV()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            barManager1.SetPopupContextMenu(gcMain, popupMenu1);
          
        }

 
        private void loadMain()
        {
            if (ID != null)
            {
         
                var data = (from sv in db.SinhViens
                            select new
                            {
                                sv.ID,
                                sv.MSV,
                                sv.TenSV,
                                TenKhoa = (from g in db.Khoas where g.ID == sv.IDKhoa select g.TenKhoa).Single(),
                                ThuocLop = (from a in db.SinhVien_LopMonHocs where a.IDSinhVien == sv.ID && a.IDLopMonHoc == ID select a.ID).Count() > 0
                            }).ToList();

                gcMain.DataSource = data;

            }
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        {
            loadMain();   
        }

    
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvMain.GetFocusedRowCellValue("ID") == null)
            {
            }
            else
            {
                int? idsv = (int)gvMain.GetFocusedRowCellValue("ID");
                if (idsv == null) return;
                if ((from a in db.SinhVien_LopMonHocs where a.IDSinhVien == (int)idsv && a.IDLopMonHoc == ID select a).Count() > 0) return;
                SinhVien_LopMonHoc obj = new SinhVien_LopMonHoc();
                obj.IDSinhVien = idsv;
                obj.IDLopMonHoc = ID;
                db.SinhVien_LopMonHocs.InsertOnSubmit(obj);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception)
                {}
                loadMain();
            }
        }

        private void btnLoai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int idsv = (int)gvMain.GetFocusedRowCellValue("ID");
            if ((from a in db.SinhVien_LopMonHocs where a.IDSinhVien == (int)idsv && a.IDLopMonHoc == ID select a).Count()==0)return;
            SinhVien_LopMonHoc obj =  (from a in db.SinhVien_LopMonHocs where a.IDSinhVien == (int)idsv && a.IDLopMonHoc==ID select a).Single();
            db.SinhVien_LopMonHocs.DeleteOnSubmit(obj);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            { }
            loadMain();
        }

        private void gcMain_Click(object sender, EventArgs e)
        {

        }

        private void frmThemSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
