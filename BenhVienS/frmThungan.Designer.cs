namespace BenhVienS
{
    partial class frmThungan
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
            this.btnThemthungan = new System.Windows.Forms.Button();
            this.cbCapnhatthungan = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailthungan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDTthungan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHotenTN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnu = new System.Windows.Forms.RadioButton();
            this.rbtnam = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(-1, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 454);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rbtnu);
            this.groupBox1.Controls.Add(this.rbtnam);
            this.groupBox1.Controls.Add(this.btnThemthungan);
            this.groupBox1.Controls.Add(this.cbCapnhatthungan);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEmailthungan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSDTthungan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHotenTN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(0, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm mới thu ngân";
            // 
            // btnThemthungan
            // 
            this.btnThemthungan.Location = new System.Drawing.Point(454, 347);
            this.btnThemthungan.Name = "btnThemthungan";
            this.btnThemthungan.Size = new System.Drawing.Size(110, 31);
            this.btnThemthungan.TabIndex = 13;
            this.btnThemthungan.Text = "Thêm";
            this.btnThemthungan.UseVisualStyleBackColor = true;
            // 
            // cbCapnhatthungan
            // 
            this.cbCapnhatthungan.AutoSize = true;
            this.cbCapnhatthungan.Location = new System.Drawing.Point(317, 204);
            this.cbCapnhatthungan.Name = "cbCapnhatthungan";
            this.cbCapnhatthungan.Size = new System.Drawing.Size(97, 22);
            this.cbCapnhatthungan.TabIndex = 10;
            this.cbCapnhatthungan.Text = "Cập nhật";
            this.cbCapnhatthungan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(314, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Trạng thái:";
            // 
            // txtEmailthungan
            // 
            this.txtEmailthungan.Location = new System.Drawing.Point(317, 88);
            this.txtEmailthungan.Name = "txtEmailthungan";
            this.txtEmailthungan.Size = new System.Drawing.Size(263, 24);
            this.txtEmailthungan.TabIndex = 7;
            this.txtEmailthungan.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(314, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email:";
            // 
            // txtSDTthungan
            // 
            this.txtSDTthungan.Location = new System.Drawing.Point(16, 204);
            this.txtSDTthungan.Name = "txtSDTthungan";
            this.txtSDTthungan.Size = new System.Drawing.Size(263, 24);
            this.txtSDTthungan.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(13, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số điện thoại:";
            // 
            // txtHotenTN
            // 
            this.txtHotenTN.Location = new System.Drawing.Point(16, 88);
            this.txtHotenTN.Name = "txtHotenTN";
            this.txtHotenTN.Size = new System.Drawing.Size(263, 24);
            this.txtHotenTN.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Họ và tên:";
            // 
            // rbtnu
            // 
            this.rbtnu.AutoSize = true;
            this.rbtnu.Location = new System.Drawing.Point(125, 255);
            this.rbtnu.Name = "rbtnu";
            this.rbtnu.Size = new System.Drawing.Size(50, 22);
            this.rbtnu.TabIndex = 17;
            this.rbtnu.TabStop = true;
            this.rbtnu.Text = "Nữ";
            this.rbtnu.UseVisualStyleBackColor = true;
            // 
            // rbtnam
            // 
            this.rbtnam.AutoSize = true;
            this.rbtnam.Location = new System.Drawing.Point(21, 255);
            this.rbtnam.Name = "rbtnam";
            this.rbtnam.Size = new System.Drawing.Size(64, 22);
            this.rbtnam.TabIndex = 16;
            this.rbtnam.TabStop = true;
            this.rbtnam.Text = "Nam";
            this.rbtnam.UseVisualStyleBackColor = true;
            // 
            // frmThungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmThungan";
            this.Text = "frmThungan";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmailthungan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDTthungan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHotenTN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbCapnhatthungan;
        private System.Windows.Forms.Button btnThemthungan;
        private System.Windows.Forms.RadioButton rbtnu;
        private System.Windows.Forms.RadioButton rbtnam;
    }
}