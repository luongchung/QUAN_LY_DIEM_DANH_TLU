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

namespace STUDENT
{
    public partial class frmAddSinhVien : DevExpress.XtraEditors.XtraForm
    {
        public int? ID { get; set; }
        private SinhVien obj;
        private DatabaseDataContext db;
        public frmAddSinhVien()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new SinhVien();
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        {
            lueKhoa.Properties.DataSource = (from a in db.Khoas select a).ToList();
            if (ID != null)
            {
                txtMaNV.Enabled = false;
                obj = db.SinhViens.Single(p => p.ID == ID);
                txtMaNV.Text = obj.MSV;
                txtHVT.Text = obj.TenSV;
                txtNgaySinh.Text = obj.NgaySinh.ToString();
                txtDiaChi.Text = obj.DiaChi;
                ckNam.Checked =(bool) obj.GioiTinh;
                ckNu.Checked = !ckNam.Checked;
                lueKhoa.EditValue = obj.IDKhoa;
            }
         
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                HeThong.Func.UserLogin lg = new HeThong.Func.UserLogin();
                if (checkvali_null()) return;
                obj.MSV = txtMaNV.Text;
                obj.TenSV = txtHVT.Text;
                obj.NgaySinh = DateTime.Parse(txtNgaySinh.Text.ToString());
                obj.DiaChi = txtDiaChi.Text;
                obj.GioiTinh = ckNam.Checked;
                obj.IDKhoa = (int)lueKhoa.EditValue;
                db.SinhViens.InsertOnSubmit(obj);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    HeThong.Thongbao.Canhbao(ex.ToString());
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                if (checkvali_null()) return;
                obj.MSV = txtMaNV.Text;
                obj.TenSV = txtHVT.Text;
                obj.NgaySinh = DateTime.Parse(txtNgaySinh.Text.ToString());
                obj.DiaChi = txtDiaChi.Text;
                obj.GioiTinh = ckNam.Checked;
                obj.IDKhoa = (int)lueKhoa.EditValue;
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    HeThong.Thongbao.Canhbao(ex.ToString());
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        private bool checkvali_null()
        {
            if (String.IsNullOrEmpty(txtMaNV.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập mã sinh viên. xin mời nhập !");
                return true;
            }
            if (String.IsNullOrEmpty(txtHVT.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập tên sinh viên. xin mời nhập !");
                return true;
            }
            if (String.IsNullOrEmpty(lueKhoa.EditValue.ToString()))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa chọn khoa. xin mời chọn !");
                return true;
            }
            return false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckNu_CheckedChanged(object sender, EventArgs e)
        {
            ckNam.Checked = !ckNu.Checked;
        }

        private void ckNam_CheckedChanged(object sender, EventArgs e)
        {
            ckNu.Checked = !ckNam.Checked;
          
        }

   
    }
}
