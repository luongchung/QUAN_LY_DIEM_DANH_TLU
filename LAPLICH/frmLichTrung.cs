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
    public partial class frmLichTrung : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db;
        public int IDChinh { get; set; }
        public int IDTietBatDau { get; set; }
        public int IDTietKetThuc { get; set; }
        public int IDDiaDiem { get; set; }
        public DateTime NgayHoc { get; set; }
        public frmLichTrung()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
        }

        private void frmLichTrung_Load(object sender, EventArgs e)
        {
            gcTrung.DataSource = from a in db.tranhtrunglich(IDDiaDiem, IDTietBatDau, IDTietKetThuc, NgayHoc)
                                 where a.ID != IDChinh
                                 select new
                                 {
                                     a.NgayHoc,
                                     a.TenBuoiHoc,
                                     TenLopMonHoc = (from dd in db.LopMonHocs where dd.ID == a.IDLopMonHoc select dd.TenLopMonHoc).Single(),
                                     TenDiaDiem =(from dd in db.DiaDiemHocs where dd.ID==a.IDDiaDiem select dd.TenDiaDiem).Single(),
                                     TietBatDau = (from dd in db.ThoiGianTietHocs where dd.ID == a.IDTietBatDau select dd.TenTiet).Single(),
                                     TietKetThuc = (from dd in db.ThoiGianTietHocs where dd.ID == a.IDTietKetThuc select dd.TenTiet).Single(),
                                 };
        }
    }
}
