namespace BenhVienS
{
    partial class frmThemoinguoidung
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThemnguoidung = new System.Windows.Forms.Button();
            this.btnHuynguoidung = new System.Windows.Forms.Button();
            this.c = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.cboVaitro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(46, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(46, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(46, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "SDT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(46, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vai trò:";
            // 
            // btnThemnguoidung
            // 
            this.btnThemnguoidung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemnguoidung.Location = new System.Drawing.Point(50, 300);
            this.btnThemnguoidung.Name = "btnThemnguoidung";
            this.btnThemnguoidung.Size = new System.Drawing.Size(105, 34);
            this.btnThemnguoidung.TabIndex = 4;
            this.btnThemnguoidung.Text = "Thêm";
            this.btnThemnguoidung.UseVisualStyleBackColor = true;
            // 
            // btnHuynguoidung
            // 
            this.btnHuynguoidung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuynguoidung.Location = new System.Drawing.Point(325, 300);
            this.btnHuynguoidung.Name = "btnHuynguoidung";
            this.btnHuynguoidung.Size = new System.Drawing.Size(96, 34);
            this.btnHuynguoidung.TabIndex = 5;
            this.btnHuynguoidung.Text = "Hủy";
            this.btnHuynguoidung.UseVisualStyleBackColor = true;
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(124, 54);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(297, 22);
            this.c.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(124, 104);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(297, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(124, 149);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(297, 22);
            this.txtSDT.TabIndex = 8;
            // 
            // cboVaitro
            // 
            this.cboVaitro.FormattingEnabled = true;
            this.cboVaitro.Location = new System.Drawing.Point(124, 205);
            this.cboVaitro.Name = "cboVaitro";
            this.cboVaitro.Size = new System.Drawing.Size(297, 24);
            this.cboVaitro.TabIndex = 9;
            // 
            // frmThemoinguoidung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 390);
            this.Controls.Add(this.cboVaitro);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.c);
            this.Controls.Add(this.btnHuynguoidung);
            this.Controls.Add(this.btnThemnguoidung);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmThemoinguoidung";
            this.Text = "frmThemoinguoidung";
            this.Load += new System.EventHandler(this.frmThemoinguoidung_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThemnguoidung;
        private System.Windows.Forms.Button btnHuynguoidung;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.ComboBox cboVaitro;
    }
}