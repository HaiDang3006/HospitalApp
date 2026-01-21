namespace BenhVienS
{
    partial class uclichhensaptoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblList = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.v = new System.Windows.Forms.Button();
            this.dgvLichHen = new System.Windows.Forms.DataGridView();
            this.colThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBacSi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuyenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(927, 572);
            this.panelMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.AliceBlue;
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnQuayLai);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(927, 146);
            this.panelHeader.TabIndex = 0;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(13, 15);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(117, 41);
            this.btnQuayLai.TabIndex = 0;
            this.btnQuayLai.Text = "← Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(274, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(404, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Danh Sách Lịch Hẹn Sắp Tới";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubTitle.Location = new System.Drawing.Point(220, 57);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(529, 18);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Chào mừng bạn đến với cổng thông tin bệnh nhân của Bệnh Viện ABC";
            this.lblSubTitle.Click += new System.EventHandler(this.lblSubTitle_Click);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgvLichHen);
            this.panelContent.Controls.Add(this.panelFilter);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 146);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(927, 426);
            this.panelContent.TabIndex = 1;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.v);
            this.panelFilter.Controls.Add(this.pictureBox7);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Controls.Add(this.lblList);
            this.panelFilter.Location = new System.Drawing.Point(3, 15);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(921, 48);
            this.panelFilter.TabIndex = 1;
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.Location = new System.Drawing.Point(6, 13);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(275, 22);
            this.lblList.TabIndex = 0;
            this.lblList.Text = " Danh Sách Lịch Hẹn Sắp Tới";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(589, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(237, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Tìm kiếm lịch hẹn...";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::BenhVienS.Properties.Resources.z7447109316691_a18290ee9f378b65c4059efb1374ca59;
            this.pictureBox7.Location = new System.Drawing.Point(549, 13);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(34, 26);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 10;
            this.pictureBox7.TabStop = false;
            // 
            // v
            // 
            this.v.BackColor = System.Drawing.Color.DodgerBlue;
            this.v.FlatAppearance.BorderSize = 0;
            this.v.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.v.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v.ForeColor = System.Drawing.Color.White;
            this.v.Location = new System.Drawing.Point(832, 13);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(43, 29);
            this.v.TabIndex = 2;
            this.v.Text = "Tìm ";
            this.v.UseVisualStyleBackColor = false;
            // 
            // dgvLichHen
            // 
            this.dgvLichHen.AllowUserToAddRows = false;
            this.dgvLichHen.AllowUserToDeleteRows = false;
            this.dgvLichHen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichHen.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichHen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichHen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLichHen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichHen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThoiGian,
            this.colBacSi,
            this.colChuyenKhoa,
            this.colPhong});
            this.dgvLichHen.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvLichHen.Location = new System.Drawing.Point(3, 80);
            this.dgvLichHen.Name = "dgvLichHen";
            this.dgvLichHen.ReadOnly = true;
            this.dgvLichHen.RowHeadersVisible = false;
            this.dgvLichHen.RowHeadersWidth = 51;
            this.dgvLichHen.RowTemplate.Height = 24;
            this.dgvLichHen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichHen.Size = new System.Drawing.Size(921, 187);
            this.dgvLichHen.TabIndex = 2;
            // 
            // colThoiGian
            // 
            this.colThoiGian.HeaderText = "Thời Gian";
            this.colThoiGian.MinimumWidth = 6;
            this.colThoiGian.Name = "colThoiGian";
            this.colThoiGian.ReadOnly = true;
            // 
            // colBacSi
            // 
            this.colBacSi.HeaderText = "Bác Sĩ";
            this.colBacSi.MinimumWidth = 6;
            this.colBacSi.Name = "colBacSi";
            this.colBacSi.ReadOnly = true;
            // 
            // colChuyenKhoa
            // 
            this.colChuyenKhoa.HeaderText = "Chuyên Khoa";
            this.colChuyenKhoa.MinimumWidth = 6;
            this.colChuyenKhoa.Name = "colChuyenKhoa";
            this.colChuyenKhoa.ReadOnly = true;
            // 
            // colPhong
            // 
            this.colPhong.HeaderText = "Phòng Khám";
            this.colPhong.MinimumWidth = 6;
            this.colPhong.Name = "colPhong";
            this.colPhong.ReadOnly = true;
            // 
            // uclichhensaptoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "uclichhensaptoi";
            this.Size = new System.Drawing.Size(927, 572);
            this.panelMain.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button v;
        private System.Windows.Forms.DataGridView dgvLichHen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBacSi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuyenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhong;
    }
}
