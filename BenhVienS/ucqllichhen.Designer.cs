namespace BenhVienS
{
    partial class ucqllichhen
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
            this.btnInPhieu = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvLichHen = new System.Windows.Forms.DataGridView();
            this.colMaLichHen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaBenhNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaBacSi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayHen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGianDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLydokham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhThucDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblThoiGianDen = new System.Windows.Forms.Label();
            this.lblLyDoKham = new System.Windows.Forms.Label();
            this.lblMaLichHen = new System.Windows.Forms.Label();
            this.lblHinhThucDat = new System.Windows.Forms.Label();
            this.cboGhiChu = new System.Windows.Forms.ComboBox();
            this.cboLyDoKham = new System.Windows.Forms.ComboBox();
            this.dtpThoiGianDen = new System.Windows.Forms.DateTimePicker();
            this.cboMaLichHen = new System.Windows.Forms.ComboBox();
            this.cboHinhThucDat = new System.Windows.Forms.ComboBox();
            this.btnDatLichMoi = new System.Windows.Forms.Button();
            this.dtpNgayHen = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHen = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboMaBacSi = new System.Windows.Forms.ComboBox();
            this.lblMaBS = new System.Windows.Forms.Label();
            this.cboMaBenhNhan = new System.Windows.Forms.ComboBox();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnInPhieu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Controls.Add(this.pnlMain);
            this.btnInPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInPhieu.ForeColor = System.Drawing.Color.White;
            this.btnInPhieu.Location = new System.Drawing.Point(0, 0);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(1244, 705);
            this.btnInPhieu.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnHuy);
            this.pnlMain.Controls.Add(this.btnSua);
            this.pnlMain.Controls.Add(this.dgvLichHen);
            this.pnlMain.Controls.Add(this.grpFilter);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.ForeColor = System.Drawing.Color.Turquoise;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1244, 705);
            this.pnlMain.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Transparent;
            this.btnHuy.Location = new System.Drawing.Point(843, 476);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(74, 35);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Xóa";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Blue;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Transparent;
            this.btnSua.Location = new System.Drawing.Point(763, 476);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(74, 35);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvLichHen
            // 
            this.dgvLichHen.AllowUserToAddRows = false;
            this.dgvLichHen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichHen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichHen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLichHen,
            this.colMaBenhNhan,
            this.colMaBacSi,
            this.colNgayHen,
            this.colThoiGianDen,
            this.colLydokham,
            this.colHinhThucDat,
            this.colTrangThai,
            this.colGhichu});
            this.dgvLichHen.Location = new System.Drawing.Point(20, 240);
            this.dgvLichHen.Name = "dgvLichHen";
            this.dgvLichHen.ReadOnly = true;
            this.dgvLichHen.RowHeadersVisible = false;
            this.dgvLichHen.RowHeadersWidth = 51;
            this.dgvLichHen.RowTemplate.Height = 24;
            this.dgvLichHen.Size = new System.Drawing.Size(900, 300);
            this.dgvLichHen.TabIndex = 2;
            this.dgvLichHen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichHen_CellContentClick);
            // 
            // colMaLichHen
            // 
            this.colMaLichHen.DataPropertyName = "MaLichHen";
            this.colMaLichHen.HeaderText = "Mã lịch hẹn";
            this.colMaLichHen.MinimumWidth = 6;
            this.colMaLichHen.Name = "colMaLichHen";
            this.colMaLichHen.ReadOnly = true;
            // 
            // colMaBenhNhan
            // 
            this.colMaBenhNhan.DataPropertyName = "MaBenhNhan";
            this.colMaBenhNhan.HeaderText = "Mã bệnh nhân";
            this.colMaBenhNhan.MinimumWidth = 6;
            this.colMaBenhNhan.Name = "colMaBenhNhan";
            this.colMaBenhNhan.ReadOnly = true;
            // 
            // colMaBacSi
            // 
            this.colMaBacSi.DataPropertyName = "MaBacSi";
            this.colMaBacSi.HeaderText = "Mã bác sĩ";
            this.colMaBacSi.MinimumWidth = 6;
            this.colMaBacSi.Name = "colMaBacSi";
            this.colMaBacSi.ReadOnly = true;
            // 
            // colNgayHen
            // 
            this.colNgayHen.DataPropertyName = "NgayHen";
            this.colNgayHen.HeaderText = "Ngày hẹn";
            this.colNgayHen.MinimumWidth = 6;
            this.colNgayHen.Name = "colNgayHen";
            this.colNgayHen.ReadOnly = true;
            // 
            // colThoiGianDen
            // 
            this.colThoiGianDen.DataPropertyName = "ThoiGianDen";
            this.colThoiGianDen.HeaderText = "Thời gian đến";
            this.colThoiGianDen.MinimumWidth = 6;
            this.colThoiGianDen.Name = "colThoiGianDen";
            this.colThoiGianDen.ReadOnly = true;
            // 
            // colLydokham
            // 
            this.colLydokham.DataPropertyName = "LyDoKham";
            this.colLydokham.HeaderText = "Lý do khám";
            this.colLydokham.MinimumWidth = 6;
            this.colLydokham.Name = "colLydokham";
            this.colLydokham.ReadOnly = true;
            // 
            // colHinhThucDat
            // 
            this.colHinhThucDat.DataPropertyName = "HinhThucDat";
            this.colHinhThucDat.HeaderText = "Hình thức đặt";
            this.colHinhThucDat.MinimumWidth = 6;
            this.colHinhThucDat.Name = "colHinhThucDat";
            this.colHinhThucDat.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colGhichu
            // 
            this.colGhichu.DataPropertyName = "GhiChu";
            this.colGhichu.HeaderText = "Ghi chú";
            this.colGhichu.MinimumWidth = 6;
            this.colGhichu.Name = "colGhichu";
            this.colGhichu.ReadOnly = true;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblGhiChu);
            this.grpFilter.Controls.Add(this.lblThoiGianDen);
            this.grpFilter.Controls.Add(this.lblLyDoKham);
            this.grpFilter.Controls.Add(this.lblMaLichHen);
            this.grpFilter.Controls.Add(this.lblHinhThucDat);
            this.grpFilter.Controls.Add(this.cboGhiChu);
            this.grpFilter.Controls.Add(this.cboLyDoKham);
            this.grpFilter.Controls.Add(this.dtpThoiGianDen);
            this.grpFilter.Controls.Add(this.cboMaLichHen);
            this.grpFilter.Controls.Add(this.cboHinhThucDat);
            this.grpFilter.Controls.Add(this.btnDatLichMoi);
            this.grpFilter.Controls.Add(this.dtpNgayHen);
            this.grpFilter.Controls.Add(this.lblNgayHen);
            this.grpFilter.Controls.Add(this.cboTrangThai);
            this.grpFilter.Controls.Add(this.lblTrangThai);
            this.grpFilter.Controls.Add(this.cboMaBacSi);
            this.grpFilter.Controls.Add(this.lblMaBS);
            this.grpFilter.Controls.Add(this.cboMaBenhNhan);
            this.grpFilter.Controls.Add(this.lblMaBN);
            this.grpFilter.Location = new System.Drawing.Point(20, 50);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(900, 184);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Bộ lọc tìm kiếm";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.Black;
            this.lblGhiChu.Location = new System.Drawing.Point(586, 158);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(51, 16);
            this.lblGhiChu.TabIndex = 19;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // lblThoiGianDen
            // 
            this.lblThoiGianDen.AutoSize = true;
            this.lblThoiGianDen.ForeColor = System.Drawing.Color.Black;
            this.lblThoiGianDen.Location = new System.Drawing.Point(266, 158);
            this.lblThoiGianDen.Name = "lblThoiGianDen";
            this.lblThoiGianDen.Size = new System.Drawing.Size(92, 16);
            this.lblThoiGianDen.TabIndex = 18;
            this.lblThoiGianDen.Text = "Thời gian đến ";
            // 
            // lblLyDoKham
            // 
            this.lblLyDoKham.AutoSize = true;
            this.lblLyDoKham.ForeColor = System.Drawing.Color.Black;
            this.lblLyDoKham.Location = new System.Drawing.Point(266, 35);
            this.lblLyDoKham.Name = "lblLyDoKham";
            this.lblLyDoKham.Size = new System.Drawing.Size(76, 16);
            this.lblLyDoKham.TabIndex = 17;
            this.lblLyDoKham.Text = "Lý do khám";
            // 
            // lblMaLichHen
            // 
            this.lblMaLichHen.AutoSize = true;
            this.lblMaLichHen.ForeColor = System.Drawing.Color.Black;
            this.lblMaLichHen.Location = new System.Drawing.Point(20, 162);
            this.lblMaLichHen.Name = "lblMaLichHen";
            this.lblMaLichHen.Size = new System.Drawing.Size(81, 16);
            this.lblMaLichHen.TabIndex = 16;
            this.lblMaLichHen.Text = "Mã Lịch Hẹn";
            // 
            // lblHinhThucDat
            // 
            this.lblHinhThucDat.AutoSize = true;
            this.lblHinhThucDat.ForeColor = System.Drawing.Color.Black;
            this.lblHinhThucDat.Location = new System.Drawing.Point(20, 118);
            this.lblHinhThucDat.Name = "lblHinhThucDat";
            this.lblHinhThucDat.Size = new System.Drawing.Size(83, 16);
            this.lblHinhThucDat.TabIndex = 15;
            this.lblHinhThucDat.Text = "Hình thức đặt";
            // 
            // cboGhiChu
            // 
            this.cboGhiChu.FormattingEnabled = true;
            this.cboGhiChu.Location = new System.Drawing.Point(677, 150);
            this.cboGhiChu.Name = "cboGhiChu";
            this.cboGhiChu.Size = new System.Drawing.Size(200, 24);
            this.cboGhiChu.TabIndex = 14;
            // 
            // cboLyDoKham
            // 
            this.cboLyDoKham.FormattingEnabled = true;
            this.cboLyDoKham.Location = new System.Drawing.Point(367, 27);
            this.cboLyDoKham.Name = "cboLyDoKham";
            this.cboLyDoKham.Size = new System.Drawing.Size(200, 24);
            this.cboLyDoKham.TabIndex = 13;
            // 
            // dtpThoiGianDen
            // 
            this.dtpThoiGianDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThoiGianDen.Location = new System.Drawing.Point(367, 152);
            this.dtpThoiGianDen.Name = "dtpThoiGianDen";
            this.dtpThoiGianDen.Size = new System.Drawing.Size(200, 22);
            this.dtpThoiGianDen.TabIndex = 12;
            // 
            // cboMaLichHen
            // 
            this.cboMaLichHen.FormattingEnabled = true;
            this.cboMaLichHen.Location = new System.Drawing.Point(120, 154);
            this.cboMaLichHen.Name = "cboMaLichHen";
            this.cboMaLichHen.Size = new System.Drawing.Size(121, 24);
            this.cboMaLichHen.TabIndex = 11;
            // 
            // cboHinhThucDat
            // 
            this.cboHinhThucDat.FormattingEnabled = true;
            this.cboHinhThucDat.Location = new System.Drawing.Point(120, 110);
            this.cboHinhThucDat.Name = "cboHinhThucDat";
            this.cboHinhThucDat.Size = new System.Drawing.Size(121, 24);
            this.cboHinhThucDat.TabIndex = 10;
            // 
            // btnDatLichMoi
            // 
            this.btnDatLichMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDatLichMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLichMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatLichMoi.ForeColor = System.Drawing.Color.Transparent;
            this.btnDatLichMoi.Location = new System.Drawing.Point(677, 21);
            this.btnDatLichMoi.Name = "btnDatLichMoi";
            this.btnDatLichMoi.Size = new System.Drawing.Size(200, 32);
            this.btnDatLichMoi.TabIndex = 9;
            this.btnDatLichMoi.Text = "Đặt lịch hẹn mới";
            this.btnDatLichMoi.UseVisualStyleBackColor = false;
            this.btnDatLichMoi.Click += new System.EventHandler(this.btnDatLichMoi_Click);
            // 
            // dtpNgayHen
            // 
            this.dtpNgayHen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHen.Location = new System.Drawing.Point(367, 112);
            this.dtpNgayHen.Name = "dtpNgayHen";
            this.dtpNgayHen.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayHen.TabIndex = 7;
            // 
            // lblNgayHen
            // 
            this.lblNgayHen.AutoSize = true;
            this.lblNgayHen.ForeColor = System.Drawing.Color.Black;
            this.lblNgayHen.Location = new System.Drawing.Point(266, 117);
            this.lblNgayHen.Name = "lblNgayHen";
            this.lblNgayHen.Size = new System.Drawing.Size(68, 16);
            this.lblNgayHen.TabIndex = 6;
            this.lblNgayHen.Text = "Ngày hẹn:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(367, 69);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(200, 24);
            this.cboTrangThai.TabIndex = 5;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.ForeColor = System.Drawing.Color.Black;
            this.lblTrangThai.Location = new System.Drawing.Point(266, 77);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(70, 16);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboMaBacSi
            // 
            this.cboMaBacSi.FormattingEnabled = true;
            this.cboMaBacSi.Location = new System.Drawing.Point(120, 64);
            this.cboMaBacSi.Name = "cboMaBacSi";
            this.cboMaBacSi.Size = new System.Drawing.Size(121, 24);
            this.cboMaBacSi.TabIndex = 3;
            // 
            // lblMaBS
            // 
            this.lblMaBS.AutoSize = true;
            this.lblMaBS.ForeColor = System.Drawing.Color.Black;
            this.lblMaBS.Location = new System.Drawing.Point(20, 72);
            this.lblMaBS.Name = "lblMaBS";
            this.lblMaBS.Size = new System.Drawing.Size(70, 16);
            this.lblMaBS.TabIndex = 2;
            this.lblMaBS.Text = "Mã bác sĩ:";
            // 
            // cboMaBenhNhan
            // 
            this.cboMaBenhNhan.FormattingEnabled = true;
            this.cboMaBenhNhan.Location = new System.Drawing.Point(120, 22);
            this.cboMaBenhNhan.Name = "cboMaBenhNhan";
            this.cboMaBenhNhan.Size = new System.Drawing.Size(121, 24);
            this.cboMaBenhNhan.TabIndex = 1;
            // 
            // lblMaBN
            // 
            this.lblMaBN.AutoSize = true;
            this.lblMaBN.ForeColor = System.Drawing.Color.Black;
            this.lblMaBN.Location = new System.Drawing.Point(20, 30);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(94, 16);
            this.lblMaBN.TabIndex = 0;
            this.lblMaBN.Text = "Mã bệnh nhân:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(438, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(289, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ LỊCH HẸN";
            // 
            // ucqllichhen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInPhieu);
            this.Name = "ucqllichhen";
            this.Size = new System.Drawing.Size(1244, 705);
            this.Load += new System.EventHandler(this.ucqllichhen_Load);
            this.btnInPhieu.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btnInPhieu;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpNgayHen;
        private System.Windows.Forms.Label lblNgayHen;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboMaBacSi;
        private System.Windows.Forms.Label lblMaBS;
        private System.Windows.Forms.ComboBox cboMaBenhNhan;
        private System.Windows.Forms.Label lblMaBN;
        private System.Windows.Forms.DataGridView dgvLichHen;
        private System.Windows.Forms.Button btnDatLichMoi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLichHen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBenhNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBacSi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayHen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGianDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLydokham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHinhThucDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhichu;
        private System.Windows.Forms.ComboBox cboGhiChu;
        private System.Windows.Forms.ComboBox cboLyDoKham;
        private System.Windows.Forms.DateTimePicker dtpThoiGianDen;
        private System.Windows.Forms.ComboBox cboMaLichHen;
        private System.Windows.Forms.ComboBox cboHinhThucDat;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblThoiGianDen;
        private System.Windows.Forms.Label lblLyDoKham;
        private System.Windows.Forms.Label lblMaLichHen;
        private System.Windows.Forms.Label lblHinhThucDat;
    }
}
