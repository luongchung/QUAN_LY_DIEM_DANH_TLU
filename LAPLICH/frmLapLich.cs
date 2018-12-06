using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using HeThong;

namespace LAPLICH
{
    public partial class frmLapLich : DevExpress.XtraEditors.XtraForm
    {
        int? IDLop=null;
        DatabaseDataContext db;
        public frmLapLich()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
        }

        private void frmLapLich_Load(object sender, EventArgs e)
        {
            
            lue.Properties.DataSource= (from a in db.LopMonHocs
                                        where a.IsKT == false
                                        select new
                                        {
                                            a.ID,
                                            MaLop = a.MaLopMonHoc,
                                            TenLop = a.TenLopMonHoc
                                        }).ToList();
        }
        private void load() {
            for (int i = 0; i < 10; i++)
            {
                flowAllLich.Controls.Add(new TimeDay());
            }
        }

        private void lue_EditValueChanged(object sender, EventArgs e)
        {
           
            IDLop = (int)lue.EditValue;
            if (IDLop == null) return;
            LoadTietHoc();
        }
        private void LoadTietHoc()
        {
           flowAllLich.Controls.Clear();
           var list= (from a in db.BuoiHocs
             where a.IDLopMonHoc.Equals(IDLop)
             select new
             {
                 a.ID,
                 a.TenBuoiHoc,
                 TietBD= (from t1 in db.ThoiGianTietHocs where t1.ID == a.IDTietBatDau select  t1.N).Single().ToString() ,
                 TietKT= (from t2 in db.ThoiGianTietHocs where t2.ID == a.IDTietKetThuc select t2.N).Single().ToString(),
                 a.NgayHoc,
                 a.GhiChu,
                 DiaDiem = (from b in db.DiaDiemHocs where b.ID.Equals(a.IDDiaDiem) select b.TenDiaDiem).SingleOrDefault()
             }).ToList();
            var arrT = (from a in db.ThoiGianTietHocs select a).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                flowAllLich.Controls.Add(new TimeDay(list[i].ID, list[i].TenBuoiHoc, String.Format("{0:dddd dd/MM/yyyy}", list[i].NgayHoc), int.Parse(list[i].TietBD), int.Parse(list[i].TietKT)
                , list[i].DiaDiem, list[i].GhiChu, arrT));
            }
        }
    }
}
