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

namespace STAFF
{
    public partial class frmAddGiangVien : DevExpress.XtraEditors.XtraForm
    {
        public int? ID { get; set; }
        private NhanVien obj;
        private DatabaseDataContext db;
        public frmAddGiangVien()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new NhanVien();
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        {
            lueKhoa.Properties.DataSource = (from a in db.Khoas select a).ToList();
            if (ID != null)
            {
                txtMaNV.Enabled = false;
                obj = db.NhanViens.Single(p => p.ID == ID);
                txtMaNV.Text = obj.MaNV;
                txtHVT.Text = obj.TenNV;
                txtSDT.Text = obj.SDT;
                txtDiaChi.Text = obj.DiaChi;
                ckNam.Checked =(bool) obj.GioiTinh;
                ckNu.Checked = !ckNam.Checked;
                txtTuoi.Value =(int) obj.Tuoi;
                lueKhoa.EditValue = obj.IDKhoa;
                
               
            }
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                HeThong.Func.UserLogin lg = new HeThong.Func.UserLogin();
                if (checkvali_null()) return;
                obj.MaNV= txtMaNV.Text;
                obj.TenNV= txtHVT.Text;
                obj.SDT = txtSDT.Text;
                obj.IsGV = true;
                obj.DiaChi=txtDiaChi.Text;
                obj.GioiTinh= ckNam.Checked;
                obj.Tuoi= (int)txtTuoi.Value;
                obj.IsLock = true;
                obj.Password = lg.HashPassword("123456");
                db.NhanViens.InsertOnSubmit(obj);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                obj.MaNV = txtMaNV.Text;
                obj.TenNV = txtHVT.Text;
                obj.SDT = txtSDT.Text;
                obj.IsGV = true;
                obj.DiaChi = txtDiaChi.Text;
                obj.GioiTinh = ckNam.Checked;
                obj.Tuoi = (int)txtTuoi.Value;
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    HeThong.Thongbao.Loi(ex.ToString());
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        private bool checkvali_null()
        {
            if (String.IsNullOrEmpty(txtMaNV.Text))
            {
                HeThong.Thongbao.Canhbao("Mã giảng viên. xin mời nhập !");
                return true;
            }
            if (String.IsNullOrEmpty(txtHVT.Text))
            {
                HeThong.Thongbao.Canhbao("Tên giảng viên. xin mời nhập !");
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
