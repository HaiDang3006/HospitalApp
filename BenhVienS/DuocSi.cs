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
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";
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
        public void LoadDashboardStats()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Tổng số loại thuốc
                    string queryTotal = "SELECT COUNT(*) FROM Thuoc";
                    SqlCommand cmd1 = new SqlCommand(queryTotal, conn);
                    lbTongSoThuoc.Text = cmd1.ExecuteScalar().ToString();

                    // 2. Thuốc sắp hết hạn (trong vòng 30 ngày)
                    string queryExpiry = "SELECT COUNT(*) FROM Thuoc WHERE HanSuDung <= DATEADD(day, 30, GETDATE())";
                    SqlCommand cmd2 = new SqlCommand(queryExpiry, conn);
                    lbThuocSapHetHan.Text = cmd2.ExecuteScalar().ToString();

                    // 3. Thuốc sắp hết hàng (Số lượng tồn < 10)
                    string queryStock = "SELECT COUNT(*) FROM TonKhoThuoc WHERE SoLuongTon < 10";
                    SqlCommand cmd3 = new SqlCommand(queryStock, conn);
                    lbThuocSapHetHang.Text = cmd3.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }
        public void LoadAllData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Danh Mục Thuốc (Bảng bên trái - Trên)
                    // Lấy dữ liệu từ bảng Thuoc
                    string sqlDanhMuc = "SELECT MaThuoc, TenThuoc, HoatChat, DonViTinh, GiaBan FROM Thuoc";
                    SqlDataAdapter da1 = new SqlDataAdapter(sqlDanhMuc, conn);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dgvDanhMucThuoc.DataSource = dt1;

                    // 2. Thuốc Sắp Hết Hàng (Bảng bên phải - Trên)
                    // Liên kết bảng Thuoc và TonKhoThuoc để lấy số lượng tồn
                    string sqlSapHetHang = @"SELECT T.TenThuoc, TK.SoLuongTon, T.DonViTinh 
                                   FROM Thuoc T 
                                   JOIN TonKhoThuoc TK ON T.MaThuoc = TK.MaThuoc 
                                   WHERE TK.SoLuongTon < 10";
                    SqlDataAdapter da2 = new SqlDataAdapter(sqlSapHetHang, conn);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dgvThuocSapHetHang.DataSource = dt2;

                    // 3. Đơn Thuốc Gần Đây (Bảng bên trái - Dưới)
                    // Liên kết DonThuoc -> PhieuKham -> LichHen -> BenhNhan
                    string sqlDonThuoc = @"SELECT TOP 10 DT.MaDonThuoc, BN.HoTen, DT.NgayKeDon, DT.TrangThai 
                                 FROM DonThuoc DT 
                                 JOIN PhieuKham PK ON DT.MaPhieuKham = PK.MaPhieuKham 
                                 JOIN LichHen LH ON PK.MaLichHen = LH.MaLichHen 
                                 JOIN BenhNhan BN ON LH.MaBenhNhan = BN.MaBenhNhan 
                                 ORDER BY DT.NgayKeDon DESC";
                    SqlDataAdapter da3 = new SqlDataAdapter(sqlDonThuoc, conn);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dgvDonThuocGanDay.DataSource = dt3;

                    // 4. Thuốc Sắp Hết Hạn (Bảng bên phải - Dưới)
                    // Lọc các thuốc có HanSuDung trong vòng 30 ngày tới
                    string sqlSapHetHan = "SELECT TenThuoc, HanSuDung, LoaiThuoc FROM Thuoc WHERE HanSuDung <= DATEADD(day, 30, GETDATE())";
                    SqlDataAdapter da4 = new SqlDataAdapter(sqlSapHetHan, conn);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    dgvThuocSapHetHan.DataSource = dt4;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
    }
}

