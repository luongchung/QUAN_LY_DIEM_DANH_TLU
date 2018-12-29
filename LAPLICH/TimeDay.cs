using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThong;

namespace LAPLICH
{
    public partial class TimeDay : UserControl
    {
        public int ID { get; set; }
        public string TenMonHoc { get; set; }
        public string NgayHoc { get; set; }
        public int TietBD { get; set; }
        public int TietKT { get; set; }
        public string DiaDiem { get; set; }
        public string GhiChu { get; set; }
        public List<ThoiGianTietHoc> arrTiet = new List<ThoiGianTietHoc>();
        public TimeDay()
        {
            InitializeComponent();
        }

        public TimeDay(int iD, string tenMonHoc, string ngayHoc, int tietBD, int tietKT, string diaDiem, string ghiChu, List<ThoiGianTietHoc> arrTiet)
        {
            InitializeComponent();
            ID = iD;
            TenMonHoc = tenMonHoc;
            NgayHoc = ngayHoc;
            TietBD = tietBD;
            TietKT = tietKT;
            DiaDiem = diaDiem;
            GhiChu = ghiChu;
            this.arrTiet = arrTiet;
            LoadTietHoc();
        }

        private void LoadTietHoc()
        {
            List<ThoiGianTietHoc> SortedList = arrTiet.OrderBy(o => o.N).ToList();
            txtBuoi.Text = TenMonHoc;
            txtNgay.Text = NgayHoc;
            txtDiaDiem.Text = "Địa điểm: " + DiaDiem;
            btngc.ToolTip = GhiChu;
            foreach(ThoiGianTietHoc i in SortedList)
            {
                if( TietBD<=i.N && i.N <= TietKT)
                {
                    Button btn = new Button() { Width = 280, Height = 40, Text = "Tiết " + i.TenTiet.ToString(),BackColor = Color.Aquamarine,Enabled=false };
                    flowTietHoc.Controls.Add(btn);
                }
                else
                {
                    Button btn = new Button() { Width = 280, Height = 40, Text = "Tiết " + i.TenTiet.ToString(),Enabled=false };
                    flowTietHoc.Controls.Add(btn);
                }

            }
        }

        private void btngc_Click(object sender, EventArgs e)
        {
            HeThong.Thongbao.ThanhCong(GhiChu);
        }

    
    }
}
