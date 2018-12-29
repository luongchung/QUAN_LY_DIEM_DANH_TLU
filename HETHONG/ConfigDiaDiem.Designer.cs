namespace HeThong
{
    partial class ConfigDiaDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDiaDiem));
            this.lueDiaDiemCf = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lueDiaDiemCf.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueDiaDiemCf
            // 
            this.lueDiaDiemCf.Location = new System.Drawing.Point(106, 60);
            this.lueDiaDiemCf.Name = "lueDiaDiemCf";
            this.lueDiaDiemCf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDiaDiemCf.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDiaDiem", "Địa điểm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KhuNha", "Khu nhà")});
            this.lueDiaDiemCf.Properties.DisplayMember = "TenDiaDiem";
            this.lueDiaDiemCf.Properties.NullText = "[Chọn địa điểm]";
            this.lueDiaDiemCf.Properties.ValueMember = "ID";
            this.lueDiaDiemCf.Size = new System.Drawing.Size(514, 34);
            this.lueDiaDiemCf.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(106, 111);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(514, 66);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ConfigDiaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 268);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lueDiaDiemCf);
            this.Name = "ConfigDiaDiem";
            this.Text = "Cấu hình vị trí phòng";
            this.Load += new System.EventHandler(this.ConfigDiaDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueDiaDiemCf.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueDiaDiemCf;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}