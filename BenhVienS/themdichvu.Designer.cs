namespace BenhVienS
{
    partial class themdichvu
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
            this.lbltendichvu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblthoigianthuchiendv = new System.Windows.Forms.Label();
            this.txtTendichvu = new System.Windows.Forms.TextBox();
            this.chbdongiadichvu = new System.Windows.Forms.CheckBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.chbapbhyt = new System.Windows.Forms.CheckBox();
            this.txtmuchuongbhyt = new System.Windows.Forms.TextBox();
            this.nudthoigianthuchien = new System.Windows.Forms.NumericUpDown();
            this.btluu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.chbtrangthai = new System.Windows.Forms.CheckBox();
            this.cboLoaiDichVu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudthoigianthuchien)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltendichvu
            // 
            this.lbltendichvu.AutoSize = true;
            this.lbltendichvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltendichvu.Location = new System.Drawing.Point(12, 21);
            this.lbltendichvu.Name = "lbltendichvu";
            this.lbltendichvu.Size = new System.Drawing.Size(123, 25);
            this.lbltendichvu.TabIndex = 0;
            this.lbltendichvu.Text = "Tên Dịch vụ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại Dịch vụ:";
            // 
            // lblthoigianthuchiendv
            // 
            this.lblthoigianthuchiendv.AutoSize = true;
            this.lblthoigianthuchiendv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblthoigianthuchiendv.Location = new System.Drawing.Point(12, 210);
            this.lblthoigianthuchiendv.Name = "lblthoigianthuchiendv";
            this.lblthoigianthuchiendv.Size = new System.Drawing.Size(183, 25);
            this.lblthoigianthuchiendv.TabIndex = 2;
            this.lblthoigianthuchiendv.Text = "Thời gian thực hiện:";
            // 
            // txtTendichvu
            // 
            this.txtTendichvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTendichvu.Location = new System.Drawing.Point(141, 24);
            this.txtTendichvu.Name = "txtTendichvu";
            this.txtTendichvu.Size = new System.Drawing.Size(302, 27);
            this.txtTendichvu.TabIndex = 3;
            // 
            // chbdongiadichvu
            // 
            this.chbdongiadichvu.AutoSize = true;
            this.chbdongiadichvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbdongiadichvu.Location = new System.Drawing.Point(17, 113);
            this.chbdongiadichvu.Name = "chbdongiadichvu";
            this.chbdongiadichvu.Size = new System.Drawing.Size(101, 29);
            this.chbdongiadichvu.TabIndex = 9;
            this.chbdongiadichvu.Text = "Đơn giá";
            this.chbdongiadichvu.UseVisualStyleBackColor = true;
            this.chbdongiadichvu.CheckedChanged += new System.EventHandler(this.chbdongiadichvu_CheckedChanged);
            // 
            // txtdongia
            // 
            this.txtdongia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdongia.Location = new System.Drawing.Point(141, 115);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(205, 27);
            this.txtdongia.TabIndex = 10;
            this.txtdongia.Text = "0";
            // 
            // chbapbhyt
            // 
            this.chbapbhyt.AutoSize = true;
            this.chbapbhyt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbapbhyt.Location = new System.Drawing.Point(17, 161);
            this.chbapbhyt.Name = "chbapbhyt";
            this.chbapbhyt.Size = new System.Drawing.Size(153, 26);
            this.chbapbhyt.TabIndex = 11;
            this.chbapbhyt.Text = "Áp dụng BHYT";
            this.chbapbhyt.UseVisualStyleBackColor = true;
            this.chbapbhyt.CheckedChanged += new System.EventHandler(this.chbapbhyt_CheckedChanged);
            // 
            // txtmuchuongbhyt
            // 
            this.txtmuchuongbhyt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmuchuongbhyt.Location = new System.Drawing.Point(176, 161);
            this.txtmuchuongbhyt.Name = "txtmuchuongbhyt";
            this.txtmuchuongbhyt.Size = new System.Drawing.Size(92, 27);
            this.txtmuchuongbhyt.TabIndex = 12;
            // 
            // nudthoigianthuchien
            // 
            this.nudthoigianthuchien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudthoigianthuchien.Location = new System.Drawing.Point(201, 210);
            this.nudthoigianthuchien.Name = "nudthoigianthuchien";
            this.nudthoigianthuchien.Size = new System.Drawing.Size(120, 30);
            this.nudthoigianthuchien.TabIndex = 13;
            // 
            // btluu
            // 
            this.btluu.Location = new System.Drawing.Point(484, 244);
            this.btluu.Name = "btluu";
            this.btluu.Size = new System.Drawing.Size(87, 42);
            this.btluu.TabIndex = 14;
            this.btluu.Text = "Lưu";
            this.btluu.UseVisualStyleBackColor = true;
            this.btluu.Click += new System.EventHandler(this.btluu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(479, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mô tả:";
            // 
            // txtMota
            // 
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(484, 49);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(302, 104);
            this.txtMota.TabIndex = 17;
            // 
            // chbtrangthai
            // 
            this.chbtrangthai.AutoSize = true;
            this.chbtrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbtrangthai.Location = new System.Drawing.Point(484, 161);
            this.chbtrangthai.Name = "chbtrangthai";
            this.chbtrangthai.Size = new System.Drawing.Size(122, 29);
            this.chbtrangthai.TabIndex = 18;
            this.chbtrangthai.Text = "Trạng thái";
            this.chbtrangthai.UseVisualStyleBackColor = true;
            // 
            // cboLoaiDichVu
            // 
            this.cboLoaiDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboLoaiDichVu.FormattingEnabled = true;
            this.cboLoaiDichVu.Location = new System.Drawing.Point(141, 65);
            this.cboLoaiDichVu.Name = "cboLoaiDichVu";
            this.cboLoaiDichVu.Size = new System.Drawing.Size(164, 33);
            this.cboLoaiDichVu.TabIndex = 19;
            this.cboLoaiDichVu.Text = "Tất cả";
            // 
            // themdichvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 298);
            this.Controls.Add(this.cboLoaiDichVu);
            this.Controls.Add(this.chbtrangthai);
            this.Controls.Add(this.txtMota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btluu);
            this.Controls.Add(this.nudthoigianthuchien);
            this.Controls.Add(this.txtmuchuongbhyt);
            this.Controls.Add(this.chbapbhyt);
            this.Controls.Add(this.txtdongia);
            this.Controls.Add(this.chbdongiadichvu);
            this.Controls.Add(this.txtTendichvu);
            this.Controls.Add(this.lblthoigianthuchiendv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbltendichvu);
            this.Name = "themdichvu";
            this.Text = "themdichvu";
            this.Load += new System.EventHandler(this.themdichvu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudthoigianthuchien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltendichvu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblthoigianthuchiendv;
        private System.Windows.Forms.TextBox txtTendichvu;
        private System.Windows.Forms.CheckBox chbdongiadichvu;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.CheckBox chbapbhyt;
        private System.Windows.Forms.TextBox txtmuchuongbhyt;
        private System.Windows.Forms.NumericUpDown nudthoigianthuchien;
        private System.Windows.Forms.Button btluu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.CheckBox chbtrangthai;
        private System.Windows.Forms.ComboBox cboLoaiDichVu;
    }
}