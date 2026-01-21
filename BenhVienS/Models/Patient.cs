using System;

namespace BenhVienS.Models
{
    public class Patient
    {
        public int Id { get; set; }              // MaBenhNhan
        public int UserId { get; set; }          // MaNguoiDung
        public string IdentityNumber { get; set; } // SoCCCD
        public string BloodGroup { get; set; }   // NhomMau
        public decimal Weight { get; set; }      // CanNang
        public decimal Height { get; set; }      // ChieuCao
        public string Job { get; set; }           // NgheNghiep
        public bool Status { get; set; }          // TrangThai
        public DateTime RegisterDate { get; set; } // NgayDangKy

        // Parameterless constructor
        public Patient()
        {
        }

        // Full constructor
        public Patient(
            int id,
            int userId,
            string fullName,
            DateTime birthDate,
            string gender,
            string identityNumber,
            string address,
            string phoneNumber,
            string email,
            string bloodGroup,
            decimal weight,
            decimal height,
            string job,
            bool status,
            DateTime registerDate)
        {
            Id = id;
            UserId = userId;
            IdentityNumber = identityNumber;
            BloodGroup = bloodGroup;
            Weight = weight;
            Height = height;
            Job = job;
            Status = status;
            RegisterDate = registerDate;
        }
    }
}
