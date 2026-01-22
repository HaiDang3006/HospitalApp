namespace BenhVienS
{
    partial class ucDanhSachNhapThuoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.chkSapHetHang = new System.Windows.Forms.CheckBox();
            this.chkSapHetHan = new System.Windows.Forms.CheckBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cbQuay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.lbTongMatHang = new System.Windows.Forms.Label();
            this.lbCanhBao = new System.Windows.Forms.Label();
            this.btNhapMoi = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 56);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Tồn Kho Và Hạn Dùng Thuốc";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btTimKiem);
            this.panel2.Controls.Add(this.chkSapHetHang);
            this.panel2.Controls.Add(this.chkSapHetHan);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.cbQuay);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(907, 83);
            this.panel2.TabIndex = 2;
            // 
            // btTimKiem
            // 
            this.btTimKiem.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem.Location = new System.Drawing.Point(781, 33);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(114, 41);
            this.btTimKiem.TabIndex = 6;
            this.btTimKiem.Text = "Tìm Kiếm";
            this.btTimKiem.UseVisualStyleBackColor = true;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // chkSapHetHang
            // 
            this.chkSapHetHang.AutoSize = true;
            this.chkSapHetHang.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSapHetHang.Location = new System.Drawing.Point(533, 49);
            this.chkSapHetHang.Name = "chkSapHetHang";
            this.chkSapHetHang.Size = new System.Drawing.Size(204, 24);
            this.chkSapHetHang.TabIndex = 5;
            this.chkSapHetHang.Text = "Sắp hết hàng (SL < 10)";
            this.chkSapHetHang.UseVisualStyleBackColor = true;
            // 
            // chkSapHetHan
            // 
            this.chkSapHetHan.AutoSize = true;
            this.chkSapHetHan.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSapHetHan.Location = new System.Drawing.Point(533, 12);
            this.chkSapHetHan.Name = "chkSapHetHan";
            this.chkSapHetHan.Size = new System.Drawing.Size(197, 24);
            this.chkSapHetHan.TabIndex = 4;
            this.chkSapHetHan.Text = "Sắp hết hạn (3 tháng)";
            this.chkSapHetHan.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(238, 47);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(223, 27);
            this.txtTimKiem.TabIndex = 3;
            // 
            // cbQuay
            // 
            this.cbQuay.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuay.FormattingEnabled = true;
            this.cbQuay.Location = new System.Drawing.Point(112, 10);
            this.cbQuay.Name = "cbQuay";
            this.cbQuay.Size = new System.Drawing.Size(349, 28);
            this.cbQuay.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tìm Kiếm (Tên/Hoạt chất):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vị trí/Quầy:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvKho);
            this.panel3.Location = new System.Drawing.Point(0, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(907, 400);
            this.panel3.TabIndex = 3;
            // 
            // dgvKho
            // 
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Location = new System.Drawing.Point(3, 3);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.RowHeadersWidth = 51;
            this.dgvKho.RowTemplate.Height = 24;
            this.dgvKho.Size = new System.Drawing.Size(901, 394);
            this.dgvKho.TabIndex = 0;
            // 
            // lbTongMatHang
            // 
            this.lbTongMatHang.AutoSize = true;
            this.lbTongMatHang.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongMatHang.Location = new System.Drawing.Point(5, 567);
            this.lbTongMatHang.Name = "lbTongMatHang";
            this.lbTongMatHang.Size = new System.Drawing.Size(129, 20);
            this.lbTongMatHang.TabIndex = 4;
            this.lbTongMatHang.Text = "Tổng mặt hàng:";
            // 
            // lbCanhBao
            // 
            this.lbCanhBao.AutoSize = true;
            this.lbCanhBao.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCanhBao.Location = new System.Drawing.Point(315, 569);
            this.lbCanhBao.Name = "lbCanhBao";
            this.lbCanhBao.Size = new System.Drawing.Size(86, 20);
            this.lbCanhBao.TabIndex = 5;
            this.lbCanhBao.Text = "Cảnh báo:";
            // 
            // btNhapMoi
            // 
            this.btNhapMoi.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNhapMoi.Location = new System.Drawing.Point(781, 559);
            this.btNhapMoi.Name = "btNhapMoi";
            this.btNhapMoi.Size = new System.Drawing.Size(114, 41);
            this.btNhapMoi.TabIndex = 7;
            this.btNhapMoi.Text = "Nhập Mới";
            this.btNhapMoi.UseVisualStyleBackColor = true;
            this.btNhapMoi.Click += new System.EventHandler(this.btNhapMoi_Click);
            // 
            // btLuu
            // 
            this.btLuu.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.Location = new System.Drawing.Point(661, 557);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(114, 41);
            this.btLuu.TabIndex = 8;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // ucDanhSachNhapThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btNhapMoi);
            this.Controls.Add(this.lbCanhBao);
            this.Controls.Add(this.lbTongMatHang);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucDanhSachNhapThuoc";
            this.Size = new System.Drawing.Size(907, 603);
            this.Load += new System.EventHandler(this.ucDanhSachNhapThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbQuay;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.CheckBox chkSapHetHang;
        private System.Windows.Forms.CheckBox chkSapHetHan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Label lbTongMatHang;
        private System.Windows.Forms.Label lbCanhBao;
        private System.Windows.Forms.Button btNhapMoi;
        private System.Windows.Forms.Button btLuu;
    }
}
