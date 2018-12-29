namespace MANAGER_TLU_MAIN
{
    partial class frmQR
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
            this.imgBarcode = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBarcode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBarcode
            // 
            this.imgBarcode.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBarcode.Location = new System.Drawing.Point(0, 0);
            this.imgBarcode.Name = "imgBarcode";
            this.imgBarcode.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgBarcode.Size = new System.Drawing.Size(1738, 1003);
            this.imgBarcode.TabIndex = 1;
            // 
            // frmQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1738, 1003);
            this.Controls.Add(this.imgBarcode);
            this.Name = "frmQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR ĐIỂM DANH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBarcode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit imgBarcode;
    }
}