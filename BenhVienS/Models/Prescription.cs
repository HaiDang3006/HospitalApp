using System;

namespace Hospital.Models
{
    public class Prescription
    {
        // Properties
        public int PrescriptionId { get; set; }   // Prescription ID
        public int ExaminationTicketId { get; set; } // Examination ticket ID
        public int DoctorId { get; set; }         // Doctor ID
        public string DoctorNote { get; set; }    // Doctor's note
        public string Status { get; set; }        // Prescription status (e.g., "Issued", "Not issued", "Completed", etc.)
        public DateTime PrescriptionDate { get; set; } // Date of prescription

        // Parameterless constructor
        public Prescription() { }

        // Full constructor
        public Prescription(int prescriptionId, int examinationTicketId, int doctorId, string doctorNote, string status, DateTime prescriptionDate)
        {
            PrescriptionId = prescriptionId;
            ExaminationTicketId = examinationTicketId;
            DoctorId = doctorId;
            DoctorNote = doctorNote;
            Status = status;
            PrescriptionDate = prescriptionDate;
        }
    }
}
