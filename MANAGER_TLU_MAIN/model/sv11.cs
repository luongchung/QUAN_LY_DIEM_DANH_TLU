using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANAGER_TLU_MAIN.model
{
    public class SV11
    {
        public string mSV { get; set; }
        public string tenSV { get; set; }
        public bool coMat { get; set; }
        public string tgDiemDanh { get; set; }
        public string tenKhoa { get; set; }

        public SV11(string mSV, string tenSV, bool coMat, string tgDiemDanh, string tenKhoa)
        {
            this.mSV = mSV;
            this.tenSV = tenSV;
            this.coMat = coMat;
            this.tgDiemDanh = tgDiemDanh;
            this.tenKhoa = tenKhoa;
        }

        public SV11()
        {
        }

    }
}
