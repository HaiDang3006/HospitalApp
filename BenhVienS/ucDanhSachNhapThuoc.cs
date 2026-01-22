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
                    tk.SoLuongTon,      -- Tồn kho hiện tại
                    tk.SoLuongNhap,     -- Cột Mới: Số lượng vừa nhập
                    tk.TongTienNhap,    -- Cột Mới: Thành tiền nhập
                    tk.SoLuongToiThieu,
                    t.DonViTinh,
                    tk.NgayNhap,
                    tk.NgayHetHan,
                    t.GiaBan,
                    t.GiaNhap           -- Cần cột này để tính tiền
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

            query += " ORDER BY tk.NgayNhap DESC";

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
                dgvKho.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
               
                dgvKho.Columns["SoLuongTon"].ReadOnly = true; // Chỉ xem, không sửa trực tiếp
                dgvKho.Columns["SoLuongTon"].DefaultCellStyle.BackColor = Color.LightGray; // Làm xám để biết là read-only

                dgvKho.Columns["SoLuongNhap"].HeaderText = "SL Nhập Mới";
                dgvKho.Columns["SoLuongNhap"].DefaultCellStyle.BackColor = Color.LightYellow; // Làm nổi bật ô cần nhập

                dgvKho.Columns["TongTienNhap"].HeaderText = "Thành Tiền";
                dgvKho.Columns["TongTienNhap"].ReadOnly = true; // Tự động tính, không cho nhập tay
               
                dgvKho.Columns["SoLuongToiThieu"].HeaderText = "Mức Min";                
                dgvKho.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvKho.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvKho.Columns["NgayHetHan"].HeaderText = "Hạn Dùng";
                dgvKho.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvKho.Columns["GiaNhap"].HeaderText = "Giá Nhập";


                dgvKho.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgvKho.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvKho.Columns["TongTienNhap"].DefaultCellStyle.Format = "N0";
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
            decimal tongTienCaKho = 0;

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

                if (row.Cells["TongTienNhap"].Value != null)
                {
                    decimal tienRow = 0;
                    decimal.TryParse(row.Cells["TongTienNhap"].Value.ToString(), out tienRow);
                    tongTienCaKho += tienRow;
                }
            }
            lbCanhBao.Text = "Cảnh báo: " + soLuongCanhBao;
            lbCanhBao.ForeColor = soLuongCanhBao > 0 ? Color.Red : Color.Green;
            lbTongTien.Text = "Tổng vốn nhập: " + tongTienCaKho.ToString("N0") + " đ";
        }
        #endregion

        #region 3. Logic Nhập Kho Mới (Dynamic Columns)
        private void btNhapMoi_Click(object sender, EventArgs e)
        {
            TaoCotNhapLieu();
            if (dgvKho.Columns.Contains("SoLuongNhap"))
            {
                dgvKho.Columns["SoLuongNhap"].DefaultCellStyle.BackColor = Color.LightYellow;
            }

            if (dgvKho.RowCount > 0)
            {
                // Focus vào ô chọn thuốc dòng cuối
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
            dgvKho.EndEdit(); // Kết thúc mọi chỉnh sửa trên lưới
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

                        // CHỈ XỬ LÝ DÒNG ĐANG NHẬP MỚI (Dòng chưa có Mã Tồn Kho)
                        if (row.Cells["MaTonKho"].Value == null || string.IsNullOrEmpty(row.Cells["MaTonKho"].Value.ToString()))
                        {
                            var maThuoc = row.Cells["cbxTenThuoc"].Value;
                            var maQuay = row.Cells["cbxQuay"].Value;

                            // 1. Lấy Số lượng NHẬP (Lưu ý: lấy từ cột SoLuongNhap, không phải SoLuongTon)
                            int slNhap = 0;
                            if (row.Cells["SoLuongNhap"].Value != null)
                                int.TryParse(row.Cells["SoLuongNhap"].Value.ToString(), out slNhap);

                            if (maThuoc == null || maQuay == null || slNhap <= 0) continue;

                            var ngayHH = row.Cells["NgayHetHan"].Value ?? DateTime.Now.AddYears(1);

                            // 2. Lấy Giá Nhập từ lưới (đã được load lên từ hàm HienThi)
                            decimal giaNhap = 0;
                            if (row.Cells["GiaNhap"].Value != null)
                                decimal.TryParse(row.Cells["GiaNhap"].Value.ToString(), out giaNhap);

                            // 3. Tính Thành Tiền
                            decimal thanhTien = slNhap * giaNhap;

                            // 4. Thực thi SQL
                            string sql = @"
                        IF EXISTS (SELECT 1 FROM TonKhoThuoc WHERE MaThuoc = @MaT AND MaQuayThuoc = @MaQ)
                        BEGIN
                            -- UPDATE: Cộng dồn tồn kho, cập nhật thông tin nhập lần cuối
                            UPDATE TonKhoThuoc 
                            SET SoLuongTon = SoLuongTon + @SL, 
                                SoLuongNhap = @SL,             
                                TongTienNhap = @ThanhTien,     
                                NgayHetHan = @HSD,
                                NgayNhap = GETDATE()
                            WHERE MaThuoc = @MaT AND MaQuayThuoc = @MaQ
                        END
                        ELSE
                        BEGIN
                            -- INSERT: Thêm mới hoàn toàn (Lúc này Tồn kho = SL Nhập)
                            INSERT INTO TonKhoThuoc (MaThuoc, MaQuayThuoc, SoLuongTon, SoLuongNhap, TongTienNhap, NgayHetHan, NgayNhap)
                            VALUES (@MaT, @MaQ, @SL, @SL, @ThanhTien, @HSD, GETDATE())
                        END";

                            SqlCommand cmd = new SqlCommand(sql, conn, trans);
                            cmd.Parameters.AddWithValue("@MaT", maThuoc);
                            cmd.Parameters.AddWithValue("@MaQ", maQuay);
                            cmd.Parameters.AddWithValue("@SL", slNhap);        // Số lượng nhập
                            cmd.Parameters.AddWithValue("@ThanhTien", thanhTien); // Tổng tiền
                            cmd.Parameters.AddWithValue("@HSD", ngayHH);

                            cmd.ExecuteNonQuery();
                            rowsSaved++;
                        }
                    }
                    trans.Commit();

                    if (rowsSaved > 0)
                    {
                        MessageBox.Show($"Đã nhập kho {rowsSaved} phiếu thành công!", "Thông báo");

                        // 1. Tải lại dữ liệu mới nhất từ Database
                        HienThiDanhSachKho();

                        // 2. Trả giao diện về ban đầu (Xóa cột nhập, hiện cột xem)
                        ResetGiaoDien();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu mới để lưu.", "Cảnh báo");
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
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

        private void ResetGiaoDien()
        {
            // 1. Xóa cột ComboBox chọn thuốc/quầy nếu đang tồn tại
            if (dgvKho.Columns.Contains("cbxTenThuoc"))
                dgvKho.Columns.Remove("cbxTenThuoc");

            if (dgvKho.Columns.Contains("cbxQuay"))
                dgvKho.Columns.Remove("cbxQuay");

            // 2. Hiện lại cột Tên Thuốc và Vị Trí (dạng text) để xem
            if (dgvKho.Columns.Contains("TenThuoc"))
                dgvKho.Columns["TenThuoc"].Visible = true;

            if (dgvKho.Columns.Contains("TenQuay"))
                dgvKho.Columns["TenQuay"].Visible = true;

            // 3. Reset màu nền của cột Số lượng nhập về mặc định (trắng)
            if (dgvKho.Columns.Contains("SoLuongNhap"))
                dgvKho.Columns["SoLuongNhap"].DefaultCellStyle.BackColor = Color.White;
        }
    }
}