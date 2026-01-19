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
    public partial class ucDanhMucThuoc : UserControl
    {
        public ucDanhMucThuoc()
        {
            InitializeComponent();
            LoadData();
        }
        // Thay đổi Server Name cho đúng với máy của bạn
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";

        // Hàm tải dữ liệu lên DataGridView
        public void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Truy vấn đúng các cột bạn yêu cầu
                    string query = @"SELECT TenThuoc, HoatChat, DonViTinh, LoaiThuoc, 
                             GiaNhap, GiaBan, ApDungBHYT, TrangThai, MaThuoc 
                             FROM Thuoc";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDanhMucThuoc.DataSource = dt;
                    // 2. Định dạng giao diện các cột
                    DinhDangLuoi();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh mục thuốc: " + ex.Message, "Thông báo");
                }
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvDanhMucThuoc.Columns.Count > 0)
            {
                // Đặt tên tiêu đề tiếng Việt
                dgvDanhMucThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvDanhMucThuoc.Columns["HoatChat"].HeaderText = "Hoạt Chất";
                dgvDanhMucThuoc.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvDanhMucThuoc.Columns["LoaiThuoc"].HeaderText = "Loại";
                dgvDanhMucThuoc.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                dgvDanhMucThuoc.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvDanhMucThuoc.Columns["ApDungBHYT"].HeaderText = "BHYT";
                dgvDanhMucThuoc.Columns["TrangThai"].HeaderText = "Trạng Thái";

                // Ẩn mã thuốc nếu không cần hiển thị cho người dùng
                if (dgvDanhMucThuoc.Columns.Contains("MaThuoc"))
                    dgvDanhMucThuoc.Columns["MaThuoc"].Visible = false;

                // Định dạng tiền tệ cho GiaNhap và GiaBan (Ví dụ: 100,000)
                dgvDanhMucThuoc.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvDanhMucThuoc.Columns["GiaBan"].DefaultCellStyle.Format = "N0";

                // Để cột ApDungBHYT có thể tích chọn trực tiếp trên lưới
                dgvDanhMucThuoc.Columns["ApDungBHYT"].ReadOnly = false;

                // Tự động căn chỉnh chiều rộng cột
                dgvDanhMucThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            // 1. Kết thúc việc gõ trên lưới để hệ thống ghi nhận giá trị cuối cùng
            dgvDanhMucThuoc.EndEdit();

            // 2. Xác định dòng bạn đang đứng (thường là dòng bạn vừa gõ xong)
            DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;

            if (row == null || row.IsNewRow)
            {
                MessageBox.Show("Hãy nhấp vào dòng trống cuối cùng của lưới và gõ thông tin trước!", "Thông báo");
                return;
            }

            // 3. Kiểm tra dữ liệu bắt buộc (ví dụ Tên thuốc không được để trống)
            if (row.Cells["TenThuoc"].Value == null || string.IsNullOrWhiteSpace(row.Cells["TenThuoc"].Value.ToString()))
            {
                MessageBox.Show("Vui lòng nhập Tên thuốc vào lưới trước khi nhấn Lưu!", "Lỗi");
                return;
            }

            // 4. Thực hiện Lưu vào Database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Thuoc (TenThuoc, HoatChat, DonViTinh, LoaiThuoc, GiaNhap, GiaBan, ApDungBHYT, TrangThai) 
                             VALUES (@Ten, @HoatChat, @DVT, @Loai, @GiaN, @GiaB, @BHYT, @TrangThai)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Lấy dữ liệu từ các ô (Cells) của dòng bạn đang đứng
                        cmd.Parameters.AddWithValue("@Ten", row.Cells["TenThuoc"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@HoatChat", row.Cells["HoatChat"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@DVT", row.Cells["DonViTinh"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Loai", row.Cells["LoaiThuoc"].Value?.ToString() ?? "");

                        decimal giaN = 0, giaB = 0;
                        decimal.TryParse(row.Cells["GiaNhap"].Value?.ToString(), out giaN);
                        decimal.TryParse(row.Cells["GiaBan"].Value?.ToString(), out giaB);
                        cmd.Parameters.AddWithValue("@GiaN", giaN);
                        cmd.Parameters.AddWithValue("@GiaB", giaB);

                        bool bhyt = false;
                        if (row.Cells["ApDungBHYT"].Value != null)
                            bool.TryParse(row.Cells["ApDungBHYT"].Value.ToString(), out bhyt);
                        cmd.Parameters.AddWithValue("@BHYT", bhyt);

                        cmd.Parameters.AddWithValue("@TrangThai", (dgvDanhMucThuoc.CurrentRow.Cells["TrangThai"].Value?.ToString().Trim().ToLower() == "hết hàng") ? "HetHang" : "ConHang");

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã lưu dữ liệu thành công vào hệ thống!", "Thành công");

                        // 5. Quan trọng nhất: Tải lại dữ liệu để khi mở app lên vẫn thấy thuốc vừa thêm
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu Database: " + ex.Message);
                }
            }
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            // 1. Kết thúc việc chỉnh sửa trên lưới để đảm bảo dữ liệu mới nhất được ghi nhận
            dgvDanhMucThuoc.EndEdit();

            // 2. Kiểm tra xem người dùng có đang chọn dòng nào hợp lệ không
            if (dgvDanhMucThuoc.CurrentRow == null || dgvDanhMucThuoc.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một dòng thuốc cụ thể để sửa!", "Thông báo");
                return;
            }

            DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;

            // 3. Lấy MaThuoc (Khóa chính) để biết cần sửa dòng nào trong SQL
            // Lưu ý: Cột MaThuoc phải có trong DataSource của dgv (dù bạn có ẩn nó đi)
            if (row.Cells["MaThuoc"].Value == null)
            {
                MessageBox.Show("Không tìm thấy mã thuốc để cập nhật!", "Lỗi");
                return;
            }
            int maThuoc = Convert.ToInt32(row.Cells["MaThuoc"].Value);

            // 4. Thực hiện cập nhật vào Database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Thuoc 
                             SET TenThuoc = @Ten, 
                                 HoatChat = @HoatChat, 
                                 DonViTinh = @DVT, 
                                 LoaiThuoc = @Loai, 
                                 GiaNhap = @GiaN, 
                                 GiaBan = @GiaB, 
                                 ApDungBHYT = @BHYT, 
                                 TrangThai = @TrangThai
                             WHERE MaThuoc = @Ma";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền tham số từ các ô trên dòng đang chọn
                        cmd.Parameters.AddWithValue("@Ma", maThuoc);
                        cmd.Parameters.AddWithValue("@Ten", row.Cells["TenThuoc"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@HoatChat", row.Cells["HoatChat"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@DVT", row.Cells["DonViTinh"].Value?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Loai", row.Cells["LoaiThuoc"].Value?.ToString() ?? "");

                        // Xử lý kiểu số
                        decimal giaN = 0, giaB = 0;
                        decimal.TryParse(row.Cells["GiaNhap"].Value?.ToString(), out giaN);
                        decimal.TryParse(row.Cells["GiaBan"].Value?.ToString(), out giaB);
                        cmd.Parameters.AddWithValue("@GiaN", giaN);
                        cmd.Parameters.AddWithValue("@GiaB", giaB);

                        // Xử lý kiểu checkbox BHYT
                        bool bhyt = false;
                        if (row.Cells["ApDungBHYT"].Value != null)
                            bool.TryParse(row.Cells["ApDungBHYT"].Value.ToString(), out bhyt);
                        cmd.Parameters.AddWithValue("@BHYT", bhyt);

                        // Lấy trạng thái từ lưới hoặc để mặc định
                        cmd.Parameters.AddWithValue("@TrangThai", row.Cells["TrangThai"].Value?.ToString() ?? "ConHang");

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin thuốc thành công!", "Thành công");
                            LoadData(); // Tải lại lưới để đồng bộ dữ liệu
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật database: " + ex.Message);
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có chọn dòng nào hợp lệ không
            if (dgvDanhMucThuoc.CurrentRow == null || dgvDanhMucThuoc.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn loại thuốc cần xóa khỏi danh sách!", "Thông báo");
                return;
            }

            // 2. Lấy thông tin MaThuoc và TenThuoc từ dòng đang chọn
            DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;
            int maThuoc = Convert.ToInt32(row.Cells["MaThuoc"].Value);
            string tenThuoc = row.Cells["TenThuoc"].Value?.ToString() ?? "này";

            // 3. Hiển thị hộp thoại xác nhận (Warning) để tránh nhấn nhầm
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thuốc '{tenThuoc}' không?\nLưu ý: Hành động này không thể hoàn tác.",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // 4. Thực hiện lệnh DELETE
                        // Lưu ý: Nếu thuốc đã có trong đơn thuốc cũ, SQL sẽ chặn xóa để bảo vệ dữ liệu.
                        string query = "DELETE FROM Thuoc WHERE MaThuoc = @Ma";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", maThuoc);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đã xóa thuốc thành công!", "Thành công");
                                LoadData(); // Tải lại danh sách thuốc
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Xử lý lỗi ràng buộc khóa ngoại (ví dụ: thuốc đã nằm trong DonThuoc hoặc ChiTietHoaDon)
                        if (ex.Number == 547)
                        {
                            MessageBox.Show("Không thể xóa thuốc này vì nó đã được sử dụng trong các đơn thuốc hoặc hóa đơn của bệnh viện!\n" +
                                            "Gợi ý: Hãy cập nhật Trạng thái sang 'NgungSuDung' thay vì xóa vĩnh viễn.",
                                            "Lỗi ràng buộc dữ liệu",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            // 1. Lấy từ khóa từ TextBox và xóa khoảng trắng thừa
            string keyword = txtTimKiem.Text.Trim();

            // 2. Nếu ô tìm kiếm trống, tải lại toàn bộ danh mục thuốc
            if (string.IsNullOrEmpty(keyword) || keyword == "Nhập mã đơn, họ tên bệnh nhân")
            {
                LoadData();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 3. Truy vấn tìm kiếm theo Tên thuốc hoặc Hoạt chất (sử dụng LIKE)
                    string query = @"SELECT TenThuoc, HoatChat, DonViTinh, LoaiThuoc, 
                             GiaNhap, GiaBan, ApDungBHYT, TrangThai, MaThuoc 
                             FROM Thuoc 
                             WHERE TenThuoc LIKE @keyword OR HoatChat LIKE @keyword";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Sử dụng %keyword% để tìm kiếm tương đối (chứa từ khóa)
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 4. Hiển thị kết quả lên DataGridView
                        dgvDanhMucThuoc.DataSource = dt;

                        // Thông báo nếu không tìm thấy kết quả
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy thuốc nào khớp với từ khóa!", "Thông báo");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }
    }
}

