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
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDonThuoc = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTongLoaiThuoc = new System.Windows.Forms.Label();
            this.la1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbTongSoLuong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbTongChiPhi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btTimkiem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(331, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH NHẬP THUỐC";
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimkiem.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTimkiem.Location = new System.Drawing.Point(3, 62);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(502, 30);
            this.txtTimkiem.TabIndex = 8;
            this.txtTimkiem.Text = "Nhập mã phiếu, nhà cung cấp";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDonThuoc);
            this.panel3.Location = new System.Drawing.Point(0, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1087, 350);
            this.panel3.TabIndex = 11;
            // 
            // dgvDonThuoc
            // 
            this.dgvDonThuoc.AllowUserToAddRows = false;
            this.dgvDonThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonThuoc.Location = new System.Drawing.Point(3, 0);
            this.dgvDonThuoc.Name = "dgvDonThuoc";
            this.dgvDonThuoc.ReadOnly = true;
            this.dgvDonThuoc.RowHeadersVisible = false;
            this.dgvDonThuoc.RowHeadersWidth = 51;
            this.dgvDonThuoc.RowTemplate.Height = 24;
            this.dgvDonThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonThuoc.Size = new System.Drawing.Size(891, 343);
            this.dgvDonThuoc.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.lbTongLoaiThuoc);
            this.panel2.Controls.Add(this.la1);
            this.panel2.Location = new System.Drawing.Point(3, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 80);
            this.panel2.TabIndex = 13;
            // 
            // lbTongLoaiThuoc
            // 
            this.lbTongLoaiThuoc.AutoSize = true;
            this.lbTongLoaiThuoc.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongLoaiThuoc.Location = new System.Drawing.Point(19, 29);
            this.lbTongLoaiThuoc.Name = "lbTongLoaiThuoc";
            this.lbTongLoaiThuoc.Size = new System.Drawing.Size(34, 37);
            this.lbTongLoaiThuoc.TabIndex = 4;
            this.lbTongLoaiThuoc.Text = "0";
            // 
            // la1
            // 
            this.la1.AutoSize = true;
            this.la1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la1.Location = new System.Drawing.Point(22, 9);
            this.la1.Name = "la1";
            this.la1.Size = new System.Drawing.Size(183, 20);
            this.la1.TabIndex = 3;
            this.la1.Text = "Tổng Loại Thuốc Nhập";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Green;
            this.panel5.Controls.Add(this.lbTongSoLuong);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(308, 98);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(285, 80);
            this.panel5.TabIndex = 14;
            // 
            // lbTongSoLuong
            // 
            this.lbTongSoLuong.AutoSize = true;
            this.lbTongSoLuong.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSoLuong.Location = new System.Drawing.Point(19, 29);
            this.lbTongSoLuong.Name = "lbTongSoLuong";
            this.lbTongSoLuong.Size = new System.Drawing.Size(34, 37);
            this.lbTongSoLuong.TabIndex = 4;
            this.lbTongSoLuong.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tổng Số Lượng Nhập";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel6.Controls.Add(this.lbTongChiPhi);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(599, 98);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(295, 80);
            this.panel6.TabIndex = 14;
            // 
            // lbTongChiPhi
            // 
            this.lbTongChiPhi.AutoSize = true;
            this.lbTongChiPhi.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongChiPhi.Location = new System.Drawing.Point(19, 29);
            this.lbTongChiPhi.Name = "lbTongChiPhi";
            this.lbTongChiPhi.Size = new System.Drawing.Size(34, 37);
            this.lbTongChiPhi.TabIndex = 4;
            this.lbTongChiPhi.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tổng Chi Phí Nhập";
            // 
            // btTimkiem
            // 
            this.btTimkiem.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btTimkiem.BackgroundImage = global::BenhVienS.Properties.Resources.Search_White_Transparent__Search_Icon__Search_Icons__Search_Clipart__Magnifying_Glass_PNG_Image_For_Free_Download_removebg_preview;
            this.btTimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btTimkiem.FlatAppearance.BorderSize = 0;
            this.btTimkiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimkiem.ImageKey = "(none)";
            this.btTimkiem.Location = new System.Drawing.Point(511, 65);
            this.btTimkiem.Name = "btTimkiem";
            this.btTimkiem.Size = new System.Drawing.Size(42, 27);
            this.btTimkiem.TabIndex = 9;
            this.btTimkiem.UseVisualStyleBackColor = false;
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.Color.White;
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(508, 548);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(87, 41);
            this.btXoa.TabIndex = 17;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.Color.White;
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(415, 548);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(87, 41);
            this.btSua.TabIndex = 16;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.Color.White;
            this.btThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Location = new System.Drawing.Point(322, 548);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(87, 41);
            this.btThem.TabIndex = 15;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            // 
            // ucDanhSachNhapThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btTimkiem);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.panel1);
            this.Name = "ucDanhSachNhapThuoc";
            this.Size = new System.Drawing.Size(907, 603);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Button btTimkiem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDonThuoc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTongLoaiThuoc;
        private System.Windows.Forms.Label la1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbTongSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbTongChiPhi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
    }
}
