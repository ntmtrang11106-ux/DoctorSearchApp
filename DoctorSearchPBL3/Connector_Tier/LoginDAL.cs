using DTO_Tier;
using Microsoft.EntityFrameworkCore;
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
                userDto.CCCD ??= "";
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
        //public bool InsertDoctorFull(int userId, string allCertCodes, string allCertImages,
        //                            string clinicAddr, string clinicName, string bio,
        //                            int? locationId, List<int> specialtyIds)
        //{
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var doctor = new DoctorDTO
        //            {
        //                UserId = userId,
        //                ClinicAddress = string.IsNullOrWhiteSpace(clinicAddr) ? "Chưa cập nhật" : clinicAddr,
        //                ClinicName = string.IsNullOrWhiteSpace(clinicName) ? "Phòng khám tư nhân" : clinicName,
        //                Bio = string.IsNullOrWhiteSpace(bio) ? "Chưa có thông tin" : bio,
        //                Price = 0,
        //                WorkingTime = "Chưa cập nhật",
        //                LocationId = locationId,
        //                IsApproved = false,
        //                ExperienceSummary = 0
        //            };

        //            _context.Doctors.Add(doctor);
        //            _context.SaveChanges();

        //            if (specialtyIds != null && specialtyIds.Any())
        //            {
        //                foreach (var specId in specialtyIds)
        //                {
        //                    var docSpec = new DoctorSpecialtyDTO
        //                    {
        //                        DoctorId = doctor.Id,
        //                        SpecialtyId = specId,
        //                        CertificateCode = string.IsNullOrWhiteSpace(allCertCodes) ? "" : allCertCodes,
        //                        CertificateImage = string.IsNullOrWhiteSpace(allCertImages) ? "" : allCertImages,
        //                        Experience_Years = 0
        //                    };
        //                    _context.DoctorSpecialties.Add(docSpec);
        //                }
        //                _context.SaveChanges();
        //            }

        //            transaction.Commit();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            Console.WriteLine("Lỗi InsertDoctorFull: " + ex.Message);
        //            return false;
        //        }
        //    }
        //}

        public bool InsertDoctorFull(int userId, string clinicAddr, string clinicName,
                            int? locationId, List<DoctorSpecialtyDTO> listCerts)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tạo đối tượng Doctor
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
                        ExperienceSummary = 0
                    };

                    _context.Doctors.Add(doctor);
                    _context.SaveChanges(); // Lưu để lấy doctor.Id

                    // 2. Lưu danh sách chứng chỉ vào bảng Doctor_Specialty
                    if (listCerts != null && listCerts.Any())
                    {
                        foreach (var cert in listCerts)
                        {
                            cert.DoctorId = doctor.Id; // Gán ID bác sĩ vừa tạo

                            // Các trường CertificateCode, CertificateImage, SpecialtyId, Experience_Years 
                            // đã có sẵn trong object cert do tầng BUS truyền xuống.
                            _context.DoctorSpecialties.Add(cert);
                        }
                        _context.SaveChanges();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Lỗi InsertDoctorFull: " + ex.Message);
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