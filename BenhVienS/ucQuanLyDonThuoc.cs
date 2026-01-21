using System;
using System.Collections;
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
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENV1;Trusted_Connection=True;TrustServerCertificate=True;";

        // Giả sử Dược sĩ đang trực tại Quầy số 1
        private int maQuayHienTai = 1;
        // Mã dược sĩ đang đăng nhập (nên truyền từ Form chính vào)
        private int maDuocSiHienTai = 1;

        public ucQuanLyDonThuoc()
        {
            InitializeComponent();
        }

        private void ucQuanLyDonThuoc_Load(object sender, EventArgs e)
        {
            LoadDanhSachDonThuoc();
            SetupGridAppearance();
        }

        #region 1. Tải Danh Sách Đơn Thuốc
        private void LoadDanhSachDonThuoc()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // JOIN NguoiDung 2 lần: 1 cho Bác sĩ, 1 cho Bệnh nhân
                    string query = @"SELECT dt.MaDonThuoc, ndBN.HoTen AS TenBenhNhan, ndBS.HoTen AS TenBacSi, 
                                            dt.NgayKeDon, dt.TrangThai, dt.MaPhieuKham
                                     FROM DonThuoc dt
                                     INNER JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                                     INNER JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                                     INNER JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                                     INNER JOIN NguoiDung ndBN ON bn.MaNguoiDung = ndBN.MaNguoiDung
                                     INNER JOIN BacSi bs ON dt.MaBacSi = bs.MaBacSi
                                     INNER JOIN NguoiDung ndBS ON bs.MaNguoiDung = ndBS.MaNguoiDung
                                     ORDER BY CASE WHEN dt.TrangThai = N'ChuaLay' THEN 0 ELSE 1 END, dt.NgayKeDon DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDonThuoc.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải đơn thuốc: " + ex.Message); }
            }
        }
        #endregion

        #region 2. Tải Chi Tiết Đơn Thuốc
        private void dgvDonThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maDon = Convert.ToInt32(dgvDonThuoc.Rows[e.RowIndex].Cells["MaDonThuoc"].Value);
                lbMaDon.Text = "Mã Đơn: " + maDon.ToString();
                lbBenhNhan.Text = "BN: " + dgvDonThuoc.Rows[e.RowIndex].Cells["TenBenhNhan"].Value.ToString();

                LoadChiTietDonThuoc(maDon);
            }
        }

        private void LoadChiTietDonThuoc(int maDon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT t.TenThuoc, ct.SoLuong, t.DonViTinh, ct.DonGia, ct.ThanhTien
                                 FROM ChiTietDonThuoc ct
                                 INNER JOIN Thuoc t ON ct.MaThuoc = t.MaThuoc
                                 WHERE ct.MaDonThuoc = @MaDon";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaDon", maDon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChiTietDonThuoc.DataSource = dt;

                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows) tongTien += Convert.ToDecimal(row["ThanhTien"]);
                lbTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
            }
        }
        #endregion

        #region 3. Xác Nhận Xuất Thuốc (Sử dụng Transaction)
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (dgvDonThuoc.CurrentRow == null) return;

            int maDon = Convert.ToInt32(dgvDonThuoc.CurrentRow.Cells["MaDonThuoc"].Value);
            string trangThai = dgvDonThuoc.CurrentRow.Cells["TrangThai"].Value.ToString();

            // Kiểm tra trạng thái theo CHECK constraint của SQL
            if (trangThai == "DaNhan")
            {
                MessageBox.Show("Đơn thuốc này đã được bệnh nhân nhận!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Xác nhận xuất thuốc cho đơn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Ghi log vào bảng XuatThuoc (TrangThai mặc định là 'DaXuat')
                    string sqlXuat = @"INSERT INTO XuatThuoc (MaDonThuoc, MaDuocSi, MaQuayThuoc, NgayXuat, TrangThai) 
                                       VALUES (@MaDon, @MaDS, @MaQuay, GETDATE(), 'DaXuat')";
                    SqlCommand cmdXuat = new SqlCommand(sqlXuat, conn, trans);
                    cmdXuat.Parameters.AddWithValue("@MaDon", maDon);
                    cmdXuat.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
                    cmdXuat.Parameters.AddWithValue("@MaQuay", maQuayHienTai);
                    cmdXuat.ExecuteNonQuery();

                    // 2. Trừ tồn kho tại đúng quầy đang trực
                    // SQL sử dụng JOIN UPDATE để trừ tồn kho dựa trên danh sách thuốc trong đơn
                    string sqlUpdateKho = @"UPDATE tk
                                            SET tk.SoLuongTon = tk.SoLuongTon - ct.SoLuong
                                            FROM TonKhoThuoc tk
                                            INNER JOIN ChiTietDonThuoc ct ON tk.MaThuoc = ct.MaThuoc
                                            WHERE ct.MaDonThuoc = @MaDon AND tk.MaQuayThuoc = @MaQuay";

                    SqlCommand cmdKho = new SqlCommand(sqlUpdateKho, conn, trans);
                    cmdKho.Parameters.AddWithValue("@MaDon", maDon);
                    cmdKho.Parameters.AddWithValue("@MaQuay", maQuayHienTai);
                    cmdKho.ExecuteNonQuery();

                    // 3. Cập nhật trạng thái đơn thuốc sang 'DaNhan' (khớp với CHECK constraint)
                    string sqlDon = "UPDATE DonThuoc SET TrangThai = 'DaNhan' WHERE MaDonThuoc = @MaDon";
                    SqlCommand cmdDon = new SqlCommand(sqlDon, conn, trans);
                    cmdDon.Parameters.AddWithValue("@MaDon", maDon);
                    cmdDon.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Đã xuất thuốc và trừ kho thành công!", "Thành công");
                    LoadDanhSachDonThuoc();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi xuất thuốc: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (dgvDonThuoc.Columns["MaDonThuoc"] != null) dgvDonThuoc.Columns["MaDonThuoc"].HeaderText = "Mã Đơn";
            // ... Thêm các định dạng tiêu đề khác nếu cần
        }
    }
}