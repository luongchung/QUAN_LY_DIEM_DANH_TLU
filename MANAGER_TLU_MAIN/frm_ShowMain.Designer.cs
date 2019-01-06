namespace AppMain
{
    partial class frm_ShowMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ShowMain));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangeToken = new DevExpress.XtraEditors.SimpleButton();
            this.btnNap = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lueBuoiHoc = new DevExpress.XtraEditors.LookUpEdit();
            this.lueLopMonHoc = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPhong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgBarcode = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcSV = new DevExpress.XtraGrid.GridControl();
            this.gvSV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBuoiHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLopMonHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSV)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnLoad);
            this.panelControl1.Controls.Add(this.btnChangeToken);
            this.panelControl1.Controls.Add(this.btnNap);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.lueBuoiHoc);
            this.panelControl1.Controls.Add(this.lueLopMonHoc);
            this.panelControl1.Controls.Add(this.txtPhong);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(2089, 117);
            this.panelControl1.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.ImageOptions.Image")));
            this.btnLoad.Location = new System.Drawing.Point(627, 23);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(164, 68);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnChangeToken
            // 
            this.btnChangeToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeToken.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeToken.ImageOptions.Image")));
            this.btnChangeToken.Location = new System.Drawing.Point(368, 23);
            this.btnChangeToken.Name = "btnChangeToken";
            this.btnChangeToken.Size = new System.Drawing.Size(242, 68);
            this.btnChangeToken.TabIndex = 8;
            this.btnChangeToken.Text = "Đổi Token";
            this.btnChangeToken.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnNap
            // 
            this.btnNap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNap.ImageOptions.Image")));
            this.btnNap.Location = new System.Drawing.Point(1769, 23);
            this.btnNap.Name = "btnNap";
            this.btnNap.Size = new System.Drawing.Size(292, 68);
            this.btnNap.TabIndex = 7;
            this.btnNap.Text = "Tra danh sách điểm danh";
            this.btnNap.Click += new System.EventHandler(this.btnNap_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1307, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Buổi học : ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(814, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Môn : ";
            // 
            // lueBuoiHoc
            // 
            this.lueBuoiHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lueBuoiHoc.Location = new System.Drawing.Point(1427, 41);
            this.lueBuoiHoc.Name = "lueBuoiHoc";
            this.lueBuoiHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBuoiHoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenBuoiHoc", "Buổi học"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NgayHoc", "Ngày học", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueBuoiHoc.Properties.DisplayMember = "TenBuoiHoc";
            this.lueBuoiHoc.Properties.NullText = "[Chọn buổi học]";
            this.lueBuoiHoc.Properties.ValueMember = "ID";
            this.lueBuoiHoc.Size = new System.Drawing.Size(325, 34);
            this.lueBuoiHoc.TabIndex = 4;
            this.lueBuoiHoc.EditValueChanged += new System.EventHandler(this.lueBuoiHoc_EditValueChanged);
            // 
            // lueLopMonHoc
            // 
            this.lueLopMonHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lueLopMonHoc.Location = new System.Drawing.Point(892, 41);
            this.lueLopMonHoc.Name = "lueLopMonHoc";
            this.lueLopMonHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLopMonHoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLopMonHoc", "Mã lớp môn học"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLopMonHoc", "Tên lớp môn học")});
            this.lueLopMonHoc.Properties.DisplayMember = "TenLopMonHoc";
            this.lueLopMonHoc.Properties.NullText = "[Chọn lớp môn học]";
            this.lueLopMonHoc.Properties.ValueMember = "ID";
            this.lueLopMonHoc.Size = new System.Drawing.Size(392, 34);
            this.lueLopMonHoc.TabIndex = 3;
            this.lueLopMonHoc.EditValueChanged += new System.EventHandler(this.lueLopMonHoc_EditValueChanged);
            // 
            // txtPhong
            // 
            this.txtPhong.AutoSize = true;
            this.txtPhong.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhong.Location = new System.Drawing.Point(103, 45);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(0, 25);
            this.txtPhong.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng: ";
            // 
            // imgBarcode
            // 
            this.imgBarcode.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBarcode.Location = new System.Drawing.Point(3, 3);
            this.imgBarcode.Name = "imgBarcode";
            this.imgBarcode.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgBarcode.Size = new System.Drawing.Size(826, 861);
            this.imgBarcode.TabIndex = 0;
            this.imgBarcode.DoubleClick += new System.EventHandler(this.imgBarcode_DoubleClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.imgBarcode);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 117);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(832, 867);
            this.panelControl2.TabIndex = 1;
            // 
            // gcSV
            // 
            this.gcSV.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gcSV.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcSV.Location = new System.Drawing.Point(832, 117);
            this.gcSV.MainView = this.gvSV;
            this.gcSV.Name = "gcSV";
            this.gcSV.Size = new System.Drawing.Size(1257, 867);
            this.gcSV.TabIndex = 2;
            this.gcSV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSV});
            // 
            // gvSV
            // 
            this.gvSV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvSV.GridControl = this.gcSV;
            this.gvSV.Name = "gvSV";
            this.gvSV.OptionsView.ShowGroupPanel = false;
            this.gvSV.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvSV_CustomUnboundColumnData);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "STT";
            this.gridColumn7.FieldName = "gridColumn7";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 89;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã sinh viên";
            this.gridColumn2.FieldName = "MSV";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 277;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên sinh viên";
            this.gridColumn3.FieldName = "TenSV";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 349;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Có mặt";
            this.gridColumn4.FieldName = "DenLop";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 139;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Thời gian điểm danh";
            this.gridColumn5.DisplayFormat.FormatString = "hh:mm dd/MM/yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "TGDiemDanh";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 298;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tên khoa";
            this.gridColumn6.FieldName = "TenKhoa";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 274;
            // 
            // frm_ShowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2089, 984);
            this.Controls.Add(this.gcSV);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_ShowMain";
            this.Text = "TRANG CHỦ ĐIỂM DANH";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ShowMain_FormClosing);
            this.Load += new System.EventHandler(this.frm_ShowMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBuoiHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLopMonHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit imgBarcode;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label txtPhong;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnNap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lueBuoiHoc;
        private DevExpress.XtraEditors.LookUpEdit lueLopMonHoc;
        private DevExpress.XtraGrid.GridControl gcSV;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSV;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnChangeToken;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
    }
}