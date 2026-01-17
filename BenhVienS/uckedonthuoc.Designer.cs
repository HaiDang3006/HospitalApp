namespace BenhVienS
{
    partial class uckedonthuoc
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTitleDonThuoc = new System.Windows.Forms.Label();
            this.grpThongTinDonThuoc = new System.Windows.Forms.GroupBox();
            this.lblMaDonThuoc = new System.Windows.Forms.Label();
            this.txtMaDonThuoc = new System.Windows.Forms.TextBox();
            this.lblMaPhieuKham = new System.Windows.Forms.Label();
            this.txtMaPhieuKham_DT = new System.Windows.Forms.TextBox();
            this.lblMaBacSi = new System.Windows.Forms.Label();
            this.txtMaBacSi_DT = new System.Windows.Forms.TextBox();
            this.lblNgayKeDon = new System.Windows.Forms.Label();
            this.dtpNgayKeDon = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThaiDon = new System.Windows.Forms.Label();
            this.cboTrangThaiDon = new System.Windows.Forms.ComboBox();
            this.grpDanhSachThuoc = new System.Windows.Forms.GroupBox();
            this.dgvDonThuoc = new System.Windows.Forms.DataGridView();
            this.colTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLieuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuongDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtonDonThuoc = new System.Windows.Forms.Panel();
            this.btnLuuDonThuoc = new System.Windows.Forms.Button();
            this.btnSuaDonThuoc = new System.Windows.Forms.Button();
            this.btnDongDonThuoc = new System.Windows.Forms.Button();
            this.btnXoaDonThuoc = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpThongTinDonThuoc.SuspendLayout();
            this.grpDanhSachThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).BeginInit();
            this.pnlButtonDonThuoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlButtonDonThuoc);
            this.pnlMain.Controls.Add(this.grpDanhSachThuoc);
            this.pnlMain.Controls.Add(this.grpThongTinDonThuoc);
            this.pnlMain.Controls.Add(this.lblTitleDonThuoc);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1359, 720);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitleDonThuoc
            // 
            this.lblTitleDonThuoc.AutoSize = true;
            this.lblTitleDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDonThuoc.Location = new System.Drawing.Point(472, 47);
            this.lblTitleDonThuoc.Name = "lblTitleDonThuoc";
            this.lblTitleDonThuoc.Size = new System.Drawing.Size(233, 39);
            this.lblTitleDonThuoc.TabIndex = 0;
            this.lblTitleDonThuoc.Text = "ĐƠN THUỐC";
            this.lblTitleDonThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpThongTinDonThuoc
            // 
            this.grpThongTinDonThuoc.Controls.Add(this.cboTrangThaiDon);
            this.grpThongTinDonThuoc.Controls.Add(this.lblTrangThaiDon);
            this.grpThongTinDonThuoc.Controls.Add(this.dtpNgayKeDon);
            this.grpThongTinDonThuoc.Controls.Add(this.lblNgayKeDon);
            this.grpThongTinDonThuoc.Controls.Add(this.txtMaBacSi_DT);
            this.grpThongTinDonThuoc.Controls.Add(this.lblMaBacSi);
            this.grpThongTinDonThuoc.Controls.Add(this.txtMaPhieuKham_DT);
            this.grpThongTinDonThuoc.Controls.Add(this.lblMaPhieuKham);
            this.grpThongTinDonThuoc.Controls.Add(this.txtMaDonThuoc);
            this.grpThongTinDonThuoc.Controls.Add(this.lblMaDonThuoc);
            this.grpThongTinDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinDonThuoc.Location = new System.Drawing.Point(49, 114);
            this.grpThongTinDonThuoc.Name = "grpThongTinDonThuoc";
            this.grpThongTinDonThuoc.Size = new System.Drawing.Size(687, 191);
            this.grpThongTinDonThuoc.TabIndex = 1;
            this.grpThongTinDonThuoc.TabStop = false;
            this.grpThongTinDonThuoc.Text = "Thông tin đơn thuốc";
            // 
            // lblMaDonThuoc
            // 
            this.lblMaDonThuoc.AutoSize = true;
            this.lblMaDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDonThuoc.Location = new System.Drawing.Point(18, 38);
            this.lblMaDonThuoc.Name = "lblMaDonThuoc";
            this.lblMaDonThuoc.Size = new System.Drawing.Size(115, 20);
            this.lblMaDonThuoc.TabIndex = 0;
            this.lblMaDonThuoc.Text = "Mã đơn thuốc:";
            // 
            // txtMaDonThuoc
            // 
            this.txtMaDonThuoc.Location = new System.Drawing.Point(163, 31);
            this.txtMaDonThuoc.Name = "txtMaDonThuoc";
            this.txtMaDonThuoc.Size = new System.Drawing.Size(145, 27);
            this.txtMaDonThuoc.TabIndex = 1;
            // 
            // lblMaPhieuKham
            // 
            this.lblMaPhieuKham.AutoSize = true;
            this.lblMaPhieuKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuKham.Location = new System.Drawing.Point(18, 71);
            this.lblMaPhieuKham.Name = "lblMaPhieuKham";
            this.lblMaPhieuKham.Size = new System.Drawing.Size(127, 20);
            this.lblMaPhieuKham.TabIndex = 2;
            this.lblMaPhieuKham.Text = "Mã phiếu khám:";
            // 
            // txtMaPhieuKham_DT
            // 
            this.txtMaPhieuKham_DT.Location = new System.Drawing.Point(163, 64);
            this.txtMaPhieuKham_DT.Name = "txtMaPhieuKham_DT";
            this.txtMaPhieuKham_DT.Size = new System.Drawing.Size(145, 27);
            this.txtMaPhieuKham_DT.TabIndex = 3;
            // 
            // lblMaBacSi
            // 
            this.lblMaBacSi.AutoSize = true;
            this.lblMaBacSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBacSi.Location = new System.Drawing.Point(18, 105);
            this.lblMaBacSi.Name = "lblMaBacSi";
            this.lblMaBacSi.Size = new System.Drawing.Size(87, 20);
            this.lblMaBacSi.TabIndex = 4;
            this.lblMaBacSi.Text = "Mã bác sĩ:";
            // 
            // txtMaBacSi_DT
            // 
            this.txtMaBacSi_DT.Location = new System.Drawing.Point(163, 102);
            this.txtMaBacSi_DT.Name = "txtMaBacSi_DT";
            this.txtMaBacSi_DT.Size = new System.Drawing.Size(145, 27);
            this.txtMaBacSi_DT.TabIndex = 5;
            // 
            // lblNgayKeDon
            // 
            this.lblNgayKeDon.AutoSize = true;
            this.lblNgayKeDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKeDon.Location = new System.Drawing.Point(327, 38);
            this.lblNgayKeDon.Name = "lblNgayKeDon";
            this.lblNgayKeDon.Size = new System.Drawing.Size(106, 20);
            this.lblNgayKeDon.TabIndex = 6;
            this.lblNgayKeDon.Text = "Ngày kê đơn:";
            // 
            // dtpNgayKeDon
            // 
            this.dtpNgayKeDon.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKeDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKeDon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKeDon.Location = new System.Drawing.Point(439, 33);
            this.dtpNgayKeDon.Name = "dtpNgayKeDon";
            this.dtpNgayKeDon.Size = new System.Drawing.Size(200, 27);
            this.dtpNgayKeDon.TabIndex = 7;
            // 
            // lblTrangThaiDon
            // 
            this.lblTrangThaiDon.AutoSize = true;
            this.lblTrangThaiDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiDon.Location = new System.Drawing.Point(327, 88);
            this.lblTrangThaiDon.Name = "lblTrangThaiDon";
            this.lblTrangThaiDon.Size = new System.Drawing.Size(89, 20);
            this.lblTrangThaiDon.TabIndex = 8;
            this.lblTrangThaiDon.Text = "Trạng thái:";
            // 
            // cboTrangThaiDon
            // 
            this.cboTrangThaiDon.FormattingEnabled = true;
            this.cboTrangThaiDon.Items.AddRange(new object[] {
            "Chờ duyệt",
            "Đã kê",
            "Đã hủy"});
            this.cboTrangThaiDon.Location = new System.Drawing.Point(439, 83);
            this.cboTrangThaiDon.Name = "cboTrangThaiDon";
            this.cboTrangThaiDon.Size = new System.Drawing.Size(200, 28);
            this.cboTrangThaiDon.TabIndex = 9;
            // 
            // grpDanhSachThuoc
            // 
            this.grpDanhSachThuoc.Controls.Add(this.dgvDonThuoc);
            this.grpDanhSachThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSachThuoc.Location = new System.Drawing.Point(49, 311);
            this.grpDanhSachThuoc.Name = "grpDanhSachThuoc";
            this.grpDanhSachThuoc.Size = new System.Drawing.Size(690, 237);
            this.grpDanhSachThuoc.TabIndex = 2;
            this.grpDanhSachThuoc.TabStop = false;
            this.grpDanhSachThuoc.Text = "Danh sách thuốc trong đơn";
            // 
            // dgvDonThuoc
            // 
            this.dgvDonThuoc.AllowUserToAddRows = false;
            this.dgvDonThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenThuoc,
            this.colSoLuong,
            this.colLieuDung,
            this.colDuongDung,
            this.colGhiChu});
            this.dgvDonThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonThuoc.Location = new System.Drawing.Point(3, 23);
            this.dgvDonThuoc.Name = "dgvDonThuoc";
            this.dgvDonThuoc.RowHeadersWidth = 51;
            this.dgvDonThuoc.RowTemplate.Height = 24;
            this.dgvDonThuoc.Size = new System.Drawing.Size(684, 211);
            this.dgvDonThuoc.TabIndex = 0;
            // 
            // colTenThuoc
            // 
            this.colTenThuoc.HeaderText = "Tên thuốc";
            this.colTenThuoc.MinimumWidth = 6;
            this.colTenThuoc.Name = "colTenThuoc";
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colLieuDung
            // 
            this.colLieuDung.HeaderText = "Liều dùng";
            this.colLieuDung.MinimumWidth = 6;
            this.colLieuDung.Name = "colLieuDung";
            // 
            // colDuongDung
            // 
            this.colDuongDung.HeaderText = "Đường dùng";
            this.colDuongDung.MinimumWidth = 6;
            this.colDuongDung.Name = "colDuongDung";
            // 
            // colGhiChu
            // 
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.MinimumWidth = 6;
            this.colGhiChu.Name = "colGhiChu";
            // 
            // pnlButtonDonThuoc
            // 
            this.pnlButtonDonThuoc.Controls.Add(this.btnXoaDonThuoc);
            this.pnlButtonDonThuoc.Controls.Add(this.btnDongDonThuoc);
            this.pnlButtonDonThuoc.Controls.Add(this.btnSuaDonThuoc);
            this.pnlButtonDonThuoc.Controls.Add(this.btnLuuDonThuoc);
            this.pnlButtonDonThuoc.Location = new System.Drawing.Point(52, 554);
            this.pnlButtonDonThuoc.Name = "pnlButtonDonThuoc";
            this.pnlButtonDonThuoc.Size = new System.Drawing.Size(684, 76);
            this.pnlButtonDonThuoc.TabIndex = 3;
            // 
            // btnLuuDonThuoc
            // 
            this.btnLuuDonThuoc.BackColor = System.Drawing.Color.Lime;
            this.btnLuuDonThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuDonThuoc.ForeColor = System.Drawing.Color.White;
            this.btnLuuDonThuoc.Location = new System.Drawing.Point(357, 17);
            this.btnLuuDonThuoc.Name = "btnLuuDonThuoc";
            this.btnLuuDonThuoc.Size = new System.Drawing.Size(73, 30);
            this.btnLuuDonThuoc.TabIndex = 0;
            this.btnLuuDonThuoc.Text = "Lưu";
            this.btnLuuDonThuoc.UseVisualStyleBackColor = false;
            // 
            // btnSuaDonThuoc
            // 
            this.btnSuaDonThuoc.BackColor = System.Drawing.Color.Blue;
            this.btnSuaDonThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaDonThuoc.ForeColor = System.Drawing.Color.White;
            this.btnSuaDonThuoc.Location = new System.Drawing.Point(436, 17);
            this.btnSuaDonThuoc.Name = "btnSuaDonThuoc";
            this.btnSuaDonThuoc.Size = new System.Drawing.Size(73, 30);
            this.btnSuaDonThuoc.TabIndex = 1;
            this.btnSuaDonThuoc.Text = "Sửa";
            this.btnSuaDonThuoc.UseVisualStyleBackColor = false;
            // 
            // btnDongDonThuoc
            // 
            this.btnDongDonThuoc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDongDonThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongDonThuoc.ForeColor = System.Drawing.Color.White;
            this.btnDongDonThuoc.Location = new System.Drawing.Point(596, 17);
            this.btnDongDonThuoc.Name = "btnDongDonThuoc";
            this.btnDongDonThuoc.Size = new System.Drawing.Size(75, 30);
            this.btnDongDonThuoc.TabIndex = 2;
            this.btnDongDonThuoc.Text = "Đóng";
            this.btnDongDonThuoc.UseVisualStyleBackColor = false;
            // 
            // btnXoaDonThuoc
            // 
            this.btnXoaDonThuoc.BackColor = System.Drawing.Color.Red;
            this.btnXoaDonThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDonThuoc.ForeColor = System.Drawing.Color.White;
            this.btnXoaDonThuoc.Location = new System.Drawing.Point(515, 17);
            this.btnXoaDonThuoc.Name = "btnXoaDonThuoc";
            this.btnXoaDonThuoc.Size = new System.Drawing.Size(75, 30);
            this.btnXoaDonThuoc.TabIndex = 3;
            this.btnXoaDonThuoc.Text = "Xóa";
            this.btnXoaDonThuoc.UseVisualStyleBackColor = false;
            // 
            // uckedonthuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "uckedonthuoc";
            this.Size = new System.Drawing.Size(1359, 720);
            this.Load += new System.EventHandler(this.uckedonthuoc_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.grpThongTinDonThuoc.ResumeLayout(false);
            this.grpThongTinDonThuoc.PerformLayout();
            this.grpDanhSachThuoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).EndInit();
            this.pnlButtonDonThuoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpThongTinDonThuoc;
        private System.Windows.Forms.Label lblTitleDonThuoc;
        private System.Windows.Forms.DateTimePicker dtpNgayKeDon;
        private System.Windows.Forms.Label lblNgayKeDon;
        private System.Windows.Forms.TextBox txtMaBacSi_DT;
        private System.Windows.Forms.Label lblMaBacSi;
        private System.Windows.Forms.TextBox txtMaPhieuKham_DT;
        private System.Windows.Forms.Label lblMaPhieuKham;
        private System.Windows.Forms.TextBox txtMaDonThuoc;
        private System.Windows.Forms.Label lblMaDonThuoc;
        private System.Windows.Forms.ComboBox cboTrangThaiDon;
        private System.Windows.Forms.Label lblTrangThaiDon;
        private System.Windows.Forms.GroupBox grpDanhSachThuoc;
        private System.Windows.Forms.DataGridView dgvDonThuoc;
        private System.Windows.Forms.Panel pnlButtonDonThuoc;
        private System.Windows.Forms.Button btnLuuDonThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLieuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuongDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Button btnXoaDonThuoc;
        private System.Windows.Forms.Button btnDongDonThuoc;
        private System.Windows.Forms.Button btnSuaDonThuoc;
    }
}
