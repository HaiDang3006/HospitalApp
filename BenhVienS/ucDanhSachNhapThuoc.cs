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
        public ucDanhSachNhapThuoc()
        {
            InitializeComponent();
        }
        string connectionString = "Server = MSI\\SQLEXPRESS; Database = BENHVIENS; Trusted_Connection = True; TrustServerCertificate = True; ";

        private void ucDanhSachNhapThuoc_Load(object sender, EventArgs e)
        {
            LoadDataKho();
            FormatGridKho();
            LoadComboBoxQuay();
        }

        private void LoadDataKho()
        {
            // Query kết hợp 3 bảng: TonKhoThuoc, Thuoc, QuayThuoc
            // Lưu ý: XuatThuoc là bảng lịch sử giao dịch, không join trực tiếp vào view tồn kho hiện tại
            string query = @"
                SELECT 
                    tk.MaTonKho,
                    t.TenThuoc,
                    t.HoatChat,
                    q.TenQuay,
                    tk.SoLuongTon,
                    t.DonViTinh,
                    tk.NgayNhap,
                    tk.NgayHetHan,
                    t.GiaBan,
                    t.GiaNhap
                FROM TonKhoThuoc tk
                INNER JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc
                INNER JOIN QuayThuoc q ON tk.MaQuayThuoc = q.MaQuayThuoc
                ORDER BY tk.NgayNhap DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvKho.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm định dạng hiển thị cho đẹp mắt (Optional)
        private void FormatGridKho()
        {
            if (dgvKho.Columns.Count > 0)
            {
                // Đặt tên tiếng Việt cho tiêu đề cột
                dgvKho.Columns["MaTonKho"].HeaderText = "Mã Lô";
                dgvKho.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvKho.Columns["HoatChat"].HeaderText = "Hoạt Chất";
                dgvKho.Columns["TenQuay"].HeaderText = "Vị Trí (Quầy)";
                dgvKho.Columns["SoLuongTon"].HeaderText = "SL Tồn";
                dgvKho.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvKho.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvKho.Columns["NgayHetHan"].HeaderText = "Hạn Dùng";
                dgvKho.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvKho.Columns["GiaNhap"].HeaderText = "Giá Nhập";

                // Định dạng tiền tệ và ngày tháng
                dgvKho.Columns["GiaBan"].DefaultCellStyle.Format = "N0"; // Số nguyên có dấu phẩy
                dgvKho.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvKho.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvKho.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Tự động chỉnh độ rộng
                dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void LoadComboBoxQuay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaQuayThuoc, TenQuay FROM QuayThuoc WHERE TrangThai = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm một dòng "Tất cả" vào đầu ComboBox
                    DataRow dr = dt.NewRow();
                    dr["MaQuayThuoc"] = 0; // Giá trị 0 đại diện cho tất cả
                    dr["TenQuay"] = "--- Tất cả vị trí ---";
                    dt.Rows.InsertAt(dr, 0);

                    cbQuay.DataSource = dt;
                    cbQuay.DisplayMember = "TenQuay";
                    cbQuay.ValueMember = "MaQuayThuoc";
                    cbQuay.SelectedIndex = 0; // Mặc định chọn "Tất cả"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load quầy: " + ex.Message);
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSachKho();
        }

        // Hàm xử lý logic tìm kiếm chính
        private void HienThiDanhSachKho()
        {
            // Query cơ bản kết nối 3 bảng
            string query = @"
                SELECT 
                    tk.MaTonKho,
                    t.TenThuoc,
                    t.HoatChat,
                    q.TenQuay,
                    tk.SoLuongTon,
                    t.DonViTinh,
                    tk.NgayNhap,
                    tk.NgayHetHan,
                    t.GiaBan
                FROM TonKhoThuoc tk
                INNER JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc
                INNER JOIN QuayThuoc q ON tk.MaQuayThuoc = q.MaQuayThuoc
                WHERE 1=1 "; // Mẹo: WHERE 1=1 giúp dễ dàng cộng chuỗi AND phía sau

            // --- XỬ LÝ ĐIỀU KIỆN ---

            // 1. Điều kiện: Vị trí / Quầy (Nếu khác 0 tức là có chọn cụ thể)
            if (cbQuay.SelectedValue != null && (int)cbQuay.SelectedValue != 0)
            {
                query += " AND tk.MaQuayThuoc = @MaQuay ";
            }

            // 2. Điều kiện: Tìm kiếm theo Tên hoặc Hoạt chất
            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                query += " AND (t.TenThuoc LIKE @TuKhoa OR t.HoatChat LIKE @TuKhoa) ";
            }

            // 3. Điều kiện: Sắp hết hạn (trong vòng 3 tháng tới)
            if (chkSapHetHan.Checked)
            {
                // Logic: Ngày hết hạn <= Ngày hiện tại + 90 ngày
                query += " AND tk.NgayHetHan <= DATEADD(day, 90, GETDATE()) AND tk.NgayHetHan >= GETDATE() ";
            }

            // 4. Điều kiện: Sắp hết hàng (SL < 10)
            if (chkSapHetHang.Checked)
            {
                query += " AND tk.SoLuongTon < 10 ";
            }

            // Sắp xếp ưu tiên: Hết hạn trước -> Số lượng ít -> Mới nhập
            query += " ORDER BY tk.NgayHetHan ASC, tk.SoLuongTon ASC";

            // --- THỰC THI QUERY ---
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền tham số để tránh lỗi và bảo mật (SQL Injection)
                    if (cbQuay.SelectedValue != null && (int)cbQuay.SelectedValue != 0)
                    {
                        cmd.Parameters.AddWithValue("@MaQuay", cbQuay.SelectedValue);
                    }

                    if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                    {
                        cmd.Parameters.AddWithValue("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvKho.DataSource = dt;
                    CapNhatThongKe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Hàm tính toán và hiển thị thống kê
        private void CapNhatThongKe()
        {
            /// 1. TÍNH TỔNG MẶT HÀNG
            int tongSoLuong = 0;
            if (dgvKho.Rows.Count > 0)
            {
                // Trừ đi dòng trống cuối cùng nếu grid cho phép user thêm dòng
                if (dgvKho.AllowUserToAddRows)
                    tongSoLuong = dgvKho.Rows.Count - 1;
                else
                    tongSoLuong = dgvKho.Rows.Count;
            }

            lbTongMatHang.Text = "Tổng mặt hàng: " + tongSoLuong.ToString();

            // 2. TÍNH SỐ LƯỢNG CẢNH BÁO
            int soLuongCanhBao = 0;

            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["NgayHetHan"].Value != DBNull.Value && row.Cells["SoLuongTon"].Value != DBNull.Value)
                {
                    DateTime ngayHetHan = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                    int slTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value);

                    // Logic: Hết hạn (hoặc < 3 tháng) HOẶC Tồn kho < 10
                    bool sapHetHan = ngayHetHan <= DateTime.Now.AddDays(90);
                    bool sapHetHang = slTon < 10;

                    if (sapHetHan || sapHetHang)
                    {
                        soLuongCanhBao++;
                        // Tô màu đỏ nhạt để báo động
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }
                    else
                    {
                        // Trả lại màu trắng
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }
            }

            if (soLuongCanhBao > 0)
            {
                lbCanhBao.Text = "Cảnh báo: " + soLuongCanhBao.ToString();
                lbCanhBao.ForeColor = System.Drawing.Color.Red; // Chữ màu đỏ nếu có cảnh báo
                lbCanhBao.Font = new System.Drawing.Font(lbCanhBao.Font, System.Drawing.FontStyle.Bold); // In đậm
            }
            else
            {
                lbCanhBao.Text = "Cảnh báo: 0";
                lbCanhBao.ForeColor = System.Drawing.Color.Green; // Màu xanh nếu an toàn
                lbCanhBao.Font = new System.Drawing.Font(lbCanhBao.Font, System.Drawing.FontStyle.Regular);
            }
        }

        private void btNhapMoi_Click(object sender, EventArgs e)
        {
            // Tạo các cột ComboBox để chọn (Thuốc, Quầy) nếu chưa có
            TaoCotNhapLieu();

            // Di chuyển con trỏ xuống dòng mới dưới cùng để nhập ngay
            if (dgvKho.RowCount > 0)
            {
                // Focus vào dòng cuối (dòng mới)
                dgvKho.CurrentCell = dgvKho.Rows[dgvKho.RowCount - 1].Cells["cbxTenThuoc"];
                dgvKho.BeginEdit(true);
            }
        }
        private void TaoCotNhapLieu()
        {
            // Kiểm tra nếu đã tạo cột rồi thì không tạo lại
            if (dgvKho.Columns["cbxTenThuoc"] != null) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // --- A. Tạo cột ComboBox chọn Thuốc ---
                DataGridViewComboBoxColumn colThuoc = new DataGridViewComboBoxColumn();
                colThuoc.HeaderText = "Chọn Thuốc (Nhập Mới)";
                colThuoc.Name = "cbxTenThuoc";
                colThuoc.DataPropertyName = "MaThuoc"; // Liên kết với dữ liệu nếu cần

                // Lấy danh sách thuốc
                SqlDataAdapter daThuoc = new SqlDataAdapter("SELECT MaThuoc, TenThuoc FROM Thuoc", conn);
                DataTable dtThuoc = new DataTable();
                daThuoc.Fill(dtThuoc);

                colThuoc.DataSource = dtThuoc;
                colThuoc.DisplayMember = "TenThuoc"; // Hiển thị tên
                colThuoc.ValueMember = "MaThuoc";   // Lưu mã
                colThuoc.Width = 200;

                // Thêm vào Grid (vị trí đầu tiên)
                dgvKho.Columns.Insert(0, colThuoc);


                // --- B. Tạo cột ComboBox chọn Quầy ---
                DataGridViewComboBoxColumn colQuay = new DataGridViewComboBoxColumn();
                colQuay.HeaderText = "Chọn Vị Trí";
                colQuay.Name = "cbxQuay";

                SqlDataAdapter daQuay = new SqlDataAdapter("SELECT MaQuayThuoc, TenQuay FROM QuayThuoc", conn);
                DataTable dtQuay = new DataTable();
                daQuay.Fill(dtQuay);

                colQuay.DataSource = dtQuay;
                colQuay.DisplayMember = "TenQuay";
                colQuay.ValueMember = "MaQuayThuoc";

                dgvKho.Columns.Insert(3, colQuay); // Chèn vào sau các cột thông tin thuốc
            }

            // Ẩn các cột Text cũ (chỉ để xem) để tránh nhầm lẫn khi nhập
            if (dgvKho.Columns["TenThuoc"] != null) dgvKho.Columns["TenThuoc"].Visible = false;
            if (dgvKho.Columns["TenQuay"] != null) dgvKho.Columns["TenQuay"].Visible = false;

            // Set cột Mã Lô là ReadOnly (vì tự tăng hoặc chưa có)
            if (dgvKho.Columns["MaTonKho"] != null) dgvKho.Columns["MaTonKho"].ReadOnly = true;
        }
        
        private void btLuu_Click(object sender, EventArgs e)
        {
            // 1. Xác nhận dữ liệu đang nhập dở
            dgvKho.EndEdit();

            int soDongDaLuu = 0;
            int soDongLoi = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 2. Duyệt qua từng dòng trong Grid
                    foreach (DataGridViewRow row in dgvKho.Rows)
                    {
                        // Bỏ qua dòng trống cuối cùng (dòng chờ nhập)
                        if (row.IsNewRow) continue;

                        // 3. Kiểm tra: Chỉ lưu những dòng CHƯA CÓ ID (MaTonKho)
                        var cellMa = row.Cells["MaTonKho"].Value;
                        bool laDongMoi = (cellMa == null || string.IsNullOrEmpty(cellMa.ToString()) || cellMa.ToString() == "0");

                        if (laDongMoi)
                        {
                            // Lấy dữ liệu từ các cột
                            var maThuoc = row.Cells["cbxTenThuoc"].Value;
                            var maQuay = row.Cells["cbxQuay"].Value;
                            var slTon = row.Cells["SoLuongTon"].Value;
                            var ngayHetHan = row.Cells["NgayHetHan"].Value;

                            // Validate: Nếu chưa chọn thuốc hoặc quầy thì bỏ qua
                            if (maThuoc == null || maQuay == null)
                            {
                                soDongLoi++;
                                continue;
                            }

                            // 4. Thực hiện Insert
                            string query = @"INSERT INTO TonKhoThuoc (MaThuoc, MaQuayThuoc, SoLuongTon, NgayHetHan, NgayNhap) 
                                     VALUES (@MaThuoc, @MaQuay, @SL, @NgayHH, GETDATE());
                                     SELECT SCOPE_IDENTITY();"; // Lấy ID vừa sinh ra

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);
                                cmd.Parameters.AddWithValue("@MaQuay", maQuay);
                                cmd.Parameters.AddWithValue("@SL", slTon ?? 0);
                                cmd.Parameters.AddWithValue("@NgayHH", ngayHetHan ?? DateTime.Now.AddYears(1));

                                // Thực thi và lấy ID mới
                                object newID = cmd.ExecuteScalar();

                                // 5. QUAN TRỌNG: Gán ID mới ngược lại vào Grid
                                // Để hệ thống biết dòng này đã được lưu rồi
                                row.Cells["MaTonKho"].Value = newID;

                                // Đổi màu dòng để báo hiệu thành công
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                                soDongDaLuu++;
                            }
                        }
                    }

                    // 6. Cập nhật lại thống kê sau khi lưu xong
                    CapNhatThongKe();

                    // Thông báo kết quả
                    if (soDongDaLuu > 0)
                    {
                        MessageBox.Show($"Đã lưu thành công {soDongDaLuu} mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (soDongLoi > 0)
                    {
                        MessageBox.Show($"Có {soDongLoi} dòng chưa chọn đủ thông tin (Thuốc/Vị trí).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu mới để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
        
  
