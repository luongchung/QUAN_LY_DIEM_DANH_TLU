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
    public partial class frmQuanLyDiemDanh : Form
    {
        private int IDphong;
        DatabaseDataContext db;
        public frmQuanLyDiemDanh()
        {
            InitializeComponent();
            IDphong = HeThong.Common.getIDPhong();
            db = new DatabaseDataContext();
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
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (lueBuoiHoc.EditValue == null) return;
            gcMain.DataSource = (from a in db.getSVtheoIDBuoi((int)lueBuoiHoc.EditValue) select a).ToList();
        }

        private void frmQuanLyDiemDanh_Load(object sender, EventArgs e)
        {
            loadDanhSach();
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

        private void gvMain_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
    }
}
