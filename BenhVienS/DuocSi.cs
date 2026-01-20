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
        // Khai báo biến để lưu nút đang được chọn (để đổi màu)
        private Button currentBtn;
        private Panel leftBorderBtn; // Cái vạch màu bên cạnh nút khi active
        private List<Control> _defaultPanelControls;
        public DuocSi()
        {
            InitializeComponent();
            _defaultPanelControls = panelBody.Controls.Cast<Control>().ToList();
            btTongquan.Click += btTongquan_Click;

            // Tạo cái vạch trang trí bên trái nút (nếu thích)
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60); // Kích thước vạch
            panelMenu.Controls.Add(leftBorderBtn); // Thêm vào panelMenu (bạn nhớ đặt tên panel chứa menu là panelMenu nhé)

        }

        private void DuocSi_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();

        }

        private void showControl(Control control)
        {

            panelBody.Controls.Clear();


            control.Dock = DockStyle.Fill;


            panelBody.Controls.Add(control);
        }
        private void RestorePanelThongTin()
        {
            // Remove any runtime control(s)
            panelBody.Controls.Clear();

            // Re-add the original controls in the same order they were captured.
            // Controls keep their properties (Location, Dock, Size, etc.), so they will appear as designed.
            foreach (var ctrl in _defaultPanelControls)
            {
                panelBody.Controls.Add(ctrl);
            }
        }
        // --- HÀM 1: Đổi màu nút khi được bấm (Hiệu ứng Active) ---
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton(); // Trả các nút khác về màu thường

                // Chỉnh màu nút được chọn
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81); // Màu đậm hơn chút để biết đang chọn
                currentBtn.ForeColor = Color.White;

                // Hiệu ứng vạch màu bên trái (Giống các app hiện đại)
                leftBorderBtn.BackColor = Color.Orange; // Hoặc màu xanh tùy bạn
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        // --- HÀM 2: Trả lại màu cũ cho nút không được chọn ---
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                // Màu nền mặc định của menu (bạn xem mã màu RGB bên design là bao nhiêu thì điền vào đây)
                // Ví dụ màu xanh menu của bạn là: 
                currentBtn.BackColor = Color.SteelBlue; // SỬA LẠI MÀU NÀY CHO TRÙNG MÀU MENU CỦA BẠN
                currentBtn.ForeColor = Color.White;
            }
        }

        // --- HÀM 3: Mở UserControl vào PanelBody (QUAN TRỌNG NHẤT) ---
        private void OpenChildControl(UserControl childControl)
        {
            // Xóa hết các control đang hiển thị cũ
            panelBody.Controls.Clear();

            // Cấu hình control mới
            childControl.Dock = DockStyle.Fill; // Lấp đầy panel
            childControl.BringToFront();

            // Thêm vào panel
            panelBody.Controls.Add(childControl);
        }
        private void btTongquan_Click(object sender, EventArgs e)
        {
            RestorePanelThongTin();
        }
        private void btDMT_Click(object sender, EventArgs e)
        {
            ucDanhMucThuoc uc = new ucDanhMucThuoc();
            showControl(uc);
        }
        private void btQLDT_Click(object sender, EventArgs e)
        {
            ucQuanLyDonThuoc uc = new ucQuanLyDonThuoc();
            showControl(uc);
        }
        private void btDSNT_Click(object sender, EventArgs e)
        {
            ucDanhSachNhapThuoc uc = new ucDanhSachNhapThuoc();
            showControl(uc);
        }

        private void btcaidat_Click(object sender, EventArgs e)
        {
            ucCD uc = new ucCD();
            showControl(uc);
        }

        private void LoadDashboardStats()
        {
            string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // --- 1. CẬP NHẬT CÁC THẺ THỐNG KÊ (CARDS) ---

                    // Đơn thuốc chờ xử lý 
                    string sqlDonChoStats = "SELECT COUNT(*) FROM DonThuoc WHERE TrangThai = N'ChuaLay'";
                    SqlCommand cmd1 = new SqlCommand(sqlDonChoStats, conn);
                    lbDonThuocChoXuLy.Text = cmd1.ExecuteScalar().ToString();

                    // Thuốc sắp hết hạn (trong vòng 3 tháng tới)
                    string sqlHetHanStats = "SELECT COUNT(*) FROM TonKhoThuoc WHERE NgayHetHan <= DATEADD(month, 3, GETDATE())";
                    SqlCommand cmd2 = new SqlCommand(sqlHetHanStats, conn);
                    lbThuocSapHetHan.Text = cmd2.ExecuteScalar().ToString();

                    // Thuốc sắp hết hàng (số lượng tồn dưới 10)
                    string sqlHetHangStats = "SELECT COUNT(*) FROM TonKhoThuoc WHERE SoLuongTon < 10";
                    SqlCommand cmd3 = new SqlCommand(sqlHetHangStats, conn);
                    lbThuocSapHetHang.Text = cmd3.ExecuteScalar().ToString();


                    // --- 2. ĐỔ DỮ LIỆU VÀO CÁC BẢNG (DATAGRIDVIEWS) ---

                    // Bảng: Đơn thuốc mới nhất (Chưa lấy thuốc)
                    string sqlDonThuocGrid = @"SELECT TOP 10 dt.MaDonThuoc, bn.HoTen AS TenBenhNhan, dt.NgayKeDon 
                           FROM DonThuoc dt 
                           JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                           JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                           JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                           WHERE dt.TrangThai = N'ChuaLay' 
                           ORDER BY dt.NgayKeDon DESC";

                    SqlDataAdapter da1 = new SqlDataAdapter(sqlDonThuocGrid, conn);
                    DataTable dtDonThuoc = new DataTable();
                    da1.Fill(dtDonThuoc);
                    dgvDonThuocMoiNhat.DataSource = dtDonThuoc;

                    // Use the actual column name returned by the query (TenBenhNhan), not "HoTen"
                    if (dgvDonThuocMoiNhat.Columns.Contains("MaDonThuoc"))
                        dgvDonThuocMoiNhat.Columns["MaDonThuoc"].HeaderText = "Mã Đơn Thuốc";
                    if (dgvDonThuocMoiNhat.Columns.Contains("TenBenhNhan"))
                        dgvDonThuocMoiNhat.Columns["TenBenhNhan"].HeaderText = "Họ Tên Bệnh Nhân";
                    if (dgvDonThuocMoiNhat.Columns.Contains("NgayKeDon"))
                        dgvDonThuocMoiNhat.Columns["NgayKeDon"].HeaderText = "Ngày Kê Đơn";

                    // Bảng: Thuốc sắp hết hàng
                    string sqlListHetHang = @"SELECT TOP 10 t.TenThuoc, tk.SoLuongTon, q.TenQuay 
                              FROM TonKhoThuoc tk 
                              JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc 
                              JOIN QuayThuoc q ON tk.MaQuayThuoc = q.MaQuayThuoc 
                              WHERE tk.SoLuongTon < 10 
                              ORDER BY tk.SoLuongTon ASC";
                    SqlDataAdapter da2 = new SqlDataAdapter(sqlListHetHang, conn);
                    DataTable dtHetHang = new DataTable();
                    da2.Fill(dtHetHang);
                    dgvThuocSapHetHang.DataSource = dtHetHang;

                    if (dgvThuocSapHetHang.Columns.Contains("TenThuoc"))
                        dgvThuocSapHetHang.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                    if (dgvThuocSapHetHang.Columns.Contains("SoLuongTon"))
                        dgvThuocSapHetHang.Columns["SoLuongTon"].HeaderText = "SL Tồn";
                    if (dgvThuocSapHetHang.Columns.Contains("TenQuay"))
                        dgvThuocSapHetHang.Columns["TenQuay"].HeaderText = "Tên Quầy";

                    // Bảng: Thuốc sắp hết hạn
                    string sqlListHetHan = @"SELECT TOP 10 t.TenThuoc, tk.NgayHetHan, tk.SoLuongTon 
                             FROM TonKhoThuoc tk 
                             JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc 
                             WHERE tk.NgayHetHan <= DATEADD(month, 3, GETDATE()) 
                             ORDER BY tk.NgayHetHan ASC";
                    SqlDataAdapter da3 = new SqlDataAdapter(sqlListHetHan, conn);
                    DataTable dtHetHan = new DataTable();
                    da3.Fill(dtHetHan);
                    dgvThuocSapHetHan.DataSource = dtHetHan;

                    if (dgvThuocSapHetHan.Columns.Contains("TenThuoc"))
                        dgvThuocSapHetHan.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                    if (dgvThuocSapHetHan.Columns.Contains("NgayHetHan"))
                        dgvThuocSapHetHan.Columns["NgayHetHan"].HeaderText = "Ngày Hết Hạn";
                    if (dgvThuocSapHetHan.Columns.Contains("SoLuongTon"))
                        dgvThuocSapHetHan.Columns["SoLuongTon"].HeaderText = "SL Tồn";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu tổng quan: " + ex.Message);
                }
            }
        }
    }
}
