using System;

namespace BenhVienS.Models
{
    public class ExaminationForm
    {
        public int Id { get; set; }        // MaPhieuKham
        public int AppointmentId { get; set; }        // MaLichHen
        public int DoctorId { get; set; }             // MaBacSi
        public DateTime ExaminationDate { get; set; } // NgayKham

        public string Symptoms { get; set; }          // TrieuChung
        public decimal Height { get; set; }           // ChieuCao
        public decimal Weight { get; set; }           // CanNang
        public decimal Temperature { get; set; }      // NhietDo

        public string BloodPressure { get; set; }     // HuyetAp
        public int HeartRate { get; set; }             // Mach
        public int RespiratoryRate { get; set; }       // NhipTho

        public string PreliminaryDiagnosis { get; set; } // ChanDoanSoBo
        public string Status { get; set; }              // TrangThai

        public ExaminationForm() { }

        public ExaminationForm(
            int Id,
            int appointmentId,
            int doctorId,
            DateTime examinationDate,
            string symptoms,
            decimal height,
            decimal weight,
            decimal temperature,
            string bloodPressure,
            int heartRate,
            int respiratoryRate,
            string preliminaryDiagnosis,
            string status)
        {
            Id = Id;
            AppointmentId = appointmentId;
            DoctorId = doctorId;
            ExaminationDate = examinationDate;
            Symptoms = symptoms;
            Height = height;
            Weight = weight;
            Temperature = temperature;
            BloodPressure = bloodPressure;
            HeartRate = heartRate;
            RespiratoryRate = respiratoryRate;
            PreliminaryDiagnosis = preliminaryDiagnosis;
            Status = status;
        }
    }

}
