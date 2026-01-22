using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class uckedonthuoc : UserControl
    {
        private string connectionString =
            "Server=MSI\\SQLPHAT;Database=Benhvienv1;Trusted_Connection=True;TrustServerCertificate=True;";

        public uckedonthuoc()
        {
            InitializeComponent();
            this.Load += uckedonthuoc_Load; // 🔥 QUAN TRỌNG
        }

        private void uckedonthuoc_Load(object sender, EventArgs e)
        {
            dgvThuoc.DataSource = null;
            dgvThuoc.Columns.Clear();
            dgvThuoc.AutoGenerateColumns = true;

            LoadTrangThai();
            LoadDonThuoc();
        }

        // ================= LOAD COMBOBOX =================
        private void LoadTrangThai()
        {
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("Chưa phát thuốc");
            cmbTrangThai.Items.Add("Đã phát thuốc");
            cmbTrangThai.Items.Add("Đã hủy");

            cmbTrangThai.SelectedIndex = 0;
            cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ================= LOAD GRID =================
        private void LoadDonThuoc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))

                {
                    conn.Open();

                    string sql = @"SELECT 
                                    MaDonThuoc, 
                                    MaPhieuKham, 
                                    MaBacSi, 
                                    LoiDan, 
                                    NgayKeDon, 
                                    TrangThai 
                                   FROM DonThuoc";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    MessageBox.Show("Số dòng load được: " + dt.Rows.Count); // TEST

                    dgvThuoc.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // ================= CLICK GRID =================
        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvThuoc.Rows[e.RowIndex];

            txtMaDonThuoc.Text = r.Cells["MaDonThuoc"].Value?.ToString();
            txtMaPhieuKham.Text = r.Cells["MaPhieuKham"].Value?.ToString();
            txtMaBacSi.Text = r.Cells["MaBacSi"].Value?.ToString();
            txtloidan.Text = r.Cells["LoiDan"].Value?.ToString();

            if (r.Cells["NgayKeDon"].Value != DBNull.Value)
                dtpNgayKeDon.Value = Convert.ToDateTime(r.Cells["NgayKeDon"].Value);

            cmbTrangThai.Text = r.Cells["TrangThai"].Value?.ToString();
        }

        private void ClearInput()
        {
            txtMaDonThuoc.Clear();
            txtMaPhieuKham.Clear();
            txtMaBacSi.Clear();
            txtloidan.Clear();

            dtpNgayKeDon.Value = DateTime.Now;
            cmbTrangThai.SelectedIndex = 0;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Nếu uchsbenhan đang nằm trong panel nội dung của form chính
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

    }
}
