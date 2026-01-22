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
    public partial class themdichvu : Form
    {
        int _maDichVu = 0;
        string connStr = ConfigurationManager
    .ConnectionStrings["BenhVienV1ConnectionString"]
    .ConnectionString;

        public themdichvu()
        {
            InitializeComponent();
        }
        public themdichvu(int maDichVu)
        {
            InitializeComponent();
            _maDichVu = maDichVu;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTendichvu.Text))
            {
                MessageBox.Show("Tên dịch vụ không được để trống");
                return;
            }

            if (cboLoaiDichVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd;

                if (_maDichVu == 0)
                {
                    cmd = new SqlCommand(@"
                        INSERT INTO DichVu
                        (TenDichVu, LoaiDichVu, DonGia, ApDungBHYT,
                         MucHuongBHYT, ThoiGianThucHien, MoTa, TrangThai)
                        VALUES
                        (@Ten,@Loai,@Gia,@BHYT,@Muc,@TG,@MoTa,@TT)", conn);
                }
                else
                {
                    cmd = new SqlCommand(@"
                        UPDATE DichVu SET
                            TenDichVu=@Ten,
                            LoaiDichVu=@Loai,
                            DonGia=@Gia,
                            ApDungBHYT=@BHYT,
                            MucHuongBHYT=@Muc,
                            ThoiGianThucHien=@TG,
                            MoTa=@MoTa,
                            TrangThai=@TT
                        WHERE MaDichVu=@Ma", conn);

                    cmd.Parameters.AddWithValue("@Ma", _maDichVu);
                }

                cmd.Parameters.AddWithValue("@Ten", txtTendichvu.Text.Trim());
                cmd.Parameters.AddWithValue("@Loai", cboLoaiDichVu.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtdongia.Text));
                cmd.Parameters.AddWithValue("@BHYT", chbapbhyt.Checked);
                cmd.Parameters.AddWithValue("@Muc",
                    chbapbhyt.Checked ? decimal.Parse(txtmuchuongbhyt.Text) : 0);
                cmd.Parameters.AddWithValue("@TG", (int)nudthoigianthuchien.Value);
                cmd.Parameters.AddWithValue("@MoTa", txtMota.Text);
                cmd.Parameters.AddWithValue("@TT", chbtrangthai.Checked);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void chbdongiadichvu_CheckedChanged(object sender, EventArgs e)
        {
            txtdongia.Enabled = chbdongiadichvu.Checked;
            if (!chbdongiadichvu.Checked) txtdongia.Text = "0";
        }

        private void chbapbhyt_CheckedChanged(object sender, EventArgs e)
        {
            txtmuchuongbhyt.Enabled = chbapbhyt.Checked;
            if (!chbapbhyt.Checked) txtmuchuongbhyt.Text = "0";
        }

        private void themdichvu_Load(object sender, EventArgs e)
        {
            // load combobox 1 lần
            cboLoaiDichVu.Items.Clear();
            cboLoaiDichVu.Items.AddRange(new string[]
            {
                "Kham",
                "XetNghiem",
                "SieuAm",
                "ChupXQuang",
                "NoiSoi",
                "Khac"
            });

            if (_maDichVu == 0)
            {
                chbtrangthai.Checked = true; // mặc định đang áp dụng
                return;
            }

            LoadDichVuSua();
            btluu.Text = "Cập nhật";
            this.Text = "Sửa dịch vụ";
        }
        private void LoadDichVuSua()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM DichVu WHERE MaDichVu=@Ma", conn);
                cmd.Parameters.AddWithValue("@Ma", _maDichVu);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.Read()) return;

                txtTendichvu.Text = rd["TenDichVu"].ToString();
                cboLoaiDichVu.SelectedItem = rd["LoaiDichVu"].ToString();
                txtdongia.Text = rd["DonGia"].ToString();

                chbapbhyt.Checked = rd["ApDungBHYT"] != DBNull.Value
                    && Convert.ToBoolean(rd["ApDungBHYT"]);

                txtmuchuongbhyt.Text = rd["MucHuongBHYT"] == DBNull.Value
                    ? "0"
                    : rd["MucHuongBHYT"].ToString();

                nudthoigianthuchien.Value = rd["ThoiGianThucHien"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(rd["ThoiGianThucHien"]);

                txtMota.Text = rd["MoTa"] == DBNull.Value ? "" : rd["MoTa"].ToString();

                chbtrangthai.Checked = rd["TrangThai"] != DBNull.Value
                    && Convert.ToBoolean(rd["TrangThai"]);
            }

        }


    }
}
