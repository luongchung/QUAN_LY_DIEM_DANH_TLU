using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong
{
    public partial class ConfigDiaDiem : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db;
        public ConfigDiaDiem()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? ID = (int)lueDiaDiemCf.EditValue;
            if (ID == null) return;
            bool kt =Common.setIDPhong((int)ID);
            if (kt) HeThong.Thongbao.Canhbao("Cấu hình thành công !");
            else Thongbao.Canhbao("Thất bại !");
        }

        private void ConfigDiaDiem_Load(object sender, EventArgs e)
        {
            lueDiaDiemCf.Properties.DataSource = (from a in db.DiaDiemHocs
                                                  select new
                                                  {
                                                      a.ID,
                                                      a.TenDiaDiem,
                                                      a.KhuNha
                                                  }).ToList();
            lueDiaDiemCf.EditValue = Common.getIDPhong();
        }
    }
}
