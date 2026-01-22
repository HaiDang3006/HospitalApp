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
            this.pnlButtonDonThuoc = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpDanhSachThuoc = new System.Windows.Forms.GroupBox();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.grpThongTinDonThuoc = new System.Windows.Forms.GroupBox();
            this.txtloidan = new System.Windows.Forms.TextBox();
            this.lblloidan = new System.Windows.Forms.Label();
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
            this.pnlButtonDonThuoc.SuspendLayout();
            this.grpDanhSachThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).BeginInit();
            this.grpThongTinDonThuoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtonDonThuoc
            // 
            this.pnlButtonDonThuoc.Controls.Add(this.btnDong);
            this.pnlButtonDonThuoc.Location = new System.Drawing.Point(22, 539);
            this.pnlButtonDonThuoc.Name = "pnlButtonDonThuoc";
            this.pnlButtonDonThuoc.Size = new System.Drawing.Size(858, 76);
            this.pnlButtonDonThuoc.TabIndex = 7;
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
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // grpDanhSachThuoc
            // 
            this.grpDanhSachThuoc.Controls.Add(this.dgvThuoc);
            this.grpDanhSachThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSachThuoc.Location = new System.Drawing.Point(19, 296);
            this.grpDanhSachThuoc.Name = "grpDanhSachThuoc";
            this.grpDanhSachThuoc.Size = new System.Drawing.Size(891, 237);
            this.grpDanhSachThuoc.TabIndex = 6;
            this.grpDanhSachThuoc.TabStop = false;
            this.grpDanhSachThuoc.Text = "Danh sách thuốc trong đơn";
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.AllowUserToAddRows = false;
            this.dgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuoc.Location = new System.Drawing.Point(6, 20);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.RowHeadersWidth = 51;
            this.dgvThuoc.RowTemplate.Height = 24;
            this.dgvThuoc.Size = new System.Drawing.Size(882, 211);
            this.dgvThuoc.TabIndex = 0;
            // 
            // grpThongTinDonThuoc
            // 
            this.grpThongTinDonThuoc.Controls.Add(this.txtloidan);
            this.grpThongTinDonThuoc.Controls.Add(this.lblloidan);
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
            this.grpThongTinDonThuoc.Location = new System.Drawing.Point(19, 99);
            this.grpThongTinDonThuoc.Name = "grpThongTinDonThuoc";
            this.grpThongTinDonThuoc.Size = new System.Drawing.Size(687, 191);
            this.grpThongTinDonThuoc.TabIndex = 5;
            this.grpThongTinDonThuoc.TabStop = false;
            this.grpThongTinDonThuoc.Text = "Thông tin đơn thuốc";
            // 
            // txtloidan
            // 
            this.txtloidan.Location = new System.Drawing.Point(163, 143);
            this.txtloidan.Multiline = true;
            this.txtloidan.Name = "txtloidan";
            this.txtloidan.Size = new System.Drawing.Size(145, 27);
            this.txtloidan.TabIndex = 11;
            // 
            // lblloidan
            // 
            this.lblloidan.AutoSize = true;
            this.lblloidan.Location = new System.Drawing.Point(18, 146);
            this.lblloidan.Name = "lblloidan";
            this.lblloidan.Size = new System.Drawing.Size(75, 20);
            this.lblloidan.TabIndex = 10;
            this.lblloidan.Text = "Lời Dặn";
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Chờ duyệt",
            "Đã kê",
            "Đã hủy"});
            this.cmbTrangThai.Location = new System.Drawing.Point(439, 88);
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
            this.txtMaPhieuKham.Location = new System.Drawing.Point(163, 71);
            this.txtMaPhieuKham.Name = "txtMaPhieuKham";
            this.txtMaPhieuKham.Size = new System.Drawing.Size(145, 27);
            this.txtMaPhieuKham.TabIndex = 3;
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
            this.lblTitleDonThuoc.Location = new System.Drawing.Point(225, 19);
            this.lblTitleDonThuoc.Name = "lblTitleDonThuoc";
            this.lblTitleDonThuoc.Size = new System.Drawing.Size(227, 38);
            this.lblTitleDonThuoc.TabIndex = 4;
            this.lblTitleDonThuoc.Text = "ĐƠN THUỐC";
            this.lblTitleDonThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uckedonthuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlButtonDonThuoc);
            this.Controls.Add(this.grpDanhSachThuoc);
            this.Controls.Add(this.grpThongTinDonThuoc);
            this.Controls.Add(this.lblTitleDonThuoc);
            this.Name = "uckedonthuoc";
            this.Size = new System.Drawing.Size(952, 663);
            this.Load += new System.EventHandler(this.uckedonthuoc_Load);
            this.pnlButtonDonThuoc.ResumeLayout(false);
            this.grpDanhSachThuoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).EndInit();
            this.grpThongTinDonThuoc.ResumeLayout(false);
            this.grpThongTinDonThuoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtonDonThuoc;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.GroupBox grpDanhSachThuoc;
        private System.Windows.Forms.DataGridView dgvThuoc;
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
        private System.Windows.Forms.Label lblTitleDonThuoc;
        private System.Windows.Forms.TextBox txtloidan;
        private System.Windows.Forms.Label lblloidan;
    }
}
