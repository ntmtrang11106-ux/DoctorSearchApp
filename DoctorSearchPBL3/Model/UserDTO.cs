using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Tier
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // 'Admin', 'Doctor', 'Patient'
        public bool Status { get; set; }
    }
}
