using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS
{
   
    public partial class frmthemvaitromoi : Form
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS02;Initial Catalog=BenhVienV1;Integrated Security=True;";
        public event Action VaiTroDaThayDoi;

        private void LoadDanhSachVaiTro()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT MaVaiTro, TenVaiTro, MoTa, TrangThai FROM VaiTro";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvvaitro.DataSource = dt;
            }
        }

        void ThemVaiTro()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO VaiTro (TenVaiTro, MoTa, TrangThai)
                       VALUES (@Ten, @MoTa, @TrangThai)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Ten", txttenvaitro.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtmota.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cbtrangthai.Checked);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadDanhSachVaiTro();
        }

        void SuaVaiTro()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE VaiTro 
                       SET TenVaiTro=@Ten, MoTa=@MoTa, TrangThai=@TrangThai
                       WHERE MaVaiTro=@Ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Ma", txtmavaitro.Text);
                cmd.Parameters.AddWithValue("@Ten", txttenvaitro.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtmota.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cbtrangthai.Checked);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadDanhSachVaiTro();
        }
        void LamMoi()
        {
            txtmavaitro.Clear();
            txttenvaitro.Clear();
            txtmota.Clear();
            cbtrangthai.Checked = true;
            txttenvaitro.Focus();
        }
        public frmthemvaitromoi()
        {
            InitializeComponent();
                

            ThemVaiTro();

            SuaVaiTro();


        }

        private void frmthemvaitromoi_Load(object sender, EventArgs e)
        {

        }

        private void dgvvaitro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvvaitro.Rows[e.RowIndex];
                txtmavaitro.Text = row.Cells["MaVaiTro"].Value.ToString();
                txttenvaitro.Text = row.Cells["TenVaiTro"].Value.ToString();
                txtmota.Text = row.Cells["MoTa"].Value.ToString();
                cbtrangthai.Checked = (bool)row.Cells["TrangThai"].Value;
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (txtmavaitro.Text == "")
            {
                MessageBox.Show("Vui lòng chọn vai trò cần xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM VaiTro WHERE MaVaiTro=@MaVaiTro";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaVaiTro", txtmavaitro.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDanhSachVaiTro();
            LamMoi();
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trên textbox
            txtmavaitro.Clear();
            txttenvaitro.Clear();
            txtmota.Clear();
            cbtrangthai.Checked = false;

            // Load lại DataGridView
            LoadDanhSachVaiTro();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            if (txttenvaitro.Text.Trim() == "")
            {
                MessageBox.Show("Tên vai trò không được để trống");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO VaiTro (TenVaiTro, MoTa, TrangThai)
                       VALUES (@TenVaiTro, @MoTa, @TrangThai)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenVaiTro", txttenvaitro.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtmota.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cbtrangthai.Checked);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            VaiTroDaThayDoi?.Invoke();
            
            MessageBox.Show("Thêm vai trò thành công");
        }

        private void txtsua_Click(object sender, EventArgs e)
        {
            if (txtmavaitro.Text == "")
            {
                MessageBox.Show("Vui lòng chọn vai trò cần sửa");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE VaiTro
                       SET TenVaiTro = @TenVaiTro,
                           MoTa = @MoTa,
                           TrangThai = @TrangThai
                       WHERE MaVaiTro = @MaVaiTro";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaVaiTro", txtmavaitro.Text);
                cmd.Parameters.AddWithValue("@TenVaiTro", txttenvaitro.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtmota.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cbtrangthai.Checked);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDanhSachVaiTro();
            LamMoi();
            MessageBox.Show("Cập nhật vai trò thành công");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
