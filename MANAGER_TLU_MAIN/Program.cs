using HeThong;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppMain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //show banner 
            //frmBanner frmb = new frmBanner();
            //frmb.Show();

            //HeThong.Func.UserLogin d = new HeThong.Func.UserLogin();
            //string s = d.HashPassword("luongchung");
            //Clipboard.SetText(s);
            //Thongbao.Canhbao(s);

            ////show form login
            //  HeThong.fromLogin frm = new HeThong.fromLogin();
            //  frmb.Close();
            //frm.ShowDialog();
            //if (frm.DialogResult != DialogResult.OK) { return; }


            #region Đăng nhập với tài khoản khách
            NhanVien UsersLogin = new NhanVien();
            var wait = Thongbao.Loading();
            try
            {
                NhanVien objnhanvien = new NhanVien();
                HeThong.Func.UserLogin ul = new HeThong.Func.UserLogin();
                objnhanvien = ul.GetUserByMaNV("macdinh","123456");
                if (objnhanvien != null)
                {
                    //Kiểm tra tài khoản khóa/kích hoạt
                    if ((bool)objnhanvien.IsLock)
                    {
                        Thongbao.Canhbao("Hệ thống bị khóa, liên hệ quản trị viên...");
                        return;
                    }
                    UsersLogin = objnhanvien;             
                }
                else
                {
                    wait.Close();
                    wait.Dispose();   
                    return;
                }
            }
            catch
            {
                wait.Close();
                wait.Dispose();
                Thongbao.Loi("Lỗi kết nối mạng. Vui lòng thử lại sau");
                return;
            }
            finally
            {
                if (!wait.IsDisposed)
                {
                    wait.Close();
                    wait.Dispose();
                }
            }
            #endregion

            //Lưu section
            HeThong.Common.User = UsersLogin;
            //Vào form main
            frm_Main frmmain = new frm_Main()
            {
                User = UsersLogin          
            };
            Application.Run(frmmain);
        }
    }
}
