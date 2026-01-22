using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Models
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public bool DaThanhToan { get; set; }
        public string TrangThaiHoaDon { get; set; }

        public int MaPhieuKham { get; set; }
        public DateTime NgayKham { get; set; }
        public string TrangThaiPhieuKham { get; set; }

        public int MaBenhNhan { get; set; }
        public string TenBenhNhan { get; set; }

    }
}
