using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong
{
    public partial class frmConf : DevExpress.XtraEditors.XtraForm
    {
        public frmConf()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string a = "Data Source=" + txtsv.Text + ";Initial Catalog=dbThanhChin;Integrated Security=True";
            //HeThong.Properties.Settings.Default.linqketnoi = a;
            //HeThong.Properties.Settings.Default.Save();

        }

        private void frmConf_Load(object sender, EventArgs e)
        {
            
        }
    }
}
