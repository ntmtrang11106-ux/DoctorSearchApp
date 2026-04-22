using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DAL_Tier
{
    public class LoginDAL
    {
        private readonly AppDbContext _context;

        // Cho phép khởi tạo có tham số (Dependency Injection)
        public LoginDAL(AppDbContext context)
        {
            _context = context;
        }

        // Bổ sung khởi tạo mặc định để tránh lỗi ở tầng BUS nếu bạn dùng 'new LoginDAL()'
        public LoginDAL()
        {
            _context = new AppDbContext();
        }

        // 1. Kiểm tra đăng nhập
        public UserDTO CheckLogin(string phone, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.PhoneNumber == phone
                                  && u.Password == password
                                  && u.Status == "Active");
        }

        // 2. Kiểm tra SĐT tồn tại
        public bool IsPhoneExists(string phone)
        {
            return _context.Users.Any(u => u.PhoneNumber == phone);
        }

        // 3. Đăng ký User cơ bản
        public int RegisterUserBasic(UserDTO userDto)
        {
            try
            {
                userDto.Status = (userDto.Role == "Doctor") ? "Pending" : "Active";
                userDto.Created_At = DateTime.Now;
                userDto.Picture ??= "default.jpg";
                //userDto.CCCD ??= "";
                userDto.Residential_Address ??= (string.IsNullOrWhiteSpace(userDto.Residential_Address))
                                        ? "Chưa cập nhật"
                                        : userDto.Residential_Address;
                userDto.Residential_Address ??= "";

                _context.Users.Add(userDto);
                _context.SaveChanges();
                return userDto.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi RegisterUserBasic: " + ex.Message);
                return 0;
            }
        }

        // 4. CHÈN CHI TIẾT BỆNH NHÂN (Hàm bạn đang thiếu)
        public bool InsertPatientFull(int userId, string bhyt)
        {
            try
            {
                var patient = new PatientDTO
                {
                    UserId = userId,
                    BHYT = string.IsNullOrWhiteSpace(bhyt) ? "N/A" : bhyt,
                    Blood_Type = "Chưa cập nhật",
                    Medical_History = "Chưa có tiền sử"
                };

                _context.Patients.Add(patient);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi InsertPatientFull: " + ex.Message);
                return false;
            }
        }

        // 5. Chèn Doctor Full (Có Transaction)
        public bool InsertDoctorFull(int userId, string clinicAddr, string clinicName,
                    int? locationId, List<DoctorSpecialtyDTO> listCerts)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // NGHIỆP VỤ: Lấy thâm niên cao nhất để gán vào bảng Doctor phục vụ Sort
                    int maxExp = 0;
                    if (listCerts != null && listCerts.Any())
                    {
                        // Sử dụng DoctorSpecialtyDTO
                        maxExp = listCerts.Max(c => c.Experience_Years ?? 0);
                    }

                    // 1. Sử dụng DoctorDTO từ file DoctorDTO.cs
                    var doctor = new DoctorDTO
                    {
                        UserId = userId,
                        ClinicAddress = string.IsNullOrWhiteSpace(clinicAddr) ? "Chưa cập nhật" : clinicAddr,
                        ClinicName = string.IsNullOrWhiteSpace(clinicName) ? "Phòng khám tư nhân" : clinicName,
                        Bio = "Chưa có thông tin",
                        Price = 0,
                        WorkingTime = "Chưa cập nhật",
                        LocationId = locationId,
                        IsApproved = false,
                        ExperienceSummary = maxExp // Lưu thâm niên tổng quát
                    };

                    _context.Doctors.Add(doctor);
                    _context.SaveChanges();

                    // 2. Lưu danh sách vào bảng Doctor_Specialty
                    if (listCerts != null && listCerts.Any())
                    {
                        foreach (var certDto in listCerts)
                        {
                            // Sử dụng DoctorSpecialtyDTO khớp với file bạn đã upload
                            certDto.DoctorId = doctor.Id; // Gán ID bác sĩ vừa tạo

                            // Đảm bảo Experience_Years được gán đúng từ DTO xuống DB
                            _context.DoctorSpecialties.Add(certDto);
                        }
                        _context.SaveChanges();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // 6. Xóa User
        public bool DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}