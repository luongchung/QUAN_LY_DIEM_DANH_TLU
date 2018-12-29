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

namespace DIEMDANH
{
    public partial class frmTracuuDiemDanh : Form
    {
        DatabaseDataContext db;
        public frmTracuuDiemDanh()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
        }

        private void frmTracuuDiemDanh_Load(object sender, EventArgs e)
        {
            loadDanhSach();
        }
        private void loadDanhSach()
        {
            lueLopMonHoc.Properties.DataSource = (from a in db.LopMonHocs
                                                  where a.IsKT == false
                                                  select new
                                                  {
                                                      a.ID,
                                                      a.MaLopMonHoc,
                                                      TenMonHoc = a.TenLopMonHoc,
                                                      GiangVien = (from b in db.NhanViens where b.ID.Equals(a.IDGiangVien) select b.TenNV).Single(),
                                                      KetThuc = a.IsKT
                                                  }).ToList();

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            int? idSV = null;
            try
            {
                idSV = (from sv in db.SinhViens where sv.MSV.Equals(txtMSV.Text.ToString()) select sv.ID).Single();
            }
            catch (Exception)
            {
                idSV = null;
            }
      
          
            if (idSV==null || lueLopMonHoc.EditValue==null) return;
            gcMain.DataSource = (from a in db.getTTDiemDanh(idSV.ToString(), lueLopMonHoc.EditValue.ToString())
                                 select new
                                 {
                                     a.ID,
                                     a.NgayHoc,
                                     a.TenBuoiHoc,
                                     a.GhiChu,
                                     a.TenDiaDiem,
                                     a.TGDiemDanh,
                                     a.CoMat
                                 }).ToList();
        }
    }
}
