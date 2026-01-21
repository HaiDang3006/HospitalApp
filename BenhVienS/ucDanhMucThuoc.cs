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
        // Chuỗi kết nối đến Database
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENV1;Trusted_Connection=True;TrustServerCertificate=True;";

        public ucDanhMucThuoc()
        {
            InitializeComponent();
            LoadData();
        }

        #region 1. Tải dữ liệu và Định dạng lưới
        // Hàm tải dữ liệu lên DataGridView (Lấy đầy đủ các cột từ SQL Schema mới)
        public void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT MaThuoc, TenThuoc, HoatChat, HamLuong, DonViTinh, 
                                     CachDung, LoaiThuoc, NhaSanXuat, NuocSanXuat, 
                                     GiaNhap, GiaBan, ApDungBHYT, HanSuDung, TrangThai 
                                     FROM Thuoc";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDanhMucThuoc.DataSource = dt;
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
                // Đặt tên tiêu đề tiếng Việt cho toàn bộ các cột trong Schema
                dgvDanhMucThuoc.Columns["MaThuoc"].HeaderText = "Mã";
                dgvDanhMucThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvDanhMucThuoc.Columns["HoatChat"].HeaderText = "Hoạt Chất";
                dgvDanhMucThuoc.Columns["HamLuong"].HeaderText = "Hàm Lượng";
                dgvDanhMucThuoc.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvDanhMucThuoc.Columns["CachDung"].HeaderText = "Cách Dùng";
                dgvDanhMucThuoc.Columns["LoaiThuoc"].HeaderText = "Loại Thuốc";
                dgvDanhMucThuoc.Columns["NhaSanXuat"].HeaderText = "Nhà SX";
                dgvDanhMucThuoc.Columns["NuocSanXuat"].HeaderText = "Nước SX";
                dgvDanhMucThuoc.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                dgvDanhMucThuoc.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvDanhMucThuoc.Columns["ApDungBHYT"].HeaderText = "BHYT";
                dgvDanhMucThuoc.Columns["HanSuDung"].HeaderText = "Hạn Dùng";
                dgvDanhMucThuoc.Columns["TrangThai"].HeaderText = "Trạng Thái";

                // Ẩn mã thuốc
                if (dgvDanhMucThuoc.Columns.Contains("MaThuoc"))
                    dgvDanhMucThuoc.Columns["MaThuoc"].Visible = false;

                // Định dạng hiển thị số tiền (decimal)
                dgvDanhMucThuoc.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvDanhMucThuoc.Columns["GiaBan"].DefaultCellStyle.Format = "N0";

                // Định dạng hiển thị ngày tháng
                dgvDanhMucThuoc.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Cho phép tích chọn BHYT trực tiếp
                dgvDanhMucThuoc.Columns["ApDungBHYT"].ReadOnly = false;

                dgvDanhMucThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
        #endregion

        #region 2. Thêm Thuốc Mới
        private void btThem_Click(object sender, EventArgs e)
        {
            dgvDanhMucThuoc.EndEdit();
            DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;

            if (row == null || row.IsNewRow)
            {
                MessageBox.Show("Hãy nhấp vào dòng cuối cùng và nhập liệu trước khi Lưu!", "Thông báo");
                return;
            }

            // Kiểm tra dữ liệu bắt buộc (NOT NULL trong SQL)
            if (string.IsNullOrWhiteSpace(row.Cells["TenThuoc"].Value?.ToString()) ||
                string.IsNullOrWhiteSpace(row.Cells["DonViTinh"].Value?.ToString()))
            {
                MessageBox.Show("Vui lòng nhập Tên thuốc và Đơn vị tính!", "Lỗi");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Thuoc (TenThuoc, HoatChat, HamLuong, DonViTinh, CachDung, 
                                     LoaiThuoc, NhaSanXuat, NuocSanXuat, GiaNhap, GiaBan, 
                                     ApDungBHYT, HanSuDung, TrangThai) 
                                     VALUES (@Ten, @Hoat, @Ham, @DVT, @Cach, @Loai, @NSX, @Nuoc, @GiaN, @GiaB, @BHYT, @HSD, @TrangThai)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        GanThamSo(cmd, row);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm thuốc mới thành công!", "Thành công");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm thuốc: " + ex.Message);
                }
            }
        }
        #endregion

        #region 3. Cập nhật Thuốc (Sửa)
        private void btSua_Click(object sender, EventArgs e)
        {
            dgvDanhMucThuoc.EndEdit();
            if (dgvDanhMucThuoc.CurrentRow == null || dgvDanhMucThuoc.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần sửa!", "Thông báo");
                return;
            }

            DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;
            int maThuoc = Convert.ToInt32(row.Cells["MaThuoc"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Thuoc SET 
                                     TenThuoc=@Ten, HoatChat=@Hoat, HamLuong=@Ham, DonViTinh=@DVT, 
                                     CachDung=@Cach, LoaiThuoc=@Loai, NhaSanXuat=@NSX, NuocSanXuat=@Nuoc, 
                                     GiaNhap=@GiaN, GiaBan=@GiaB, ApDungBHYT=@BHYT, HanSuDung=@HSD, TrangThai=@TrangThai 
                                     WHERE MaThuoc=@Ma";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma", maThuoc);
                        GanThamSo(cmd, row);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thành công");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }
        #endregion

        #region 4. Xóa Thuốc
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhMucThuoc.CurrentRow == null || dgvDanhMucThuoc.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần xóa!", "Thông báo");
                return;
            }

            DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;
            int maThuoc = Convert.ToInt32(row.Cells["MaThuoc"].Value);
            string tenThuoc = row.Cells["TenThuoc"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa thuốc {tenThuoc}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Thuoc WHERE MaThuoc = @Ma";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", maThuoc);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Đã xóa thuốc thành công!");
                            LoadData();
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Lỗi 547: Vi phạm khóa ngoại (thuốc đã có trong đơn thuốc)
                        if (ex.Number == 547)
                            MessageBox.Show("Không thể xóa thuốc này vì dữ liệu đã được dùng trong Đơn thuốc/Hóa đơn!", "Lỗi ràng buộc");
                        else
                            MessageBox.Show("Lỗi SQL: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        #region 5. Tìm kiếm Thuốc
        private void btTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT * FROM Thuoc 
                                     WHERE TenThuoc LIKE @key OR HoatChat LIKE @key OR NhaSanXuat LIKE @key";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDanhMucThuoc.DataSource = dt;
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
            }
        }
        #endregion

        #region 6. Hàm hỗ trợ Gán tham số (Tránh thiếu cột)
        // Hàm này gán toàn bộ các cột từ Grid vào Parameters để dùng cho cả Thêm và Sửa
        private void GanThamSo(SqlCommand cmd, DataGridViewRow row)
        {
            cmd.Parameters.AddWithValue("@Ten", row.Cells["TenThuoc"].Value ?? "");
            cmd.Parameters.AddWithValue("@Hoat", row.Cells["HoatChat"].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ham", row.Cells["HamLuong"].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DVT", row.Cells["DonViTinh"].Value ?? "");
            cmd.Parameters.AddWithValue("@Cach", row.Cells["CachDung"].Value ?? DBNull.Value);

            // Ép kiểu chuỗi cho các trường có Check Constraint (LoaiThuoc, TrangThai)
            cmd.Parameters.AddWithValue("@Loai", row.Cells["LoaiThuoc"].Value ?? "ThuocThongThuong");
            cmd.Parameters.AddWithValue("@NSX", row.Cells["NhaSanXuat"].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Nuoc", row.Cells["NuocSanXuat"].Value ?? DBNull.Value);

            // Xử lý giá tiền
            decimal giaN, giaB;
            decimal.TryParse(row.Cells["GiaNhap"].Value?.ToString(), out giaN);
            decimal.TryParse(row.Cells["GiaBan"].Value?.ToString(), out giaB);
            cmd.Parameters.AddWithValue("@GiaN", giaN);
            cmd.Parameters.AddWithValue("@GiaB", giaB);

            // Xử lý BHYT (bit)
            cmd.Parameters.AddWithValue("@BHYT", Convert.ToBoolean(row.Cells["ApDungBHYT"].Value ?? false));

            // Xử lý Ngày hết hạn (date)
            if (row.Cells["HanSuDung"].Value != null && DateTime.TryParse(row.Cells["HanSuDung"].Value.ToString(), out DateTime hsd))
                cmd.Parameters.AddWithValue("@HSD", hsd);
            else
                cmd.Parameters.AddWithValue("@HSD", DBNull.Value);

            cmd.Parameters.AddWithValue("@TrangThai", row.Cells["TrangThai"].Value ?? "ConHang");
        }
        #endregion
    }
}