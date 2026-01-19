using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Models
{
    public class Appointment
    {
        public int Id { get; set; } 
        public int PatientId { get; set; } // id bệnh nhanâ
        public int DoctorId { get; set; } // id bác sĩ
        public int WorkScheduleId { get; set; } // id lịch làm việc
        public DateTime DateAppointment { get; set; } // ngày đặt lịch
        public string Reasion { get; set; } // lý do chia tay là gì em có biết không vì....
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
        public void SetOrderType(string type)
        {
            if (type == "online")
                _orderType = 0;
            else if (type == "ofline")
                _orderType = 1;
            else
                _orderType = 0;
        }

        // trang thai
        private int _status;
        public int Status
        {
            get => _status;
            set => _status = value;
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
    }
}
