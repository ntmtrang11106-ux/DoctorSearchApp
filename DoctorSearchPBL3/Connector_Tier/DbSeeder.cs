using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context, bool force = false)
        {
            if (force)
            {
                context.Database.EnsureDeleted();
            }

            // Always align schema before seeding so refactor changes are applied.
            context.Database.Migrate();

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

            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new RoomDTO { RoomCode = "P101", RoomName = "Phòng khám 101", Floor = "1" },
                    new RoomDTO { RoomCode = "P201", RoomName = "Phòng khám 201", Floor = "2" },
                    new RoomDTO { RoomCode = "P202", RoomName = "Phòng khám 202", Floor = "2" }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any(u => u.Role == "Admin" && u.PhoneNumber == "000"))
            {
                context.Users.Add(new UserDTO
                {
                    FullName = "Admin Hệ Thống",
                    Role = "Admin",
                    PhoneNumber = "000",
                    Password = "123",
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

            string[] docNames = { "BS. Nguyễn Văn An", "BS. Lê Thị Mỹ Hạnh", "BS. Trần Thành Nhân", "BS. Phạm Minh Tuấn" };
            var departments = context.Departments.OrderBy(d => d.Id).ToList();
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
                        Password = "123",
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

            if (!context.Users.Any(u => u.PhoneNumber == "070"))
            {
                context.Users.Add(new UserDTO
                {
                    FullName = "Nguyễn Thị Mai Trang",
                    Role = "Patient",
                    PhoneNumber = "070",
                    Password = "123",
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
                    Password = "123",
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

            if (!context.TimeSlots.Any())
            {
                var doctors = context.Doctors.OrderBy(d => d.Id).ToList();
                var rooms = context.Rooms.OrderBy(r => r.Id).ToList();
                foreach (var doctor in doctors)
                {
                    context.TimeSlots.Add(new TimeSlotsDTO
                    {
                        DoctorId = doctor.Id,
                        RoomId = rooms[doctor.Id % rooms.Count].Id,
                        WorkDate = DateTime.Today.AddDays(1),
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(9, 0, 0),
                        MaxAppointments = 5,
                        Status = "Open"
                    });
                }
                context.SaveChanges();
            }

            var admin = context.Admins.First();
            if (!context.Contents.Any())
            {
                var departmentId = context.Departments.First().Id;
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
                        DepartmentId = departmentId,
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
