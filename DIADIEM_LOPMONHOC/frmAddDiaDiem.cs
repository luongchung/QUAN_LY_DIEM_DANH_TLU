﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThong;

namespace DIADIEM_LOPMONHOC
{
    public partial class frmAddDiaDiem : DevExpress.XtraEditors.XtraForm
    {
        public int? ID { get; set; }
        private DiaDiemHoc obj;
        private DatabaseDataContext db;
        public frmAddDiaDiem()
        {
            InitializeComponent();
            db = new DatabaseDataContext();
            obj = new DiaDiemHoc();
        }

        private void frmAddNhanVien_Load(object sender, EventArgs e)
        { 
            if (ID != null)
            {
                obj = db.DiaDiemHocs.Single(p => p.ID == ID);
                txtTenDiaDiem.Text = obj.TenDiaDiem;
                txtKhuNha.Text = obj.KhuNha;
                txtGhiChu.Text = obj.GhiChu;
            }
         
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
        
                if (checkvali_null()) return;
                obj.TenDiaDiem = txtTenDiaDiem.Text;
                obj.KhuNha = txtKhuNha.Text;
                obj.GhiChu = txtGhiChu.Text;
                db.DiaDiemHocs.InsertOnSubmit(obj);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    HeThong.Thongbao.Loi(ex.ToString());
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                if (checkvali_null()) return;
                obj.TenDiaDiem = txtTenDiaDiem.Text;
                obj.KhuNha = txtKhuNha.Text;
                obj.GhiChu = txtGhiChu.Text;
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    HeThong.Thongbao.Loi(ex.ToString());
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        private bool checkvali_null()
        {
            if (String.IsNullOrEmpty(txtTenDiaDiem.Text))
            {
                HeThong.Thongbao.Canhbao("Bạn chưa nhập tên địa điểm. xin mời nhập !");
                return true;
            }
            return false;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
