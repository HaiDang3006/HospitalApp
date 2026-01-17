namespace BenhVienS
{
    partial class uchsbenhan
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtMaHoSo = new System.Windows.Forms.Label();
            this.txtHoSoID = new System.Windows.Forms.TextBox();
            this.lblMaBenhNhan = new System.Windows.Forms.Label();
            this.txtBenhNhanID = new System.Windows.Forms.TextBox();
            this.lblMaPhieuKham = new System.Windows.Forms.Label();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.txtPhieuKhamID = new System.Windows.Forms.TextBox();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.grpTienSu = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label = new System.Windows.Forms.Label();
            this.txtTienSuBenhAn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiUngBenhAn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTienSuGiaDinhBenhAn = new System.Windows.Forms.TextBox();
            this.btnLuuHoSo = new System.Windows.Forms.Button();
            this.btnSuaHoSo = new System.Windows.Forms.Button();
            this.btnXoaHoSo = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpTienSu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpTienSu);
            this.pnlMain.Controls.Add(this.grpThongTin);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1354, 677);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(450, 69);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(263, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỒ SƠ BỆNH ÁN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.dtpNgayTao);
            this.grpThongTin.Controls.Add(this.txtPhieuKhamID);
            this.grpThongTin.Controls.Add(this.lblNgayTao);
            this.grpThongTin.Controls.Add(this.lblMaPhieuKham);
            this.grpThongTin.Controls.Add(this.txtBenhNhanID);
            this.grpThongTin.Controls.Add(this.lblMaBenhNhan);
            this.grpThongTin.Controls.Add(this.txtHoSoID);
            this.grpThongTin.Controls.Add(this.txtMaHoSo);
            this.grpThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTin.Location = new System.Drawing.Point(21, 131);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(1058, 220);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin hồ sơ";
            this.grpThongTin.Enter += new System.EventHandler(this.grpThongTin_Enter);
            // 
            // txtMaHoSo
            // 
            this.txtMaHoSo.AutoSize = true;
            this.txtMaHoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoSo.Location = new System.Drawing.Point(24, 39);
            this.txtMaHoSo.Name = "txtMaHoSo";
            this.txtMaHoSo.Size = new System.Drawing.Size(83, 20);
            this.txtMaHoSo.TabIndex = 0;
            this.txtMaHoSo.Text = "Mã hồ sơ:";
            this.txtMaHoSo.Click += new System.EventHandler(this.txtMaHoSo_Click);
            // 
            // txtHoSoID
            // 
            this.txtHoSoID.Location = new System.Drawing.Point(226, 26);
            this.txtHoSoID.Name = "txtHoSoID";
            this.txtHoSoID.Size = new System.Drawing.Size(200, 27);
            this.txtHoSoID.TabIndex = 1;
            this.txtHoSoID.TextChanged += new System.EventHandler(this.txtHoSoID_TextChanged);
            // 
            // lblMaBenhNhan
            // 
            this.lblMaBenhNhan.AutoSize = true;
            this.lblMaBenhNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBenhNhan.Location = new System.Drawing.Point(24, 77);
            this.lblMaBenhNhan.Name = "lblMaBenhNhan";
            this.lblMaBenhNhan.Size = new System.Drawing.Size(119, 20);
            this.lblMaBenhNhan.TabIndex = 2;
            this.lblMaBenhNhan.Text = "Mã bệnh nhân:";
            this.lblMaBenhNhan.Click += new System.EventHandler(this.lblMaBenhNhan_Click);
            // 
            // txtBenhNhanID
            // 
            this.txtBenhNhanID.Location = new System.Drawing.Point(226, 70);
            this.txtBenhNhanID.Name = "txtBenhNhanID";
            this.txtBenhNhanID.Size = new System.Drawing.Size(200, 27);
            this.txtBenhNhanID.TabIndex = 3;
            this.txtBenhNhanID.TextChanged += new System.EventHandler(this.txtBenhNhanID_TextChanged);
            // 
            // lblMaPhieuKham
            // 
            this.lblMaPhieuKham.AutoSize = true;
            this.lblMaPhieuKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuKham.Location = new System.Drawing.Point(24, 115);
            this.lblMaPhieuKham.Name = "lblMaPhieuKham";
            this.lblMaPhieuKham.Size = new System.Drawing.Size(127, 20);
            this.lblMaPhieuKham.TabIndex = 4;
            this.lblMaPhieuKham.Text = "Mã phiếu khám:";
            this.lblMaPhieuKham.Click += new System.EventHandler(this.lblMaPhieuKham_Click);
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTao.Location = new System.Drawing.Point(24, 152);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(80, 20);
            this.lblNgayTao.TabIndex = 5;
            this.lblNgayTao.Text = "Ngày tạo:";
            this.lblNgayTao.Click += new System.EventHandler(this.lblNgayTao_Click);
            // 
            // txtPhieuKhamID
            // 
            this.txtPhieuKhamID.Location = new System.Drawing.Point(226, 108);
            this.txtPhieuKhamID.Name = "txtPhieuKhamID";
            this.txtPhieuKhamID.Size = new System.Drawing.Size(200, 27);
            this.txtPhieuKhamID.TabIndex = 6;
            this.txtPhieuKhamID.TextChanged += new System.EventHandler(this.txtPhieuKhamID_TextChanged);
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(226, 152);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(200, 27);
            this.dtpNgayTao.TabIndex = 7;
            this.dtpNgayTao.ValueChanged += new System.EventHandler(this.dtpNgayTao_ValueChanged);
            // 
            // grpTienSu
            // 
            this.grpTienSu.Controls.Add(this.btnXoaHoSo);
            this.grpTienSu.Controls.Add(this.btnSuaHoSo);
            this.grpTienSu.Controls.Add(this.btnLuuHoSo);
            this.grpTienSu.Controls.Add(this.txtTienSuGiaDinhBenhAn);
            this.grpTienSu.Controls.Add(this.label2);
            this.grpTienSu.Controls.Add(this.txtDiUngBenhAn);
            this.grpTienSu.Controls.Add(this.label1);
            this.grpTienSu.Controls.Add(this.txtTienSuBenhAn);
            this.grpTienSu.Controls.Add(this.label);
            this.grpTienSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTienSu.Location = new System.Drawing.Point(21, 372);
            this.grpTienSu.Name = "grpTienSu";
            this.grpTienSu.Size = new System.Drawing.Size(1058, 213);
            this.grpTienSu.TabIndex = 2;
            this.grpTienSu.TabStop = false;
            this.grpTienSu.Text = "Tiền sử và dị ứng";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(24, 40);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(110, 20);
            this.label.TabIndex = 0;
            this.label.Text = "Tiền sử bệnh:";
            // 
            // txtTienSuBenhAn
            // 
            this.txtTienSuBenhAn.Location = new System.Drawing.Point(226, 37);
            this.txtTienSuBenhAn.Name = "txtTienSuBenhAn";
            this.txtTienSuBenhAn.Size = new System.Drawing.Size(200, 27);
            this.txtTienSuBenhAn.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dị ứng:";
            // 
            // txtDiUngBenhAn
            // 
            this.txtDiUngBenhAn.Location = new System.Drawing.Point(226, 71);
            this.txtDiUngBenhAn.Name = "txtDiUngBenhAn";
            this.txtDiUngBenhAn.Size = new System.Drawing.Size(200, 27);
            this.txtDiUngBenhAn.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tiền sử gia đình:";
            // 
            // txtTienSuGiaDinhBenhAn
            // 
            this.txtTienSuGiaDinhBenhAn.Location = new System.Drawing.Point(226, 105);
            this.txtTienSuGiaDinhBenhAn.Name = "txtTienSuGiaDinhBenhAn";
            this.txtTienSuGiaDinhBenhAn.Size = new System.Drawing.Size(200, 27);
            this.txtTienSuGiaDinhBenhAn.TabIndex = 6;
            // 
            // btnLuuHoSo
            // 
            this.btnLuuHoSo.BackColor = System.Drawing.Color.Lime;
            this.btnLuuHoSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuHoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuHoSo.ForeColor = System.Drawing.Color.White;
            this.btnLuuHoSo.Location = new System.Drawing.Point(189, 150);
            this.btnLuuHoSo.Name = "btnLuuHoSo";
            this.btnLuuHoSo.Size = new System.Drawing.Size(75, 34);
            this.btnLuuHoSo.TabIndex = 7;
            this.btnLuuHoSo.Text = "Lưu";
            this.btnLuuHoSo.UseVisualStyleBackColor = false;
            // 
            // btnSuaHoSo
            // 
            this.btnSuaHoSo.BackColor = System.Drawing.Color.Blue;
            this.btnSuaHoSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaHoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaHoSo.ForeColor = System.Drawing.Color.White;
            this.btnSuaHoSo.Location = new System.Drawing.Point(270, 150);
            this.btnSuaHoSo.Name = "btnSuaHoSo";
            this.btnSuaHoSo.Size = new System.Drawing.Size(75, 34);
            this.btnSuaHoSo.TabIndex = 8;
            this.btnSuaHoSo.Text = "Sửa";
            this.btnSuaHoSo.UseVisualStyleBackColor = false;
            // 
            // btnXoaHoSo
            // 
            this.btnXoaHoSo.BackColor = System.Drawing.Color.Red;
            this.btnXoaHoSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaHoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHoSo.ForeColor = System.Drawing.Color.White;
            this.btnXoaHoSo.Location = new System.Drawing.Point(351, 150);
            this.btnXoaHoSo.Name = "btnXoaHoSo";
            this.btnXoaHoSo.Size = new System.Drawing.Size(75, 34);
            this.btnXoaHoSo.TabIndex = 9;
            this.btnXoaHoSo.Text = "Xóa";
            this.btnXoaHoSo.UseVisualStyleBackColor = false;
            // 
            // uchsbenhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "uchsbenhan";
            this.Size = new System.Drawing.Size(1354, 677);
            this.Load += new System.EventHandler(this.uchsbenhan_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpTienSu.ResumeLayout(false);
            this.grpTienSu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Label lblMaPhieuKham;
        private System.Windows.Forms.TextBox txtBenhNhanID;
        private System.Windows.Forms.Label lblMaBenhNhan;
        private System.Windows.Forms.TextBox txtHoSoID;
        private System.Windows.Forms.Label txtMaHoSo;
        private System.Windows.Forms.TextBox txtPhieuKhamID;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.GroupBox grpTienSu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiUngBenhAn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTienSuBenhAn;
        private System.Windows.Forms.Label label;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnSuaHoSo;
        private System.Windows.Forms.Button btnLuuHoSo;
        private System.Windows.Forms.TextBox txtTienSuGiaDinhBenhAn;
        private System.Windows.Forms.Button btnXoaHoSo;
    }
}
