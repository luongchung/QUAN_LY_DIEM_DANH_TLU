using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThong;
namespace HeThong
{
    public static class Common
    {
        public static NhanVien User { get; set;}
        public static bool IsClose { get; set; }
        public static bool setIDPhong(int Id)
        {
            bool kt = false;
            try
            {
                HeThong.Properties.Settings.Default.IDDiaDiem = Id;
                HeThong.Properties.Settings.Default.Save();
                kt = true;
            }
            catch (Exception)
            {

            }
            return kt;
            
        }
        public static int getIDPhong()
        {
            return Properties.Settings.Default.IDDiaDiem;
        }
        public static String getChuoiKetNoi()
        {
            return Properties.Settings.Default.linqketnoi.ToString().Trim();
        }
        public static bool TestConnection(string serverName, string initialCatalog, string userId, string password, bool integratedSecurity)
        {
            var canConnect = false;

            var connectionString = integratedSecurity ? string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", serverName, initialCatalog)
                                                      : string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", serverName, initialCatalog, userId, password);

            var connection = new OleDbConnection(connectionString);

            try
            {
                using (connection)
                {
                    connection.Open();

                    canConnect = true;
                }
            }
            catch (Exception )
            {
                Thongbao.Loi("Không thể kết nối Cơ sở dữ liệu");
            }
            finally
            {
                connection.Close();
            }

            return canConnect;
        }
        public static bool TestConnection(string chuoiketnoi)
        {
            var canConnect = false;

            var connectionString = chuoiketnoi;

            var connection = new OleDbConnection(connectionString);

            try
            {
                using (connection)
                {
                    connection.Open();

                    canConnect = true;
                }
            }
            catch (Exception)
            {
                Thongbao.Loi("Không thể kết nối Cơ sở dữ liệu");
            }
            finally
            {
                connection.Close();
            }

            return canConnect;
        }
    }
}
