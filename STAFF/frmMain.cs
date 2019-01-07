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
namespace STAFF
{
    public partial class frmMain : Form
    {
        DatabaseDataContext db;
        public frmMain()
        {
            InitializeComponent();
            db = new DatabaseDataContext();

        }
        private void loadNV()
        {

            HeThong.Func.PhanQuyen.phanQuyenBarManager(this,Common.User, barManager1);
            gcMain.DataSource =( from a in db.NhanViens
                                select new
                                {
                                    a.ID,
                                    a.MaNV,
                                    a.TenNV,
                                    a.Tuoi,
                                    GioiTinh=((bool)a.GioiTinh)?"Nam":"Nữ",
                                    a.DiaChi,
                                    a.SDT
                                }).ToList();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadNV();
        }

        private void btnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadNV();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmAddNhanVien();
            f.ID = null;
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                loadNV();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = (int?)gvMain.GetFocusedRowCellValue("ID");
            if (id == null)
            {
                MessageBox.Show("Bạn chưa chọn vào hàng cần sửa, vui lòng chọn.");
                return;
            }
            var f = new frmAddNhanVien();
            f.ID = id;
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                loadNV();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvMain.GetFocusedRowCellValue("ID") == null)
            {
                Thongbao.Hoi("Mời bạn chọn hàng cần xóa.");
            }
            else
            {
                int id_tmp = (int)gvMain.GetFocusedRowCellValue("ID");
                DialogResult f = Thongbao._CauHoi();
                if (f == System.Windows.Forms.DialogResult.Yes)
                {
                    var delete = (from a in db.NhanViens where a.ID == (int)id_tmp select a).Single();
                    db.NhanViens.DeleteOnSubmit(delete);
                    try { db.SubmitChanges(); }
                    catch (Exception) { MessageBox.Show("Xóa không thành công, vui lòng kiểm tra lại."); }
                    loadNV();
                }
            }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
