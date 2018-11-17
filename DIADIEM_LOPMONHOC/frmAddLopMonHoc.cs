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

namespace DIADIEM_LOPMONHOC
{
    public partial class frmAddLopMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public int? ID { get; set; }
        private LopMonHoc obj;
        private DatabaseDataContext db;
        public frmAddLopMonHoc()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new LopMonHoc();
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        {
            lueGiangVien.Properties.DataSource = (from a in db.NhanViens
                                                  where a.IsGV == true
                                                  select new
                                                  {
                                                      a.ID,
                                                      a.TenNV,
                                                      TenKhoa = (from b in db.Khoas where b.ID.Equals(a.IDKhoa) select b.TenKhoa).Single()
                                                  }).ToList();
            if (ID != null)
            {
                obj = db.LopMonHocs.Single(p => p.ID == ID);
                txtMaMH.Text = obj.MaLopMonHoc;
                txtTenMonHoc.Text = obj.TenLopMonHoc;
                lueGiangVien.EditValue = obj.IDGiangVien;
                txtSoTC.Value = (int)obj.SoTinChi;
                txtSoTiet.Text = obj.TongSoTiet.ToString();
                txtGhiChu.Text = obj.GhiChu;
                ckKhoa.Checked = (bool)obj.IsKT;
            }
         
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
        
                if (checkvali_null()) return;
                obj.MaLopMonHoc = txtMaMH.Text;
                obj.TenLopMonHoc = txtTenMonHoc.Text;
                obj.SoTinChi = (int)txtSoTC.Value;
                obj.IDGiangVien = (int)lueGiangVien.EditValue;
                obj.TongSoTiet = int.Parse(txtSoTiet.Text);
                obj.GhiChu = txtGhiChu.Text;
                obj.IsKT = ckKhoa.Checked ? true : false;
                db.LopMonHocs.InsertOnSubmit(obj);
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
                obj.MaLopMonHoc = txtMaMH.Text;
                obj.TenLopMonHoc = txtTenMonHoc.Text;
                obj.SoTinChi = (int)txtSoTC.Value;
                obj.IDGiangVien = (int)lueGiangVien.EditValue;
                obj.TongSoTiet = int.Parse(txtSoTiet.Text);
                obj.GhiChu = txtGhiChu.Text;
                obj.IsKT = ckKhoa.Checked ? true : false;
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
            if (String.IsNullOrEmpty(txtMaMH.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập tên địa điểm. xin mời nhập !");
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
