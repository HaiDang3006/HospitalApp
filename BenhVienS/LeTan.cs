using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class LeTan : Form
    {
        private List<Control> _defaultPanelControls;

        public LeTan()
        {
            InitializeComponent();

            _defaultPanelControls = panel3.Controls.Cast<Control>().ToList();
            btlichhenhomnay.Click += btlichhenhomnay_Click;
        }

        private void showControl(Control control)
        {
            panel3.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel3.Controls.Add(control);
        }

        private void RestorePanelThongTin()
        {
            panel3.Controls.Clear();
            foreach (var ctrl in _defaultPanelControls)
                panel3.Controls.Add(ctrl);
        }

        // ================= LOAD LỊCH HẸN =================
        private void LoadLichHen(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = dbUtils.GetConnection())
                {
                    conn.Open();

                    // Đã sửa lại các tên cột để khớp với ảnh Database bạn gửi
                    string sql = @"
SELECT 
    lh.MaLichHen,
    bn.MaBenhNhan,
    nd_bn.HoTen AS TenBenhNhan, -- Lấy từ bảng NguoiDung (nd_bn)
    bs.MaBacSi,
    nd_bs.HoTen AS TenBacSi,     -- Lấy từ bảng NguoiDung (nd_bs)
    ll.MaLichLamViec,            -- Tên cột trong bảng LichLamViec
    lh.NgayHen,
    lh.LyDoKham,
    lh.HinhThucDat,
    lh.TrangThai,
    lt.MaLeTan,
    lh.ThoiGianDen,
    lh.GhiChu
FROM LichHen lh
JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
JOIN NguoiDung nd_bn ON bn.MaNguoiDung = nd_bn.MaNguoiDung
LEFT JOIN BacSi bs ON lh.MaBacSi = bs.MaBacSi
LEFT JOIN NguoiDung nd_bs ON bs.MaNguoiDung = nd_bs.MaNguoiDung
JOIN LichLamViec ll ON lh.MaLichLamViec = ll.MaLichLamViec -- Kiểm tra xem bảng LichHen có đúng cột MaLichLamViec không
LEFT JOIN LeTan lt ON lh.MaLeTan = lt.MaLeTan
WHERE 1 = 1
";

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sql += " AND (CAST(bn.MaBenhNhan AS NVARCHAR(50)) LIKE @key OR nd_bn.HoTen LIKE @key)";
                    }

                    sql += " ORDER BY lh.NgayHen DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    if (!string.IsNullOrEmpty(keyword))
                        da.SelectCommand.Parameters.AddWithValue("@key", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLichhenhomnay.AutoGenerateColumns = true;
                    dgvLichhenhomnay.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi chi tiết để biết chính xác nó đang vướng ở cột nào
                MessageBox.Show("Lỗi chi tiết: " + ex.Message);
            }
        }
        private void LeTan_Load(object sender, EventArgs e)
        {
            LoadLichHen();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            LoadLichHen(txtNhapten.Text.Trim());
        }

        private void btlichhenhomnay_Click(object sender, EventArgs e)
        {
            RestorePanelThongTin();
            LoadLichHen();
        }

        private void bttaolichhen_Click(object sender, EventArgs e)
        {
            showControl(new uctaolichhen());
        }

        private void btbenhnhan_Click(object sender, EventArgs e)
        {
            showControl(new ucLetan_Benhnhan());
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
