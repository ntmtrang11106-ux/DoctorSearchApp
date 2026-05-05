using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DAL_Tier
{
    public static class DbSeeder
    {
        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();
        }

        public static void Seed(AppDbContext context, bool force = false)
        {
            if (force)
                context.Database.EnsureDeleted();

            context.Database.Migrate();

            // 1. Departments
            var departments = new[] {
                new DepartmentDTO { DepartmentName = "Nội khoa", Description = "Khám và điều trị nội khoa", DisplayOrder = 1, IsActive = true, CreatedAt = DateTime.Now },
                new DepartmentDTO { DepartmentName = "Tim mạch", Description = "Khám chuyên khoa tim mạch", DisplayOrder = 2, IsActive = true, CreatedAt = DateTime.Now },
                new DepartmentDTO { DepartmentName = "Nhi khoa", Description = "Khám cho trẻ em", DisplayOrder = 3, IsActive = true, CreatedAt = DateTime.Now },
                new DepartmentDTO { DepartmentName = "Da liễu", Description = "Khám bệnh về da", DisplayOrder = 4, IsActive = true, CreatedAt = DateTime.Now }
            };

            foreach (var dep in departments)
            {
                if (!context.Departments.Any(d => d.DepartmentName == dep.DepartmentName))
                {
                    context.Departments.Add(dep);
                }
            }
            context.SaveChanges();
            
            var depList = context.Departments.OrderBy(d => d.Id).ToList();

            // 2. Rooms
            var rooms = new[] {
                new RoomDTO { RoomCode = "P101", RoomName = "Phòng khám 101", Floor = "1", DepartmentId = depList[0].Id },
                new RoomDTO { RoomCode = "P201", RoomName = "Phòng khám 201", Floor = "2", DepartmentId = depList[0].Id },
                new RoomDTO { RoomCode = "P301", RoomName = "Phòng khám 301", Floor = "3", DepartmentId = depList[2].Id }
            };

            foreach (var room in rooms)
            {
                if (!context.Rooms.Any(r => r.RoomCode == room.RoomCode))
                {
                    context.Rooms.Add(room);
                }
            }
            context.SaveChanges();
            
            var roomList = context.Rooms.OrderBy(r => r.Id).ToList();

            // 3. Admin user
            if (!context.Users.Any(u => u.Role == "Admin" && u.PhoneNumber == "000"))
            {
                var adminUser = new UserDTO
                {
                    FullName = "Admin Hệ Thống",
                    Role = "Admin",
                    PhoneNumber = "000",
                    Password = HashPassword("123"),
                    Gender = "Nam",
                    Status = "Active",
                    CCCD = "999999999999",
                    Residential_Address = "Đà Nẵng",
                    CreatedAt = DateTime.Now
                };
                context.Users.Add(adminUser);
                context.SaveChanges();

                context.Admins.Add(new AdminDTO { UserId = adminUser.Id, Position = "Quản trị hệ thống", IsActive = true, CreatedAt = DateTime.Now });
                context.SaveChanges();
            }
            var admin = context.Admins.First();

            // 4. Doctors 
            string[] docNames = { "BS. Nguyễn Văn An", "BS. Lê Thị Mỹ Hạnh", "BS. Trần Thành Nhân", "BS. Phạm Minh Tuấn" };
            for (int i = 0; i < docNames.Length; i++)
            {
                string phone = $"090{i}";
                if (!context.Users.Any(u => u.PhoneNumber == phone))
                {
                    var user = new UserDTO 
                    {
                        FullName = docNames[i],
                        Role = "Doctor",
                        PhoneNumber = phone,
                        Password = HashPassword("123"),
                        Gender = i % 2 == 0 ? "Nam" : "Nữ",
                        Status = "Active",
                        CCCD = $"10000000000{i}",
                        Residential_Address = "Đà Nẵng",
                        Dob = new DateTime(1985 + i, 1, 1),
                        CreatedAt = DateTime.Now
                    };
                    context.Users.Add(user);
                    context.SaveChanges();

                    context.Doctors.Add(new DoctorDTO
                    {
                        UserId = user.Id,
                        DepartmentId = depList[i % depList.Count].Id,
                        Position = "Bác sĩ chuyên khoa",
                        LicenseNumber = $"LIC-{user.Id:000}",
                        ConsultationFee = 150000,
                        ExperienceYears = 5 + i,
                        IsApproved = true,
                        IsActive = true,
                        JoinDate = DateTime.Today.AddYears(-2),
                        CreatedAt = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }

            // 5. Patients
            if (!context.Users.Any(u => u.PhoneNumber == "070"))
            {
                var patientUser = new UserDTO 
                {
                    FullName = "Nguyễn Thị Mai Trang",
                    Role = "Patient",
                    PhoneNumber = "070",
                    Password = HashPassword("123"),
                    Gender = "Nữ",
                    Status = "Active",
                    CCCD = "2001",
                    Residential_Address = "Đà Nẵng",
                    Dob = new DateTime(1995, 5, 5),
                    CreatedAt = DateTime.Now
                };
                context.Users.Add(patientUser);
                context.SaveChanges();

                context.Patients.Add(new PatientDTO { UserId = patientUser.Id, CreatedAt = DateTime.Now });
                context.SaveChanges();
            }

            // 6. TimeSlots (Phải có trước Appointment)
            if (!context.TimeSlots.Any())
            {
                var doctors = context.Doctors.ToList();
                foreach (var doc in doctors)
                {
                    context.TimeSlots.Add(new TimeSlotsDTO
                    {
                        DoctorId = doc.Id,
                        RoomId = roomList[doc.Id % roomList.Count].Id,
                        CreatedByAdminId = admin.Id,
                        WorkDate = DateTime.Today.AddDays(1),
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(9, 0, 0),
                        MaxAppointments = 5,
                        Status = "Open"
                    });
                }
                context.SaveChanges();
            }

            // 7. Appointments (Dữ liệu mẫu phong phú hơn)
            if (!context.Appointments.Any())
            {
                var patient = context.Patients.First();
                var doctors = context.Doctors.Include(d => d.User).Include(d => d.Department).ToList();
                var slots = context.TimeSlots.ToList();

                if (doctors.Any() && slots.Any())
                {
                    var appointmentData = new List<AppointmentsDTO>
                    {
                        new AppointmentsDTO
                        {
                            PatientId = patient.Id,
                            DoctorId = doctors[0].Id,
                            TimeSlotId = slots.FirstOrDefault(s => s.DoctorId == doctors[0].Id)?.Id ?? slots[0].Id,
                            Reason = "Khám định kỳ hàng tháng",
                            Status = "Pending",
                            DoctorNameSnapshot = doctors[0].User.FullName,
                            DepartmentNameSnapshot = doctors[0].Department.DepartmentName,
                            FeeSnapshot = doctors[0].ConsultationFee,
                            CreatedAt = DateTime.Now.AddHours(-2)
                        },
                        new AppointmentsDTO
                        {
                            PatientId = patient.Id,
                            DoctorId = doctors[1 % doctors.Count].Id,
                            TimeSlotId = slots.FirstOrDefault(s => s.DoctorId == doctors[1 % doctors.Count].Id)?.Id ?? slots[0].Id,
                            Reason = "Tư vấn sức khỏe tim mạch",
                            Status = "Confirmed",
                            DoctorNameSnapshot = doctors[1 % doctors.Count].User.FullName,
                            DepartmentNameSnapshot = doctors[1 % doctors.Count].Department.DepartmentName,
                            FeeSnapshot = doctors[1 % doctors.Count].ConsultationFee,
                            CreatedAt = DateTime.Now.AddDays(-1)
                        },
                        new AppointmentsDTO
                        {
                            PatientId = patient.Id,
                            DoctorId = doctors[0].Id,
                            TimeSlotId = slots[0].Id,
                            Reason = "Kiểm tra đau dạ dày",
                            Status = "Completed",
                            DoctorNameSnapshot = doctors[0].User.FullName,
                            DepartmentNameSnapshot = doctors[0].Department.DepartmentName,
                            FeeSnapshot = doctors[0].ConsultationFee,
                            CreatedAt = DateTime.Now.AddDays(-5)
                        }
                    };

                    context.Appointments.AddRange(appointmentData);
                    context.SaveChanges();
                }
            }

            // 8. Contents
            var contents = new[] {
                new ContentDTO
                {
                    AuthorAdminId = admin.Id,
                    Title = "Thông báo thay đổi giờ khám ngày lễ",
                    Summary = "Bệnh viện điều chỉnh giờ tiếp nhận bệnh nhân.",
                    Body = "Nội dung thông báo chi tiết...",
                    ContentType = "HospitalNotice",
                    Status = "Published",
                    IsPinned = true,
                    PublishedAt = DateTime.Now
                },
                new ContentDTO
                {
                    DepartmentId = depList[0].Id,
                    AuthorAdminId = admin.Id,
                    Title = "Hướng dẫn khám Nội khoa",
                    Summary = "Quy trình thăm khám tại khoa Nội.",
                    Body = "Nội dung hướng dẫn chi tiết...",
                    ContentType = "DepartmentGuide",
                    Status = "Published",
                    PublishedAt = DateTime.Now
                }
            };

            foreach (var content in contents)
            {
                if (!context.Contents.Any(c => c.Title == content.Title))
                {
                    context.Contents.Add(content);
                }
            }
            context.SaveChanges();

            // 9. Reviews (Test data)
            if (!context.Reviews.Any())
            {
                var patient = context.Patients.First();
                var doctors = context.Doctors.ToList();

                if (doctors.Count >= 2)
                {
                    var reviews = new List<ReviewsDTO>
                    {
                        new ReviewsDTO { PatientId = patient.Id, DoctorId = doctors[0].Id, Rating = 5, Comment = "Bác sĩ rất nhiệt tình và chuyên nghiệp!", CreatedAt = DateTime.Now.AddDays(-10) },
                        new ReviewsDTO { PatientId = patient.Id, DoctorId = doctors[0].Id, Rating = 4, Comment = "Khám kỹ, tư vấn tận tâm.", CreatedAt = DateTime.Now.AddDays(-5) },
                        new ReviewsDTO { PatientId = patient.Id, DoctorId = doctors[1].Id, Rating = 5, Comment = "Rất hài lòng với dịch vụ.", CreatedAt = DateTime.Now.AddDays(-2) }
                    };

                    context.Reviews.AddRange(reviews);
                    context.SaveChanges();

                    // Update Doctor ratings snapshot
                    foreach (var doc in doctors)
                    {
                        var docReviews = context.Reviews.Where(r => r.DoctorId == doc.Id && !r.IsDeleted).ToList();
                        if (docReviews.Any())
                        {
                            doc.TotalReviews = docReviews.Count;
                            doc.AverageRating = docReviews.Average(r => r.Rating);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}