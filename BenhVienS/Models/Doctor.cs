using System;

namespace BenhVienS.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string Degree { get; set; }
        public string Specialty { get; set; }
        public int YearsOfExperience { get; set; }
        public byte Rating { get; set; }
        public int Status { get; set; }

        // Parameterless constructor
        public Doctor()
        {

        }

        // Full constructor
        public Doctor(
            int Id,
            int userId,
            int departmentId,
            string degree,
            string specialty,
            int yearsOfExperience,
            byte rating,
            int status)
        {
            Id = Id;
            UserId = userId;
            DepartmentId = departmentId;
            Degree = degree;
            Specialty = specialty;
            YearsOfExperience = yearsOfExperience;
            Rating = rating;
            Status = status;
        }
    }
}
