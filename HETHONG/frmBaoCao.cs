using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong
{
    public partial class frmBaoCao : DevExpress.XtraEditors.XtraForm
    {
        private int? IDLopMonHoc = null;
        DatabaseDataContext db;
        public frmBaoCao()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
        }

        private void btnXuatBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraBaoCaoLop baocao = new XtraBaoCaoLop(4);
            using (ReportPrintTool printTool = new ReportPrintTool(baocao))
            {
                printTool.ShowPreviewDialog();
            }
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatExcel(gcMain);
        }
        private void XuatExcel(DevExpress.XtraGrid.GridControl grid)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx ";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            grid.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            grid.ExportToXlsx(exportFilePath);
                            break;

                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            HeThong.Thongbao.Loi("Không thể mở file.");
                        }
                    }
                    else
                    {
                        HeThong.Thongbao.Loi("Không thể lưu file.");
                    }
                }
            }
        }
        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            LoadMain();
        }
        private void load()
        {
            IDLopMonHoc =(int) lueLopMonHoc.EditValue;
            if (IDLopMonHoc == null) return;
            var dsSVlop = from a in db.SinhVien_LopMonHocs
                          where a.IDLopMonHoc.Equals(IDLopMonHoc)
                          select new
                          {
                              TenSV = (from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.TenSV).Single(),
                              SoBuoiCoMat = db.getSoBuoiDiHoc(a.IDSinhVien, IDLopMonHoc),
                              SoBuoiVangMat = db.getTongSoBuoi(IDLopMonHoc) - db.getSoBuoiDiHoc(a.IDSinhVien, IDLopMonHoc),
                              TongSoBuoi = db.getTongSoBuoi(IDLopMonHoc),
                              MSV = (from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.MSV).Single(),
                              TenKhoa = (from k in db.Khoas where k.ID.Equals((from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.IDKhoa).Single()) select k.TenKhoa).Single()
                          };
            gcMain.DataSource = dsSVlop;
        }

        private void btnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadMain();
        }
        private void LoadMain()
        {

            if ((bool)HeThong.Common.User.IsGV)
            {
                lueLopMonHoc.Properties.DataSource = (from a in db.LopMonHocs
                                                      where a.IDGiangVien == Common.User.ID
                                                      where a.IsKT == false
                                                      select new
                                                      {
                                                          a.ID,
                                                          a.MaLopMonHoc,
                                                          TenMonHoc = a.TenLopMonHoc,
                                                          GiangVien = (from b in db.NhanViens where b.ID.Equals(a.IDGiangVien) select b.TenNV).Single(),
                                                          KetThuc = a.IsKT
                                                      }).ToList();


            }
            else
            {
                lueLopMonHoc.Properties.DataSource = (from a in db.LopMonHocs
                                                      where a.IsKT == false
                                                      select new
                                                      {
                                                          a.ID,
                                                          a.MaLopMonHoc,
                                                          TenMonHoc = a.TenLopMonHoc,
                                                          GiangVien = (from b in db.NhanViens where b.ID.Equals(a.IDGiangVien) select b.TenNV).Single(),
                                                          KetThuc = a.IsKT
                                                      }).ToList();

            }
           

        }

        private void lueLopMonHoc_EditValueChanged(object sender, EventArgs e)
        {
    
            load();
        }

        private void gvMain_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
    }
}
