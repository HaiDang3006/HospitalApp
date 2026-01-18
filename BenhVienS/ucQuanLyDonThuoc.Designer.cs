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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.dgvQuanLyDonThuoc = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.btTimkiem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyDonThuoc)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ ĐƠN THUỐC";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.dgvQuanLyDonThuoc);
            this.panel3.Location = new System.Drawing.Point(3, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(904, 548);
            this.panel3.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btXoa);
            this.panel4.Controls.Add(this.btSua);
            this.panel4.Controls.Add(this.btThem);
            this.panel4.Location = new System.Drawing.Point(3, 431);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(791, 86);
            this.panel4.TabIndex = 1;
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.Color.White;
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(496, 11);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(87, 41);
            this.btXoa.TabIndex = 2;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.Color.White;
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(403, 11);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(87, 41);
            this.btSua.TabIndex = 1;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.Color.White;
            this.btThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Location = new System.Drawing.Point(310, 11);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(87, 41);
            this.btThem.TabIndex = 0;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            // 
            // dgvQuanLyDonThuoc
            // 
            this.dgvQuanLyDonThuoc.AllowUserToAddRows = false;
            this.dgvQuanLyDonThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanLyDonThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLyDonThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaDon,
            this.colHoTen,
            this.colNgay,
            this.colTongTien,
            this.colThaoTac});
            this.dgvQuanLyDonThuoc.Location = new System.Drawing.Point(3, 32);
            this.dgvQuanLyDonThuoc.Name = "dgvQuanLyDonThuoc";
            this.dgvQuanLyDonThuoc.ReadOnly = true;
            this.dgvQuanLyDonThuoc.RowHeadersVisible = false;
            this.dgvQuanLyDonThuoc.RowHeadersWidth = 51;
            this.dgvQuanLyDonThuoc.RowTemplate.Height = 24;
            this.dgvQuanLyDonThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuanLyDonThuoc.Size = new System.Drawing.Size(885, 393);
            this.dgvQuanLyDonThuoc.TabIndex = 0;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 6;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            // 
            // colMaDon
            // 
            this.colMaDon.HeaderText = "Mã Đơn";
            this.colMaDon.MinimumWidth = 6;
            this.colMaDon.Name = "colMaDon";
            this.colMaDon.ReadOnly = true;
            // 
            // colHoTen
            // 
            this.colHoTen.HeaderText = "Họ Tên BN";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colNgay
            // 
            this.colNgay.HeaderText = "Ngày Kê Đơn";
            this.colNgay.MinimumWidth = 6;
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.HeaderText = "Tổng Tiền";
            this.colTongTien.MinimumWidth = 6;
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.HeaderText = "Thao Tác";
            this.colThaoTac.MinimumWidth = 6;
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            this.colThaoTac.Text = "Sửa / Xóa";
            this.colThaoTac.UseColumnTextForButtonValue = true;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimkiem.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTimkiem.Location = new System.Drawing.Point(6, 68);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(442, 30);
            this.txtTimkiem.TabIndex = 7;
            this.txtTimkiem.Text = "Nhập tên, mã thuốc";
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
            // ucQuanLyDonThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btTimkiem);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ucQuanLyDonThuoc";
            this.Size = new System.Drawing.Size(907, 603);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyDonThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btTimkiem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvQuanLyDonThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewButtonColumn colThaoTac;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.TextBox txtTimkiem;
    }
}
