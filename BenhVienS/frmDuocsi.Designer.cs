namespace BenhVienS
{
    partial class frmDuocsi
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHotenduocsi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSDTduocsi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtemailduocsi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCapnhatduocsi = new System.Windows.Forms.CheckBox();
            this.btnThemduocsi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(-1, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 451);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnThemduocsi);
            this.groupBox1.Controls.Add(this.cbCapnhatduocsi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtemailduocsi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSDTduocsi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHotenduocsi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(0, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 349);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm mới dược sĩ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Họ và tên:";
            // 
            // txtHotenduocsi
            // 
            this.txtHotenduocsi.Location = new System.Drawing.Point(13, 84);
            this.txtHotenduocsi.Name = "txtHotenduocsi";
            this.txtHotenduocsi.Size = new System.Drawing.Size(263, 24);
            this.txtHotenduocsi.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(13, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số điện thoại:";
            // 
            // txtSDTduocsi
            // 
            this.txtSDTduocsi.Location = new System.Drawing.Point(13, 186);
            this.txtSDTduocsi.Name = "txtSDTduocsi";
            this.txtSDTduocsi.Size = new System.Drawing.Size(263, 24);
            this.txtSDTduocsi.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(322, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email:";
            // 
            // txtemailduocsi
            // 
            this.txtemailduocsi.Location = new System.Drawing.Point(325, 84);
            this.txtemailduocsi.Name = "txtemailduocsi";
            this.txtemailduocsi.Size = new System.Drawing.Size(263, 24);
            this.txtemailduocsi.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(322, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Trạng thái:";
            // 
            // cbCapnhatduocsi
            // 
            this.cbCapnhatduocsi.AutoSize = true;
            this.cbCapnhatduocsi.Location = new System.Drawing.Point(325, 189);
            this.cbCapnhatduocsi.Name = "cbCapnhatduocsi";
            this.cbCapnhatduocsi.Size = new System.Drawing.Size(102, 22);
            this.cbCapnhatduocsi.TabIndex = 10;
            this.cbCapnhatduocsi.Text = "Cập nhật:";
            this.cbCapnhatduocsi.UseVisualStyleBackColor = true;
            // 
            // btnThemduocsi
            // 
            this.btnThemduocsi.Location = new System.Drawing.Point(468, 312);
            this.btnThemduocsi.Name = "btnThemduocsi";
            this.btnThemduocsi.Size = new System.Drawing.Size(110, 31);
            this.btnThemduocsi.TabIndex = 14;
            this.btnThemduocsi.Text = "Thêm";
            this.btnThemduocsi.UseVisualStyleBackColor = true;
            // 
            // frmDuocsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmDuocsi";
            this.Text = "frmDuocsi";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHotenduocsi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbCapnhatduocsi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtemailduocsi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDTduocsi;
        private System.Windows.Forms.Button btnThemduocsi;
    }
}