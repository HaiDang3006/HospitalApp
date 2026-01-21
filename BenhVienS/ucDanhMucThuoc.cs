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
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENV1;Trusted_Connection=True;TrustServerCertificate=True;";

        public ucDanhMucThuoc()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Lấy đầy đủ các cột theo schema SQL mới
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
                    MessageBox.Show("Lỗi khi tải danh mục thuốc: " + ex.Message);
                }
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvDanhMucThuoc.Columns.Count > 0)
            {
                // Đặt tiêu đề tiếng Việt cho các cột mới
                dgvDanhMucThuoc.Columns["MaThuoc"].Visible = false;
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

                // Định dạng tiền tệ và ngày tháng
                dgvDanhMucThuoc.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvDanhMucThuoc.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgvDanhMucThuoc.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvDanhMucThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            dgvDanhMucThuoc.EndEdit();
            DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;

            if (row == null || row.IsNewRow) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Cập nhật câu lệnh INSERT với đầy đủ các trường mới
                    string query = @"INSERT INTO Thuoc (TenThuoc, HoatChat, HamLuong, DonViTinh, CachDung, 
                                     LoaiThuoc, NhaSanXuat, NuocSanXuat, GiaNhap, GiaBan, 
                                     ApDungBHYT, HanSuDung, TrangThai) 
                                     VALUES (@Ten, @Hoat, @Ham, @DVT, @Cach, @Loai, @NSX, @Nuoc, @GiaN, @GiaB, @BHYT, @HSD, @TrangThai)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SetupParameters(cmd, row);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thuốc mới thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            dgvDanhMucThuoc.EndEdit();
            if (dgvDanhMucThuoc.CurrentRow == null) return;

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

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", maThuoc);
                    SetupParameters(cmd, row);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        // Hàm dùng chung để gán tham số nhằm tránh lặp code
        private void SetupParameters(SqlCommand cmd, DataGridViewRow row)
        {
            cmd.Parameters.AddWithValue("@Ten", row.Cells["TenThuoc"].Value ?? "");
            cmd.Parameters.AddWithValue("@Hoat", row.Cells["HoatChat"].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ham", row.Cells["HamLuong"].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DVT", row.Cells["DonViTinh"].Value ?? "");
            cmd.Parameters.AddWithValue("@Cach", row.Cells["CachDung"].Value ?? DBNull.Value);

            // Lưu ý: Giá trị Loại Thuốc phải khớp với CHECK constraint trong SQL
            // ('ThuocThongThuong', 'ThuocDichVu', 'ThuocBHYT')
            cmd.Parameters.AddWithValue("@Loai", row.Cells["LoaiThuoc"].Value ?? "ThuocThongThuong");

            cmd.Parameters.AddWithValue("@NSX", row.Cells["NhaSanXuat"].Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Nuoc", row.Cells["NuocSanXuat"].Value ?? DBNull.Value);

            decimal giaN, giaB;
            decimal.TryParse(row.Cells["GiaNhap"].Value?.ToString(), out giaN);
            decimal.TryParse(row.Cells["GiaBan"].Value?.ToString(), out giaB);
            cmd.Parameters.AddWithValue("@GiaN", giaN);
            cmd.Parameters.AddWithValue("@GiaB", giaB);

            cmd.Parameters.AddWithValue("@BHYT", Convert.ToBoolean(row.Cells["ApDungBHYT"].Value ?? false));

            if (row.Cells["HanSuDung"].Value != null && DateTime.TryParse(row.Cells["HanSuDung"].Value.ToString(), out DateTime hsd))
                cmd.Parameters.AddWithValue("@HSD", hsd);
            else
                cmd.Parameters.AddWithValue("@HSD", DBNull.Value);

            // Lưu ý: Trạng thái phải khớp với CHECK constraint ('NgungKinhDoanh', 'HetHang', 'ConHang')
            cmd.Parameters.AddWithValue("@TrangThai", row.Cells["TrangThai"].Value ?? "ConHang");
        }

        // ... (Các hàm Xóa và Tìm kiếm giữ nguyên logic cũ nhưng cập nhật query nếu cần)
    }
}

