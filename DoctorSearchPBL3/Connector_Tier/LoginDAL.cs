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

        public bool InsertDoctorFull(int userId, string clinicAddr, string clinicName,
            int? locationId, List<DoctorSpecialtyDTO> listCerts, int totalExp) // Thêm tham số totalExp
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tạo đối tượng Doctor và gán tổng thâm niên từ BUS truyền xuống
                    var doctor = new DoctorDTO
                    {
                        UserId = userId,
                        // Kiểm tra null/trống ngay tại đây để tránh lỗi DB
                        ClinicAddress = string.IsNullOrWhiteSpace(clinicAddr) ? "Chưa cập nhật" : clinicAddr,
                        ClinicName = string.IsNullOrWhiteSpace(clinicName) ? "Phòng khám tư nhân" : clinicName,
                        Bio = "Chưa có thông tin",
                        Price = 0,
                        WorkingTime = "Chưa cập nhật",
                        LocationId = locationId,
                        IsApproved = false,
                        // Sử dụng giá trị tổng (Sum) đã tính ở tầng BUS
                        ExperienceSummary = totalExp
                    };

                    _context.Doctors.Add(doctor);
                    _context.SaveChanges(); // Lưu để lấy doctor.Id

                    // 2. Lưu danh sách chứng chỉ chi tiết vào bảng Doctor_Specialty
                    if (listCerts != null && listCerts.Any())
                    {
                        foreach (var certDto in listCerts)
                        {
                            // Chuyển đổi DTO sang Entity nếu cần (hoặc dùng trực tiếp nếu đã khớp)
                            // Gán Id của Doctor vừa tạo cho từng chứng chỉ
                            certDto.DoctorId = doctor.Id;

                            _context.DoctorSpecialties.Add(certDto);
                        }
                        _context.SaveChanges();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có bất kỳ lỗi nào, hoàn tác toàn bộ (không tạo User lửng lơ)
                    transaction.Rollback();
                    // Bạn có thể log lỗi ex tại đây nếu cần
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