namespace BenhVienS
{
    partial class frmThemSuaLichLamViec
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
            this.cbophong = new System.Windows.Forms.GroupBox();
            this.dtpNgayLamViec = new System.Windows.Forms.DateTimePicker();
            this.cboCa = new System.Windows.Forms.ComboBox();
            this.cbophon = new System.Windows.Forms.ComboBox();
            this.cbobacsi = new System.Windows.Forms.ComboBox();
            this.cbotrangthai = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btLuu = new System.Windows.Forms.Button();
            this.btHuy = new System.Windows.Forms.Button();
            this.cbophong.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbophong
            // 
            this.cbophong.Controls.Add(this.dtpNgayLamViec);
            this.cbophong.Controls.Add(this.cboCa);
            this.cbophong.Controls.Add(this.cbophon);
            this.cbophong.Controls.Add(this.cbobacsi);
            this.cbophong.Controls.Add(this.cbotrangthai);
            this.cbophong.Controls.Add(this.label4);
            this.cbophong.Controls.Add(this.label3);
            this.cbophong.Controls.Add(this.label2);
            this.cbophong.Controls.Add(this.label1);
            this.cbophong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbophong.Location = new System.Drawing.Point(12, 12);
            this.cbophong.Name = "cbophong";
            this.cbophong.Size = new System.Drawing.Size(402, 299);
            this.cbophong.TabIndex = 0;
            this.cbophong.TabStop = false;
            this.cbophong.Text = "Thêm/sửa lịch làm việc";
            // 
            // dtpNgayLamViec
            // 
            this.dtpNgayLamViec.Location = new System.Drawing.Point(168, 171);
            this.dtpNgayLamViec.Name = "dtpNgayLamViec";
            this.dtpNgayLamViec.Size = new System.Drawing.Size(200, 30);
            this.dtpNgayLamViec.TabIndex = 9;
            // 
            // cboCa
            // 
            this.cboCa.FormattingEnabled = true;
            this.cboCa.Location = new System.Drawing.Point(167, 120);
            this.cboCa.Name = "cboCa";
            this.cboCa.Size = new System.Drawing.Size(167, 33);
            this.cboCa.TabIndex = 8;
            // 
            // cbophon
            // 
            this.cbophon.FormattingEnabled = true;
            this.cbophon.Location = new System.Drawing.Point(168, 74);
            this.cbophon.Name = "cbophon";
            this.cbophon.Size = new System.Drawing.Size(167, 33);
            this.cbophon.TabIndex = 7;
            // 
            // cbobacsi
            // 
            this.cbobacsi.FormattingEnabled = true;
            this.cbobacsi.Location = new System.Drawing.Point(167, 35);
            this.cbobacsi.Name = "cbobacsi";
            this.cbobacsi.Size = new System.Drawing.Size(167, 33);
            this.cbobacsi.TabIndex = 6;
            // 
            // cbotrangthai
            // 
            this.cbotrangthai.AutoSize = true;
            this.cbotrangthai.Location = new System.Drawing.Point(27, 217);
            this.cbotrangthai.Name = "cbotrangthai";
            this.cbotrangthai.Size = new System.Drawing.Size(122, 29);
            this.cbotrangthai.TabIndex = 5;
            this.cbotrangthai.Text = "Trạng thái";
            this.cbotrangthai.UseVisualStyleBackColor = true;
            this.cbotrangthai.CheckedChanged += new System.EventHandler(this.cbotrangthai_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày làm việc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ca làm việc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bác sĩ:";
            // 
            // btLuu
            // 
            this.btLuu.BackColor = System.Drawing.Color.ForestGreen;
            this.btLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.Location = new System.Drawing.Point(180, 317);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(84, 51);
            this.btLuu.TabIndex = 1;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = false;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btHuy
            // 
            this.btHuy.BackColor = System.Drawing.Color.Firebrick;
            this.btHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy.Location = new System.Drawing.Point(303, 317);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(84, 51);
            this.btHuy.TabIndex = 2;
            this.btHuy.Text = "Hủy";
            this.btHuy.UseVisualStyleBackColor = false;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // frmThemSuaLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 404);
            this.Controls.Add(this.btHuy);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.cbophong);
            this.Name = "frmThemSuaLichLamViec";
            this.Text = "frmThemSuaLichLamViec";
            this.Load += new System.EventHandler(this.frmThemSuaLichLamViec_Load);
            this.cbophong.ResumeLayout(false);
            this.cbophong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cbophong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbophon;
        private System.Windows.Forms.ComboBox cbobacsi;
        private System.Windows.Forms.CheckBox cbotrangthai;
        private System.Windows.Forms.DateTimePicker dtpNgayLamViec;
        private System.Windows.Forms.ComboBox cboCa;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btHuy;
    }
}