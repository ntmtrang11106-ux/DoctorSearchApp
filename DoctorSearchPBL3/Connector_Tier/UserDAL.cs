using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL_Tier
{
    public class UserDAL
    {
        private readonly AppDbContext _context;

        public UserDAL() => _context = new AppDbContext();
        public UserDAL(AppDbContext context) => _context = context;

        /// <summary>
        /// Hàm dùng chung để khởi tạo thông tin User
        /// </summary>
        private void RegisterUserCommon(UserDTO userDto)
        {
            //userDto.Status = "Active";
            userDto.CreatedAt = DateTime.Now;
            userDto.IsDeleted = false;

            _context.Users.Add(userDto);
            _context.SaveChanges();
        }

        /// <summary>
        /// Đăng ký Bệnh nhân (Khớp với ô Mã số BHYT trên ảnh)
        /// </summary>
        public bool RegisterPatient(UserDTO userDto, string? insuranceCode)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                userDto.Role = "Patient";
                userDto.Status = "Active";
                RegisterUserCommon(userDto);

                var patient = new PatientDTO
                {
                    UserId = userDto.Id,
                    InsuranceCode = string.IsNullOrWhiteSpace(insuranceCode) ? null : insuranceCode,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };

                _context.Patients.Add(patient);
                _context.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }

        /// <summary>
        /// Đăng ký Bác sĩ (Thêm clinicName lưu vào cột Position)
        /// </summary>
        // Thêm tham số licenseNumber vào đầu hàm
        public bool RegisterDoctor(UserDTO userDto, int deptId, int exp, string clinicName, string licenseNumber)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                userDto.Role = "Doctor";
                userDto.Status = "False";

                // Bước 1: Lưu thông tin User chung
                // Đảm bảo hàm này có gọi _context.Users.Add(user) và _context.SaveChanges()
                RegisterUserCommon(userDto);

                // Bước 2: Tạo đối tượng Doctor
                var doctor = new DoctorDTO
                {
                    UserId = userDto.Id, // Lúc này Id đã được EF Core tự cập nhật sau khi SaveChanges ở trên
                    DepartmentId = deptId,
                    ExperienceYears = exp,
                    Position = clinicName,
                    LicenseNumber = licenseNumber, // Nhớ gán mã giấy phép ở đây!
                    ConsultationFee = 0,
                    IsApproved = false,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    JoinDate = DateTime.Now,
                    IsDeleted = false
                };

                // Bước 3: Lưu thông tin Doctor
                _context.Doctors.Add(doctor);
                _context.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                // Bạn có thể log lỗi ex ở đây để biết tại sao nó fail (ví dụ: lỗi khóa ngoại, trùng dữ liệu...)
                return false;
            }
        }

        public bool IsPhoneExists(string phone)
            => _context.Users.Any(u => u.PhoneNumber == phone && !u.IsDeleted);

        public UserDTO? CheckLogin(string phone, string pass)
        {
            // Nó sẽ trả về cả đối tượng User, trong đó có chứa Id
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.PhoneNumber == phone
                                  && u.Password == pass
                                  && !u.IsDeleted
                                  && u.Status == "Active");
        }
    }
}