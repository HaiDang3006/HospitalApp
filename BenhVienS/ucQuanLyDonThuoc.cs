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
        // Chuỗi kết nối
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENV1;Trusted_Connection=True;TrustServerCertificate=True;";

        // Giả định các thông số này được truyền từ Form Đăng nhập
        private int maDuocSiHienTai = 1;
        private int maQuayHienTai = 1;

        public ucQuanLyDonThuoc()
        {
            InitializeComponent();
        }

        private void ucQuanLyDonThuoc_Load(object sender, EventArgs e)
        {
            LoadDanhSachDonThuoc();
            SetupGridAppearance();
        }

        #region 1. Tải Danh Sách Đơn Thuốc (Master)
        private void LoadDanhSachDonThuoc()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
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

        #region 2. Tải Chi Tiết Đơn Thuốc (Detail)
        // Thay vì dùng CellContentClick, dùng CellClick để chính xác hơn khi chọn dòng
        private void dgvDonThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonThuoc.Rows[e.RowIndex];
                int maDon = Convert.ToInt32(row.Cells["MaDonThuoc"].Value);

                // Cập nhật thông tin hiển thị nhanh
                lbMaDon.Text = "Mã Đơn: " + maDon.ToString();
                lbBenhNhan.Text = "BN: " + row.Cells["TenBenhNhan"].Value.ToString();

                LoadChiTietDonThuoc(maDon);
            }
        }

        private void LoadChiTietDonThuoc(int maDon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"
                        SELECT t.TenThuoc, ct.SoLuong, t.DonViTinh, ct.DonGia, ct.ThanhTien, ct.CachDung
                        FROM ChiTietDonThuoc ct
                        INNER JOIN Thuoc t ON ct.MaThuoc = t.MaThuoc
                        WHERE ct.MaDonThuoc = @MaDon";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaDon", maDon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvChiTietDonThuoc.DataSource = dt;

                    // Tính tổng tiền đơn thuốc
                    decimal tongTien = 0;
                    foreach (DataRow row in dt.Rows)
                        tongTien += Convert.ToDecimal(row["ThanhTien"]);

                    lbTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải chi tiết: " + ex.Message); }
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

            using (SqlConnection conn = new SqlConnection(connectionString))
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
                    cmdXuat.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
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
    }
}