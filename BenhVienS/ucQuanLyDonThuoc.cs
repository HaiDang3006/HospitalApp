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
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";
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
                    // Truy vấn liên kết 5 bảng để lấy thông tin định danh
                    string query = @"SELECT dt.MaDonThuoc, bn.HoTen AS TenBenhNhan, nd.HoTen AS TenBacSi, 
                                     dt.NgayKeDon, dt.TrangThai, dt.MaPhieuKham
                                     FROM DonThuoc dt
                                     JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                                     JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                                     JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                                     JOIN BacSi bs ON dt.MaBacSi = bs.MaBacSi
                                     JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
                                     ORDER BY dt.NgayKeDon DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDonThuoc.DataSource = dt;

                    // Định dạng tiêu đề tiếng Việt
                    dgvDonThuoc.Columns["MaDonThuoc"].HeaderText = "Mã Đơn";
                    dgvDonThuoc.Columns["TenBenhNhan"].HeaderText = "Bệnh Nhân";
                    dgvDonThuoc.Columns["TenBacSi"].HeaderText = "Bác Sĩ Kê";
                    dgvDonThuoc.Columns["NgayKeDon"].HeaderText = "Ngày Kê Đơn";
                    dgvDonThuoc.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dgvDonThuoc.Columns["MaPhieuKham"].Visible = false; // Ẩn mã phiếu khám
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải đơn thuốc: " + ex.Message); }
            }
        }
        #endregion

        #region 2. Tải Chi Tiết Đơn Thuốc (Detail)
        private void dgvDonThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maDon = Convert.ToInt32(dgvDonThuoc.Rows[e.RowIndex].Cells["MaDonThuoc"].Value);

                // Hiển thị thông tin lên Label minh họa
                lbMaDon.Text = "Mã Phiếu: " + dgvDonThuoc.Rows[e.RowIndex].Cells["MaPhieuKham"].Value.ToString();
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
                                 JOIN Thuoc t ON ct.MaThuoc = t.MaThuoc
                                 WHERE ct.MaDonThuoc = @MaDon";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaDon", maDon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChiTietDonThuoc.DataSource = dt;

                // Tự động tính tổng tiền
                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows) tongTien += Convert.ToDecimal(row["ThanhTien"]);
                lbTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
            }
        }
        #endregion

        #region 3. Xác Nhận Xuất Thuốc (Transaction & Inventory)
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (dgvDonThuoc.CurrentRow == null) return;

            int maDon = Convert.ToInt32(dgvDonThuoc.CurrentRow.Cells["MaDonThuoc"].Value);
            string trangThai = dgvDonThuoc.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (trangThai == "DaLay")
            {
                MessageBox.Show("Đơn này đã được phát thuốc rồi!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Lưu vào bảng XuatThuoc
                    string sqlXuat = "INSERT INTO XuatThuoc (MaDonThuoc, MaDuocSi, MaQuayThuoc, NgayXuat) VALUES (@MaDon, 1, 1, GETDATE())";
                    SqlCommand cmdXuat = new SqlCommand(sqlXuat, conn, trans);
                    cmdXuat.Parameters.AddWithValue("@MaDon", maDon);
                    cmdXuat.ExecuteNonQuery();

                    // 2. Trừ tồn kho (Dựa trên MaThuoc trong ChiTietDonThuoc)
                    string sqlUpdateKho = @"UPDATE TonKhoThuoc 
                                            SET SoLuongTon = SoLuongTon - ct.SoLuong
                                            FROM TonKhoThuoc tk
                                            JOIN ChiTietDonThuoc ct ON tk.MaThuoc = ct.MaThuoc
                                            WHERE ct.MaDonThuoc = @MaDon AND tk.MaQuayThuoc = 1";
                    SqlCommand cmdKho = new SqlCommand(sqlUpdateKho, conn, trans);
                    cmdKho.Parameters.AddWithValue("@MaDon", maDon);
                    cmdKho.ExecuteNonQuery();

                    // 3. Cập nhật trạng thái đơn
                    string sqlDon = "UPDATE DonThuoc SET TrangThai = 'DaLay' WHERE MaDonThuoc = @MaDon";
                    SqlCommand cmdDon = new SqlCommand(sqlDon, conn, trans);
                    cmdDon.Parameters.AddWithValue("@MaDon", maDon);
                    cmdDon.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Xuất thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDonThuoc();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                }
            }
        }
            #endregion

        private void SetupGridAppearance()
        {
            dgvDonThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietDonThuoc.ReadOnly = true;
            dgvDonThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietDonThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
    }
