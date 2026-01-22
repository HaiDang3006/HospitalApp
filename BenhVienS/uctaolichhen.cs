using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class uctaolichhen : UserControl
    {
        public uctaolichhen()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lbtaolichhenmoi_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboBacsi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grptaolichhenmooi_Enter(object sender, EventArgs e)
        {

        }

        private void btdatlich_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBN.Text) || string.IsNullOrEmpty(txtTenBN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Mã BN và Tên BN!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gán dữ liệu từ các ô nhập (TextBox/ComboBox/DateTimePicker) sang các Label xác nhận

            // Gán Mã BN
            lblMaBN.Text = txtMaBN.Text;

            // Gán Tên Bệnh Nhân
            lblTenBN.Text = txtTenBN.Text;

            // Gán Bác Sĩ (Lấy text từ TextBox Bác Sĩ)
            lblBacsi.Text = txtTenbs.Text;

            // Gán Ngày Khám (Định dạng dd/MM/yyyy để dễ đọc)
            lblNgayKham.Text = dtpNgayKham.Value.ToString("dd/MM/yyyy");

            // 3. Thông báo cho người dùng
            MessageBox.Show("Đã chuyển thông tin sang phần Xác nhận. Vui lòng kiểm tra lại!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMINN;Initial Catalog=Benhvienv1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // 2. Câu lệnh SQL Insert dựa trên các cột trong ảnh của bạn
            string query = "INSERT INTO LichHen (MaBenhNhan, MaBacSi, NgayHen, TrangThai, NgayTao) " +
                           "VALUES (@MaBN, @MaBS, @NgayHen, @TrangThai, @NgayTao)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // 3. Truyền tham số từ giao diện vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@MaBN", lblMaBN.Text); // Đảm bảo panelMaBN là TextBox hoặc Label
                    cmd.Parameters.AddWithValue("@MaBS", 1); // ID bác sĩ tạm thời
                    cmd.Parameters.AddWithValue("@NgayHen", dtpNgayKham.Value); // Dùng đúng tên DateTimePicker
                    cmd.Parameters.AddWithValue("@TrangThai", "DaDen"); // Theo mẫu trong ảnh Database của bạn
                    cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);
                    // 4. Thực thi lệnh
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Đặt lịch thành công và đã lưu vào cơ sở dữ liệu!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
                }
            }
        }
    }
}


