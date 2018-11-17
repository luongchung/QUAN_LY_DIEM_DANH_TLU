namespace DIADIEM_LOPMONHOC
{
    partial class frmAddTG
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTG));
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.teBatDau = new DevExpress.XtraEditors.TimeEdit();
            this.teKetThuc = new DevExpress.XtraEditors.TimeEdit();
            this.nudTiet = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tiết";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thời gian bắt đầu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Thời gian kết thúc";
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(232, 196);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(248, 66);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu và đóng";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.Location = new System.Drawing.Point(496, 196);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(131, 66);
            this.btnDong.TabIndex = 15;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // teBatDau
            // 
            this.teBatDau.EditValue = new System.DateTime(2018, 11, 9, 0, 0, 0, 0);
            this.teBatDau.Location = new System.Drawing.Point(232, 90);
            this.teBatDau.Name = "teBatDau";
            this.teBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.teBatDau.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.teBatDau.Size = new System.Drawing.Size(395, 34);
            this.teBatDau.TabIndex = 16;
            // 
            // teKetThuc
            // 
            this.teKetThuc.EditValue = new System.DateTime(2018, 11, 9, 0, 0, 0, 0);
            this.teKetThuc.Location = new System.Drawing.Point(232, 140);
            this.teKetThuc.Name = "teKetThuc";
            this.teKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.teKetThuc.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.teKetThuc.Size = new System.Drawing.Size(395, 34);
            this.teKetThuc.TabIndex = 17;
            // 
            // nudTiet
            // 
            this.nudTiet.Location = new System.Drawing.Point(232, 53);
            this.nudTiet.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudTiet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTiet.Name = "nudTiet";
            this.nudTiet.Size = new System.Drawing.Size(395, 33);
            this.nudTiet.TabIndex = 18;
            this.nudTiet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmAddTG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 314);
            this.Controls.Add(this.nudTiet);
            this.Controls.Add(this.teKetThuc);
            this.Controls.Add(this.teBatDau);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Name = "frmAddTG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm / Sửa thời gian tiết học";
            this.Load += new System.EventHandler(this.frmAddNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraEditors.TimeEdit teBatDau;
        private DevExpress.XtraEditors.TimeEdit teKetThuc;
        private System.Windows.Forms.NumericUpDown nudTiet;
    }
}