namespace BenhVienS
{
    partial class ucQuanLyDonThuoc
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
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btTimkiem = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDonThuoc = new System.Windows.Forms.DataGridView();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.btXacNhan = new System.Windows.Forms.Button();
            this.dgvChiTietDonThuoc = new System.Windows.Forms.DataGridView();
            this.lbBacSi = new System.Windows.Forms.Label();
            this.lbBenhNhan = new System.Windows.Forms.Label();
            this.lbMaDon = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonThuoc)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(907, 62);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ ĐƠN THUỐC";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTimKiem.Location = new System.Drawing.Point(6, 68);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(442, 30);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.Text = "Tìm kiếm...";
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
            this.btTimkiem.Location = new System.Drawing.Point(454, 71);
            this.btTimkiem.Name = "btTimkiem";
            this.btTimkiem.Size = new System.Drawing.Size(42, 27);
            this.btTimkiem.TabIndex = 8;
            this.btTimkiem.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 104);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.dgvDonThuoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbTongTien);
            this.splitContainer1.Panel2.Controls.Add(this.btXacNhan);
            this.splitContainer1.Panel2.Controls.Add(this.dgvChiTietDonThuoc);
            this.splitContainer1.Panel2.Controls.Add(this.lbBacSi);
            this.splitContainer1.Panel2.Controls.Add(this.lbBenhNhan);
            this.splitContainer1.Panel2.Controls.Add(this.lbMaDon);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(904, 496);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 27);
            this.label4.TabIndex = 1;
            this.label4.Text = "Danh Sách Đơn Chờ";
            // 
            // dgvDonThuoc
            // 
            this.dgvDonThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonThuoc.Location = new System.Drawing.Point(0, 42);
            this.dgvDonThuoc.Name = "dgvDonThuoc";
            this.dgvDonThuoc.RowHeadersWidth = 51;
            this.dgvDonThuoc.RowTemplate.Height = 24;
            this.dgvDonThuoc.Size = new System.Drawing.Size(448, 451);
            this.dgvDonThuoc.TabIndex = 0;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(212, 461);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(92, 20);
            this.lbTongTien.TabIndex = 8;
            this.lbTongTien.Text = "Tổng Tiền:";
            // 
            // btXacNhan
            // 
            this.btXacNhan.BackColor = System.Drawing.Color.Green;
            this.btXacNhan.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXacNhan.Location = new System.Drawing.Point(3, 451);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(203, 42);
            this.btXacNhan.TabIndex = 7;
            this.btXacNhan.Text = "Xác Nhận Xuất Thuốc";
            this.btXacNhan.UseVisualStyleBackColor = false;
            this.btXacNhan.Click += new System.EventHandler(this.btXacNhan_Click);
            // 
            // dgvChiTietDonThuoc
            // 
            this.dgvChiTietDonThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDonThuoc.Location = new System.Drawing.Point(3, 115);
            this.dgvChiTietDonThuoc.Name = "dgvChiTietDonThuoc";
            this.dgvChiTietDonThuoc.RowHeadersWidth = 51;
            this.dgvChiTietDonThuoc.RowTemplate.Height = 24;
            this.dgvChiTietDonThuoc.Size = new System.Drawing.Size(443, 330);
            this.dgvChiTietDonThuoc.TabIndex = 6;
            // 
            // lbBacSi
            // 
            this.lbBacSi.AutoSize = true;
            this.lbBacSi.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBacSi.Location = new System.Drawing.Point(5, 92);
            this.lbBacSi.Name = "lbBacSi";
            this.lbBacSi.Size = new System.Drawing.Size(93, 20);
            this.lbBacSi.TabIndex = 5;
            this.lbBacSi.Text = "Tên Bác Sĩ:";
            // 
            // lbBenhNhan
            // 
            this.lbBenhNhan.AutoSize = true;
            this.lbBenhNhan.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBenhNhan.Location = new System.Drawing.Point(4, 56);
            this.lbBenhNhan.Name = "lbBenhNhan";
            this.lbBenhNhan.Size = new System.Drawing.Size(132, 20);
            this.lbBenhNhan.TabIndex = 4;
            this.lbBenhNhan.Text = "Tên Bệnh Nhân:";
            // 
            // lbMaDon
            // 
            this.lbMaDon.AutoSize = true;
            this.lbMaDon.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaDon.Location = new System.Drawing.Point(276, 13);
            this.lbMaDon.Name = "lbMaDon";
            this.lbMaDon.Size = new System.Drawing.Size(88, 23);
            this.lbMaDon.TabIndex = 3;
            this.lbMaDon.Text = "Mã Đơn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chi Tiết Đơn Thuốc";
            // 
            // ucQuanLyDonThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btTimkiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.panel1);
            this.Name = "ucQuanLyDonThuoc";
            this.Size = new System.Drawing.Size(907, 603);
            this.Load += new System.EventHandler(this.ucQuanLyDonThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btTimkiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDonThuoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbBacSi;
        private System.Windows.Forms.Label lbBenhNhan;
        private System.Windows.Forms.Label lbMaDon;
        private System.Windows.Forms.DataGridView dgvChiTietDonThuoc;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Button btXacNhan;
    }
}
