using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class uchsbenhan : UserControl
    {
        string connectionString =
            "Server=MSI\\SQLPHAT;Database=Benhvienv1;Trusted_Connection=True;TrustServerCertificate=True;";

        public uchsbenhan()
        {
            InitializeComponent();

            dgvHoSoBenhAn.AutoGenerateColumns = true;
            dgvHoSoBenhAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoSoBenhAn.ScrollBars = ScrollBars.Both;
        }

        private void uchsbenhan_Load(object sender, EventArgs e)
        {
            LoadHoSoBenhAn();
            dtpNgayTao.Value = DateTime.Now;
            dtpNgayCapNhat.Value = DateTime.Now;
        }

        // ================= LOAD =================
        private void LoadHoSoBenhAn()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT 
                                MaHoSo,
                                MaBenhNhan,
                                MaPhieuKham,
                                NgayTao,
                                NgayCapNhat,
                                TienSuBenh,
                                DiUng,
                                TienSuGiaDinh,
                                BenhManTinh
                               FROM HoSoBenhAn";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHoSoBenhAn.DataSource = dt;
            }
        }

        // ================= LƯU =================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO HoSoBenhAn
                               (MaBenhNhan, MaPhieuKham, NgayTao, NgayCapNhat,
                                TienSuBenh, DiUng, TienSuGiaDinh, BenhManTinh)
                               VALUES
                               (@MaBenhNhan,@MaPhieuKham,@NgayTao,@NgayCapNhat,
                                @TienSuBenh,@DiUng,@TienSuGiaDinh,@BenhManTinh)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBenhNhan", txtBenhNhanID.Text);
                cmd.Parameters.AddWithValue("@MaPhieuKham", txtPhieuKhamID.Text);
                cmd.Parameters.AddWithValue("@NgayTao", dtpNgayTao.Value);
                cmd.Parameters.AddWithValue("@NgayCapNhat", dtpNgayCapNhat.Value);
                cmd.Parameters.AddWithValue("@TienSuBenh", txtTienSuBenh.Text);
                cmd.Parameters.AddWithValue("@DiUng", txtDiUng.Text);
                cmd.Parameters.AddWithValue("@TienSuGiaDinh", txtTienSuGiaDinh.Text);
                cmd.Parameters.AddWithValue("@BenhManTinh", txtBenhManTinh.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadHoSoBenhAn();
            ClearForm();
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE HoSoBenhAn SET
                                MaBenhNhan=@MaBenhNhan,
                                MaPhieuKham=@MaPhieuKham,
                                NgayTao=@NgayTao,
                                NgayCapNhat=@NgayCapNhat,
                                TienSuBenh=@TienSuBenh,
                                DiUng=@DiUng,
                                TienSuGiaDinh=@TienSuGiaDinh,
                                BenhManTinh=@BenhManTinh
                               WHERE MaHoSo=@MaHoSo";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHoSo", txtHoSoID.Text);
                cmd.Parameters.AddWithValue("@MaBenhNhan", txtBenhNhanID.Text);
                cmd.Parameters.AddWithValue("@MaPhieuKham", txtPhieuKhamID.Text);
                cmd.Parameters.AddWithValue("@NgayTao", dtpNgayTao.Value);
                cmd.Parameters.AddWithValue("@NgayCapNhat", dtpNgayCapNhat.Value);
                cmd.Parameters.AddWithValue("@TienSuBenh", txtTienSuBenh.Text);
                cmd.Parameters.AddWithValue("@DiUng", txtDiUng.Text);
                cmd.Parameters.AddWithValue("@TienSuGiaDinh", txtTienSuGiaDinh.Text);
                cmd.Parameters.AddWithValue("@BenhManTinh", txtBenhManTinh.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadHoSoBenhAn();
        }

        // ================= XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoSoBenhAn.CurrentRow == null) return;

            int maHoSo = Convert.ToInt32(dgvHoSoBenhAn.CurrentRow.Cells["MaHoSo"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM HoSoBenhAn WHERE MaHoSo=@MaHoSo", conn);
                cmd.Parameters.AddWithValue("@MaHoSo", maHoSo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadHoSoBenhAn();
        }

        // ================= CLICK GRID =================
        private void dgvHoSoBenhAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvHoSoBenhAn.Rows[e.RowIndex];

            txtHoSoID.Text = r.Cells["MaHoSo"].Value.ToString();
            txtBenhNhanID.Text = r.Cells["MaBenhNhan"].Value.ToString();
            txtPhieuKhamID.Text = r.Cells["MaPhieuKham"].Value.ToString();
            txtTienSuBenh.Text = r.Cells["TienSuBenh"].Value.ToString();
            txtDiUng.Text = r.Cells["DiUng"].Value.ToString();
            txtTienSuGiaDinh.Text = r.Cells["TienSuGiaDinh"].Value.ToString();
            txtBenhManTinh.Text = r.Cells["BenhManTinh"].Value.ToString();
            dtpNgayTao.Value = Convert.ToDateTime(r.Cells["NgayTao"].Value);
            dtpNgayCapNhat.Value = Convert.ToDateTime(r.Cells["NgayCapNhat"].Value);
        }

        // ================= CLEAR =================
        private void ClearForm()
        {
            txtHoSoID.Clear();
            txtBenhNhanID.Clear();
            txtPhieuKhamID.Clear();
            txtTienSuBenh.Clear();
            txtDiUng.Clear();
            txtTienSuGiaDinh.Clear();
            txtBenhManTinh.Clear();
            dtpNgayTao.Value = DateTime.Now;
            dtpNgayCapNhat.Value = DateTime.Now;
        }
    }
}
