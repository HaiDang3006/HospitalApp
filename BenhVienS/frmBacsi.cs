using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace BenhVienS
{
    
    public partial class frmBacsi : Form
    {
        public string State { get; set; }
        public frmBacsi()
        {
            InitializeComponent();
        }
        private void frmBacsi_Load(object sender, EventArgs e)
        {
            // Tùy biến giao diện dựa trên trạng thái
            if (State == "Them")
            {
                this.Text = "Thêm mới Bác sĩ";
                btnLuu.Text = "Thêm";
            }
            else if (State == "Sua")
            {
                this.Text = "Chỉnh sửa thông tin Bác sĩ";
                btnLuu.Text = "Cập nhật";
                txtID.ReadOnly = true; // Không cho sửa ID
            }
            else if (State == "Xoa")
            {
                this.Text = "Xác nhận xóa Bác sĩ";
                btnLuu.Text = "Xóa ngay";
                VôHiệuHóaCacO(false); // Hàm tự viết để ngăn người dùng nhập liệu khi xóa
            }
        }

        private void cbChuyenkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtHoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateNgaysinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTrinhdo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKinhnghiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thực hiện thành công!");
            this.DialogResult = DialogResult.OK; // Trả kết quả về Form2
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void VôHiệuHóaCacO(bool status)
        {
            txtHoten.Enabled = status;
            txtSDT.Enabled = status;
            cbChuyenkhoa.Enabled = status;
            txtEmail.Enabled = status;
            txtTrinhdo.Enabled = status;
            txtKinhnghiem.Enabled = status;
            dateNgaysinh.Enabled = status;
            radNam.Enabled = status;
            radNu.Enabled = status;
            txtID.Enabled = status;

            // ... các control khác tương tự
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
