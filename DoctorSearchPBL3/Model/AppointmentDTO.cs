using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Tier
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Symptoms { get; set; }
        public string Status { get; set; }
        public string AppointmentDate { get; set; } // Ngày khám
        public string TimeRange { get; set; }      // VD: 08:30 - 09:45
        public DateTime CreatedAt { get; set; }
    }
}
