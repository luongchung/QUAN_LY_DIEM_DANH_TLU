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
    public partial class frmAddDiemDanh : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db;
        DiemDanh obj;
        public frmAddDiemDanh()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new DiemDanh();
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            //if (db.GetLopMonHocTheoDiaDiem(HeThong.Common.getIDPhong()).Count() <= 0)
            //{
            //    HeThong.Thongbao.Canhbao("Hiện không có lớp nào!"+ HeThong.Common.getIDPhong());
            //    return;
            //}
            //int tmp = int.Parse((from a in db.GetLopMonHocTheoDiaDiem(HeThong.Common.getIDPhong()) select new {
            //    a.ID
            //}).Single().ToString());

            //if (checkvali_null()) return;
            //obj.IDBuoiHoc = tmp;
            //obj.IDSinhVien = int.Parse(txtMSV.Text.ToString());
            //db.DiemDanhs.InsertOnSubmit(obj);
            //try
            //{
            //    db.SubmitChanges();
            //    HeThong.Thongbao.Canhbao("Điểm danh thành công !");
            //}
            //catch (Exception)
            //{
            //    HeThong.Thongbao.Canhbao("Điểm danh không thành công !");
            //}
            //txtMSV.Text = "";

        }
        private bool checkvali_null()
        {
            if (String.IsNullOrEmpty(txtMSV.Text))
            {
                HeThong.Thongbao.Canhbao("Mã sinh viên trống!");
                return true;
            }
            return false;

        }
    }
}
