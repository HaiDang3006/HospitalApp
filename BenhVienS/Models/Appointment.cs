using System;

namespace BenhVienS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int WorkScheduleId { get; set; }
        public DateTime DateAppointment { get; set; }
        public string Reasion { get; set; }
        public int ReceptionId { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }

        // hinh thuc dat
        private int _orderType;
        public int OrderType
        {
            get => _orderType;
            set => _orderType = value;
        }

        // trang thai
        private int _status;
        public int Status
        {
            get => _status;
            set => _status = value;
        }

        public Appointment()
        {
        }

        public Appointment(
            int id,
            int patientId,
            int doctorId,
            int workScheduleId,
            DateTime dateAppointment,
            string reasion,
            int receptionId,
            string note,
            DateTime createDate,
            int orderType,
            int status)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            WorkScheduleId = workScheduleId;
            DateAppointment = dateAppointment;
            Reasion = reasion;
            ReceptionId = receptionId;
            Note = note;
            CreateDate = createDate;
            _orderType = orderType;
            _status = status;
        }

        // giữ nguyên logic cũ
        public void SetOrderType(string type)
        {
            if (type == "online")
                _orderType = 0;
            else if (type == "ofline")
                _orderType = 1;
            else
                _orderType = 0;
        }

        public void SetStatus(string type)
        {
            if (type == "DaDat")
                _status = 0;
            else if (type == "ChoXacNhan")
                _status = 1;
            else if (type == "XacNhan")
                _status = 2;
            else if (type == "DaDen")
                _status = 3;
            else
                _status = 4;
        }

        public string GetStatusMap()
        {
            switch (_status)
            {
                case 0:
                    return "DaDat";
                case 1:
                    return "ChoXacNhan";
                case 2:
                    return "XacNhan";
                case 3:
                    return "DaDen";
                default:
                    return "Huy";
            }
        }

    }
}
