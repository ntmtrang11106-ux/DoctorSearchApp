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
            const int saltSize = 16;
            const int keySize = 32;
            const int iterations = 10000;

            byte[] salt = RandomNumberGenerator.GetBytes(saltSize);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(keySize);

            byte[] combinedBytes = new byte[saltSize + keySize];
            Array.Copy(salt, 0, combinedBytes, 0, saltSize);
            Array.Copy(hash, 0, combinedBytes, saltSize, keySize);

            return Convert.ToBase64String(combinedBytes);
        }

        public static void Seed(AppDbContext context, bool force = false)
        {
            if (force)
            {
                context.Database.EnsureDeleted();
            }

            context.Database.Migrate();

            SeedDepartments(context);
            SeedRooms(context);
            SeedAdmin(context);
            SeedDoctors(context);
            SeedPatient(context);
            SeedTimeSlots(context);
            SeedAppointments(context);
            SeedContents(context);
            SeedReviews(context);
        }

        private static void SeedDepartments(AppDbContext context)
        {
            var departments = new[]
            {
                new DepartmentDTO { DepartmentName = "Nội khoa", Description = "Khám và điều trị nội khoa", DisplayOrder = 1, IsActive = true, CreatedAt = DateTime.Now },
                new DepartmentDTO { DepartmentName = "Tim mạch", Description = "Khám chuyên khoa tim mạch", DisplayOrder = 2, IsActive = true, CreatedAt = DateTime.Now },
                new DepartmentDTO { DepartmentName = "Nhi khoa", Description = "Khám cho trẻ em", DisplayOrder = 3, IsActive = true, CreatedAt = DateTime.Now },
                new DepartmentDTO { DepartmentName = "Da liễu", Description = "Khám bệnh về da", DisplayOrder = 4, IsActive = true, CreatedAt = DateTime.Now }
            };

            foreach (var department in departments)
            {
                if (!context.Departments.Any(d => d.DepartmentName == department.DepartmentName))
                {
                    context.Departments.Add(department);
                }
            }

            context.SaveChanges();
        }

        private static void SeedRooms(AppDbContext context)
        {
            var depList = context.Departments.OrderBy(d => d.Id).ToList();
            if (depList.Count < 4)
            {
                return;
            }

            var rooms = new[]
            {
                new RoomDTO { RoomCode = "P101", RoomName = "Phòng khám Nội khoa 1", DepartmentId = depList[0].Id, IsActive = true, CreatedAt = DateTime.Now },
                new RoomDTO { RoomCode = "P102", RoomName = "Phòng khám Nội khoa 2", DepartmentId = depList[0].Id, IsActive = true, CreatedAt = DateTime.Now },
                new RoomDTO { RoomCode = "P201", RoomName = "Phòng khám Tim mạch", DepartmentId = depList[1].Id, IsActive = true, CreatedAt = DateTime.Now },
                new RoomDTO { RoomCode = "P301", RoomName = "Phòng khám Nhi khoa", DepartmentId = depList[2].Id, IsActive = true, CreatedAt = DateTime.Now },
                new RoomDTO { RoomCode = "P401", RoomName = "Phòng khám Da liễu", DepartmentId = depList[3].Id, IsActive = true, CreatedAt = DateTime.Now }
            };

            foreach (var room in rooms)
            {
                if (!context.Rooms.Any(r => r.RoomCode == room.RoomCode))
                {
                    context.Rooms.Add(room);
                }
            }

            context.SaveChanges();
        }

        private static void SeedAdmin(AppDbContext context)
        {
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

                context.Admins.Add(new AdminDTO
                {
                    UserId = adminUser.Id,
                    Position = "Quản trị hệ thống",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
                context.SaveChanges();
            }
        }

        private static void SeedDoctors(AppDbContext context)
        {
            var depList = context.Departments.OrderBy(d => d.Id).ToList();
            string[] doctorNames = { "BS. Nguyễn Văn An", "BS. Lê Thị Mỹ Hạnh", "BS. Trần Thành Nhân", "BS. Phạm Minh Tuấn" };

            for (int i = 0; i < doctorNames.Length; i++)
            {
                string phone = $"090{i}";
                if (context.Users.Any(u => u.PhoneNumber == phone))
                {
                    continue;
                }

                var user = new UserDTO
                {
                    FullName = doctorNames[i],
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

        private static void SeedPatient(AppDbContext context)
        {
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

                context.Patients.Add(new PatientDTO
                {
                    UserId = patientUser.Id,
                    CreatedAt = DateTime.Now,
                    BloodType = "O+"
                });
                context.SaveChanges();
            }
        }

        private static void SeedTimeSlots(AppDbContext context)
        {
            if (context.TimeSlots.Any())
            {
                return;
            }

            var admin = context.Admins.First();
            var doctors = context.Doctors
                .Include(d => d.Department)
                .OrderBy(d => d.Id)
                .ToList();
            var rooms = context.Rooms
                .Where(r => !r.IsDeleted && r.IsActive)
                .OrderBy(r => r.Id)
                .ToList();

            var roomByDepartment = rooms
                .GroupBy(r => r.DepartmentId)
                .ToDictionary(g => g.Key, g => g.OrderBy(r => r.Id).ToList());

            var slotsToSeed = new List<TimeSlotsDTO>();

            foreach (var doctor in doctors)
            {
                if (!roomByDepartment.TryGetValue(doctor.DepartmentId, out var departmentRooms) || !departmentRooms.Any())
                {
                    continue;
                }

                var primaryRoom = departmentRooms.First();

                slotsToSeed.Add(new TimeSlotsDTO
                {
                    DoctorId = doctor.Id,
                    RoomId = primaryRoom.Id,
                    CreatedByAdminId = admin.Id,
                    WorkDate = DateTime.Today.AddDays(1),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    MaxAppointments = 5,
                    BookedCount = 0,
                    Status = "Open",
                    IsDeleted = false,
                    CreatedAt = DateTime.Now
                });

                slotsToSeed.Add(new TimeSlotsDTO
                {
                    DoctorId = doctor.Id,
                    RoomId = primaryRoom.Id,
                    CreatedByAdminId = admin.Id,
                    WorkDate = DateTime.Today.AddDays(2),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    MaxAppointments = 5,
                    BookedCount = 0,
                    Status = "Open",
                    IsDeleted = false,
                    CreatedAt = DateTime.Now
                });
            }

            context.TimeSlots.AddRange(slotsToSeed);
            context.SaveChanges();
        }

        private static void SeedAppointments(AppDbContext context)
        {
            if (context.Appointments.Any())
            {
                return;
            }

            var patient = context.Patients.First();
            var doctors = context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .OrderBy(d => d.Id)
                .ToList();
            var slots = context.TimeSlots
                .Include(s => s.Room)
                .OrderBy(s => s.WorkDate)
                .ThenBy(s => s.StartTime)
                .ToList();

            if (!doctors.Any() || !slots.Any())
            {
                return;
            }

            var firstDoctorSlot = slots.FirstOrDefault(s => s.DoctorId == doctors[0].Id && s.WorkDate >= DateTime.Today.AddDays(1));
            var secondDoctorSlot = doctors.Count > 1
                ? slots.FirstOrDefault(s => s.DoctorId == doctors[1].Id && s.WorkDate >= DateTime.Today.AddDays(1))
                : null;
            var thirdDoctorSlot = doctors.Count > 2
                ? slots.FirstOrDefault(s => s.DoctorId == doctors[2].Id && s.WorkDate >= DateTime.Today.AddDays(1))
                : null;

            var appointmentData = new List<AppointmentsDTO>();

            if (firstDoctorSlot != null)
            {
                appointmentData.Add(new AppointmentsDTO
                {
                    PatientId = patient.Id,
                    DoctorId = doctors[0].Id,
                    TimeSlotId = firstDoctorSlot.Id,
                    Reason = "Khám định kỳ hàng tháng",
                    Status = "Pending",
                    DoctorNameSnapshot = doctors[0].User?.FullName,
                    DepartmentNameSnapshot = doctors[0].Department?.DepartmentName,
                    RoomNameSnapshot = firstDoctorSlot.Room?.RoomName,
                    FeeSnapshot = doctors[0].ConsultationFee,
                    CreatedAt = DateTime.Now.AddHours(-2)
                });
            }

            if (secondDoctorSlot != null)
            {
                appointmentData.Add(new AppointmentsDTO
                {
                    PatientId = patient.Id,
                    DoctorId = doctors[1].Id,
                    TimeSlotId = secondDoctorSlot.Id,
                    Reason = "Tư vấn sức khỏe tim mạch",
                    Status = "Confirmed",
                    DoctorNameSnapshot = doctors[1].User?.FullName,
                    DepartmentNameSnapshot = doctors[1].Department?.DepartmentName,
                    RoomNameSnapshot = secondDoctorSlot.Room?.RoomName,
                    FeeSnapshot = doctors[1].ConsultationFee,
                    CreatedAt = DateTime.Now.AddDays(-1)
                });
            }

            if (thirdDoctorSlot != null)
            {
                appointmentData.Add(new AppointmentsDTO
                {
                    PatientId = patient.Id,
                    DoctorId = doctors[2].Id,
                    TimeSlotId = thirdDoctorSlot.Id,
                    Reason = "Kiểm tra đau dạ dày",
                    Status = "Completed",
                    DoctorNameSnapshot = doctors[2].User?.FullName,
                    DepartmentNameSnapshot = doctors[2].Department?.DepartmentName,
                    RoomNameSnapshot = thirdDoctorSlot.Room?.RoomName,
                    FeeSnapshot = doctors[2].ConsultationFee,
                    CreatedAt = DateTime.Now.AddDays(-5),
                    CompletedAt = DateTime.Now.AddDays(-4)
                });
            }

            if (appointmentData.Any())
            {
                context.Appointments.AddRange(appointmentData);
                context.SaveChanges();
            }
        }

        private static void SeedContents(AppDbContext context)
        {
            var admin = context.Admins.First();
            var depList = context.Departments.OrderBy(d => d.Id).ToList();

            var contents = new[]
            {
                new ContentDTO
                {
                    AuthorAdminId = admin.Id,
                    Title = "Thông báo thay đổi giờ khám ngày lễ",
                    Summary = "Bệnh viện điều chỉnh giờ tiếp nhận bệnh nhân.",
                    Body = "Nội dung thông báo chi tiết...",
                    ContentType = "HospitalNotice",
                    Status = "Published",
                    IsPinned = true,
                    PublishedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
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
                    PublishedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
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
        }

        private static void SeedReviews(AppDbContext context)
        {
            if (context.Reviews.Any())
            {
                return;
            }

            var patient = context.Patients.First();
            var doctors = context.Doctors.ToList();

            if (doctors.Count < 2)
            {
                return;
            }

            var reviews = new List<ReviewsDTO>
            {
                new ReviewsDTO { PatientId = patient.Id, DoctorId = doctors[0].Id, Rating = 5, Comment = "Bác sĩ rất nhiệt tình và chuyên nghiệp!", CreatedAt = DateTime.Now.AddDays(-10) },
                new ReviewsDTO { PatientId = patient.Id, DoctorId = doctors[0].Id, Rating = 4, Comment = "Khám kỹ, tư vấn tận tâm.", CreatedAt = DateTime.Now.AddDays(-5) },
                new ReviewsDTO { PatientId = patient.Id, DoctorId = doctors[1].Id, Rating = 5, Comment = "Rất hài lòng với dịch vụ.", CreatedAt = DateTime.Now.AddDays(-2) }
            };

            context.Reviews.AddRange(reviews);
            context.SaveChanges();
        }
    }
}
