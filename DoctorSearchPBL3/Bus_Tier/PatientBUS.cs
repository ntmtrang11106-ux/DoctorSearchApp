using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BUS_Tier
{
    public class PatientBUS
    {
        private readonly PatientDAL _patientDAL = new PatientDAL();
        private readonly UserDAL _userDAL = new UserDAL();
        private readonly UserBUS _userBUS = new UserBUS();

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
            var errors = CollectPatientProfileErrors(patient);
            if (errors.Count > 0) return FormatValidationErrors(errors);

            bool success = _patientDAL.UpdatePatientProfile(patient);
            return success ? "Success" : "Lỗi hệ thống khi cập nhật hồ sơ.";
        }

        private List<string> CollectPatientProfileErrors(PatientDTO patient)
        {
            var errors = new List<string>();
            if (patient == null || patient.User == null)
            {
                errors.Add("Dữ liệu hồ sơ không hợp lệ.");
                return errors;
            }

            patient.User.FullName = NormalizeRequired(patient.User.FullName);
            patient.User.PhoneNumber = NormalizePhone(patient.User.PhoneNumber);
            patient.User.Gender = NormalizeRequired(patient.User.Gender);
            patient.User.CCCD = NormalizeRequired(patient.User.CCCD);
            patient.User.Residential_Address = NormalizeRequired(patient.User.Residential_Address);
            patient.EmergencyContactName = NormalizeRequired(patient.EmergencyContactName);
            patient.EmergencyContactPhone = NormalizePhone(patient.EmergencyContactPhone);
            patient.BloodType = NormalizeRequired(patient.BloodType);
            patient.Note = NormalizeRequired(patient.Note);

            if (string.IsNullOrWhiteSpace(patient.User.FullName))
            {
                errors.Add("Họ tên không được để trống.");
            }
            else
            {
                if (patient.User.FullName.Length < 2 || patient.User.FullName.Length > 100)
                    errors.Add("Họ tên phải từ 2 đến 100 ký tự.");
                if (!Regex.IsMatch(patient.User.FullName, @"^[\p{L}\s'.-]+$"))
                    errors.Add("Họ tên chỉ được chứa chữ cái và khoảng trắng.");
            }

            bool hasValidPhone = false;
            if (string.IsNullOrWhiteSpace(patient.User.PhoneNumber))
            {
                errors.Add("Số điện thoại không được để trống.");
            }
            else if (!IsValidPhone(patient.User.PhoneNumber))
            {
                errors.Add("Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng 0.");
            }
            else
            {
                hasValidPhone = true;
            }

            if (hasValidPhone && _userDAL.IsPhoneExists(patient.User.PhoneNumber, patient.UserId))
                errors.Add("Số điện thoại này đã được sử dụng bởi tài khoản khác.");

            if (patient.User.Dob == null)
            {
                errors.Add("Ngày sinh không được để trống.");
            }
            else if (patient.User.Dob.Value.Date > DateTime.Now.Date)
            {
                errors.Add("Ngày sinh không hợp lệ.");
            }
            else
            {
                int age = _userBUS.CalculateAge(patient.User.Dob.Value);
                bool hasUnderAgeCccdText = patient.User.CCCD == "Chưa đủ tuổi";
                if (age < 16)
                {
                    if (!string.IsNullOrWhiteSpace(patient.User.CCCD) && !hasUnderAgeCccdText)
                        errors.Add("Bệnh nhân dưới 16 tuổi không được nhập CCCD.");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(patient.User.CCCD) || hasUnderAgeCccdText)
                        errors.Add("Bệnh nhân từ 16 tuổi trở lên bắt buộc nhập CCCD.");
                    else if (!IsValidCccd(patient.User.CCCD))
                        errors.Add("Số CCCD phải gồm đúng 12 chữ số.");
                }
            }

            if (string.IsNullOrWhiteSpace(patient.User.Gender))
                errors.Add("Vui lòng nhập giới tính.");
            else if (!IsValidGender(patient.User.Gender))
                errors.Add("Giới tính chỉ nhận Nam hoặc Nữ.");

            if (string.IsNullOrWhiteSpace(patient.User.Residential_Address))
            {
                errors.Add("Địa chỉ không được để trống.");
            }
            else
            {
                if (patient.User.Residential_Address.Length < 5 || patient.User.Residential_Address.Length > 255)
                    errors.Add("Địa chỉ phải từ 5 đến 255 ký tự.");
                if (ContainsControlCharacter(patient.User.Residential_Address))
                    errors.Add("Địa chỉ chứa ký tự không hợp lệ.");
            }

            if (!string.IsNullOrWhiteSpace(patient.EmergencyContactName) && patient.EmergencyContactName.Length > 100)
                errors.Add("Tên liên hệ khẩn cấp không được vượt quá 100 ký tự.");

            if (!string.IsNullOrWhiteSpace(patient.EmergencyContactPhone) && !IsValidPhone(patient.EmergencyContactPhone))
                errors.Add("Số điện thoại liên hệ khẩn cấp phải gồm đúng 10 chữ số và bắt đầu bằng 0.");

            if (!string.IsNullOrWhiteSpace(patient.BloodType)
                && !Regex.IsMatch(patient.BloodType, @"^(A|B|AB|O)[+-]?$", RegexOptions.IgnoreCase))
                errors.Add("Nhóm máu chỉ nhận A, B, AB, O và có thể kèm dấu + hoặc -.");

            if (!string.IsNullOrWhiteSpace(patient.Note) && patient.Note.Length > 2000)
                errors.Add("Tiền sử bệnh không được vượt quá 2000 ký tự.");

            return errors;
        }

        public List<AppointmentsDTO> GetPatientAppointments(int patientId)
        {
            if (patientId <= 0) return new List<AppointmentsDTO>();
            return _patientDAL.GetPatientAppointments(patientId);
        }

        private static string NormalizePhone(string? value)
        {
            value = (value ?? "").Trim();
            value = value.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "");

            if (value.StartsWith("+84")) value = "0" + value.Substring(3);
            else if (value.StartsWith("84") && value.Length == 11) value = "0" + value.Substring(2);

            return value;
        }

        private static string NormalizeRequired(string? value)
            => Regex.Replace((value ?? "").Trim(), @"\s+", " ");

        private static bool IsValidPhone(string phone)
            => Regex.IsMatch(phone, @"^0\d{9}$");

        private static bool IsValidCccd(string cccd)
            => Regex.IsMatch(cccd, @"^\d{12}$");

        private static bool IsValidGender(string gender)
            => gender == "Nam" || gender == "Nữ";

        private static bool ContainsControlCharacter(string value)
            => value.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n' && ch != '\t');

        private static string FormatValidationErrors(List<string> errors)
            => errors.Count == 0 ? "OK" : "Vui lòng kiểm tra lại:\n- " + string.Join("\n- ", errors.Distinct());
    }
}
