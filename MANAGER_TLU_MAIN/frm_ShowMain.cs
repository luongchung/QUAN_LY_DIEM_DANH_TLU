using HeThong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using MANAGER_TLU_MAIN.model;
using System.IO;

namespace AppMain
{
    public partial class frm_ShowMain : Form
    {
        List<SV11> listsv;
        private string IDPhong;
        private string Token;
        DatabaseDataContext db;
        DiaDiemHoc obj;
        private static Random random = new Random();
        public frm_ShowMain()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            listsv = new List<SV11>();
        }

        private void frm_ShowMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void InsertToken(string IDphong, string Token)
        {
            obj = db.DiaDiemHocs.Single(p => p.ID == int.Parse(IDPhong));
            obj.Token = Token;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Thongbao.Canhbao(ex.ToString());
            }
        }
        private string getToken(String IdPhong)
        {
            String tmp = "";
            tmp = (from a in db.DiaDiemHocs where a.ID.Equals(IdPhong) select a.Token).Single();
            return tmp;
        }
        private void loadData()
        {
            IDPhong = Common.getIDPhong().ToString();
            ///lấy ID phòng null
            if (String.IsNullOrEmpty(IDPhong)) return;
            Token = RandomString(8);
            InsertToken(IDPhong, Token);

            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 800,
                Height = 800,
            };
            IDPhong = HeThong.Common.getIDPhong().ToString();
            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            Token = getToken(IDPhong);
            String tmp = IDPhong + "," + Token;
            btnChangeToken.Text = Token;
            var result = new Bitmap(qr.Write(tmp));
            imgBarcode.Image = result;
            txtPhong.Text = (from a in db.DiaDiemHocs where a.ID == int.Parse(IDPhong) select a.TenDiaDiem).Single().ToString();
            lueLopMonHoc.Properties.DataSource = db.getDSLopHocTheoNgay(int.Parse(IDPhong));
        }

        private void frm_ShowMain_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void gvLoai_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void lueLopMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLopMonHoc.EditValue == null) return;
            lueBuoiHoc.Properties.DataSource = (from a in db.BuoiHocs
                                                where a.IDLopMonHoc == (int)lueLopMonHoc.EditValue
                                                select new
                                                {
                                                    a.ID,
                                                    a.TenBuoiHoc,
                                                    a.NgayHoc
                                                }).ToList();
        }

        private void btnNap_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void gvSV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lueLopMonHoc.Properties.DataSource = db.getDSLopHocTheoNgay(int.Parse(IDPhong));
        }

        private void imgBarcode_DoubleClick(object sender, EventArgs e)
        {
            String tmp = IDPhong + "," + Token;
            var fm = new MANAGER_TLU_MAIN.frmQR()
            {
                chuoi = tmp
            };
            fm.ShowDialog();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void lueBuoiHoc_EditValueChanged(object sender, EventArgs e)
        {
            loadDuLieu();
        }


        private void loadDuLieu()
        {
            listsv.Clear();
            if (lueLopMonHoc.EditValue == null) return;
            if (lueBuoiHoc.EditValue == null) return;
            var dsSVlop = from a in db.SinhVien_LopMonHocs
                where a.IDLopMonHoc.Equals(lueLopMonHoc.EditValue)
                select new
                {
                    TenSV = (from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.TenSV).Single(),
                    MSV = (from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.MSV).Single(),
                    TenKhoa= (from k in db.Khoas where k.ID.Equals((from sv in db.SinhViens where sv.ID.Equals(a.IDSinhVien) select sv.IDKhoa).Single()) select k.TenKhoa).Single()
                };
            foreach (var item in dsSVlop)
            {
                listsv.Add(new SV11(item.MSV.ToString(), item.TenSV.ToString(), false, "",item.TenKhoa));
            }
          
            ///loc
            var dsDD = db.getSVtheoIDBuoi(int.Parse(lueBuoiHoc.EditValue.ToString()));
            foreach (var item in dsDD)
            {
                for (int i = 0; i < listsv.Count; i++)
                {
                    if (item.MSV.Equals(listsv[i].mSV))
                    {
                        listsv[i].tgDiemDanh = item.TGDiemDanh.ToString();
                        listsv[i].coMat = (bool)item.DenLop;
                    }
                }
            }

            //update
            gcSV.DataSource = listsv;
            gcSV.RefreshDataSource();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            XuatExcel(gcSV);
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
