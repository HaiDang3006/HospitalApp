namespace BenhVienS
{
    partial class QuenMK
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labEmail = new System.Windows.Forms.Label();
            this.labKetqua = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btLaylaiMK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BenhVienS.Properties.Resources.icons8_profile;
            this.pictureBox1.Location = new System.Drawing.Point(125, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEmail.Location = new System.Drawing.Point(29, 182);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(148, 25);
            this.labEmail.TabIndex = 2;
            this.labEmail.Text = "Email đăng kí";
            // 
            // labKetqua
            // 
            this.labKetqua.AutoSize = true;
            this.labKetqua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labKetqua.Location = new System.Drawing.Point(29, 252);
            this.labKetqua.Name = "labKetqua";
            this.labKetqua.Size = new System.Drawing.Size(93, 25);
            this.labKetqua.TabIndex = 3;
            this.labKetqua.Text = "Kết quả";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(204, 252);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(204, 182);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 25);
            this.textBox2.TabIndex = 5;
            // 
            // btLaylaiMK
            // 
            this.btLaylaiMK.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLaylaiMK.Location = new System.Drawing.Point(106, 328);
            this.btLaylaiMK.Name = "btLaylaiMK";
            this.btLaylaiMK.Size = new System.Drawing.Size(229, 60);
            this.btLaylaiMK.TabIndex = 6;
            this.btLaylaiMK.Text = "Lấy lại mật khẩu";
            this.btLaylaiMK.UseVisualStyleBackColor = true;
            this.btLaylaiMK.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuenMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(446, 482);
            this.Controls.Add(this.btLaylaiMK);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labKetqua);
            this.Controls.Add(this.labEmail);
            this.Controls.Add(this.pictureBox1);
            this.Name = "QuenMK";
            this.Text = "QuenMK";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labEmail;
        private System.Windows.Forms.Label labKetqua;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btLaylaiMK;
    }
}