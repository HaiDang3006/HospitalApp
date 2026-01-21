using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class uchotro : UserControl
    {
        public uchotro()
        {
            InitializeComponent();
        }

        private void btnGuiPhanHoi_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra người dùng đã nhập dữ liệu chưa (Giả định tên TextBox của bạn)
            // Thay 'txtChuDe', 'txtTieuDe', 'txtNoiDung' bằng đúng tên Name bạn đặt trong Design
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text) || string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tiêu đề và Nội dung phản hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hiện MessageBox thông báo đã gửi thành công
            string message = "✅ Đã gửi phản hồi thành công!\n\n" +
                             "Hệ thống sẽ ghi nhận và phản hồi lại cho bạn sớm nhất thông qua Email hoặc số điện thoại.";

            MessageBox.Show(message, "Xác nhận gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Xóa trắng các ô sau khi gửi xong
            txtChuDe.Clear();
            txtTieuDe.Clear();
            txtNoiDung.Clear();
        }
    }
}
