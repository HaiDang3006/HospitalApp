namespace BenhVienS
{
    partial class uctaolichhen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHUY = new System.Windows.Forms.Button();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grptaolichhenmooi = new System.Windows.Forms.GroupBox();
            this.txtTenbs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bthuy = new System.Windows.Forms.Button();
            this.btdatlich = new System.Windows.Forms.Button();
            this.cboChuyenkhoa = new System.Windows.Forms.ComboBox();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.txtMaBN = new System.Windows.Forms.TextBox();
            this.lbngaykham = new System.Windows.Forms.Label();
            this.lbbacsi = new System.Windows.Forms.Label();
            this.lbtenbenhnhan = new System.Windows.Forms.Label();
            this.lbmabn = new System.Windows.Forms.Label();
            this.dtpNgayKham = new System.Windows.Forms.DateTimePicker();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.lblTenBN = new System.Windows.Forms.Label();
            this.lblBacsi = new System.Windows.Forms.Label();
            this.lblNgayKham = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grptaolichhenmooi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 489);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(519, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 486);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xác nhận lịch hẹn";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lblNgayKham);
            this.groupBox2.Controls.Add(this.lblBacsi);
            this.groupBox2.Controls.Add(this.lblTenBN);
            this.groupBox2.Controls.Add(this.lblMaBN);
            this.groupBox2.Controls.Add(this.btnHUY);
            this.groupBox2.Controls.Add(this.btnXacnhan);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(17, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 426);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin lịch hẹn";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnHUY
            // 
            this.btnHUY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHUY.ForeColor = System.Drawing.Color.Black;
            this.btnHUY.Location = new System.Drawing.Point(287, 344);
            this.btnHUY.Name = "btnHUY";
            this.btnHUY.Size = new System.Drawing.Size(103, 30);
            this.btnHUY.TabIndex = 18;
            this.btnHUY.Text = "Hủy";
            this.btnHUY.UseVisualStyleBackColor = true;
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacnhan.ForeColor = System.Drawing.Color.Black;
            this.btnXacnhan.Location = new System.Drawing.Point(45, 344);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(103, 30);
            this.btnXacnhan.TabIndex = 17;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.UseVisualStyleBackColor = true;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Xác nhận đặt lịch cho khách này?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ngày Khám";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bác Sĩ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên Bệnh Nhân";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã BN";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox3.Controls.Add(this.grptaolichhenmooi);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(527, 486);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tạo mới";
            // 
            // grptaolichhenmooi
            // 
            this.grptaolichhenmooi.BackColor = System.Drawing.Color.White;
            this.grptaolichhenmooi.Controls.Add(this.txtTenbs);
            this.grptaolichhenmooi.Controls.Add(this.label6);
            this.grptaolichhenmooi.Controls.Add(this.bthuy);
            this.grptaolichhenmooi.Controls.Add(this.btdatlich);
            this.grptaolichhenmooi.Controls.Add(this.dtpNgayKham);
            this.grptaolichhenmooi.Controls.Add(this.cboChuyenkhoa);
            this.grptaolichhenmooi.Controls.Add(this.txtTenBN);
            this.grptaolichhenmooi.Controls.Add(this.txtMaBN);
            this.grptaolichhenmooi.Controls.Add(this.lbngaykham);
            this.grptaolichhenmooi.Controls.Add(this.lbbacsi);
            this.grptaolichhenmooi.Controls.Add(this.lbtenbenhnhan);
            this.grptaolichhenmooi.Controls.Add(this.lbmabn);
            this.grptaolichhenmooi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptaolichhenmooi.Location = new System.Drawing.Point(18, 41);
            this.grptaolichhenmooi.Name = "grptaolichhenmooi";
            this.grptaolichhenmooi.Size = new System.Drawing.Size(473, 426);
            this.grptaolichhenmooi.TabIndex = 2;
            this.grptaolichhenmooi.TabStop = false;
            this.grptaolichhenmooi.Text = "Tạo Lịch Hẹn Mới";
            this.grptaolichhenmooi.Enter += new System.EventHandler(this.grptaolichhenmooi_Enter);
            // 
            // txtTenbs
            // 
            this.txtTenbs.Location = new System.Drawing.Point(143, 140);
            this.txtTenbs.Name = "txtTenbs";
            this.txtTenbs.Size = new System.Drawing.Size(236, 30);
            this.txtTenbs.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Chuyên Khoa";
            // 
            // bthuy
            // 
            this.bthuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bthuy.Location = new System.Drawing.Point(357, 368);
            this.bthuy.Name = "bthuy";
            this.bthuy.Size = new System.Drawing.Size(99, 28);
            this.bthuy.TabIndex = 3;
            this.bthuy.Text = "Hủy";
            this.bthuy.UseVisualStyleBackColor = true;
            // 
            // btdatlich
            // 
            this.btdatlich.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdatlich.Location = new System.Drawing.Point(21, 368);
            this.btdatlich.Name = "btdatlich";
            this.btdatlich.Size = new System.Drawing.Size(112, 28);
            this.btdatlich.TabIndex = 10;
            this.btdatlich.Text = "Đặt Lịch";
            this.btdatlich.UseVisualStyleBackColor = true;
            this.btdatlich.Click += new System.EventHandler(this.btdatlich_Click);
            // 
            // cboChuyenkhoa
            // 
            this.cboChuyenkhoa.FormattingEnabled = true;
            this.cboChuyenkhoa.Location = new System.Drawing.Point(143, 205);
            this.cboChuyenkhoa.Name = "cboChuyenkhoa";
            this.cboChuyenkhoa.Size = new System.Drawing.Size(236, 33);
            this.cboChuyenkhoa.TabIndex = 7;
            this.cboChuyenkhoa.SelectedIndexChanged += new System.EventHandler(this.cboBacsi_SelectedIndexChanged);
            // 
            // txtTenBN
            // 
            this.txtTenBN.Location = new System.Drawing.Point(162, 80);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.Size = new System.Drawing.Size(217, 30);
            this.txtTenBN.TabIndex = 6;
            // 
            // txtMaBN
            // 
            this.txtMaBN.Location = new System.Drawing.Point(133, 33);
            this.txtMaBN.Name = "txtMaBN";
            this.txtMaBN.Size = new System.Drawing.Size(246, 30);
            this.txtMaBN.TabIndex = 5;
            // 
            // lbngaykham
            // 
            this.lbngaykham.AutoSize = true;
            this.lbngaykham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbngaykham.Location = new System.Drawing.Point(27, 275);
            this.lbngaykham.Name = "lbngaykham";
            this.lbngaykham.Size = new System.Drawing.Size(94, 18);
            this.lbngaykham.TabIndex = 4;
            this.lbngaykham.Text = "Ngày Khám";
            // 
            // lbbacsi
            // 
            this.lbbacsi.AutoSize = true;
            this.lbbacsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbacsi.Location = new System.Drawing.Point(27, 145);
            this.lbbacsi.Name = "lbbacsi";
            this.lbbacsi.Size = new System.Drawing.Size(57, 18);
            this.lbbacsi.TabIndex = 3;
            this.lbbacsi.Text = "Bác Sĩ";
            // 
            // lbtenbenhnhan
            // 
            this.lbtenbenhnhan.AutoSize = true;
            this.lbtenbenhnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenbenhnhan.Location = new System.Drawing.Point(23, 88);
            this.lbtenbenhnhan.Name = "lbtenbenhnhan";
            this.lbtenbenhnhan.Size = new System.Drawing.Size(123, 18);
            this.lbtenbenhnhan.TabIndex = 2;
            this.lbtenbenhnhan.Text = "Tên Bệnh Nhân";
            // 
            // lbmabn
            // 
            this.lbmabn.AutoSize = true;
            this.lbmabn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmabn.Location = new System.Drawing.Point(25, 41);
            this.lbmabn.Name = "lbmabn";
            this.lbmabn.Size = new System.Drawing.Size(59, 18);
            this.lbmabn.TabIndex = 1;
            this.lbmabn.Text = "Mã BN";
            // 
            // dtpNgayKham
            // 
            this.dtpNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKham.Location = new System.Drawing.Point(143, 263);
            this.dtpNgayKham.Name = "dtpNgayKham";
            this.dtpNgayKham.Size = new System.Drawing.Size(236, 30);
            this.dtpNgayKham.TabIndex = 8;
            // 
            // lblMaBN
            // 
            this.lblMaBN.AutoSize = true;
            this.lblMaBN.BackColor = System.Drawing.Color.White;
            this.lblMaBN.Location = new System.Drawing.Point(103, 66);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(0, 20);
            this.lblMaBN.TabIndex = 19;
            // 
            // lblTenBN
            // 
            this.lblTenBN.AutoSize = true;
            this.lblTenBN.Location = new System.Drawing.Point(165, 123);
            this.lblTenBN.Name = "lblTenBN";
            this.lblTenBN.Size = new System.Drawing.Size(0, 20);
            this.lblTenBN.TabIndex = 20;
            // 
            // lblBacsi
            // 
            this.lblBacsi.AutoSize = true;
            this.lblBacsi.Location = new System.Drawing.Point(103, 179);
            this.lblBacsi.Name = "lblBacsi";
            this.lblBacsi.Size = new System.Drawing.Size(0, 20);
            this.lblBacsi.TabIndex = 21;
            // 
            // lblNgayKham
            // 
            this.lblNgayKham.AutoSize = true;
            this.lblNgayKham.Location = new System.Drawing.Point(120, 234);
            this.lblNgayKham.Name = "lblNgayKham";
            this.lblNgayKham.Size = new System.Drawing.Size(0, 20);
            this.lblNgayKham.TabIndex = 22;
            // 
            // uctaolichhen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "uctaolichhen";
            this.Size = new System.Drawing.Size(981, 489);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.grptaolichhenmooi.ResumeLayout(false);
            this.grptaolichhenmooi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grptaolichhenmooi;
        private System.Windows.Forms.Label lbmabn;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.TextBox txtMaBN;
        private System.Windows.Forms.Label lbngaykham;
        private System.Windows.Forms.Label lbbacsi;
        private System.Windows.Forms.Label lbtenbenhnhan;
        private System.Windows.Forms.Button bthuy;
        private System.Windows.Forms.Button btdatlich;
        private System.Windows.Forms.ComboBox cboChuyenkhoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHUY;
        private System.Windows.Forms.Button btnXacnhan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenbs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpNgayKham;
        private System.Windows.Forms.Label lblNgayKham;
        private System.Windows.Forms.Label lblBacsi;
        private System.Windows.Forms.Label lblTenBN;
        public System.Windows.Forms.Label lblMaBN;
    }
}
