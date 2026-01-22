using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class ucqllichhen : UserControl
    {
        public ucqllichhen()
        {
            InitializeComponent();
            // Cấu hình để DataGridView hiển thị đúng các cột từ SQL
            dgvLichHen.AutoGenerateColumns = true;
        }

        private void ucqllichhen_Load(object sender, EventArgs e)
        {
            LoadLichHen();
            LoadComboBoxData();
        }

        // ================= 1. LOAD DỮ LIỆU LÊN BẢNG =================
        private void LoadLichHen()
        {
            try
            {
                using (SqlConnection conn = dbUtils.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string sql = @"SELECT 
                            MaLichHen,
                            MaBenhNhan,
                            MaBacSi,
                            MaLichLamViec,
                            LyDoKham,
                            TrangThai,
                            NgayHen,
                            NgayTao,
                            HinhThucDat
                           FROM LichHen";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLichHen.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // ================= 2. NẠP DỮ LIỆU COMBOBOX =================
        private void LoadComboBoxData()
        {
            // ===== LÝ DO KHÁM =====
            cboLyDoKham.Items.Clear();
            cboLyDoKham.Items.AddRange(new object[]
            {
                    "Khám tổng quát",
                    "Tái khám",
                    "Khám chuyên khoa"
            });

            // ===== TRẠNG THÁI (ĐỒNG BỘ VỚI DATABASE) =====
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[]
            {
        "ChoKham",
        "DaXacNhan",
        "Huy"
            });

            // ===== HÌNH THỨC ĐẶT =====
            cboHinhThucDat.Items.Clear();
            cboHinhThucDat.Items.AddRange(new object[]
            {
        "TrucTiep",
        "Online",
        "QuaDienThoai"
            });

            // ===== CHỌN MẶC ĐỊNH =====
            cboLyDoKham.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            cboHinhThucDat.SelectedIndex = 0;
        }


        // ================= 3. NÚT THÊM / ĐẶT LỊCH MỚI =================
        private void btnTimLich_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = dbUtils.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string sql = @"SELECT 
                                MaLichHen,
                                MaBenhNhan,
                                MaBacSi,
                                MaLichLamViec,
                                LyDoKham,
                                TrangThai,
                                NgayHen,
                                NgayTao,
                                HinhThucDat
                           FROM LichHen
                           WHERE 1 = 1";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    // ===== LỌC MÃ BỆNH NHÂN =====
                    if (!string.IsNullOrWhiteSpace(txtMaBenhNhan.Text))
                    {
                        sql += " AND MaBenhNhan = @bn";
                        cmd.Parameters.AddWithValue("@bn", txtMaBenhNhan.Text);
                    }

                    // ===== LỌC TRẠNG THÁI =====
                    if (cboTrangThai.SelectedIndex >= 0)
                    {
                        sql += " AND TrangThai = @tt";
                        cmd.Parameters.AddWithValue("@tt", cboTrangThai.Text);
                    }

                    // ===== LỌC LÝ DO KHÁM =====
                    if (cboLyDoKham.SelectedIndex >= 0)
                    {
                        sql += " AND LyDoKham = @lydo";
                        cmd.Parameters.AddWithValue("@lydo", cboLyDoKham.Text);
                    }

                    // ===== LỌC NGÀY HẸN =====
                    sql += " AND CAST(NgayHen AS DATE) = @ngayhen";
                    cmd.Parameters.AddWithValue("@ngayhen", dtpNgayHen.Value.Date);

                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLichHen.DataSource = dt;

                    // ===== MESSAGEBOX =====
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(
                            $"✅ Tìm thấy {dt.Rows.Count} lịch hẹn!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "❌ Không tìm thấy lịch hẹn nào!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm lịch: " + ex.Message);
            }
        }


        // ================= 4. NÚT XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichHen.CurrentRow == null) return;

            // Lấy ID từ cột đầu tiên của dòng đang chọn
            string maLichHen = dgvLichHen.CurrentRow.Cells[0].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa lịch hẹn mã " + maLichHen + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = dbUtils.GetConnection())
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();
                        string sql = "DELETE FROM LichHen WHERE MaLichHen = @ma";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ma", maLichHen);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xóa thành công!");
                        LoadLichHen();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        // ================= 5. NÚT SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLichHen.CurrentRow == null) return;
            string maLichHen = dgvLichHen.CurrentRow.Cells[0].Value.ToString();

            try
            {
                using (SqlConnection conn = dbUtils.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    string sql = @"UPDATE LichHen SET 
                                    MaBacSi = @bs, 
                                    LyDoKham = @lydo, 
                                    TrangThai = @tt 
                                   WHERE MaLichHen = @ma";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@bs", txtMaBacSi.Text);
                    cmd.Parameters.AddWithValue("@lydo", cboLyDoKham.Text);
                    cmd.Parameters.AddWithValue("@tt", cboTrangThai.Text);
                    cmd.Parameters.AddWithValue("@ma", maLichHen);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadLichHen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        private void ucqllichhen_Load_1(object sender, EventArgs e)
        {

        }
    }
}