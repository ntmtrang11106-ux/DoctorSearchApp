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

        private readonly UserDAL _userDAL = new UserDAL();
        private readonly UserBUS _userBUS = new UserBUS();

        public string UpdatePatientProfile(PatientDTO patient)
        {
            // 1. Basic validation
            if (patient == null || patient.User == null) return "Dữ liệu không hợp lệ.";
            
            if (string.IsNullOrWhiteSpace(patient.User.FullName))
                return "Họ tên không được để trống.";
            
            // 2. Validate Phone
            string phone = patient.User.PhoneNumber?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(phone))
                return "Số điện thoại không được để trống.";
            if (phone.Length < 10)
                return "Số điện thoại chính phải đủ 10 số.";

            // Kiểm tra trùng SĐT (trừ chính mình)
            if (_userDAL.IsPhoneExists(phone, patient.UserId))
                return "Số điện thoại này đã được sử dụng bởi tài khoản khác.";

            // 3. Validate Emergency Phone (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(patient.EmergencyContactPhone))
            {
                if (patient.EmergencyContactPhone.Trim().Length < 10)
                    return "Số điện thoại liên hệ khẩn cấp phải đủ 10 số.";
            }

            // 4. Validate Age & CCCD (Giống Register)
            if (patient.User.Dob.HasValue)
            {
                int age = _userBUS.CalculateAge(patient.User.Dob.Value);
                if (age < 16)
                {
                    // Nếu dưới 16 mà lại có nhập CCCD (khác chuỗi thông báo)
                    if (!string.IsNullOrWhiteSpace(patient.User.CCCD) && patient.User.CCCD != "Chưa đủ tuổi")
                        return "Bệnh nhân chưa đủ 16 tuổi, không được nhập CCCD.";
                }
                else
                {
                    // Nếu từ 16 trở lên mà để trống CCCD
                    if (string.IsNullOrWhiteSpace(patient.User.CCCD) || patient.User.CCCD == "Chưa đủ tuổi")
                        return "Bệnh nhân từ 16 tuổi trở lên vui lòng nhập CCCD.";
                }
            }

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