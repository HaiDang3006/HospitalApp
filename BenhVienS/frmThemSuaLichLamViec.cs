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
    public partial class frmThemSuaLichLamViec : Form
    {
        int _maLichLamViec = 0;

        string connStr = ConfigurationManager
            .ConnectionStrings["BenhVienV1ConnectionString"]
            .ConnectionString;
        public frmThemSuaLichLamViec()
        {
            InitializeComponent();
        }

        public frmThemSuaLichLamViec(int maLichLamViec)
        {
            InitializeComponent();
            _maLichLamViec = maLichLamViec;
        }


        private void frmThemSuaLichLamViec_Load(object sender, EventArgs e)
        {
            LoadBacSi();
            LoadPhong();
            LoadCa();

            if (_maLichLamViec != 0)
                LoadChiTiet();
        }

        void LoadBacSi()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT 
                bs.MaBacSi,
                nd.HoTen AS TenBacSi
            FROM BacSi bs
            JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
            WHERE bs.TrangThai = 1
        ", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbobacsi.DataSource = dt;
                cbobacsi.DisplayMember = "TenBacSi";
                cbobacsi.ValueMember = "MaBacSi";
                cbobacsi.SelectedIndex = -1;
            }
        }

        void LoadPhong()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MaPhong, TenPhong FROM PhongKham", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbophon.DataSource = dt;
                cbophon.DisplayMember = "TenPhong";
                cbophon.ValueMember = "MaPhong";
                cbophon.SelectedIndex = -1;
            }
        }

        void LoadCa()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MaCa, TenCa FROM CaLamViec", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboCa.DataSource = dt;
                cboCa.DisplayMember = "TenCa";
                cboCa.ValueMember = "MaCa";
            }
        }

        void LoadChiTiet()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM LichLamViec WHERE MaLichLamViec=@Ma", conn);
                cmd.Parameters.AddWithValue("@Ma", _maLichLamViec);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    cbobacsi.SelectedValue = rd["MaBacSi"];
                    cbophon.SelectedValue = rd["MaPhong"];
                    cboCa.SelectedValue = rd["MaCa"];
                    dtpNgayLamViec.Value = Convert.ToDateTime(rd["NgayLamViec"]);
                    cbotrangthai.Checked = rd["TrangThai"].ToString() == "SanSang";
                }
            }

            this.Text = "Sửa lịch làm việc";
            btLuu.Text = "Cập nhật";
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd;

                if (_maLichLamViec == 0)
                {
                    cmd = new SqlCommand(@"
                INSERT INTO LichLamViec
                (MaBacSi, MaPhong, MaCa, NgayLamViec, TrangThai)
                VALUES
                (@BacSi,@Phong,@Ca,@Ngay,@TrangThai)", conn);
                }
                else
                {
                    cmd = new SqlCommand(@"
                UPDATE LichLamViec SET
                    MaBacSi=@BacSi,
                    MaPhong=@Phong,
                    MaCa=@Ca,
                    NgayLamViec=@Ngay,
                    TrangThai=@TrangThai
                WHERE MaLichLamViec=@Ma", conn);

                    cmd.Parameters.Add("@Ma", SqlDbType.Int).Value = _maLichLamViec;
                }

                cmd.Parameters.Add("@BacSi", SqlDbType.Int)
                    .Value = Convert.ToInt32(cbobacsi.SelectedValue);

                cmd.Parameters.Add("@Phong", SqlDbType.Int)
                    .Value = Convert.ToInt32(cbophon.SelectedValue);

                cmd.Parameters.Add("@Ca", SqlDbType.Int)
                    .Value = Convert.ToInt32(cboCa.SelectedValue);

                cmd.Parameters.Add("@Ngay", SqlDbType.Date)
                    .Value = dtpNgayLamViec.Value.Date;

                string trangThai = cbotrangthai.Checked ? "SanSang" : "Nghi";

                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 20)
                    .Value = trangThai;

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbotrangthai_CheckedChanged(object sender, EventArgs e)
        {
            if (cbotrangthai.Checked)
                cbotrangthai.Text = "Sẵn sàng làm việc";
            else
                cbotrangthai.Text = "Nghỉ";
        }
    }
}
