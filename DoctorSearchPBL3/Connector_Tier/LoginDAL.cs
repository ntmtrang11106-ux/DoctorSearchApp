using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public UserDTO? CheckLogin(string phone, string password)
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
                userDto.CreatedAt = DateTime.Now;
                userDto.Picture ??= "default.jpg";
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
                    InsuranceCode = string.IsNullOrWhiteSpace(bhyt) ? "N/A" : bhyt,
                    Note = "Chưa có tiền sử"
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
        public bool InsertDoctorFull(int userId, string clinicAddr, string clinicName)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var firstDepartmentId = _context.Departments
                        .Where(d => d.IsActive && !d.IsDeleted)
                        .OrderBy(d => d.DisplayOrder)
                        .Select(d => d.Id)
                        .FirstOrDefault();
                    if (firstDepartmentId == 0)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    var doctor = new DoctorDTO
                    {
                        UserId = userId,
                        DepartmentId = firstDepartmentId,
                        Position = "Bác sĩ",
                        LicenseNumber = null,
                        Biography = string.IsNullOrWhiteSpace(clinicName)
                            ? "Chưa có thông tin"
                            : $"Phòng khám: {clinicName}. Địa chỉ liên hệ: {clinicAddr}",
                        ConsultationFee = 0,
                        ExperienceYears = 0,
                        IsApproved = false,
                        IsActive = true,
                        JoinDate = DateTime.Today
                    };

                    _context.Doctors.Add(doctor);
                    _context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch
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