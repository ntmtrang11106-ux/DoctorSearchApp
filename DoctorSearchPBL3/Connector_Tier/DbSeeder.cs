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
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new DepartmentDTO { DepartmentName = "Nội khoa", Description = "Khám và điều trị nội khoa", DisplayOrder = 1 },
                    new DepartmentDTO { DepartmentName = "Tim mạch", Description = "Khám chuyên khoa tim mạch", DisplayOrder = 2 },
                    new DepartmentDTO { DepartmentName = "Nhi khoa", Description = "Khám cho trẻ em", DisplayOrder = 3 },
                    new DepartmentDTO { DepartmentName = "Da liễu", Description = "Khám bệnh về da", DisplayOrder = 4 }
                );
                context.SaveChanges();
            }
            var depList = context.Departments.OrderBy(d => d.Id).ToList();

            // 2. Rooms (chỉ một block — block duplicate đã xóa)
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new RoomDTO { RoomCode = "P101", RoomName = "Phòng khám 101", Floor = "1", DepartmentId = depList[0].Id },
                    new RoomDTO { RoomCode = "P201", RoomName = "Phòng khám 201", Floor = "2", DepartmentId = depList[0].Id },
                    new RoomDTO { RoomCode = "P301", RoomName = "Phòng khám 301", Floor = "3", DepartmentId = depList[2].Id }
                );
                context.SaveChanges();
            }

            // 3. Admin user — khai báo sớm để dùng được ở TimeSlots
            if (!context.Users.Any(u => u.Role == "Admin" && u.PhoneNumber == "000"))
            {
                context.Users.Add(new UserDTO
                {
                    FullName = "Admin Hệ Thống",
                    Role = "Admin",
                    PhoneNumber = "000",
                    Password = HashPassword("123"),
                    Gender = "Nam",
                    Status = "Active",
                    CCCD = "999",
                    Residential_Address = "Đà Nẵng"
                });
                context.SaveChanges();
            }

            var adminUser = context.Users.First(u => u.PhoneNumber == "000");
            if (!context.Admins.Any(a => a.UserId == adminUser.Id))
            {
                context.Admins.Add(new AdminDTO { UserId = adminUser.Id, Position = "Quản trị hệ thống" });
                context.SaveChanges();
            }

            // admin được khai báo ở đây — dùng được cho cả TimeSlots lẫn Contents
            var admin = context.Admins.First();

            // 4. Doctors
            var departments = context.Departments.OrderBy(d => d.Id).ToList();
            if (departments.Count == 0)
                throw new InvalidOperationException("Seed failed: Department table is empty.");

            string[] docNames = { "BS. Nguyễn Văn An", "BS. Lê Thị Mỹ Hạnh", "BS. Trần Thành Nhân", "BS. Phạm Minh Tuấn" };
            for (int i = 0; i < docNames.Length; i++)
            {
                string phone = $"090{i}";
                if (!context.Users.Any(u => u.PhoneNumber == phone))
                {
                    context.Users.Add(new UserDTO
                    {
                        FullName = docNames[i],
                        Role = "Doctor",
                        PhoneNumber = phone,
                        Password = HashPassword("123"),
                        Gender = i % 2 == 0 ? "Nam" : "Nữ",
                        Status = "Active",
                        CCCD = $"100{i}",
                        Residential_Address = "Đà Nẵng",
                        Dob = new DateTime(1985 + i, 1, 1)
                    });
                }
            }
            context.SaveChanges();

            var doctorUsers = context.Users.Where(u => u.Role == "Doctor").OrderBy(u => u.Id).ToList();
            for (int i = 0; i < doctorUsers.Count; i++)
            {
                var user = doctorUsers[i];
                if (!context.Doctors.Any(d => d.UserId == user.Id))
                {
                    context.Doctors.Add(new DoctorDTO
                    {
                        UserId = user.Id,
                        DepartmentId = departments[i % departments.Count].Id,
                        Position = "Bác sĩ",
                        LicenseNumber = $"LIC-{user.Id:000}",
                        Biography = "Bác sĩ tận tâm, giàu kinh nghiệm.",
                        ConsultationFee = 150000 + (i * 50000),
                        ExperienceYears = 5 + (i * 3),
                        IsApproved = true,
                        IsActive = true,
                        JoinDate = DateTime.Today.AddYears(-(5 + i))
                    });
                }
            }
            context.SaveChanges();

            // 5. Patients
            if (!context.Users.Any(u => u.PhoneNumber == "070"))
            {
                context.Users.Add(new UserDTO
                {
                    FullName = "Nguyễn Thị Mai Trang",
                    Role = "Patient",
                    PhoneNumber = "070",
                    Password = HashPassword("123"),
                    Gender = "Nữ",
                    Status = "Active",
                    CCCD = "2001",
                    Residential_Address = "Đà Nẵng",
                    Dob = new DateTime(1995, 5, 5)
                });
            }
            if (!context.Users.Any(u => u.PhoneNumber == "077"))
            {
                context.Users.Add(new UserDTO
                {
                    FullName = "Lê Văn Tiến",
                    Role = "Patient",
                    PhoneNumber = "077",
                    Password = HashPassword("123"),
                    Gender = "Nam",
                    Status = "Active",
                    CCCD = "2002",
                    Residential_Address = "Quảng Nam",
                    Dob = new DateTime(1992, 2, 2)
                });
            }
            context.SaveChanges();

            var patientUsers = context.Users.Where(u => u.Role == "Patient").ToList();
            foreach (var user in patientUsers)
            {
                if (!context.Patients.Any(p => p.UserId == user.Id))
                {
                    context.Patients.Add(new PatientDTO
                    {
                        UserId = user.Id,
                        MedicalCode = $"PT-{user.Id:0000}",
                        InsuranceCode = $"BHYT-{user.Id:0000}"
                    });
                }
            }
            context.SaveChanges();

            // 6. TimeSlots — dùng admin.Id đã khai báo ở trên
            if (!context.TimeSlots.Any())
            {
                var doctors = context.Doctors.OrderBy(d => d.Id).ToList();
                var rooms = context.Rooms.OrderBy(r => r.Id).ToList();
                if (rooms.Count == 0)
                    throw new InvalidOperationException("Seed failed: Room table is empty.");

                foreach (var doctor in doctors)
                {
                    context.TimeSlots.Add(new TimeSlotsDTO
                    {
                        DoctorId = doctor.Id,
                        RoomId = rooms[doctor.Id % rooms.Count].Id,
                        CreatedByAdminId = admin.Id,  // ✅ field bắt buộc
                        WorkDate = DateTime.Today.AddDays(1),
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(9, 0, 0),
                        MaxAppointments = 5,
                        Status = "Open"
                    });
                }
                context.SaveChanges();
            }

            // 7. Contents
            if (!context.Contents.Any())
            {
                var firstDepartment = context.Departments.OrderBy(d => d.Id).FirstOrDefault()
                    ?? throw new InvalidOperationException("Seed failed: no Department available for Content.");

                context.Contents.AddRange(
                    new ContentDTO
                    {
                        AuthorAdminId = admin.Id,
                        Title = "Thông báo thay đổi giờ khám ngày lễ",
                        Summary = "Bệnh viện điều chỉnh giờ tiếp nhận bệnh nhân trong dịp lễ.",
                        Body = "Nội dung thông báo thay đổi giờ khám áp dụng toàn bệnh viện.",
                        ContentType = "HospitalNotice",
                        Status = "Published",
                        IsPinned = true,
                        PublishedAt = DateTime.Now
                    },
                    new ContentDTO
                    {
                        DepartmentId = firstDepartment.Id,
                        AuthorAdminId = admin.Id,
                        Title = "Hướng dẫn khám Nội khoa",
                        Summary = "Quy trình tiếp nhận và thăm khám tại khoa Nội.",
                        Body = "Nội dung hướng dẫn quy trình khám dành cho bệnh nhân khoa Nội.",
                        ContentType = "DepartmentGuide",
                        Status = "Published",
                        PublishedAt = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}