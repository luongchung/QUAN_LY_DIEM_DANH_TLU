namespace LAPLICH
{
    partial class TimeDay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeDay));
            this.txtNgay = new DevExpress.XtraEditors.GroupControl();
            this.flowTietHoc = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btngc = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaDiem = new System.Windows.Forms.Label();
            this.txtBuoi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay)).BeginInit();
            this.txtNgay.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNgay
            // 
            this.txtNgay.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNgay.Appearance.Options.UseBackColor = true;
            this.txtNgay.Controls.Add(this.flowTietHoc);
            this.txtNgay.Controls.Add(this.panel1);
            this.txtNgay.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNgay.Location = new System.Drawing.Point(0, 0);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(300, 1098);
            this.txtNgay.TabIndex = 0;
            this.txtNgay.Text = "13/11/2018";
       
            // 
            // flowTietHoc
            // 
            this.flowTietHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTietHoc.Location = new System.Drawing.Point(3, 282);
            this.flowTietHoc.Name = "flowTietHoc";
            this.flowTietHoc.Size = new System.Drawing.Size(294, 813);
            this.flowTietHoc.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btngc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDiaDiem);
            this.panel1.Controls.Add(this.txtBuoi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 242);
            this.panel1.TabIndex = 2;
            // 
            // btngc
            // 
            this.btngc.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btngc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btngc.ImageOptions.Image")));
            this.btngc.Location = new System.Drawing.Point(132, 141);
            this.btngc.Name = "btngc";
            this.btngc.Size = new System.Drawing.Size(114, 45);
            this.btngc.TabIndex = 5;
            this.btngc.Text = "Xem";
            this.btngc.Click += new System.EventHandler(this.btngc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ghi chú: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trạng thái: Chưa học";
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.AutoSize = true;
            this.txtDiaDiem.Location = new System.Drawing.Point(16, 61);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(167, 25);
            this.txtDiaDiem.TabIndex = 1;
            this.txtDiaDiem.Text = "Địa điểm: 245A3";
            // 
            // txtBuoi
            // 
            this.txtBuoi.AutoSize = true;
            this.txtBuoi.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold);
            this.txtBuoi.Location = new System.Drawing.Point(16, 21);
            this.txtBuoi.Name = "txtBuoi";
            this.txtBuoi.Size = new System.Drawing.Size(85, 25);
            this.txtBuoi.TabIndex = 0;
            this.txtBuoi.Text = "Buổi: 1";
            // 
            // TimeDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNgay);
            this.Name = "TimeDay";
            this.Size = new System.Drawing.Size(309, 1098);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay)).EndInit();
            this.txtNgay.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl txtNgay;
        private System.Windows.Forms.FlowLayoutPanel flowTietHoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtDiaDiem;
        private System.Windows.Forms.Label txtBuoi;
        private DevExpress.XtraEditors.SimpleButton btngc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
