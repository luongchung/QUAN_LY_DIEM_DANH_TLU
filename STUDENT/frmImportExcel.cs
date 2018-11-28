using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using HeThong;

namespace STUDENT
{
    public partial class frmImportExcel : DevExpress.XtraEditors.XtraForm
    {
        public frmImportExcel()
        {
            InitializeComponent();
        }

        private void btnNhapExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xử lý excel nhập sinh viên
            //Mở dialog nhập excel
            OpenFileDialog openFile = new OpenFileDialog();
            //lọc các file excel
            openFile.Filter = "(Các tệp Excel)|*.xlsx";
            //mở dialog
            openFile.ShowDialog();
            //kiểm tra có chọn file
            if (openFile.FileName != "")
            {
                txtDuongDan.Caption = openFile.FileName.ToString();
                //Tạo đối tượng
                Excel.Application app = new Excel.Application();
                //Mở excel
                Excel.Workbook wb = app.Workbooks.Open(openFile.FileName);
                List<SinhVien> arrSinhVien = new List<SinhVien>();
                try
                {
                    //Đọc dữ liệu
                    //Mở sheet 1
                    Excel._Worksheet sheet = wb.Sheets[1];
                    Excel.Range range = sheet.get_Range("$L$2:$M:$3", Type.Missing);
                    //lấy số hàng số cột
                    int rows = range.Rows.Count;
                    int cols = range.Columns.Count;
                    //lặp từ hàng 2 trở đi

                    for (int i = 2; i <= rows; i++)
                    {
                        SinhVien sv = new SinhVien();
                        HeThong.Thongbao.Loi(range.Cells[i, 1]);
                        sv.MSV = range.Cells[i, 1].Value;
                        sv.TenSV = range.Cells[i, 2].Value.toString();
                        sv.NgaySinh= (DateTime)range.Cells[i, 3].Value.toString();
                        sv.GioiTinh = (int)range.Cells[i, 4].Value.toString()==0?false:true;
                        sv.IDKhoa = (int)range.Cells[i, 5].Value.toString();
                        sv.DiaChi = range.Cells[i, 6].Value.toString();
                        arrSinhVien.Add(sv);
                    }
                    gvDuLieu.DataSource = arrSinhVien;

                }
                catch (Exception ex)
                {
                    HeThong.Thongbao.Loi(ex.ToString());
                }
               

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn file nào ! Mời chọn lại... ");
            }
        }

      
    }
}
