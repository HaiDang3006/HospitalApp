namespace BenhVienS
{
    partial class Dangnhap
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btDangnhap = new System.Windows.Forms.Button();
            this.linkQuenMK = new System.Windows.Forms.LinkLabel();
            this.cobVaitro = new System.Windows.Forms.ComboBox();
            this.picIconNguoi = new System.Windows.Forms.PictureBox();
            this.picIconKhoa = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIconNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.ForeColor = System.Drawing.Color.Silver;
            this.txtEmail.Location = new System.Drawing.Point(129, 202);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 39);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.textEmail_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtPassword.Location = new System.Drawing.Point(129, 333);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(220, 39);
            this.txtPassword.TabIndex = 4;
            // 
            // btDangnhap
            // 
            this.btDangnhap.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btDangnhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangnhap.Location = new System.Drawing.Point(124, 406);
            this.btDangnhap.Name = "btDangnhap";
            this.btDangnhap.Size = new System.Drawing.Size(143, 58);
            this.btDangnhap.TabIndex = 5;
            this.btDangnhap.Text = "Đăng nhập";
            this.btDangnhap.UseVisualStyleBackColor = false;
            this.btDangnhap.Click += new System.EventHandler(this.btDangnhap_Click);
            // 
            // linkQuenMK
            // 
            this.linkQuenMK.AutoSize = true;
            this.linkQuenMK.Location = new System.Drawing.Point(143, 479);
            this.linkQuenMK.Name = "linkQuenMK";
            this.linkQuenMK.Size = new System.Drawing.Size(96, 16);
            this.linkQuenMK.TabIndex = 6;
            this.linkQuenMK.TabStop = true;
            this.linkQuenMK.Text = "Quên mật khẩu";
            this.linkQuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkQuenMK_LinkClicked);
            // 
            // cobVaitro
            // 
            this.cobVaitro.FormattingEnabled = true;
            this.cobVaitro.Location = new System.Drawing.Point(129, 259);
            this.cobVaitro.Name = "cobVaitro";
            this.cobVaitro.Size = new System.Drawing.Size(183, 24);
            this.cobVaitro.TabIndex = 7;
            this.cobVaitro.SelectedIndexChanged += new System.EventHandler(this.cobVaitro_SelectedIndexChanged);
            // 
            // picIconNguoi
            // 
            this.picIconNguoi.Image = global::BenhVienS.Properties.Resources.icon_ngươig;
            this.picIconNguoi.Location = new System.Drawing.Point(59, 202);
            this.picIconNguoi.Name = "picIconNguoi";
            this.picIconNguoi.Size = new System.Drawing.Size(53, 39);
            this.picIconNguoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconNguoi.TabIndex = 2;
            this.picIconNguoi.TabStop = false;
            // 
            // picIconKhoa
            // 
            this.picIconKhoa.Image = global::BenhVienS.Properties.Resources.khóa;
            this.picIconKhoa.Location = new System.Drawing.Point(59, 331);
            this.picIconKhoa.Name = "picIconKhoa";
            this.picIconKhoa.Size = new System.Drawing.Size(53, 41);
            this.picIconKhoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconKhoa.TabIndex = 1;
            this.picIconKhoa.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BenhVienS.Properties.Resources.icons8_profile;
            this.pictureBox1.Location = new System.Drawing.Point(129, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(419, 540);
            this.Controls.Add(this.cobVaitro);
            this.Controls.Add(this.linkQuenMK);
            this.Controls.Add(this.btDangnhap);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.picIconNguoi);
            this.Controls.Add(this.picIconKhoa);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Dangnhap";
            this.Text = "Dangnhap";
            this.Load += new System.EventHandler(this.Dangnhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIconNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picIconKhoa;
        private System.Windows.Forms.PictureBox picIconNguoi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btDangnhap;
        private System.Windows.Forms.LinkLabel linkQuenMK;
        private System.Windows.Forms.ComboBox cobVaitro;
    }
}