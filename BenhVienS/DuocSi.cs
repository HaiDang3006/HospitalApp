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
    public partial class DuocSi : Form
    {
        private Button currentBtn;
        private Panel leftBorderBtn;
        private List<Control> _defaultPanelControls;

        public DuocSi()
        {
            InitializeComponent();
            _defaultPanelControls = panelBody.Controls.Cast<Control>().ToList();
        }

        private void DuocSi_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
        }

        #region UI Logic (Chuyển đổi màn hình)


        private void showControl(Control control)
        {
            panelBody.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelBody.Controls.Add(control);
        }

        private void RestorePanelThongTin()
        {
            panelBody.Controls.Clear();
            foreach (var ctrl in _defaultPanelControls)
            {
                panelBody.Controls.Add(ctrl);
            }
            LoadDashboardStats(); // Load lại số liệu khi quay về tổng quan
        }

        #endregion

        #region Sự kiện Click Menu

        private void btTongquan_Click(object sender, EventArgs e)
        {
            RestorePanelThongTin();
        }

        private void btDMT_Click(object sender, EventArgs e)
        {
            showControl(new ucDanhMucThuoc());
        }

        private void btQLDT_Click(object sender, EventArgs e)
        {
            showControl(new ucQuanLyDonThuoc());
        }

        private void btDSNT_Click(object sender, EventArgs e)
        {
            showControl(new ucDanhSachNhapThuoc());
        }

        private void btcaidat_Click(object sender, EventArgs e)
        {
            showControl(new ucCD());
        }

        #endregion

        #region Database Logic (Thống kê)

        private void LoadDashboardStats()
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Thống kê số lượng (Cards)
                    lbDonThuocChoXuLy.Text = GetScalar(conn, "SELECT COUNT(*) FROM DonThuoc WHERE TrangThai = N'ChuaLay'");
                    lbThuocSapHetHan.Text = GetScalar(conn, "SELECT COUNT(*) FROM TonKhoThuoc WHERE NgayHetHan <= DATEADD(month, 3, GETDATE())");
                    lbThuocSapHetHang.Text = GetScalar(conn, "SELECT COUNT(*) FROM TonKhoThuoc WHERE SoLuongTon < SoLuongToiThieu"); // Sửa logic theo cột SoLuongToiThieu

                    // 2. Đổ dữ liệu vào Grid: Đơn thuốc mới nhất (JOIN 4 bảng để lấy tên bệnh nhân)
                    string sqlDonThuoc = @"SELECT TOP 10 dt.MaDonThuoc, nd.HoTen AS TenBenhNhan, dt.NgayKeDon 
                                           FROM DonThuoc dt 
                                           INNER JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                                           INNER JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                                           INNER JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                                           INNER JOIN NguoiDung nd ON bn.MaNguoiDung = nd.MaNguoiDung
                                           WHERE dt.TrangThai = N'ChuaLay' 
                                           ORDER BY dt.NgayKeDon DESC";
                    FillDataGrid(dgvDonThuocMoiNhat, sqlDonThuoc, conn);

                    // 3. Đổ dữ liệu vào Grid: Thuốc sắp hết hàng
                    string sqlHetHang = @"SELECT TOP 10 t.TenThuoc, tk.SoLuongTon, q.TenQuay 
                                          FROM TonKhoThuoc tk 
                                          JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc 
                                          JOIN QuayThuoc q ON tk.MaQuayThuoc = q.MaQuayThuoc 
                                          WHERE tk.SoLuongTon < tk.SoLuongToiThieu
                                          ORDER BY tk.SoLuongTon ASC";
                    FillDataGrid(dgvThuocSapHetHang, sqlHetHang, conn); // Chú ý kiểm tra ID dgv trong Design

                    // 4. Đổ dữ liệu vào Grid: Thuốc sắp hết hạn
                    string sqlHetHan = @"SELECT TOP 10 t.TenThuoc, tk.NgayHetHan, tk.SoLuongTon 
                                         FROM TonKhoThuoc tk 
                                         JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc 
                                         WHERE tk.NgayHetHan <= DATEADD(month, 3, GETDATE()) 
                                         ORDER BY tk.NgayHetHan ASC";
                    // Giả sử bạn có thêm 1 grid nữa là dgvDSHetHan, nếu không hãy điều chỉnh tên
                    FillDataGrid(dgvThuocSapHetHan, sqlHetHan, conn);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm phụ trợ để lấy 1 giá trị duy nhất
        private string GetScalar(SqlConnection conn, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "0";
            }
        }

        // Hàm phụ trợ để điền dữ liệu vào Grid
        private void FillDataGrid(DataGridView dgv, string query, SqlConnection conn)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                da.Fill(dt);
            }
            dgv.DataSource = dt;

            // Tự động chỉnh tiêu đề cột nếu có dữ liệu
            if (dgv.Columns.Contains("TenBenhNhan")) dgv.Columns["TenBenhNhan"].HeaderText = "Bệnh Nhân";
            if (dgv.Columns.Contains("TenThuoc")) dgv.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
            if (dgv.Columns.Contains("SoLuongTon")) dgv.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
        }

        #endregion
    }
}
