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
            if (db.GetLopMonHocTheoDiaDiem(HeThong.Common.getIDPhong()).Count() <= 0)
            {
                HeThong.Thongbao.Canhbao("Hiện không có lớp nào!" + HeThong.Common.getIDPhong());
                return;
            }
            if (checkvali_null()) return;

            int? tmp = null;
            tmp = (from a in db.GetLopMonHocTheoDiaDiem(HeThong.Common.getIDPhong())
                   select a.ID).Single();

            int? idsv = null;
            if (db.SinhViens.Where(p => p.MSV.Equals(txtMSV.Text)).Count() > 0)
            {
                idsv = (from a in db.SinhViens
                        where a.MSV.Equals(txtMSV.Text)
                        select a.ID).Single();
            }
            else
            {
                HeThong.Thongbao.Canhbao("Mã sinh viên nhập không đúng !");
                return;
            }
           
            if (tmp == null || idsv == null) return;

            obj.IDBuoiHoc = tmp;
            obj.IDSinhVien = idsv;
            obj.DenLop = true;
            db.DiemDanhs.InsertOnSubmit(obj);
            try
            {
                db.SubmitChanges();
                HeThong.Thongbao.ThanhCong("Điểm danh thành công !");
            }
            catch (Exception)
            {
                HeThong.Thongbao.Canhbao("Điểm danh không thành công !");
            }
            txtMSV.Text = "";

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
