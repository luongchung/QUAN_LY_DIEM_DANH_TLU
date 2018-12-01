using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIADIEM_LOPMONHOC.models
{
    public class SinhVienCheck
    {
        public SinhVienCheck(int iD,int iD2, string mSV, string tenSV, string tenKhoa, bool thuocLop)
        {
            iD2 = ID2;
            ID = iD;
            MSV = mSV;
            TenSV = tenSV;
            TenKhoa = tenKhoa;
            ThuocLop = thuocLop;
        }

        public int ID { get; set; }
        public int ID2 { get; set; }
        public String MSV { get; set;}
        public String TenSV { get; set; }
        public String TenKhoa { get; set; }
        public bool ThuocLop { get; set; }

    }
}
