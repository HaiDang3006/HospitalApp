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
    public partial class ucQuanLyDonThuoc : UserControl
    {
        private int maDuocSi = 5;       // Giả sử ID Dược sĩ đang đăng nhập là 5
        private int maQuayHienTai = 1;
        public ucQuanLyDonThuoc()
        {
            InitializeComponent();
            dgvDonThuoc.CellClick += dgvDonThuoc_CellClick;
        }
        private void dgvDonThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        string connectionString = "Server=localhost\\SQLEXPRESS02;Initial Catalog=BenhVienV1;Integrated Security=True";
        public void LoadData()
        {
            // Kiểm tra xem người dùng có click vào dòng hợp lệ không (tránh click vào header)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại đang chọn
                DataGridViewRow row = dgvDonThuoc.Rows[e.RowIndex];

                // Lấy MaDonThuoc từ cột đầu tiên (hoặc tên cột "MaDonThuoc")
                // Lưu ý: Đảm bảo cột 0 là Mã đơn, nếu không hãy thay bằng row.Cells["TenCotMaDon"].Value
                int maDonThuoc = Convert.ToInt32(row.Cells[0].Value);

                // Gọi hàm hiển thị chi tiết
                HienThiChiTietDonThuoc(maDonThuoc);
            }
        }

        private void HienThiChiTietDonThuoc(int maDonThuoc)
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();

                    // --- BƯỚC 1: LẤY THÔNG TIN CHUNG (Tên BN, Tên BS) ---
                    string queryInfo = @"
                SELECT 
                    DT.MaDonThuoc,
                    ND_BN.HoTen AS TenBenhNhan,
                    ND_BS.HoTen AS TenBacSi
                FROM DonThuoc DT
                JOIN PhieuKham PK ON DT.MaPhieuKham = PK.MaPhieuKham
                JOIN LichHen LH ON PK.MaLichHen = LH.MaLichHen
                JOIN BenhNhan BN ON LH.MaBenhNhan = BN.MaBenhNhan
                JOIN NguoiDung ND_BN ON BN.MaNguoiDung = ND_BN.MaNguoiDung
                JOIN BacSi BS ON DT.MaBacSi = BS.MaBacSi
                JOIN NguoiDung ND_BS ON BS.MaNguoiDung = ND_BS.MaNguoiDung
                WHERE DT.MaDonThuoc = @MaDonThuoc";

                    SqlCommand cmdInfo = new SqlCommand(queryInfo, conn);
                    cmdInfo.Parameters.AddWithValue("@MaDonThuoc", maDonThuoc);

                    SqlDataReader reader = cmdInfo.ExecuteReader();
                    if (reader.Read())
                    {
                        // --- SỬA Ở ĐÂY: Thêm chuỗi tiêu đề vào trước dữ liệu ---
                        lbMaDon.Text = "Mã Đơn: " + reader["MaDonThuoc"].ToString();
                        lbBenhNhan.Text = "Tên Bệnh Nhân: " + reader["TenBenhNhan"].ToString();
                        lbBacSi.Text = "Tên Bác Sĩ: " + reader["TenBacSi"].ToString();
                    }
                    reader.Close();

                    // --- BƯỚC 2: LẤY DANH SÁCH THUỐC ĐỔ VÀO GRID BÊN PHẢI ---
                    string queryThuoc = @"
                SELECT 
                    T.TenThuoc AS [Tên Thuốc],
                    CT.SoLuong AS [SL],
                    T.DonViTinh AS [ĐVT],
                    CT.CachDung AS [Cách Dùng],
                    FORMAT(CT.DonGia, '#,##0') AS [Đơn Giá],
                    FORMAT(CT.ThanhTien, '#,##0') AS [Thành Tiền]
                FROM ChiTietDonThuoc CT
                JOIN Thuoc T ON CT.MaThuoc = T.MaThuoc
                WHERE CT.MaDonThuoc = @MaDonThuoc";

                    SqlDataAdapter da = new SqlDataAdapter(queryThuoc, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaDonThuoc", maDonThuoc);

                    DataTable dtChiTiet = new DataTable();
                    da.Fill(dtChiTiet);

                    dgvChiTietDonThuoc.DataSource = dtChiTiet;

                    // --- BƯỚC 3: TÍNH TỔNG TIỀN ---
                    decimal tongTien = 0;
                    string queryTong = "SELECT SUM(ThanhTien) FROM ChiTietDonThuoc WHERE MaDonThuoc = @MaDonThuoc";
                    SqlCommand cmdTong = new SqlCommand(queryTong, conn);
                    cmdTong.Parameters.AddWithValue("@MaDonThuoc", maDonThuoc);

                    object result = cmdTong.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        tongTien = Convert.ToDecimal(result);
                    }

                    // Cũng thêm tiêu đề cho tổng tiền nếu cần
                    lbTongTien.Text = "Tổng Tiền: " + string.Format("{0:#,##0} VNĐ", tongTien);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải chi tiết: " + ex.Message);
                }
            }
        }
        private void ucQuanLyDonThuoc_Load(object sender, EventArgs e)
        {
            LoadDanhSachDonThuoc();
            SetupGridAppearance();
        }

        #region 1. Tải Danh Sách Đơn Thuốc (Master)
        private void LoadDanhSachDonThuoc()
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    // JOIN qua nhiều bảng để lấy Họ tên Bệnh nhân và Bác sĩ từ bảng NguoiDung
                    string query = @"
                        SELECT 
                            dt.MaDonThuoc, 
                            ndBN.HoTen AS TenBenhNhan, 
                            ndBS.HoTen AS TenBacSi, 
                            dt.NgayKeDon, 
                            dt.TrangThai, 
                            dt.MaPhieuKham
                        FROM DonThuoc dt
                        INNER JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                        INNER JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                        INNER JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                        INNER JOIN NguoiDung ndBN ON bn.MaNguoiDung = ndBN.MaNguoiDung
                        INNER JOIN BacSi bs ON dt.MaBacSi = bs.MaBacSi
                        INNER JOIN NguoiDung ndBS ON bs.MaNguoiDung = ndBS.MaNguoiDung
                        ORDER BY 
                            CASE WHEN dt.TrangThai = N'ChuaLay' THEN 0 ELSE 1 END, 
                            dt.NgayKeDon DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDonThuoc.DataSource = dt;

                    // Định dạng tiêu đề cột
                    if (dgvDonThuoc.Columns.Contains("MaDonThuoc")) dgvDonThuoc.Columns["MaDonThuoc"].HeaderText = "Mã Đơn";
                    if (dgvDonThuoc.Columns.Contains("TenBenhNhan")) dgvDonThuoc.Columns["TenBenhNhan"].HeaderText = "Bệnh Nhân";
                    if (dgvDonThuoc.Columns.Contains("TenBacSi")) dgvDonThuoc.Columns["TenBacSi"].HeaderText = "Bác Sĩ";
                    if (dgvDonThuoc.Columns.Contains("NgayKeDon")) dgvDonThuoc.Columns["NgayKeDon"].HeaderText = "Ngày Kê";
                    if (dgvDonThuoc.Columns.Contains("TrangThai")) dgvDonThuoc.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    if (dgvDonThuoc.Columns.Contains("MaPhieuKham")) dgvDonThuoc.Columns["MaPhieuKham"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

     

        #region 3. Xác Nhận Xuất Thuốc (Transaction & Inventory)
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (dgvDonThuoc.CurrentRow == null) return;

            int maDon = Convert.ToInt32(dgvDonThuoc.CurrentRow.Cells["MaDonThuoc"].Value);
            string trangThai = dgvDonThuoc.CurrentRow.Cells["TrangThai"].Value.ToString();

            // Kiểm tra trạng thái dựa trên CHECK CONSTRAINT của SQL ('ChuaLay', 'DaNhan',...)
            if (trangThai == "DaNhan")
            {
                MessageBox.Show("Đơn thuốc này đã hoàn tất xuất thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận xuất thuốc cho đơn này và trừ tồn kho?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Chèn vào bảng XuatThuoc (Theo Schema: MaDonThuoc, MaDuocSi, MaQuayThuoc, NgayXuat, TrangThai)
                    string sqlXuat = @"
                        INSERT INTO XuatThuoc (MaDonThuoc, MaDuocSi, MaQuayThuoc, NgayXuat, TrangThai) 
                        VALUES (@MaDon, @MaDS, @MaQuay, GETDATE(), 'DaXuat')";

                    SqlCommand cmdXuat = new SqlCommand(sqlXuat, conn, trans);
                    cmdXuat.Parameters.AddWithValue("@MaDon", maDon);
                    cmdXuat.Parameters.AddWithValue("@MaDS", maDuocSi);
                    cmdXuat.Parameters.AddWithValue("@MaQuay", maQuayHienTai);
                    cmdXuat.ExecuteNonQuery();

                    // 2. Trừ tồn kho trong bảng TonKhoThuoc
                    // Sử dụng INNER JOIN để trừ số lượng cho tất cả thuốc có trong đơn thuốc này tại Quầy tương ứng
                    string sqlUpdateKho = @"
                        UPDATE tk
                        SET tk.SoLuongTon = tk.SoLuongTon - ct.SoLuong
                        FROM TonKhoThuoc tk
                        INNER JOIN ChiTietDonThuoc ct ON tk.MaThuoc = ct.MaThuoc
                        WHERE ct.MaDonThuoc = @MaDon AND tk.MaQuayThuoc = @MaQuay";

                    SqlCommand cmdKho = new SqlCommand(sqlUpdateKho, conn, trans);
                    cmdKho.Parameters.AddWithValue("@MaDon", maDon);
                    cmdKho.Parameters.AddWithValue("@MaQuay", maQuayHienTai);
                    cmdKho.ExecuteNonQuery();

                    // 3. Cập nhật trạng thái đơn thuốc sang 'DaNhan' (Khớp với CHECK CONSTRAINT SQL)
                    string sqlDon = "UPDATE DonThuoc SET TrangThai = 'DaNhan' WHERE MaDonThuoc = @MaDon";
                    SqlCommand cmdDon = new SqlCommand(sqlDon, conn, trans);
                    cmdDon.Parameters.AddWithValue("@MaDon", maDon);
                    cmdDon.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Xuất thuốc và cập nhật kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDanhSachDonThuoc(); // Refresh danh sách
                    dgvChiTietDonThuoc.DataSource = null; // Clear chi tiết sau khi xong
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi quy trình xuất thuốc: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void SetupGridAppearance()
        {
            dgvDonThuoc.ReadOnly = true;
            dgvDonThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvChiTietDonThuoc.ReadOnly = true;
            dgvChiTietDonThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ngăn chặn người dùng thêm dòng trực tiếp trên lưới
            dgvDonThuoc.AllowUserToAddRows = false;
            dgvChiTietDonThuoc.AllowUserToAddRows = false;
        }

        private void dgvChiTietDonThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}