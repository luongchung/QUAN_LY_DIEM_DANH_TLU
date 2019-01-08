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
using HeThong;

namespace DIEMDANH
{
    public partial class frmQuanLyDiemDanh : Form
    {
        private int IDphong;
        DatabaseDataContext db;
        public frmQuanLyDiemDanh()
        {
            InitializeComponent();
            IDphong = HeThong.Common.getIDPhong();
            db = new DatabaseDataContext();
            barManager1.SetPopupContextMenu(gcMain, popupMenu1);
        }
        private void loadDanhSach()
        {
            if ((bool)HeThong.Common.User.IsGV)
            {
                lueLopMonHoc.Properties.DataSource = (from a in db.LopMonHocs
                                                      where a.IDGiangVien ==Common.User.ID
                                                      where a.IsKT == false
                                                      select new
                                                      {
                                                          a.ID,
                                                          a.MaLopMonHoc,
                                                          TenMonHoc = a.TenLopMonHoc,
                                                          GiangVien = (from b in db.NhanViens where b.ID.Equals(a.IDGiangVien) select b.TenNV).Single(),
                                                          KetThuc = a.IsKT
                                                      }).ToList();


            }else
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
    

        private void frmQuanLyDiemDanh_Load(object sender, EventArgs e)
        {

          
            loadDanhSach();


        }

        private void lueLopMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLopMonHoc.EditValue == null) return;
            lueBuoiHoc.Properties.DataSource = (from a in db.BuoiHocs
                                                where a.IDLopMonHoc == (int)lueLopMonHoc.EditValue
                                                select new
                                                {
                                                    a.ID,
                                                    a.TenBuoiHoc
                                                }).ToList();
        }

        private void gvMain_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void Reload()
        {
            if (lueBuoiHoc.EditValue == null) return;
            gcMain.DataSource = (from a in db.getSVtheoIDBuoi((int)lueBuoiHoc.EditValue)
                                 select new
                                 {
                                     a.DenLop,
                                     a.ID,
                                     a.MSV,
                                     a.TenKhoa,
                                     a.TenSV,
                                     a.TGDiemDanh
                                 }).ToList();
        }

        private void lueBuoiHoc_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnDiemDanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvMain.GetFocusedRowCellValue("ID") == null)
            {
                Thongbao.Hoi("Mời bạn chọn hàng cần điểm danh.");
            }
            else
            {
                int id_tmp = (int)gvMain.GetFocusedRowCellValue("ID");
                DialogResult f = Thongbao._CauHoi("Có chắc chắn điểm danh sinh viên");
                if (f == System.Windows.Forms.DialogResult.Yes)
                {
                    var delete = (from a in db.DiemDanhs where a.ID == (int)id_tmp select a).Single();
                    delete.DenLop = true;
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        HeThong.Thongbao.Canhbao(ex.ToString());
                    }
                    Reload();
                }
            }
        }

        private void btnHuyDiemDanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (gvMain.GetFocusedRowCellValue("ID") == null)
            {
                Thongbao.Hoi("Mời bạn chọn hàng cần hủy điểm danh.");
            }
            else
            {
                int id_tmp = (int)gvMain.GetFocusedRowCellValue("ID");
                DialogResult f = Thongbao._CauHoi("Có chắc chắn hủy điểm danh sinh viên");
                if (f == System.Windows.Forms.DialogResult.Yes)
                {
                    var delete = (from a in db.DiemDanhs where a.ID == (int)id_tmp select a).Single();
                    delete.DenLop = false;
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        HeThong.Thongbao.Canhbao(ex.ToString());
                    }
                    Reload();
                }
            }
        }

        private void gcMain_Click(object sender, EventArgs e)
        {

        }

        private void btnHuyAllDiemDanh_Click(object sender, EventArgs e)
        {
            if (lueBuoiHoc.EditValue == null)
            {
                Thongbao.Canhbao("Bạn chưa chọn buổi học.");
                return;
            }


            int id_Buoihoc = (int)lueBuoiHoc.EditValue;
            DialogResult f = Thongbao._CauHoi("Có chắc chắn hủy kết quả điểm danh buổi này !");
            if (f == System.Windows.Forms.DialogResult.Yes)
            {
                var deletes = (from a in db.DiemDanhs where a.IDBuoiHoc== id_Buoihoc select a);
                foreach(var i in deletes)
                {
                    db.DiemDanhs.DeleteOnSubmit(i);
                }
                try
                {
                    db.SubmitChanges();
                    Thongbao.ThanhCong("Hủy thành công !");
                }
                catch (Exception ex)
                {
                    HeThong.Thongbao.Canhbao(ex.ToString());
                }
                Reload();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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
    }
}
