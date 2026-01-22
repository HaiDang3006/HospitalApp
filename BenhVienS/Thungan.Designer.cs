using System.Drawing;
using System.Windows.Forms;

namespace BenhVienS
{
    partial class Thungan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private Panel TaoCard(string tenBN, string maBN)
        {
            Panel card = new Panel();
            card.Height = 75;
            card.Dock = DockStyle.Top;
            card.Padding = new Padding(16, 12, 16, 12);
            card.Margin = new Padding(15, 8, 15, 8);  // Tăng khoảng cách giữa các card
            card.BorderStyle = BorderStyle.None;
            card.BackColor = Color.White;

            // Vẽ border mượt mà
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            // TextBox tên bệnh nhân
            TextBox txtTen = new TextBox();
            txtTen.Text = tenBN;
            txtTen.ReadOnly = true;
            txtTen.BorderStyle = BorderStyle.None;
            txtTen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtTen.ForeColor = Color.FromArgb(33, 33, 33);
            txtTen.Location = new Point(16, 14);
            txtTen.Width = card.Width - 150;
            txtTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTen.BackColor = Color.White;

            // TextBox mã bệnh nhân
            TextBox txtMa = new TextBox();
            txtMa.Text = "ID: " + maBN;
            txtMa.ReadOnly = true;
            txtMa.BorderStyle = BorderStyle.None;
            txtMa.Font = new Font("Segoe UI", 8.5F);
            txtMa.ForeColor = Color.FromArgb(130, 130, 130);
            txtMa.Location = new Point(16, 38);
            txtMa.Width = 250;
            txtMa.BackColor = Color.White;

            // Button xử lý đẹp với custom paint
            Button btnXuLy = new Button();
            btnXuLy.Text = "Xử lý";
            btnXuLy.Size = new Size(80, 32);
            btnXuLy.Location = new Point(card.Width - 95, 21);
            btnXuLy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuLy.FlatStyle = FlatStyle.Flat;
            btnXuLy.FlatAppearance.BorderSize = 0;
            btnXuLy.BackColor = Color.Transparent;
            btnXuLy.ForeColor = Color.White;
            btnXuLy.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            btnXuLy.Cursor = Cursors.Hand;

            bool isHover = false;

            // Custom paint cho button với gradient và border radius
            btnXuLy.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int radius = 8;
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btnXuLy.Width - radius - 1, 0, radius, radius, 270, 90);
                path.AddArc(btnXuLy.Width - radius - 1, btnXuLy.Height - radius - 1, radius, radius, 0, 90);
                path.AddArc(0, btnXuLy.Height - radius - 1, radius, radius, 90, 90);
                path.CloseFigure();

                // Gradient background
                Color color1 = isHover ? Color.FromArgb(25, 118, 210) : Color.FromArgb(33, 150, 243);
                Color color2 = isHover ? Color.FromArgb(21, 101, 192) : Color.FromArgb(30, 136, 229);

                using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                    new System.Drawing.Drawing2D.LinearGradientBrush(
                        new Point(0, 0),
                        new Point(0, btnXuLy.Height),
                        color1,
                        color2))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Vẽ text
                TextRenderer.DrawText(e.Graphics, btnXuLy.Text, btnXuLy.Font,
                    new Rectangle(0, 0, btnXuLy.Width, btnXuLy.Height),
                    btnXuLy.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            btnXuLy.MouseEnter += (s, e) =>
            {
                isHover = true;
                btnXuLy.Invalidate();
            };

            btnXuLy.MouseLeave += (s, e) =>
            {
                isHover = false;
                btnXuLy.Invalidate();
            };


            btnXuLy.Click += (s, e) =>
            {
                cthoadon.Controls.Clear();
                Panel hoaDon = TaoPanelChiTietHoaDon("haha", "S");

                cthoadon.Controls.Add(hoaDon);
            };

            // Hover effect nhẹ cho card
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(252, 252, 252);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            card.Controls.Add(txtTen);
            card.Controls.Add(txtMa);
            card.Controls.Add(btnXuLy);

            return card;
        }


        private Panel TaoPanelChiTietHoaDon(string tenBN, string maBN)
        {
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.Padding = new Padding(20);
            pnl.BackColor = Color.White;

            // ===== TIÊU ĐỀ =====
            Label lblTitle = new Label()
            {
                Text = "CHI TIẾT HÓA ĐƠN",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true
            };

            // ===== THÔNG TIN BN =====
            Label lblInfo = new Label()
            {
                Text = $"Bệnh nhân: {tenBN}   |   Mã BN: {maBN}",
                Font = new Font("Segoe UI", 9.5F),
                Top = 35,
                AutoSize = true,
                Left = 0
            };

            // ===== TỔNG TIỀN (NGANG HÀNG) =====
            Label lblTong = new Label()
            {
                Text = "Tổng tiền: 0 VNĐ",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(211, 47, 47),
                Top = lblInfo.Top,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // ===== ĐƠN THUỐC =====
            Label lblThuoc = new Label()
            {
                Text = "Đơn thuốc",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Top = 70,
                AutoSize = true
            };

            Panel pnlThuoc = new Panel()
            {
                Top = 95,
                Width = 430,
                Height = 150,
                AutoScroll = true
            };

            DataGridView dgvThuoc = TaoBang();
            dgvThuoc.Dock = DockStyle.Top;
            dgvThuoc.Height = 300;

            dgvThuoc.Columns.Add("TenThuoc", "Tên thuốc");
            dgvThuoc.Columns.Add("SoLuong", "Số lượng");
            dgvThuoc.Columns.Add("DonGia", "Đơn giá");
            dgvThuoc.Columns.Add("ThanhTien", "Thành tiền");

            SetColumnWidthThuoc(dgvThuoc);

            pnlThuoc.Controls.Add(dgvThuoc);

            // ===== DỊCH VỤ =====
            Label lblDV = new Label()
            {
                Text = "Dịch vụ sử dụng",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Top = 255,
                AutoSize = true
            };

            Panel pnlDV = new Panel()
            {
                Top = 280,
                Width = 430,
                Height = 130,
                AutoScroll = true
            };

            DataGridView dgvDV = TaoBang();
            dgvDV.Dock = DockStyle.Top;
            dgvDV.Height = 250;

            dgvDV.Columns.Add("TenDV", "Tên dịch vụ");
            dgvDV.Columns.Add("Gia", "Giá");

            dgvDV.Columns["TenDV"].Width = 250;
            dgvDV.Columns["Gia"].Width = 180;

            pnlDV.Controls.Add(dgvDV);

            // ===== DATA DEMO =====
            ThemThuoc(dgvThuoc, "Paracetamol", 10, 5000);
            ThemThuoc(dgvThuoc, "Amoxicillin", 5, 10000);
            ThemThuoc(dgvThuoc, "Vitamin C", 20, 3000);
            ThemThuoc(dgvThuoc, "Ibuprofen", 15, 7000);

            dgvDV.Rows.Add("Khám tổng quát", 100000);
            dgvDV.Rows.Add("Siêu âm", 200000);
            dgvDV.Rows.Add("Xét nghiệm máu", 150000);

            // ===== TÍNH TỔNG =====
            CapNhatTongTien(lblTong, dgvThuoc, dgvDV);

            // ===== ADD CONTROL =====
            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblInfo);
            pnl.Controls.Add(lblTong);
            pnl.Controls.Add(lblThuoc);
            pnl.Controls.Add(pnlThuoc);
            pnl.Controls.Add(lblDV);
            pnl.Controls.Add(pnlDV);

            // canh phải lblTong sau khi add
            lblTong.Left = pnl.Width - lblTong.Width - 20;

            return pnl;
        }

        private void SetColumnWidthThuoc(DataGridView dgv)
        {
            dgv.Columns["TenThuoc"].Width = 250;
            dgv.Columns["SoLuong"].Width = 120;
            dgv.Columns["DonGia"].Width = 150;
            dgv.Columns["ThanhTien"].Width = 180;
        }


        private DataGridView TaoBang()
        {
            DataGridView dgv = new DataGridView();

            dgv.Width = 300;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;

            dgv.ScrollBars = ScrollBars.Both;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;

            return dgv;
        }



        private void HienThiChiTietHoaDon(Panel cthoadon, string tenBN, string maBN)
        {
            // Clear panel trước
            cthoadon.Controls.Clear();
            cthoadon.AutoScroll = true;
            cthoadon.Padding = new Padding(20);
            cthoadon.BackColor = Color.FromArgb(245, 245, 245);

            // Header - Thông tin bệnh nhân
            Panel headerPanel = new Panel();
            headerPanel.Height = 100;
            headerPanel.Dock = DockStyle.Top;
            headerPanel.BackColor = Color.White;
            headerPanel.Margin = new Padding(0, 0, 0, 15);
            headerPanel.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, headerPanel.Width - 1, headerPanel.Height - 1);
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

            headerPanel.Controls.Add(lblTieuDe);
            headerPanel.Controls.Add(lblTenBN);
            headerPanel.Controls.Add(lblMaBN);

            // Container cho nội dung cuộn
            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 245, 245);

            int yPos = 10;

            // Phần Dịch Vụ
            Panel dichVuPanel = TaoSectionDichVu(ref yPos);
            if (dichVuPanel != null)
            {
                contentPanel.Controls.Add(dichVuPanel);
            }

            // Phần Đơn Thuốc
            Panel donThuocPanel = TaoSectionDonThuoc(ref yPos);
            if (donThuocPanel != null)
            {
                contentPanel.Controls.Add(donThuocPanel);
            }

            // Phần Tổng Kết
            Panel tongKetPanel = TaoSectionTongKet(350000, 120000, ref yPos);
            contentPanel.Controls.Add(tongKetPanel);

            cthoadon.Controls.Add(headerPanel);
            cthoadon.Controls.Add(contentPanel);
        }

        private Panel TaoSectionDichVu(ref int yPos)
        {
            Panel section = new Panel();
            section.Width = 560;
            section.AutoSize = true;
            section.Location = new Point(0, yPos);
            section.BackColor = Color.Transparent;

            // Tiêu đề section
            Label lblTieuDe = new Label();
            lblTieuDe.Text = "DỊCH VỤ KHÁM";
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(66, 66, 66);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.AutoSize = true;
            section.Controls.Add(lblTieuDe);

            int itemY = 35;

            // Danh sách dịch vụ mẫu
            var dichVuList = new[]
            {
        new { Ten = "Khám tổng quát", Gia = 150000 },
        new { Ten = "Xét nghiệm máu", Gia = 100000 },
        new { Ten = "Chụp X-Quang", Gia = 100000 }
    };

            foreach (var dv in dichVuList)
            {
                Panel itemPanel = TaoItemCard(dv.Ten, dv.Gia.ToString("N0") + " đ");
                itemPanel.Location = new Point(0, itemY);
                section.Controls.Add(itemPanel);
                itemY += 70;
            }

            section.Height = itemY;
            yPos += itemY + 20;

            return section;
        }

        private Panel TaoSectionDonThuoc(ref int yPos)
        {
            Panel section = new Panel();
            section.Width = 560;
            section.AutoSize = true;
            section.Location = new Point(0, yPos);
            section.BackColor = Color.Transparent;

            // Tiêu đề section
            Label lblTieuDe = new Label();
            lblTieuDe.Text = "ĐƠN THUỐC";
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(66, 66, 66);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.AutoSize = true;
            section.Controls.Add(lblTieuDe);

            int itemY = 35;

            // Danh sách thuốc mẫu
            var thuocList = new[]
            {
        new { Ten = "Paracetamol 500mg", SoLuong = "2 hộp", Gia = 40000 },
        new { Ten = "Amoxicillin 500mg", SoLuong = "1 hộp", Gia = 80000 }
    };

            foreach (var thuoc in thuocList)
            {
                Panel itemPanel = TaoItemCardThuoc(thuoc.Ten, thuoc.SoLuong, thuoc.Gia.ToString("N0") + " đ");
                itemPanel.Location = new Point(0, itemY);
                section.Controls.Add(itemPanel);
                itemY += 80;
            }

            section.Height = itemY;
            yPos += itemY + 20;

            return section;
        }

        private Panel TaoItemCard(string tenDichVu, string gia)
        {
            Panel card = new Panel();
            card.Width = 560;
            card.Height = 60;
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 0, 10);

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            // Icon dịch vụ
            Panel iconPanel = new Panel();
            iconPanel.Width = 8;
            iconPanel.Height = card.Height;
            iconPanel.BackColor = Color.FromArgb(76, 175, 80);
            iconPanel.Dock = DockStyle.Left;
            card.Controls.Add(iconPanel);

            // Tên dịch vụ
            Label lblTen = new Label();
            lblTen.Text = tenDichVu;
            lblTen.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblTen.ForeColor = Color.FromArgb(33, 33, 33);
            lblTen.Location = new Point(25, 20);
            lblTen.AutoSize = true;
            card.Controls.Add(lblTen);

            // Giá
            Label lblGia = new Label();
            lblGia.Text = gia;
            lblGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGia.ForeColor = Color.FromArgb(76, 175, 80);
            lblGia.Location = new Point(card.Width - 150, 18);
            lblGia.AutoSize = true;
            lblGia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            card.Controls.Add(lblGia);

            return card;
        }

        private Panel TaoItemCardThuoc(string tenThuoc, string soLuong, string gia)
        {
            Panel card = new Panel();
            card.Width = 560;
            card.Height = 70;
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 0, 10);

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            // Icon thuốc
            Panel iconPanel = new Panel();
            iconPanel.Width = 8;
            iconPanel.Height = card.Height;
            iconPanel.BackColor = Color.FromArgb(255, 152, 0);
            iconPanel.Dock = DockStyle.Left;
            card.Controls.Add(iconPanel);

            // Tên thuốc
            Label lblTen = new Label();
            lblTen.Text = tenThuoc;
            lblTen.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblTen.ForeColor = Color.FromArgb(33, 33, 33);
            lblTen.Location = new Point(25, 15);
            lblTen.AutoSize = true;
            card.Controls.Add(lblTen);

            // Số lượng
            Label lblSoLuong = new Label();
            lblSoLuong.Text = "Số lượng: " + soLuong;
            lblSoLuong.Font = new Font("Segoe UI", 8.5F);
            lblSoLuong.ForeColor = Color.FromArgb(130, 130, 130);
            lblSoLuong.Location = new Point(25, 40);
            lblSoLuong.AutoSize = true;
            card.Controls.Add(lblSoLuong);

            // Giá
            Label lblGia = new Label();
            lblGia.Text = gia;
            lblGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGia.ForeColor = Color.FromArgb(255, 152, 0);
            lblGia.Location = new Point(card.Width - 150, 24);
            lblGia.AutoSize = true;
            lblGia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            card.Controls.Add(lblGia);

            return card;
        }

        private Panel TaoSectionTongKet(int tongDichVu, int tongThuoc, ref int yPos)
        {
            Panel section = new Panel();
            section.Width = 300;
            section.Height = 150;
            section.Location = new Point(0, yPos);
            section.BackColor = Color.White;
            section.Margin = new Padding(0, 10, 0, 0);

            section.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(33, 150, 243), 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, section.Width - 1, section.Height - 1);
                }
            };

            // Tổng dịch vụ
            Label lblDichVu = new Label();
            lblDichVu.Text = "Tổng dịch vụ:";
            lblDichVu.Font = new Font("Segoe UI", 9.5F);
            lblDichVu.ForeColor = Color.FromArgb(66, 66, 66);
            lblDichVu.Location = new Point(20, 20);
            lblDichVu.AutoSize = true;

            Label lblGiaDichVu = new Label();
            lblGiaDichVu.Text = tongDichVu.ToString("N0") + " đ";
            lblGiaDichVu.Font = new Font("Segoe UI", 9.5F);
            lblGiaDichVu.ForeColor = Color.FromArgb(66, 66, 66);
            lblGiaDichVu.Location = new Point(section.Width - 150, 20);
            lblGiaDichVu.AutoSize = true;
            lblGiaDichVu.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Tổng thuốc
            Label lblThuoc = new Label();
            lblThuoc.Text = "Tổng thuốc:";
            lblThuoc.Font = new Font("Segoe UI", 9.5F);
            lblThuoc.ForeColor = Color.FromArgb(66, 66, 66);
            lblThuoc.Location = new Point(20, 50);
            lblThuoc.AutoSize = true;

            Label lblGiaThuoc = new Label();
            lblGiaThuoc.Text = tongThuoc.ToString("N0") + " đ";
            lblGiaThuoc.Font = new Font("Segoe UI", 9.5F);
            lblGiaThuoc.ForeColor = Color.FromArgb(66, 66, 66);
            lblGiaThuoc.Location = new Point(section.Width - 150, 50);
            lblGiaThuoc.AutoSize = true;
            lblGiaThuoc.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Đường kẻ
            Panel divider = new Panel();
            divider.Height = 1;
            divider.Width = section.Width - 40;
            divider.Location = new Point(20, 85);
            divider.BackColor = Color.FromArgb(230, 230, 230);

            // Tổng cộng
            Label lblTongCong = new Label();
            lblTongCong.Text = "TỔNG CỘNG:";
            lblTongCong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongCong.ForeColor = Color.FromArgb(33, 150, 243);
            lblTongCong.Location = new Point(20, 105);
            lblTongCong.AutoSize = true;

            Label lblTongTien = new Label();
            lblTongTien.Text = (tongDichVu + tongThuoc).ToString("N0") + " đ";
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(244, 67, 54);
            lblTongTien.Location = new Point(section.Width - 150, 103);
            lblTongTien.AutoSize = true;
            lblTongTien.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            section.Controls.Add(lblDichVu);
            section.Controls.Add(lblGiaDichVu);
            section.Controls.Add(lblThuoc);
            section.Controls.Add(lblGiaThuoc);
            section.Controls.Add(divider);
            section.Controls.Add(lblTongCong);
            section.Controls.Add(lblTongTien);  

            return section;
        }




        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cthoadon = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panelView = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(2, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 628);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button5);
            this.panel7.Controls.Add(this.pictureBox5);
            this.panel7.Location = new System.Drawing.Point(3, 513);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(230, 53);
            this.panel7.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(54, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(176, 47);
            this.button5.TabIndex = 4;
            this.button5.Text = "Đăng Xuất";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BenhVienS.Properties.Resources.power;
            this.pictureBox5.Location = new System.Drawing.Point(3, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(45, 47);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button6);
            this.panel8.Controls.Add(this.pictureBox6);
            this.panel8.Location = new System.Drawing.Point(3, 228);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(230, 53);
            this.panel8.TabIndex = 7;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(54, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(173, 47);
            this.button6.TabIndex = 4;
            this.button6.Text = "Cài Đặt";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::BenhVienS.Properties.Resources.settings;
            this.pictureBox6.Location = new System.Drawing.Point(3, 6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(48, 44);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 3;
            this.pictureBox6.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 53);
            this.panel3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(54, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tổng Quan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BenhVienS.Properties.Resources.home_icon_silhouette1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Location = new System.Drawing.Point(4, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 53);
            this.panel4.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(54, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 47);
            this.button2.TabIndex = 4;
            this.button2.Text = "Thanh Toán Viện Phí";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BenhVienS.Properties.Resources.pension;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Location = new System.Drawing.Point(3, 171);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(230, 53);
            this.panel6.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(54, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 47);
            this.button4.TabIndex = 4;
            this.button4.Text = "Danh Sách Thu Chi";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BenhVienS.Properties.Resources.document1;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(45, 47);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Location = new System.Drawing.Point(4, 115);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 53);
            this.panel5.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(54, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 47);
            this.button3.TabIndex = 4;
            this.button3.Text = "Danh Sách Hóa Đơn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BenhVienS.Properties.Resources.invoice;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 47);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1468, 87);
            this.panel2.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(629, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(362, 32);
            this.label12.TabIndex = 0;
            this.label12.Text = "THU NGÂN BỆNH VIỆN S";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel9.Controls.Add(this.button7);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.pictureBox7);
            this.panel9.Location = new System.Drawing.Point(245, 95);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(307, 85);
            this.panel9.TabIndex = 2;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(111, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 42);
            this.button7.TabIndex = 3;
            this.button7.Text = "99";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số Hóa Đơn Hôm Nay ";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::BenhVienS.Properties.Resources.cash;
            this.pictureBox7.Location = new System.Drawing.Point(3, 6);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(59, 61);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 3;
            this.pictureBox7.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Green;
            this.panel10.Controls.Add(this.button8);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.pictureBox8);
            this.panel10.Location = new System.Drawing.Point(558, 95);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(303, 85);
            this.panel10.TabIndex = 3;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(115, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 42);
            this.button8.TabIndex = 3;
            this.button8.Text = "99";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hóa Đơn Đã Thanh Toán ";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::BenhVienS.Properties.Resources._checked;
            this.pictureBox8.Location = new System.Drawing.Point(3, 6);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(59, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 3;
            this.pictureBox8.TabStop = false;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label6);
            this.panel14.Controls.Add(this.cthoadon);
            this.panel14.Controls.Add(this.button13);
            this.panel14.Controls.Add(this.button12);
            this.panel14.Controls.Add(this.button11);
            this.panel14.Location = new System.Drawing.Point(626, 3);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(599, 529);
            this.panel14.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(14, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "CHI TIẾT HÓA ĐƠN";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // cthoadon
            // 
            this.cthoadon.AutoScroll = true;
            this.cthoadon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cthoadon.Location = new System.Drawing.Point(8, 37);
            this.cthoadon.Name = "cthoadon";
            this.cthoadon.Size = new System.Drawing.Size(577, 448);
            this.cthoadon.TabIndex = 18;
            this.cthoadon.Paint += new System.Windows.Forms.PaintEventHandler(this.cthoadon_Paint);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(455, 491);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(44, 33);
            this.button13.TabIndex = 14;
            this.button13.Text = "Hủy";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(294, 491);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(104, 33);
            this.button12.TabIndex = 13;
            this.button12.Text = "In Hóa Đơn";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Green;
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(112, 491);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(115, 33);
            this.button11.TabIndex = 12;
            this.button11.Text = "Thanh Toán";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel17);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Location = new System.Drawing.Point(241, 186);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1228, 537);
            this.panel13.TabIndex = 10;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.panelView);
            this.panel17.Controls.Add(this.label7);
            this.panel17.Controls.Add(this.label5);
            this.panel17.Location = new System.Drawing.Point(4, 3);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(620, 529);
            this.panel17.TabIndex = 10;
            // 
            // panelView
            // 
            this.panelView.AutoScroll = true;
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Location = new System.Drawing.Point(3, 37);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(613, 492);
            this.panelView.TabIndex = 17;
            this.panelView.Paint += new System.Windows.Forms.PaintEventHandler(this.panelView_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(8, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "HÓA ĐƠN CẦN THANH TOÁN";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 9;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::BenhVienS.Properties.Resources.business_continuity;
            this.pictureBox9.Location = new System.Drawing.Point(3, 6);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(59, 50);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 3;
            this.pictureBox9.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tổng Doanh Thu Hôm Nay";
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(136, 25);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 42);
            this.button9.TabIndex = 3;
            this.button9.Text = "99";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel11.Controls.Add(this.button9);
            this.panel11.Controls.Add(this.label3);
            this.panel11.Controls.Add(this.pictureBox9);
            this.panel11.Location = new System.Drawing.Point(1173, 95);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(297, 85);
            this.panel11.TabIndex = 4;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::BenhVienS.Properties.Resources.report;
            this.pictureBox10.Location = new System.Drawing.Point(3, 6);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(59, 50);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 3;
            this.pictureBox10.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hóa Đơn Chưa Thanh Toán";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel12.Controls.Add(this.button10);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Controls.Add(this.pictureBox10);
            this.panel12.Location = new System.Drawing.Point(871, 95);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(296, 85);
            this.panel12.TabIndex = 5;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(135, 25);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 42);
            this.button10.TabIndex = 3;
            this.button10.Text = "99";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // Thungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 750);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Thungan";
            this.Text = "Thungan";
            this.Load += new System.EventHandler(this.Thungan_Load);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelView;
        private Panel cthoadon;
        private PictureBox pictureBox9;
        private Label label3;
        private Button button9;
        private Panel panel11;
        private PictureBox pictureBox10;
        private Label label4;
        private Panel panel12;
        private Button button10;
        private Label label6;
    }
}