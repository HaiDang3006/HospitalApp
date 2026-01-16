namespace BenhVienS
{
    partial class caidat
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
            this.btttht = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btmatkhau = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblhospital = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btttht
            // 
            this.btttht.BackColor = System.Drawing.Color.SteelBlue;
            this.btttht.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btttht.Location = new System.Drawing.Point(12, 73);
            this.btttht.Name = "btttht";
            this.btttht.Size = new System.Drawing.Size(159, 45);
            this.btttht.TabIndex = 0;
            this.btttht.Text = "Thông Tin Hệ Thống";
            this.btttht.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblhospital);
            this.panel1.Location = new System.Drawing.Point(191, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 631);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 52);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cài đặt";
            // 
            // btmatkhau
            // 
            this.btmatkhau.BackColor = System.Drawing.Color.SteelBlue;
            this.btmatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmatkhau.Location = new System.Drawing.Point(12, 124);
            this.btmatkhau.Name = "btmatkhau";
            this.btmatkhau.Size = new System.Drawing.Size(159, 45);
            this.btmatkhau.TabIndex = 7;
            this.btmatkhau.Text = "Đổi Mật Khẩu Admin";
            this.btmatkhau.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(12, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 45);
            this.button3.TabIndex = 8;
            this.button3.Text = "Thông Tin Hệ Thống";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SteelBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(12, 226);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 45);
            this.button4.TabIndex = 9;
            this.button4.Text = "Thông Tin Hệ Thống";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblhospital
            // 
            this.lblhospital.AutoSize = true;
            this.lblhospital.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhospital.Location = new System.Drawing.Point(15, 17);
            this.lblhospital.Name = "lblhospital";
            this.lblhospital.Size = new System.Drawing.Size(308, 54);
            this.lblhospital.TabIndex = 0;
            this.lblhospital.Text = "HOSPITAL S";
            // 
            // caidat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 653);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btmatkhau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btttht);
            this.Name = "caidat";
            this.Text = "caidat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btttht;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btmatkhau;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblhospital;
    }
}