using BenhVienS.Models;
using BenhVienS.Service;
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
    public partial class Thungan : Form
    {
        public Thungan()
        {
            InitializeComponent();
            LoadDanhSachCard();
/*            HienThiHoaDonDayDu(cthoadon);
*/        }

        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }
        private void FrmThuNgan_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Thungan_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ttvphi uc = new ttvphi();
            ShowControl(uc);
        }

        // Add this method to show a UserControl in the form
        private void ShowControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(control);
            control.BringToFront();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            /*if (dgvChuaThuTien.CurrentRow == null)
            {
                MessageBox.Show("Chọn đơn thuốc cần xử lý!");
                return;
            }

            DataGridViewRow row = dgvChuaThuTien.CurrentRow;

            // Clone dòng
            int index = dgvCanXuLy.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dgvCanXuLy.Rows[index].Cells[i].Value = row.Cells[i].Value;
            }

            // Xóa khỏi bảng cũ
            dgvChuaThuTien.Rows.Remove(row);*/
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvChuaThuTien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




private void LoadDanhSachCard()
        {            
            panelView.Controls.Clear();
            panelView.AutoScroll = true;

            List<HoaDon> list = GetHoaDonPhieuKhamHoanThanh();

            if (list == null || list.Count == 0)
                        {
                            list = new List<HoaDon>()
                {
                    new HoaDon
                    {
                        MaBenhNhan = 1,
                        TenBenhNhan = "Nguyễn Văn A"
                    },
                    new HoaDon
                    {
                        MaBenhNhan = 2,
                        TenBenhNhan = "Trần Thị B"
                    },
                    new HoaDon
                    {
                        MaBenhNhan = 3,
                        TenBenhNhan = "Lê Văn C"
                    }
                };
                        }

            int y = 10;
            for (int i = 0; i < list.Count; i++)   
            {
                HoaDon hd = list[i];

                Panel card = TaoCard(
                   hd.TenBenhNhan,                
                    $"BN{hd.MaBenhNhan:D4}"
                );

                card.Location = new Point(10, y);
                panelView.Controls.Add(card);

                y += card.Height + 10;
            }
        }


public List<HoaDon> GetHoaDonPhieuKhamHoanThanh()
        {
            List<HoaDon> list = new List<HoaDon>();

            string sql = @"
                    SELECT 
                        pk.MaPhieuKham,
                        pk.NgayKham,
                        bn.MaBenhNhan,
                        nd.HoTen AS TenBenhNhan
                    FROM PhieuKham pk
                    JOIN HoSoBenhAn hs ON pk.MaPhieuKham = hs.MaPhieuKham
                    JOIN BenhNhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
                    LEFT JOIN NguoiDung nd ON bn.MaNguoiDung = nd.MaNguoiDung
                    LEFT JOIN HoaDon hd ON pk.MaPhieuKham = hd.MaPhieuKham
                    WHERE pk.TrangThai = N'HoanThanh'
                      AND hd.MaHoaDon IS NULL;
                ";

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDon hd = new HoaDon
                        {
                            MaHoaDon = reader.GetInt32(0),
                            NgayLap = reader.GetDateTime(1),
                            TongTien = reader.GetDecimal(2),
                            DaThanhToan = reader.GetBoolean(3),
                            TrangThaiHoaDon = reader.GetString(4),

                            MaPhieuKham = reader.GetInt32(5),
                            NgayKham = reader.GetDateTime(6),

                            MaBenhNhan = reader.GetInt32(7),
                            TenBenhNhan = reader.IsDBNull(8) ? "" : reader.GetString(8)
                        };

                        list.Add(hd);
                    }
                }
            }

            return list;
        }

       /* private string TaoHoacLayHoaDon(string maPhieuKham)
        {
            string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DB;Integrated Security=True"; // thay bằng chuỗi kết nối của bạn
            string maHoaDon = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra đã có hóa đơn chưa
                string queryCheck = @"SELECT MaHoaDon FROM HoaDon WHERE MaPhieuKham = @MaPhieuKham";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);
                    var result = cmdCheck.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString(); // đã có → trả về luôn
                    }
                }

                // Chưa có → tạo mới
                maHoaDon = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(10, 99); // cách tạo mã tạm, bạn có thể dùng IDENTITY hoặc sequence

                // Lấy tổng tiền dịch vụ
                decimal tongDichVu = 0;
                string qDichVu = @"
            SELECT SUM(ISNULL(pkd.SoLuong * dv.DonGia, 0))
            FROM PhieuKham_DichVu pkd
            INNER JOIN DichVu dv ON pkd.MaDichVu = dv.MaDichVu
            WHERE pkd.MaPhieuKham = @MaPhieuKham";
                using (SqlCommand cmdDV = new SqlCommand(qDichVu, conn))
                {
                    cmdDV.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);
                    var resDV = cmdDV.ExecuteScalar();
                    tongDichVu = resDV != DBNull.Value ? Convert.ToDecimal(resDV) : 0;
                }

                // Lấy tổng tiền thuốc (giả sử đơn thuốc gắn với MaPhieuKham, nếu có bảng DonThuoc riêng thì join thêm)
                decimal tongThuoc = 0;
                string qThuoc = @"
            SELECT SUM(ISNULL(ct.SoLuong * th.DonGia, 0))
            FROM ChiTietDonThuoc ct
            INNER JOIN Thuoc th ON ct.MaThuoc = th.MaThuoc
            WHERE ct.MaDonThuoc = @MaPhieuKham";  // sửa nếu MaDonThuoc khác
                using (SqlCommand cmdThuoc = new SqlCommand(qThuoc, conn))
                {
                    cmdThuoc.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);
                    var resThuoc = cmdThuoc.ExecuteScalar();
                    tongThuoc = resThuoc != DBNull.Value ? Convert.ToDecimal(resThuoc) : 0;
                }

                decimal tongTien = tongDichVu + tongThuoc;

                // Insert HoaDon
                string insertHD = @"
            INSERT INTO HoaDon (MaHoaDon, MaPhieuKham, NgayLap, TongTien, TrangThai)
            VALUES (@MaHoaDon, @MaPhieuKham, GETDATE(), @TongTien, 'S')";
                using (SqlCommand cmdInsert = new SqlCommand(insertHD, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdInsert.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);
                    cmdInsert.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdInsert.ExecuteNonQuery();
                }

                // Insert ChiTietHoaDon - Dịch vụ
                string insertCTDV = @"
            INSERT INTO ChiTietHoaDon (MaHoaDon, Loai, MaSP, TenSP, SoLuong, DonGia, ThanhTien)
            SELECT @MaHoaDon, 'D', pkd.MaDichVu, dv.TenDichVu, pkd.SoLuong, dv.DonGia, pkd.SoLuong * dv.DonGia
            FROM PhieuKham_DichVu pkd
            INNER JOIN DichVu dv ON pkd.MaDichVu = dv.MaDichVu
            WHERE pkd.MaPhieuKham = @MaPhieuKham";
                using (SqlCommand cmdCTDV = new SqlCommand(insertCTDV, conn))
                {
                    cmdCTDV.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdCTDV.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);
                    cmdCTDV.ExecuteNonQuery();
                }

                // Insert ChiTietHoaDon - Thuốc
                string insertCTThuoc = @"
            INSERT INTO ChiTietHoaDon (MaHoaDon, Loai, MaSP, TenSP, SoLuong, DonGia, ThanhTien)
            SELECT @MaHoaDon, 'T', ct.MaThuoc, th.TenThuoc, ct.SoLuong, th.DonGia, ct.SoLuong * th.DonGia
            FROM ChiTietDonThuoc ct
            INNER JOIN Thuoc th ON ct.MaThuoc = th.MaThuoc
            WHERE ct.MaDonThuoc = @MaPhieuKham";  // sửa nếu cần
                using (SqlCommand cmdCTThuoc = new SqlCommand(insertCTThuoc, conn))
                {
                    cmdCTThuoc.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdCTThuoc.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);
                    cmdCTThuoc.ExecuteNonQuery();
                }
            }

            return maHoaDon;
        }*/


        private void panelView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cthoadon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CapNhatTongTien(Label lblTong, DataGridView dgvThuoc, DataGridView dgvDV)
        {
            decimal tong = 10000000;

           /* // Tổng tiền thuốc
            foreach (DataGridViewRow row in dgvThuoc.Rows)
            {
                tong += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }

            // Tổng tiền dịch vụ
            foreach (DataGridViewRow row in dgvDV.Rows)
            {
                tong += Convert.ToDecimal(row.Cells["Gia"].Value);
            }*/

            lblTong.Text = $"TỔNG TIỀN: {tong:N0} VNĐ";
        }

        private void ThemThuoc(DataGridView dgv, string tenThuoc, int soLuong, decimal donGia)
        {
            decimal thanhTien = soLuong * donGia;
            dgv.Rows.Add(tenThuoc, soLuong, donGia, thanhTien);
        }




        private void HienThiHoaDonDayDu(Panel cthoadon)
        {
            cthoadon.Controls.Clear();
            cthoadon.AutoScroll = true;
            cthoadon.Padding = new Padding(20);
            cthoadon.BackColor = Color.FromArgb(245, 245, 245);

            // Header
            Panel header = TaoHeader("Nguyễn Văn A", "BN001");
            cthoadon.Controls.Add(header);

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 245, 245);

            int yPos = 10;

            // Dịch vụ
            Panel dvPanel = TaoSectionDichVu(yPos);
            TaoItemDichVu(dvPanel, "Khám tổng quát", 150000, ref yPos);
            TaoItemDichVu(dvPanel, "Xét nghiệm máu", 100000, ref yPos);
            TaoItemDichVu(dvPanel, "Chụp X-Quang", 100000, ref yPos);
            contentPanel.Controls.Add(dvPanel);

            yPos += 20;

            // Đơn thuốc
            Panel thuocPanel = TaoSectionDonThuoc(yPos);
            TaoItemThuoc(thuocPanel, "Paracetamol 500mg", "2 hộp", 40000, ref yPos);
            TaoItemThuoc(thuocPanel, "Amoxicillin 500mg", "1 hộp", 80000, ref yPos);
            contentPanel.Controls.Add(thuocPanel);

            yPos += 20;

            // Tổng kết
            Panel tongKet = TaoSectionTongKet(350000, 120000, yPos);
            contentPanel.Controls.Add(tongKet);

            cthoadon.Controls.Add(contentPanel);
        }

        // Gọi hàm này để hiển thị chỉ có dịch vụ (không có thuốc)
        private void HienThiHoaDonChiDichVu(Panel cthoadon)
        {
            cthoadon.Controls.Clear();
            cthoadon.AutoScroll = true;
            cthoadon.Padding = new Padding(20);
            cthoadon.BackColor = Color.FromArgb(245, 245, 245);

            Panel header = TaoHeader("Trần Thị B", "BN002");
            cthoadon.Controls.Add(header);

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 245, 245);

            int yPos = 10;

            Panel dvPanel = TaoSectionDichVu(yPos);
            TaoItemDichVu(dvPanel, "Khám chuyên khoa tim mạch", 200000, ref yPos);
            TaoItemDichVu(dvPanel, "Siêu âm tim", 300000, ref yPos);
            TaoItemDichVu(dvPanel, "Điện tâm đồ", 150000, ref yPos);
            contentPanel.Controls.Add(dvPanel);

            yPos += 20;

            Panel tongKet = TaoSectionTongKet(650000, 0, yPos);
            contentPanel.Controls.Add(tongKet);

            cthoadon.Controls.Add(contentPanel);
        }

        // Gọi hàm này để hiển thị chỉ có đơn thuốc (không có dịch vụ)
        private void HienThiHoaDonChiThuoc(Panel cthoadon)
        {
            cthoadon.Controls.Clear();
            cthoadon.AutoScroll = true;
            cthoadon.Padding = new Padding(20);
            cthoadon.BackColor = Color.FromArgb(245, 245, 245);

            Panel header = TaoHeader("Lê Văn C", "BN003");
            cthoadon.Controls.Add(header);

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 245, 245);

            int yPos = 10;

            Panel thuocPanel = TaoSectionDonThuoc(yPos);
            TaoItemThuoc(thuocPanel, "Vitamin C 1000mg", "3 hộp", 120000, ref yPos);
            TaoItemThuoc(thuocPanel, "Omega 3", "1 hộp", 250000, ref yPos);
            TaoItemThuoc(thuocPanel, "Calcium + D3", "2 hộp", 180000, ref yPos);
            contentPanel.Controls.Add(thuocPanel);

            yPos += 20;

            Panel tongKet = TaoSectionTongKet(0, 550000, yPos);
            contentPanel.Controls.Add(tongKet);

            cthoadon.Controls.Add(contentPanel);
        }

        // ===== CÁC HÀM TẠO COMPONENT =====

        private Panel TaoHeader(string tenBN, string maBN)
        {
            Panel header = new Panel();
            header.Height = 100;
            header.Dock = DockStyle.Top;
            header.BackColor = Color.White;
            header.Margin = new Padding(0, 0, 0, 15);
            header.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, header.Width - 1, header.Height - 1);
                }
            };

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "CHI TIẾT HÓA ĐƠN";
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(33, 150, 243);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.AutoSize = true;

            Label lblTenBN = new Label();
            lblTenBN.Text = "Bệnh nhân: " + tenBN;
            lblTenBN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTenBN.ForeColor = Color.FromArgb(33, 33, 33);
            lblTenBN.Location = new Point(20, 50);
            lblTenBN.AutoSize = true;

            Label lblMaBN = new Label();
            lblMaBN.Text = "Mã BN: " + maBN;
            lblMaBN.Font = new Font("Segoe UI", 9F);
            lblMaBN.ForeColor = Color.FromArgb(130, 130, 130);
            lblMaBN.Location = new Point(20, 72);
            lblMaBN.AutoSize = true;

            header.Controls.Add(lblTieuDe);
            header.Controls.Add(lblTenBN);
            header.Controls.Add(lblMaBN);

            return header;
        }

        private Panel TaoSectionDichVu(int yPos)
        {
            Panel section = new Panel();
            section.Width = 560;
            section.Location = new Point(0, yPos);
            section.BackColor = Color.Transparent;
            section.AutoSize = true;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "DỊCH VỤ KHÁM";
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(66, 66, 66);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.AutoSize = true;
            section.Controls.Add(lblTieuDe);

            return section;
        }

        private void TaoItemDichVu(Panel section, string tenDV, int gia, ref int yPos)
        {
            if (section.Controls.Count == 1) yPos = 35; // Bắt đầu từ vị trí sau tiêu đề
            else yPos += 70;

            Panel card = new Panel();
            card.Width = 560;
            card.Height = 60;
            card.Location = new Point(0, yPos);
            card.BackColor = Color.White;

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            Panel icon = new Panel();
            icon.Width = 8;
            icon.Height = card.Height;
            icon.BackColor = Color.FromArgb(76, 175, 80);
            icon.Dock = DockStyle.Left;

            Label lblTen = new Label();
            lblTen.Text = tenDV;
            lblTen.Font = new Font("Segoe UI", 9.5F);
            lblTen.ForeColor = Color.FromArgb(33, 33, 33);
            lblTen.Location = new Point(25, 20);
            lblTen.AutoSize = true;

            Label lblGia = new Label();
            lblGia.Text = gia.ToString("N0") + " đ";
            lblGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGia.ForeColor = Color.FromArgb(76, 175, 80);
            lblGia.Location = new Point(card.Width - 150, 18);
            lblGia.AutoSize = true;

            card.Controls.Add(icon);
            card.Controls.Add(lblTen);
            card.Controls.Add(lblGia);
            section.Controls.Add(card);
            section.Height = yPos + 60;
        }

        private Panel TaoSectionDonThuoc(int yPos)
        {
            Panel section = new Panel();
            section.Width = 560;
            section.Location = new Point(0, yPos);
            section.BackColor = Color.Transparent;
            section.AutoSize = true;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "ĐƠN THUỐC";
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(66, 66, 66);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.AutoSize = true;
            section.Controls.Add(lblTieuDe);

            return section;
        }

        private void TaoItemThuoc(Panel section, string tenThuoc, string soLuong, int gia, ref int yPos)
        {
            if (section.Controls.Count == 1) yPos = 35;
            else yPos += 80;

            Panel card = new Panel();
            card.Width = 560;
            card.Height = 70;
            card.Location = new Point(0, yPos);
            card.BackColor = Color.White;

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            Panel icon = new Panel();
            icon.Width = 8;
            icon.Height = card.Height;
            icon.BackColor = Color.FromArgb(255, 152, 0);
            icon.Dock = DockStyle.Left;

            Label lblTen = new Label();
            lblTen.Text = tenThuoc;
            lblTen.Font = new Font("Segoe UI", 9.5F);
            lblTen.ForeColor = Color.FromArgb(33, 33, 33);
            lblTen.Location = new Point(25, 15);
            lblTen.AutoSize = true;

            Label lblSoLuong = new Label();
            lblSoLuong.Text = "Số lượng: " + soLuong;
            lblSoLuong.Font = new Font("Segoe UI", 8.5F);
            lblSoLuong.ForeColor = Color.FromArgb(130, 130, 130);
            lblSoLuong.Location = new Point(25, 40);
            lblSoLuong.AutoSize = true;

            Label lblGia = new Label();
            lblGia.Text = gia.ToString("N0") + " đ";
            lblGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGia.ForeColor = Color.FromArgb(255, 152, 0);
            lblGia.Location = new Point(card.Width - 150, 24);
            lblGia.AutoSize = true;

            card.Controls.Add(icon);
            card.Controls.Add(lblTen);
            card.Controls.Add(lblSoLuong);
            card.Controls.Add(lblGia);
            section.Controls.Add(card);
            section.Height = yPos + 70;
        }

        private Panel TaoSectionTongKet(int tongDV, int tongThuoc, int yPos)
        {
            Panel section = new Panel();
            section.Width = 560;
            section.Height = 150;
            section.Location = new Point(0, yPos);
            section.BackColor = Color.White;

            section.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(33, 150, 243), 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, section.Width - 1, section.Height - 1);
                }
            };

            Label lblDV = new Label();
            lblDV.Text = "Tổng dịch vụ:";
            lblDV.Font = new Font("Segoe UI", 9.5F);
            lblDV.Location = new Point(20, 20);
            lblDV.AutoSize = true;

            Label lblGiaDV = new Label();
            lblGiaDV.Text = tongDV.ToString("N0") + " đ";
            lblGiaDV.Font = new Font("Segoe UI", 9.5F);
            lblGiaDV.Location = new Point(section.Width - 150, 20);
            lblGiaDV.AutoSize = true;

            Label lblThuoc = new Label();
            lblThuoc.Text = "Tổng thuốc:";
            lblThuoc.Font = new Font("Segoe UI", 9.5F);
            lblThuoc.Location = new Point(20, 50);
            lblThuoc.AutoSize = true;

            Label lblGiaThuoc = new Label();
            lblGiaThuoc.Text = tongThuoc.ToString("N0") + " đ";
            lblGiaThuoc.Font = new Font("Segoe UI", 9.5F);
            lblGiaThuoc.Location = new Point(section.Width - 150, 50);
            lblGiaThuoc.AutoSize = true;

            Panel divider = new Panel();
            divider.Height = 1;
            divider.Width = section.Width - 40;
            divider.Location = new Point(20, 85);
            divider.BackColor = Color.FromArgb(230, 230, 230);

            Label lblTongCong = new Label();
            lblTongCong.Text = "TỔNG CỘNG:";
            lblTongCong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongCong.ForeColor = Color.FromArgb(33, 150, 243);
            lblTongCong.Location = new Point(20, 105);
            lblTongCong.AutoSize = true;

            Label lblTongTien = new Label();
            lblTongTien.Text = (tongDV + tongThuoc).ToString("N0") + " đ";
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(244, 67, 54);
            lblTongTien.Location = new Point(section.Width - 150, 103);
            lblTongTien.AutoSize = true;

            section.Controls.Add(lblDV);
            section.Controls.Add(lblGiaDV);
            section.Controls.Add(lblThuoc);
            section.Controls.Add(lblGiaThuoc);
            section.Controls.Add(divider);
            section.Controls.Add(lblTongCong);
            section.Controls.Add(lblTongTien);

            return section;
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            cthoadon.Controls.Clear();
            Panel hoaDon = TaoPanelChiTietHoaDon("haha", "AA");
            cthoadon.Controls.Add(hoaDon);
        }
    }
}