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
            this.pnlButtonDonThuoc = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.grpDanhSachThuoc = new System.Windows.Forms.GroupBox();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.colTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLieuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuongDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpThongTinDonThuoc = new System.Windows.Forms.GroupBox();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiDon = new System.Windows.Forms.Label();
            this.dtpNgayKeDon = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKeDon = new System.Windows.Forms.Label();
            this.txtMaBacSi = new System.Windows.Forms.TextBox();
            this.lblMaBacSi = new System.Windows.Forms.Label();
            this.txtMaPhieuKham = new System.Windows.Forms.TextBox();
            this.lblMaPhieuKham = new System.Windows.Forms.Label();
            this.txtMaDonThuoc = new System.Windows.Forms.TextBox();
            this.lblMaDonThuoc = new System.Windows.Forms.Label();
            this.lblTitleDonThuoc = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlButtonDonThuoc.SuspendLayout();
            this.grpDanhSachThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).BeginInit();
            this.grpThongTinDonThuoc.SuspendLayout();
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
            // pnlButtonDonThuoc
            // 
            this.pnlButtonDonThuoc.Controls.Add(this.btnXoa);
            this.pnlButtonDonThuoc.Controls.Add(this.btnDong);
            this.pnlButtonDonThuoc.Controls.Add(this.btnSua);
            this.pnlButtonDonThuoc.Controls.Add(this.btnLuu);
            this.pnlButtonDonThuoc.Location = new System.Drawing.Point(52, 554);
            this.pnlButtonDonThuoc.Name = "pnlButtonDonThuoc";
            this.pnlButtonDonThuoc.Size = new System.Drawing.Size(684, 76);
            this.pnlButtonDonThuoc.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(515, 17);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(596, 17);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 30);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Blue;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(436, 17);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(73, 30);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Lime;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(357, 17);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(73, 30);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // grpDanhSachThuoc
            // 
            this.grpDanhSachThuoc.Controls.Add(this.dgvThuoc);
            this.grpDanhSachThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSachThuoc.Location = new System.Drawing.Point(49, 311);
            this.grpDanhSachThuoc.Name = "grpDanhSachThuoc";
            this.grpDanhSachThuoc.Size = new System.Drawing.Size(690, 237);
            this.grpDanhSachThuoc.TabIndex = 2;
            this.grpDanhSachThuoc.TabStop = false;
            this.grpDanhSachThuoc.Text = "Danh sách thuốc trong đơn";
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.AllowUserToAddRows = false;
            this.dgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenThuoc,
            this.colSoLuong,
            this.colLieuDung,
            this.colDuongDung,
            this.colGhiChu});
            this.dgvThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThuoc.Location = new System.Drawing.Point(3, 23);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.RowHeadersWidth = 51;
            this.dgvThuoc.RowTemplate.Height = 24;
            this.dgvThuoc.Size = new System.Drawing.Size(684, 211);
            this.dgvThuoc.TabIndex = 0;
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
            // grpThongTinDonThuoc
            // 
            this.grpThongTinDonThuoc.Controls.Add(this.cmbTrangThai);
            this.grpThongTinDonThuoc.Controls.Add(this.lblTrangThaiDon);
            this.grpThongTinDonThuoc.Controls.Add(this.dtpNgayKeDon);
            this.grpThongTinDonThuoc.Controls.Add(this.lblNgayKeDon);
            this.grpThongTinDonThuoc.Controls.Add(this.txtMaBacSi);
            this.grpThongTinDonThuoc.Controls.Add(this.lblMaBacSi);
            this.grpThongTinDonThuoc.Controls.Add(this.txtMaPhieuKham);
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
            // cmbTrangThai
            // 
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Chờ duyệt",
            "Đã kê",
            "Đã hủy"});
            this.cmbTrangThai.Location = new System.Drawing.Point(439, 83);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(200, 28);
            this.cmbTrangThai.TabIndex = 9;
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
            // txtMaBacSi
            // 
            this.txtMaBacSi.Location = new System.Drawing.Point(163, 102);
            this.txtMaBacSi.Name = "txtMaBacSi";
            this.txtMaBacSi.Size = new System.Drawing.Size(145, 27);
            this.txtMaBacSi.TabIndex = 5;
            this.txtMaBacSi.TextChanged += new System.EventHandler(this.txtMaBacSi_TextChanged);
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
            // txtMaPhieuKham
            // 
            this.txtMaPhieuKham.Location = new System.Drawing.Point(163, 64);
            this.txtMaPhieuKham.Name = "txtMaPhieuKham";
            this.txtMaPhieuKham.Size = new System.Drawing.Size(145, 27);
            this.txtMaPhieuKham.TabIndex = 3;
            this.txtMaPhieuKham.TextChanged += new System.EventHandler(this.txtMaPhieuKham_TextChanged_1);
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
            // txtMaDonThuoc
            // 
            this.txtMaDonThuoc.Location = new System.Drawing.Point(163, 31);
            this.txtMaDonThuoc.Name = "txtMaDonThuoc";
            this.txtMaDonThuoc.Size = new System.Drawing.Size(145, 27);
            this.txtMaDonThuoc.TabIndex = 1;
            this.txtMaDonThuoc.TextChanged += new System.EventHandler(this.txtMaDonThuoc_TextChanged);
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
            // lblTitleDonThuoc
            // 
            this.lblTitleDonThuoc.AutoSize = true;
            this.lblTitleDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDonThuoc.Location = new System.Drawing.Point(472, 47);
            this.lblTitleDonThuoc.Name = "lblTitleDonThuoc";
            this.lblTitleDonThuoc.Size = new System.Drawing.Size(227, 38);
            this.lblTitleDonThuoc.TabIndex = 0;
            this.lblTitleDonThuoc.Text = "ĐƠN THUỐC";
            this.lblTitleDonThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlButtonDonThuoc.ResumeLayout(false);
            this.grpDanhSachThuoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).EndInit();
            this.grpThongTinDonThuoc.ResumeLayout(false);
            this.grpThongTinDonThuoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitleDonThuoc;
        private System.Windows.Forms.GroupBox grpDanhSachThuoc;
        private System.Windows.Forms.DataGridView dgvThuoc;
        private System.Windows.Forms.Panel pnlButtonDonThuoc;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLieuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuongDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox grpThongTinDonThuoc;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label lblTrangThaiDon;
        private System.Windows.Forms.DateTimePicker dtpNgayKeDon;
        private System.Windows.Forms.Label lblNgayKeDon;
        private System.Windows.Forms.TextBox txtMaBacSi;
        private System.Windows.Forms.Label lblMaBacSi;
        private System.Windows.Forms.TextBox txtMaPhieuKham;
        private System.Windows.Forms.Label lblMaPhieuKham;
        private System.Windows.Forms.TextBox txtMaDonThuoc;
        private System.Windows.Forms.Label lblMaDonThuoc;
    }
}
