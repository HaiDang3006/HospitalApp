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
using System.Windows.Forms.DataVisualization.Charting;

namespace BenhVienS
{
    public partial class ucDanhSachNhapThuoc : UserControl
    {
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENV1;Trusted_Connection=True;TrustServerCertificate=True;";

        public ucDanhSachNhapThuoc()
        {
            InitializeComponent();
        }

        private void ucDanhSachNhapThuoc_Load(object sender, EventArgs e)
        {
            LoadComboBoxQuay();
            HienThiDanhSachKho(); // Gọi hàm này để load dữ liệu ban đầu
            FormatGridKho();
        }

        // --- 1. LOAD DỮ LIỆU & TÌM KIẾM ---
        private void HienThiDanhSachKho()
        {
            // Query lấy thêm SoLuongToiThieu để làm cảnh báo động
            string query = @"
                SELECT 
                    tk.MaTonKho,
                    t.TenThuoc,
                    t.HoatChat,
                    q.TenQuay,
                    tk.SoLuongTon,
                    tk.SoLuongToiThieu,
                    t.DonViTinh,
                    tk.NgayNhap,
                    tk.NgayHetHan,
                    t.GiaBan,
                    t.GiaNhap
                FROM TonKhoThuoc tk
                INNER JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc
                INNER JOIN QuayThuoc q ON tk.MaQuayThuoc = q.MaQuayThuoc
                WHERE 1=1 ";

            if (cbQuay.SelectedValue != null && (int)cbQuay.SelectedValue != 0)
                query += " AND tk.MaQuayThuoc = @MaQuay ";

            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                query += " AND (t.TenThuoc LIKE @TuKhoa OR t.HoatChat LIKE @TuKhoa) ";

            if (chkSapHetHan.Checked)
                query += " AND tk.NgayHetHan <= DATEADD(day, 90, GETDATE()) AND tk.NgayHetHan >= GETDATE() ";

            if (chkSapHetHang.Checked)
                query += " AND tk.SoLuongTon < tk.SoLuongToiThieu "; // Dùng cột trong DB thay vì số 10

            query += " ORDER BY tk.NgayHetHan ASC, tk.SoLuongTon ASC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (query.Contains("@MaQuay")) cmd.Parameters.AddWithValue("@MaQuay", cbQuay.SelectedValue);
                    if (query.Contains("@TuKhoa")) cmd.Parameters.AddWithValue("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKho.DataSource = dt;

                    CapNhatThongKe();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- 2. THỐNG KÊ & CẢNH BÁO MÀU SẮC ---
        private void CapNhatThongKe()
        {
            int tongMatHang = dgvKho.Rows.Count - (dgvKho.AllowUserToAddRows ? 1 : 0);
            lbTongMatHang.Text = "Tổng mặt hàng: " + (tongMatHang < 0 ? 0 : tongMatHang);

            int soLuongCanhBao = 0;

            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                if (row.IsNewRow) continue;

                // Lấy giá trị tồn và hạn dùng
                int slTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value ?? 0);
                int slToiThieu = Convert.ToInt32(row.Cells["SoLuongToiThieu"].Value ?? 10);
                DateTime ngayHetHan = row.Cells["NgayHetHan"].Value != DBNull.Value
                                      ? Convert.ToDateTime(row.Cells["NgayHetHan"].Value)
                                      : DateTime.MaxValue;

                bool sapHetHan = ngayHetHan <= DateTime.Now.AddDays(90);
                bool sapHetHang = slTon < slToiThieu;

                if (sapHetHan || sapHetHang)
                {
                    soLuongCanhBao++;
                    row.DefaultCellStyle.BackColor = Color.MistyRose; // Đỏ nhạt
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            lbCanhBao.Text = "Cảnh báo: " + soLuongCanhBao;
            lbCanhBao.ForeColor = soLuongCanhBao > 0 ? Color.Red : Color.Green;
        }

        // --- 3. NHẬP KHO (INSERT) ---
        private void btLuu_Click(object sender, EventArgs e)
        {
            dgvKho.EndEdit();
            int thanhCong = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    foreach (DataGridViewRow row in dgvKho.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Chỉ xử lý dòng mới (chưa có MaTonKho)
                        if (row.Cells["MaTonKho"].Value == null || string.IsNullOrEmpty(row.Cells["MaTonKho"].Value.ToString()))
                        {
                            // Lưu ý: SQL có ràng buộc UNIQUE (MaThuoc, MaQuayThuoc)
                            string sql = @"
                                IF NOT EXISTS (SELECT 1 FROM TonKhoThuoc WHERE MaThuoc = @MaT AND MaQuayThuoc = @MaQ)
                                BEGIN
                                    INSERT INTO TonKhoThuoc (MaThuoc, MaQuayThuoc, SoLuongTon, NgayHetHan, NgayNhap) 
                                    VALUES (@MaT, @MaQ, @SL, @HSD, GETDATE())
                                END
                                ELSE
                                BEGIN
                                    UPDATE TonKhoThuoc SET SoLuongTon = SoLuongTon + @SL, NgayHetHan = @HSD
                                    WHERE MaThuoc = @MaT AND MaQuayThuoc = @MaQ
                                END";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                // Lấy ID từ ComboBox trong Grid (Cần hàm TaoCotNhapLieu đã viết ở code cũ của bạn)
                                cmd.Parameters.AddWithValue("@MaT", row.Cells["cbxTenThuoc"].Value ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@MaQ", row.Cells["cbxQuay"].Value ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SL", row.Cells["SoLuongTon"].Value ?? 0);
                                cmd.Parameters.AddWithValue("@HSD", row.Cells["NgayHetHan"].Value ?? DateTime.Now.AddYears(2));

                                cmd.ExecuteNonQuery();
                                thanhCong++;
                            }
                        }
                    }
                    MessageBox.Show($"Xử lý thành công {thanhCong} lô thuốc!");
                    HienThiDanhSachKho(); // Refresh
                }
                catch (Exception ex) { MessageBox.Show("Lỗi lưu kho: " + ex.Message); }
            }
        }

        // --- 4. CÁC HÀM HỖ TRỢ ---
        private void LoadComboBoxQuay()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaQuayThuoc, TenQuay FROM QuayThuoc WHERE TrangThai = 1", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow dr = dt.NewRow();
                dr["MaQuayThuoc"] = 0;
                dr["TenQuay"] = "-- Tất cả quầy --";
                dt.Rows.InsertAt(dr, 0);
                cbQuay.DataSource = dt;
                cbQuay.DisplayMember = "TenQuay";
                cbQuay.ValueMember = "MaQuayThuoc";
            }
        }

        private void FormatGridKho()
        {
            if (dgvKho.Columns.Count == 0) return;
            dgvKho.Columns["MaTonKho"].HeaderText = "Mã Lô";
            dgvKho.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
            dgvKho.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
            dgvKho.Columns["SoLuongToiThieu"].Visible = false; // Ẩn đi nhưng dùng để so sánh logic
            dgvKho.Columns["NgayHetHan"].HeaderText = "Hạn Dùng";
            dgvKho.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvKho.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btTimKiem_Click(object sender, EventArgs e) => HienThiDanhSachKho();
    }
}