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

namespace KHOA
{
    public partial class frmAddKhoa : DevExpress.XtraEditors.XtraForm
    {
        public int? ID { get; set; }
        private Khoa obj;
        private DatabaseDataContext db;
        public frmAddKhoa()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new Khoa();
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        { 
            if (ID != null)
            {
                obj = db.Khoas.Single(p => p.ID == ID);
                txtTenKhoa.Text = obj.TenKhoa;
                txtSDT.Text = obj.SDT;
                txtDiaChi.Text = obj.DiaChi;
            }
         
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {     
                if (checkvali_null()) return;
                obj.TenKhoa = txtTenKhoa.Text;
                obj.SDT = txtSDT.Text;
                obj.DiaChi = txtDiaChi.Text;
                db.Khoas.InsertOnSubmit(obj);
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
            else
            {
                if (checkvali_null()) return;
                obj.TenKhoa = txtTenKhoa.Text;
                obj.SDT = txtSDT.Text;
                obj.DiaChi = txtDiaChi.Text;    
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
            if (String.IsNullOrEmpty(txtTenKhoa.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập tên khoa. xin mời nhập !");
                return true;
            }
            if (String.IsNullOrEmpty(txtSDT.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập số điện thoại. xin mời nhập !");
                return true;
            }
            if (String.IsNullOrEmpty(txtDiaChi.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn nhập địa chỉ. xin mời nhập!");
                return true;
            }
            return false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
