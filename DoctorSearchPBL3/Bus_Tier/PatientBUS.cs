using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class PatientBUS
    {
        private readonly PatientDAL _patientDAL = new PatientDAL();

        public PatientDTO? GetPatientProfile(int patientId)
        {
            if (patientId <= 0) return null;
            return _patientDAL.GetPatientProfile(patientId);
        }

        public int GetPatientIdByUserId(int userId)
        {
            if (userId <= 0) return 0;
            return _patientDAL.GetPatientIdByUserId(userId);
        }

        public string UpdatePatientProfile(PatientDTO patient)
        {
            // Basic validation
            if (patient == null) return "Dữ liệu không hợp lệ.";
            if (patient.User == null) return "Thông tin người dùng không hợp lệ.";
            
            if (string.IsNullOrWhiteSpace(patient.User.FullName))
                return "Họ tên không được để trống.";
            
            if (string.IsNullOrWhiteSpace(patient.User.PhoneNumber))
                return "Số điện thoại không được để trống.";

            if (patient.User.PhoneNumber.Length < 10)
                return "Số điện thoại không hợp lệ.";

            bool success = _patientDAL.UpdatePatientProfile(patient);
            return success ? "Success" : "Lỗi hệ thống khi cập nhật hồ sơ.";
        }

        public List<AppointmentsDTO> GetPatientAppointments(int patientId)
        {
            if (patientId <= 0) return new List<AppointmentsDTO>();
            return _patientDAL.GetPatientAppointments(patientId);
        }
    }
}