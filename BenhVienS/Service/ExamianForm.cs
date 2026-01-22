using System;

namespace BenhVienS.Models
{
    public class ExaminationForm
    {
        public int Id { get; set; }              // MaPhieuKham
        public int AppointmentId { get; set; }   // MaLichHen
        public string Diagnosis { get; set; }    // ChanDoan
        public string Advice { get; set; }       // LoiKhuyen
        public DateTime ExamDate { get; set; }   // NgayKham

        // Constructor không tham số
        public ExaminationForm()
        {
        }

        // Constructor đầy đủ
        public ExaminationForm(
            int id,
            int appointmentId,
            string diagnosis,
            string advice,
            DateTime examDate)
        {
            Id = id;
            AppointmentId = appointmentId;
            Diagnosis = diagnosis;
            Advice = advice;
            ExamDate = examDate;
        }
    }
}
