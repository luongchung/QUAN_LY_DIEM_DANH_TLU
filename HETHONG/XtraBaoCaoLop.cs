using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace HeThong
{
    public partial class XtraBaoCaoLop : DevExpress.XtraReports.UI.XtraReport
    {
        DatabaseDataContext db;
        public XtraBaoCaoLop(int IDLopMonHoc)
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            xrSTT.DataBindings.Add(new XRBinding("Text", null, "STT"));
            xrTenSV.DataBindings.Add(new XRBinding("Text", null, "TenSV"));
            xrMaSV.DataBindings.Add(new XRBinding("Text", null, "MSV"));
            xrSoBuoiCoMat.DataBindings.Add(new XRBinding("Text", null, "SoBuoiCoMat"));
            xrSoBuoiVangMat.DataBindings.Add(new XRBinding("Text", null, "SoBuoiVangMat"));
            xrTongSoBuoiHoc.DataBindings.Add(new XRBinding("Text", null, "TongSoBuoi"));



            var wait = HeThong.Thongbao.Loading();
            txtTenLopMonHoc.Text = db.LopMonHocs.Single(p => p.ID == IDLopMonHoc).TenLopMonHoc;
            var IDGV = db.LopMonHocs.Single(p => p.ID == IDLopMonHoc).IDGiangVien;
            txtTenGiangVien.Text = db.NhanViens.Single(p => p.ID == IDGV).TenNV;
            try
            {
                var dsSVlop = from a in db.SinhVien_LopMonHocs
                              where a.IDLopMonHoc.Equals(IDLopMonHoc)
                              select new
                              {
                                  TenSV = (from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.TenSV).Single(),
                                  SoBuoiCoMat = db.getSoBuoiDiHoc(a.IDSinhVien, IDLopMonHoc),
                                  SoBuoiVangMat= db.getTongSoBuoi(IDLopMonHoc) - db.getSoBuoiDiHoc(a.IDSinhVien, IDLopMonHoc),
                                  TongSoBuoi = db.getTongSoBuoi(IDLopMonHoc),
                                  MSV = (from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.MSV).Single(),
                                  TenKhoa = (from k in db.Khoas where k.ID.Equals((from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.IDKhoa).Single()) select k.TenKhoa).Single()
                };
                DataSource = dsSVlop;
            }
            catch { }
            finally
            {
                wait.Close();
                wait.Dispose();
            }
        }
    }
}
