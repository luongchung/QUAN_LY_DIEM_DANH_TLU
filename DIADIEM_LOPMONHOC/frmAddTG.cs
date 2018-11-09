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
using DevExpress.XtraScheduler;

namespace DIADIEM_LOPMONHOC
{
    public partial class frmAddTG : DevExpress.XtraEditors.XtraForm
    {
        public int? ID { get; set; }
        private ThoiGianTietHoc obj;
        private DatabaseDataContext db;
        public frmAddTG()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new ThoiGianTietHoc();
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        { 
            if (ID != null)
            {
                obj = db.ThoiGianTietHocs.Single(p => p.ID == ID);
                nudTiet.Value = (int)obj.TenTiet;
                teBatDau.EditValue = obj.ThoiGianBatDau;
                teKetThuc.EditValue = obj.ThoiGianKetThuc;
            }
         
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
            
                if (checkvali_null()) return;
                obj.TenTiet = (int)nudTiet.Value;
                obj.ThoiGianBatDau = (DateTime)teBatDau.EditValue;
                obj.ThoiGianKetThuc = (DateTime)teKetThuc.EditValue;
                db.ThoiGianTietHocs.InsertOnSubmit(obj);
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
                obj.TenTiet = (int)nudTiet.Value;
                obj.ThoiGianBatDau = (DateTime)teBatDau.EditValue;
                obj.ThoiGianKetThuc = (DateTime)teKetThuc.EditValue;
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
            if (String.IsNullOrEmpty(nudTiet.Text))
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
