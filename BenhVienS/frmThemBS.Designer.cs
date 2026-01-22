namespace BenhVienS
{
    partial class frmThemBS
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboChuyenKhoa = new System.Windows.Forms.ComboBox();
            this.btnThembacsi = new System.Windows.Forms.Button();
            this.cbCapnhatbacsi = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrinhdo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChuyenkhoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnam = new System.Windows.Forms.RadioButton();
            this.rbtnu = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 494);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rbtnu);
            this.groupBox1.Controls.Add(this.rbtnam);
            this.groupBox1.Controls.Add(this.cboChuyenKhoa);
            this.groupBox1.Controls.Add(this.btnThembacsi);
            this.groupBox1.Controls.Add(this.cbCapnhatbacsi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTrinhdo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtChuyenkhoa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHoten);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 422);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm mới bác sĩ";
            // 
            // cboChuyenKhoa
            // 
            this.cboChuyenKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenKhoa.FormattingEnabled = true;
            this.cboChuyenKhoa.Location = new System.Drawing.Point(23, 306);
            this.cboChuyenKhoa.Name = "cboChuyenKhoa";
            this.cboChuyenKhoa.Size = new System.Drawing.Size(263, 28);
            this.cboChuyenKhoa.TabIndex = 13;
            // 
            // btnThembacsi
            // 
            this.btnThembacsi.Location = new System.Drawing.Point(505, 373);
            this.btnThembacsi.Name = "btnThembacsi";
            this.btnThembacsi.Size = new System.Drawing.Size(110, 31);
            this.btnThembacsi.TabIndex = 12;
            this.btnThembacsi.Text = "Thêm";
            this.btnThembacsi.UseVisualStyleBackColor = true;
            this.btnThembacsi.Click += new System.EventHandler(this.btnThembacsi_Click);
            // 
            // cbCapnhatbacsi
            // 
            this.cbCapnhatbacsi.AutoSize = true;
            this.cbCapnhatbacsi.Location = new System.Drawing.Point(356, 316);
            this.cbCapnhatbacsi.Name = "cbCapnhatbacsi";
            this.cbCapnhatbacsi.Size = new System.Drawing.Size(106, 24);
            this.cbCapnhatbacsi.TabIndex = 11;
            this.cbCapnhatbacsi.Text = "Cập nhật";
            this.cbCapnhatbacsi.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Trạng thái:";
            // 
            // txtTrinhdo
            // 
            this.txtTrinhdo.Location = new System.Drawing.Point(352, 226);
            this.txtTrinhdo.Name = "txtTrinhdo";
            this.txtTrinhdo.Size = new System.Drawing.Size(263, 27);
            this.txtTrinhdo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(349, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trình độ:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(352, 133);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(263, 27);
            this.txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(349, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email:";
            // 
            // txtChuyenkhoa
            // 
            this.txtChuyenkhoa.Location = new System.Drawing.Point(23, 262);
            this.txtChuyenkhoa.Name = "txtChuyenkhoa";
            this.txtChuyenkhoa.Size = new System.Drawing.Size(263, 27);
            this.txtChuyenkhoa.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(20, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chuyên khoa:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(23, 174);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(263, 27);
            this.txtSDT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(20, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại:";
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(23, 81);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(263, 27);
            this.txtHoten.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // rbtnam
            // 
            this.rbtnam.AutoSize = true;
            this.rbtnam.Location = new System.Drawing.Point(431, 81);
            this.rbtnam.Name = "rbtnam";
            this.rbtnam.Size = new System.Drawing.Size(68, 24);
            this.rbtnam.TabIndex = 14;
            this.rbtnam.TabStop = true;
            this.rbtnam.Text = "Nam";
            this.rbtnam.UseVisualStyleBackColor = true;
            // 
            // rbtnu
            // 
            this.rbtnu.AutoSize = true;
            this.rbtnu.Location = new System.Drawing.Point(535, 81);
            this.rbtnu.Name = "rbtnu";
            this.rbtnu.Size = new System.Drawing.Size(53, 24);
            this.rbtnu.TabIndex = 15;
            this.rbtnu.TabStop = true;
            this.rbtnu.Text = "Nữ";
            this.rbtnu.UseVisualStyleBackColor = true;
            // 
            // frmThemBS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 494);
            this.Controls.Add(this.panel1);
            this.Name = "frmThemBS";
            this.Text = "frmThemBS";
            this.Load += new System.EventHandler(this.frmThemBS_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChuyenkhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTrinhdo;
        private System.Windows.Forms.Button btnThembacsi;
        private System.Windows.Forms.CheckBox cbCapnhatbacsi;
        private System.Windows.Forms.ComboBox cboChuyenKhoa;
        private System.Windows.Forms.RadioButton rbtnu;
        private System.Windows.Forms.RadioButton rbtnam;
    }
}