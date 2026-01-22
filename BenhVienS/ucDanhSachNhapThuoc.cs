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
    public partial class ucDanhSachNhapThuoc : UserControl
    {
        // Chuỗi kết nối Database
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENV1;Trusted_Connection=True;TrustServerCertificate=True;";

        public ucDanhSachNhapThuoc()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost\\SQLEXPRESS02;Initial Catalog=BenhVienV1;Integrated Security=True";

        private void ucDanhSachNhapThuoc_Load(object sender, EventArgs e)
        {
            LoadComboBoxQuay();
            HienThiDanhSachKho(); // Tải dữ liệu mặc định
            FormatGridKho();
        }

        #region 1. Tải dữ liệu & Tìm kiếm nâng cao
        private void HienThiDanhSachKho()
        {
            // Query kết nối 3 bảng theo Schema SQL
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

            // Xử lý bộ lọc tìm kiếm
            if (cbQuay.SelectedValue != null && (int)cbQuay.SelectedValue != 0)
                query += " AND tk.MaQuayThuoc = @MaQuay ";

            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                query += " AND (t.TenThuoc LIKE @TuKhoa OR t.HoatChat LIKE @TuKhoa) ";

            if (chkSapHetHan.Checked)
                query += " AND tk.NgayHetHan <= DATEADD(day, 90, GETDATE()) AND tk.NgayHetHan >= GETDATE() ";

            if (chkSapHetHang.Checked)
                query += " AND tk.SoLuongTon < tk.SoLuongToiThieu "; // So sánh với cột tối thiểu trong DB

            query += " ORDER BY tk.NgayHetHan ASC, tk.SoLuongTon ASC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách kho: " + ex.Message);
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSachKho();
        }
        #endregion

        #region 2. Định dạng giao diện & Thống kê
        private void FormatGridKho()
        {
            if (dgvKho.Columns.Count > 0)
            {
                dgvKho.Columns["MaTonKho"].HeaderText = "Mã Lô";
                dgvKho.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvKho.Columns["HoatChat"].HeaderText = "Hoạt Chất";
                dgvKho.Columns["TenQuay"].HeaderText = "Vị Trí";
                dgvKho.Columns["SoLuongTon"].HeaderText = "SL Tồn";
                dgvKho.Columns["SoLuongToiThieu"].HeaderText = "Mức T.Thiểu";
                dgvKho.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvKho.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvKho.Columns["NgayHetHan"].HeaderText = "Hạn Dùng";
                dgvKho.Columns["GiaBan"].HeaderText = "Giá Bán";

                dgvKho.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgvKho.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvKho.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void CapNhatThongKe()
        {
            int tongMatHang = dgvKho.Rows.Count - (dgvKho.AllowUserToAddRows ? 1 : 0);
            lbTongMatHang.Text = "Tổng mặt hàng: " + (tongMatHang < 0 ? 0 : tongMatHang);

            int soLuongCanhBao = 0;

            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                if (row.IsNewRow) continue;

                // Lấy thông tin tồn kho và mức tối thiểu từ dòng hiện tại
                int slTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value ?? 0);
                int slToiThieu = Convert.ToInt32(row.Cells["SoLuongToiThieu"].Value ?? 10);
                DateTime ngayHH = row.Cells["NgayHetHan"].Value != DBNull.Value ? (DateTime)row.Cells["NgayHetHan"].Value : DateTime.MaxValue;

                bool sapHetHan = ngayHH <= DateTime.Now.AddDays(90);
                bool sapHetHang = slTon < slToiThieu;

                if (sapHetHan || sapHetHang)
                {
                    soLuongCanhBao++;
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
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
        #endregion

        #region 3. Logic Nhập Kho Mới (Dynamic Columns)
        private void btNhapMoi_Click(object sender, EventArgs e)
        {
            TaoCotNhapLieu();
            if (dgvKho.RowCount > 0)
            {
                dgvKho.CurrentCell = dgvKho.Rows[dgvKho.RowCount - 1].Cells["cbxTenThuoc"];
                dgvKho.BeginEdit(true);
            }
        }

        private void TaoCotNhapLieu()
        {
            if (dgvKho.Columns["cbxTenThuoc"] != null) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Cột ComboBox chọn Thuốc
                DataGridViewComboBoxColumn colThuoc = new DataGridViewComboBoxColumn();
                colThuoc.HeaderText = "Chọn Thuốc";
                colThuoc.Name = "cbxTenThuoc";
                DataTable dtThuoc = new DataTable();
                new SqlDataAdapter("SELECT MaThuoc, TenThuoc FROM Thuoc", conn).Fill(dtThuoc);
                colThuoc.DataSource = dtThuoc;
                colThuoc.DisplayMember = "TenThuoc";
                colThuoc.ValueMember = "MaThuoc";
                dgvKho.Columns.Insert(0, colThuoc);

                // Cột ComboBox chọn Quầy
                DataGridViewComboBoxColumn colQuay = new DataGridViewComboBoxColumn();
                colQuay.HeaderText = "Chọn Quầy";
                colQuay.Name = "cbxQuay";
                DataTable dtQuay = new DataTable();
                new SqlDataAdapter("SELECT MaQuayThuoc, TenQuay FROM QuayThuoc WHERE TrangThai = 1", conn).Fill(dtQuay);
                colQuay.DataSource = dtQuay;
                colQuay.DisplayMember = "TenQuay";
                colQuay.ValueMember = "MaQuayThuoc";
                dgvKho.Columns.Insert(3, colQuay);
            }
            dgvKho.Columns["TenThuoc"].Visible = false;
            dgvKho.Columns["TenQuay"].Visible = false;
            dgvKho.Columns["MaTonKho"].ReadOnly = true;
        }
        #endregion

        #region 4. Lưu dữ liệu (Transaction & Upsert Logic)
        private void btLuu_Click(object sender, EventArgs e)
        {
            dgvKho.EndEdit();
            int rowsSaved = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow row in dgvKho.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Chỉ lưu những dòng chưa có ID
                        if (row.Cells["MaTonKho"].Value == null || string.IsNullOrEmpty(row.Cells["MaTonKho"].Value.ToString()))
                        {
                            var maThuoc = row.Cells["cbxTenThuoc"].Value;
                            var maQuay = row.Cells["cbxQuay"].Value;
                            var sl = row.Cells["SoLuongTon"].Value ?? 0;
                            var ngayHH = row.Cells["NgayHetHan"].Value ?? DateTime.Now.AddYears(1);

                            if (maThuoc == null || maQuay == null) continue;

                            // Logic UPSERT: Tránh lỗi trùng MaThuoc-MaQuay theo Unique Constraint trong SQL
                            string sql = @"
                                IF EXISTS (SELECT 1 FROM TonKhoThuoc WHERE MaThuoc = @MaT AND MaQuayThuoc = @MaQ)
                                BEGIN
                                    UPDATE TonKhoThuoc SET SoLuongTon = SoLuongTon + @SL, NgayHetHan = @HSD
                                    WHERE MaThuoc = @MaT AND MaQuayThuoc = @MaQ
                                END
                                ELSE
                                BEGIN
                                    INSERT INTO TonKhoThuoc (MaThuoc, MaQuayThuoc, SoLuongTon, NgayHetHan, NgayNhap)
                                    VALUES (@MaT, @MaQ, @SL, @HSD, GETDATE())
                                END";

                            SqlCommand cmd = new SqlCommand(sql, conn, trans);
                            cmd.Parameters.AddWithValue("@MaT", maThuoc);
                            cmd.Parameters.AddWithValue("@MaQ", maQuay);
                            cmd.Parameters.AddWithValue("@SL", sl);
                            cmd.Parameters.AddWithValue("@HSD", ngayHH);
                            cmd.ExecuteNonQuery();
                            rowsSaved++;
                        }
                    }
                    trans.Commit();
                    MessageBox.Show($"Đã xử lý thành công {rowsSaved} mục tồn kho!");
                    HienThiDanhSachKho();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                }
            }
        }
        #endregion

        #region 5. Các hàm hỗ trợ ComboBox
        private void LoadComboBoxQuay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaQuayThuoc, TenQuay FROM QuayThuoc WHERE TrangThai = 1", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow dr = dt.NewRow();
                    dr["MaQuayThuoc"] = 0;
                    dr["TenQuay"] = "--- Tất cả vị trí ---";
                    dt.Rows.InsertAt(dr, 0);

                    cbQuay.DataSource = dt;
                    cbQuay.DisplayMember = "TenQuay";
                    cbQuay.ValueMember = "MaQuayThuoc";
                    cbQuay.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load quầy: " + ex.Message); }
        }
        #endregion
    }
}