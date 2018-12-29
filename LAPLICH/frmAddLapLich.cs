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
    public partial class frmAddLapLich : DevExpress.XtraEditors.XtraForm
    {
        public int? IDLopMonHoc { get; set; }
        public int? ID { get; set; }
        private BuoiHoc obj;
        private DatabaseDataContext db;
        public frmAddLapLich()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new BuoiHoc();
            dateNgayHoc.Properties.Mask.EditMask = "dd-MM-yyyy";
            dateNgayHoc.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        {
            lueTietBD.Properties.DataSource = (from a in db.ThoiGianTietHocs
                                                  select new
                                                  {
                                                      a.ID,
                                                      a.TenTiet
                                                  }).ToList();

            lueTietKT.Properties.DataSource = (from a in db.ThoiGianTietHocs
                                               select new
                                               {
                                                   a.ID,
                                                   a.TenTiet
                                               }).ToList();
            lueDiaDiem.Properties.DataSource = (from a in db.DiaDiemHocs
                                               select new
                                               {
                                                   a.ID,
                                                   a.TenDiaDiem,
                                                   a.KhuNha
                                               }).ToList();
            if (ID != null)
            {
                obj = db.BuoiHocs.Single(p => p.ID == ID);
                txtTenBuoiHoc.Text = obj.TenBuoiHoc;
                dateNgayHoc.EditValue = obj.NgayHoc;
                lueTietBD.EditValue = obj.IDTietBatDau;
                lueTietKT.EditValue = obj.IDTietKetThuc;
                lueDiaDiem.EditValue = obj.IDDiaDiem;
                txtGhiChu.Text = obj.GhiChu;
            }
         
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                if (checkvali_null()) return;
                if (db.tranhtrunglich((int)lueDiaDiem.EditValue, (int)lueTietBD.EditValue, (int)lueTietKT.EditValue, (DateTime)dateNgayHoc.EditValue).Count() > 0)
                {
                    LAPLICH.frmLichTrung obj = new frmLichTrung()
                    {
                        IDDiaDiem = (int)lueDiaDiem.EditValue,
                        IDTietBatDau = (int)lueTietBD.EditValue,
                        IDTietKetThuc = (int)lueTietKT.EditValue,
                        NgayHoc = (DateTime)dateNgayHoc.EditValue
                    };
                    obj.ShowDialog();
                }
                obj.IDLopMonHoc = IDLopMonHoc;
                obj.TenBuoiHoc= txtTenBuoiHoc.Text;
                obj.NgayHoc = (DateTime)dateNgayHoc.EditValue;
                obj.IDTietBatDau = (int)lueTietBD.EditValue;
                obj.IDTietKetThuc = (int)lueTietKT.EditValue;
                obj.IDDiaDiem = (int)lueDiaDiem.EditValue;
                obj.GhiChu = txtGhiChu.Text;
                db.BuoiHocs.InsertOnSubmit(obj);
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
                if ((from a in db.tranhtrunglich((int)lueDiaDiem.EditValue, (int)lueTietBD.EditValue, (int)lueTietKT.EditValue, (DateTime)dateNgayHoc.EditValue) where a.ID!=ID select a).Count() > 0)
                {
                    LAPLICH.frmLichTrung obj = new frmLichTrung()
                    {
                        IDChinh = (int)ID,
                        IDDiaDiem = (int)lueDiaDiem.EditValue,
                        IDTietBatDau = (int)lueTietBD.EditValue,
                        IDTietKetThuc = (int)lueTietKT.EditValue,
                        NgayHoc = (DateTime)dateNgayHoc.EditValue
                    };
                    obj.ShowDialog();
                    //ngắt hoạt động thêm
                    return;
                }
                obj.IDLopMonHoc = IDLopMonHoc;
                obj.TenBuoiHoc = txtTenBuoiHoc.Text;
                obj.NgayHoc = (DateTime)dateNgayHoc.EditValue;
                obj.IDTietBatDau = (int)lueTietBD.EditValue;
                obj.IDTietKetThuc = (int)lueTietKT.EditValue;
                obj.IDDiaDiem = (int)lueDiaDiem.EditValue;
                obj.GhiChu = txtGhiChu.Text;
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
           
            if (String.IsNullOrEmpty(txtTenBuoiHoc.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập tên địa điểm. xin mời nhập !");
                return true;
            }
            if (dateNgayHoc.EditValue==null)
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập đủ thông tin. xin mời nhập !");
                return true;
            }
            if (lueTietBD.EditValue==null)
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập đủ thông tin. xin mời nhập !");
                return true;
            }
            if (lueTietKT.EditValue==null)
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập đủ thông tin. xin mời nhập !");
                return true;
            }
            if (lueDiaDiem.EditValue==null)
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập đủ thông tin. xin mời nhập !");
                return true;
            }
            if ((int)lueTietBD.EditValue>(int)lueTietKT.EditValue)
            {
                HeThong.Thongbao.Canhbao("Tiết bắt đầu không thể lớn hơn tiết kết thúc !");
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
