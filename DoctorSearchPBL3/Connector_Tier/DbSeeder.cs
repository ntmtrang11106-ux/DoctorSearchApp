//using DTO_Tier;
//using Microsoft.EntityFrameworkCore;

//namespace DAL_Tier
//{
//    public static class DbSeeder
//    {
//        public static void Seed(AppDbContext context, bool force = false)
//        {
//            if (force)
//            {
//                context.Database.EnsureDeleted();
//            }

//            // Always align schema before seeding so refactor changes are applied.
//            context.Database.Migrate();

//            if (!context.Departments.Any())
//            {
//                context.Departments.AddRange(
//                    new DepartmentDTO { DepartmentName = "Nội khoa", Description = "Khám và điều trị nội khoa", DisplayOrder = 1 },
//                    new DepartmentDTO { DepartmentName = "Tim mạch", Description = "Khám chuyên khoa tim mạch", DisplayOrder = 2 },
//                    new DepartmentDTO { DepartmentName = "Nhi khoa", Description = "Khám cho trẻ em", DisplayOrder = 3 },
//                    new DepartmentDTO { DepartmentName = "Da liễu", Description = "Khám bệnh về da", DisplayOrder = 4 }
//                );
//                context.SaveChanges();
//            }

//            if (!context.Rooms.Any())
//            {
//                context.Rooms.AddRange(
//                    new RoomDTO { RoomCode = "P101", RoomName = "Phòng khám 101", Floor = "1" },
//                    new RoomDTO { RoomCode = "P201", RoomName = "Phòng khám 201", Floor = "2" },
//                    new RoomDTO { RoomCode = "P202", RoomName = "Phòng khám 202", Floor = "2" }
//                );
//                context.SaveChanges();
//            }

//            if (!context.Users.Any(u => u.Role == "Admin" && u.PhoneNumber == "000"))
//            {
//                context.Users.Add(new UserDTO
//                {
//                    FullName = "Admin Hệ Thống",
//                    Role = "Admin",
//                    PhoneNumber = "000",
//                    Password = "123",
//                    Gender = "Nam",
//                    Status = "Active",
//                    CCCD = "999",
//                    Residential_Address = "Đà Nẵng"
//                });
//                context.SaveChanges();
//            }

//            var adminUser = context.Users.First(u => u.PhoneNumber == "000");
//            if (!context.Admins.Any(a => a.UserId == adminUser.Id))
//            {
//                context.Admins.Add(new AdminDTO { UserId = adminUser.Id, Position = "Quản trị hệ thống" });
//                context.SaveChanges();
//            }

//            string[] docNames = { "BS. Nguyễn Văn An", "BS. Lê Thị Mỹ Hạnh", "BS. Trần Thành Nhân", "BS. Phạm Minh Tuấn" };
//            var departments = context.Departments.OrderBy(d => d.Id).ToList();
//            if (departments.Count == 0)
//            {
//                throw new InvalidOperationException("Seed failed: Department table is empty.");
//            }
//            for (int i = 0; i < docNames.Length; i++)
//            {
//                string phone = $"090{i}";
//                if (!context.Users.Any(u => u.PhoneNumber == phone))
//                {
//                    context.Users.Add(new UserDTO
//                    {
//                        FullName = docNames[i],
//                        Role = "Doctor",
//                        PhoneNumber = phone,
//                        Password = "123",
//                        Gender = i % 2 == 0 ? "Nam" : "Nữ",
//                        Status = "Active",
//                        CCCD = $"100{i}",
//                        Residential_Address = "Đà Nẵng",
//                        Dob = new DateTime(1985 + i, 1, 1)
//                    });
//                }
//            }
//            context.SaveChanges();

//            var doctorUsers = context.Users.Where(u => u.Role == "Doctor").OrderBy(u => u.Id).ToList();
//            for (int i = 0; i < doctorUsers.Count; i++)
//            {
//                var user = doctorUsers[i];
//                if (!context.Doctors.Any(d => d.UserId == user.Id))
//                {
//                    context.Doctors.Add(new DoctorDTO
//                    {
//                        UserId = user.Id,
//                        DepartmentId = departments[i % departments.Count].Id,
//                        Position = "Bác sĩ",
//                        LicenseNumber = $"LIC-{user.Id:000}",
//                        Biography = "Bác sĩ tận tâm, giàu kinh nghiệm.",
//                        ConsultationFee = 150000 + (i * 50000),
//                        ExperienceYears = 5 + (i * 3),
//                        IsApproved = true,
//                        IsActive = true,
//                        JoinDate = DateTime.Today.AddYears(-(5 + i))
//                    });
//                }
//            }
//            context.SaveChanges();

//            if (!context.Users.Any(u => u.PhoneNumber == "070"))
//            {
//                context.Users.Add(new UserDTO
//                {
//                    FullName = "Nguyễn Thị Mai Trang",
//                    Role = "Patient",
//                    PhoneNumber = "070",
//                    Password = "123",
//                    Gender = "Nữ",
//                    Status = "Active",
//                    CCCD = "2001",
//                    Residential_Address = "Đà Nẵng",
//                    Dob = new DateTime(1995, 5, 5)
//                });
//            }

//            if (!context.Users.Any(u => u.PhoneNumber == "077"))
//            {
//                context.Users.Add(new UserDTO
//                {
//                    FullName = "Lê Văn Tiến",
//                    Role = "Patient",
//                    PhoneNumber = "077",
//                    Password = "123",
//                    Gender = "Nam",
//                    Status = "Active",
//                    CCCD = "2002",
//                    Residential_Address = "Quảng Nam",
//                    Dob = new DateTime(1992, 2, 2)
//                });
//            }
//            context.SaveChanges();

//            var patientUsers = context.Users.Where(u => u.Role == "Patient").ToList();
//            foreach (var user in patientUsers)
//            {
//                if (!context.Patients.Any(p => p.UserId == user.Id))
//                {
//                    context.Patients.Add(new PatientDTO
//                    {
//                        UserId = user.Id,
//                        MedicalCode = $"PT-{user.Id:0000}",
//                        InsuranceCode = $"BHYT-{user.Id:0000}"
//                    });
//                }
//            }
//            context.SaveChanges();

//            if (!context.TimeSlots.Any())
//            {
//                var doctors = context.Doctors.OrderBy(d => d.Id).ToList();
//                var rooms = context.Rooms.OrderBy(r => r.Id).ToList();
//                if (rooms.Count == 0)
//                {
//                    throw new InvalidOperationException("Seed failed: Room table is empty.");
//                }
//                foreach (var doctor in doctors)
//                {
//                    context.TimeSlots.Add(new TimeSlotsDTO
//                    {
//                        DoctorId = doctor.Id,
//                        RoomId = rooms[doctor.Id % rooms.Count].Id,
//                        WorkDate = DateTime.Today.AddDays(1),
//                        StartTime = new TimeSpan(8, 0, 0),
//                        EndTime = new TimeSpan(9, 0, 0),
//                        MaxAppointments = 5,
//                        Status = "Open"
//                    });
//                }
//                context.SaveChanges();
//            }

//            var admin = context.Admins.First();
//            if (!context.Contents.Any())
//            {
//                var firstDepartment = context.Departments.OrderBy(d => d.Id).FirstOrDefault();
//                if (firstDepartment == null)
//                {
//                    throw new InvalidOperationException("Seed failed: no Department available for Content.");
//                }
//                var departmentId = firstDepartment.Id;
//                context.Contents.AddRange(
//                    new ContentDTO
//                    {
//                        AuthorAdminId = admin.Id,
//                        Title = "Thông báo thay đổi giờ khám ngày lễ",
//                        Summary = "Bệnh viện điều chỉnh giờ tiếp nhận bệnh nhân trong dịp lễ.",
//                        Body = "Nội dung thông báo thay đổi giờ khám áp dụng toàn bệnh viện.",
//                        ContentType = "HospitalNotice",
//                        Status = "Published",
//                        IsPinned = true,
//                        PublishedAt = DateTime.Now
//                    },
//                    new ContentDTO
//                    {
//                        DepartmentId = departmentId,
//                        AuthorAdminId = admin.Id,
//                        Title = "Hướng dẫn khám Nội khoa",
//                        Summary = "Quy trình tiếp nhận và thăm khám tại khoa Nội.",
//                        Body = "Nội dung hướng dẫn quy trình khám dành cho bệnh nhân khoa Nội.",
//                        ContentType = "DepartmentGuide",
//                        Status = "Published",
//                        PublishedAt = DateTime.Now
//                    }
//                );
//                context.SaveChanges();
//            }
//        }
//    }
//}


using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL_Tier
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context, bool force = false)
        {
            if (force)
            {
                // Xóa toàn bộ Database hiện tại để reset dữ liệu
                context.Database.EnsureDeleted();
            }

            // Tạo lại DB và chạy các Migration mới nhất
            context.Database.Migrate();

            // 1. SEED DEPARTMENTS (Chuyên khoa)
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new DepartmentDTO { DepartmentName = "Nội khoa", Description = "Khám và điều trị nội khoa", DisplayOrder = 1, IsActive = true, CreatedAt = DateTime.Now },
                    new DepartmentDTO { DepartmentName = "Tim mạch", Description = "Khám chuyên khoa tim mạch", DisplayOrder = 2, IsActive = true, CreatedAt = DateTime.Now },
                    new DepartmentDTO { DepartmentName = "Nhi khoa", Description = "Khám cho trẻ em", DisplayOrder = 3, IsActive = true, CreatedAt = DateTime.Now },
                    new DepartmentDTO { DepartmentName = "Da liễu", Description = "Khám bệnh về da", DisplayOrder = 4, IsActive = true, CreatedAt = DateTime.Now }
                );
                context.SaveChanges();
            }

            // 2. SEED ROOMS (Phòng khám)
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new RoomDTO { RoomCode = "P101", RoomName = "Phòng khám 101", Floor = "1", IsActive = true, CreatedAt = DateTime.Now },
                    new RoomDTO { RoomCode = "P201", RoomName = "Phòng khám 201", Floor = "2", IsActive = true, CreatedAt = DateTime.Now },
                    new RoomDTO { RoomCode = "P202", RoomName = "Phòng khám 202", Floor = "2", IsActive = true, CreatedAt = DateTime.Now }
                );
                context.SaveChanges();
            }

            // 3. SEED ADMIN
            if (!context.Users.Any(u => u.Role == "Admin"))
            {
                var adminUser = new UserDTO
                {
                    FullName = "Admin Hệ Thống",
                    Role = "Admin",
                    PhoneNumber = "000",
                    Password = "123",
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

            // 4. SEED DOCTORS
            if (!context.Doctors.Any())
            {
                string[] docNames = { "BS. Nguyễn Văn An", "BS. Lê Thị Mỹ Hạnh", "BS. Trần Thành Nhân", "BS. Phạm Minh Tuấn" };
                var depts = context.Departments.ToList();

                for (int i = 0; i < docNames.Length; i++)
                {
                    var user = new UserDTO
                    {
                        FullName = docNames[i],
                        Role = "Doctor",
                        PhoneNumber = $"090{i}",
                        Password = "123",
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
                        DepartmentId = depts[i % depts.Count].Id,
                        Position = "Bác sĩ chuyên khoa",
                        LicenseNumber = $"LIC-{user.Id:000}",
                        ConsultationFee = 150000,
                        ExperienceYears = 5 + i,
                        IsApproved = true,
                        IsActive = true,
                        JoinDate = DateTime.Today.AddYears(-2),
                        CreatedAt = DateTime.Now
                    });
                }
                context.SaveChanges();
            }

            // 5. SEED PATIENTS (Trang và Tiến)
            if (!context.Patients.Any())
            {
                var p1 = new UserDTO { FullName = "Nguyễn Thị Mai Trang", Role = "Patient", PhoneNumber = "070", Password = "123", Gender = "Nữ", Status = "Active", CCCD = "200000000001", Residential_Address = "Đà Nẵng", CreatedAt = DateTime.Now };
                var p2 = new UserDTO { FullName = "Lê Văn Tiến", Role = "Patient", PhoneNumber = "077", Password = "123", Gender = "Nam", Status = "Active", CCCD = "200000000002", Residential_Address = "Quảng Nam", CreatedAt = DateTime.Now };

                context.Users.AddRange(p1, p2);
                context.SaveChanges();

                context.Patients.Add(new PatientDTO { UserId = p1.Id, MedicalCode = "PT-0001", CreatedAt = DateTime.Now });
                context.Patients.Add(new PatientDTO { UserId = p2.Id, MedicalCode = "PT-0002", CreatedAt = DateTime.Now });
                context.SaveChanges();
            }

            // 6. SEED TIMESLOTS (Khung giờ khám)
            if (!context.TimeSlots.Any())
            {
                var doctors = context.Doctors.ToList();
                var rooms = context.Rooms.ToList();

                foreach (var doc in doctors)
                {
                    // Tạo 2 khung giờ cho mỗi bác sĩ vào ngày mai
                    context.TimeSlots.AddRange(
                        new TimeSlotsDTO { DoctorId = doc.Id, RoomId = rooms[0].Id, WorkDate = DateTime.Today.AddDays(1), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(9, 0, 0), Status = "Open", CreatedAt = DateTime.Now },
                        new TimeSlotsDTO { DoctorId = doc.Id, RoomId = rooms[1].Id, WorkDate = DateTime.Today.AddDays(1), StartTime = new TimeSpan(9, 30, 0), EndTime = new TimeSpan(10, 30, 0), Status = "Open", CreatedAt = DateTime.Now }
                    );
                }
                context.SaveChanges();
            }

            // 7. SEED APPOINTMENTS (Dữ liệu test quan trọng)
            if (!context.Appointments.Any())
            {
                var patient = context.Patients.First();
                var doctor = context.Doctors.Include(d => d.User).Include(d => d.Department).First();
                var slots = context.TimeSlots.Where(s => s.DoctorId == doctor.Id).ToList();

                // Lịch hẹn 1: Chờ duyệt (Pending)
                context.Appointments.Add(new AppointmentsDTO
                {
                    PatientId = patient.Id,
                    DoctorId = doctor.Id,
                    TimeSlotId = slots[0].Id,
                    Reason = "Đau bụng kéo dài",
                    Status = "Pending",
                    DoctorNameSnapshot = doctor.User.FullName,
                    DepartmentNameSnapshot = doctor.Department.DepartmentName,
                    FeeSnapshot = doctor.ConsultationFee,
                    CreatedAt = DateTime.Now
                });

                // Lịch hẹn 2: Đã duyệt (Confirmed)
                context.Appointments.Add(new AppointmentsDTO
                {
                    PatientId = patient.Id,
                    DoctorId = doctor.Id,
                    TimeSlotId = slots[1].Id,
                    Reason = "Khám sức khỏe định kỳ",
                    Status = "Confirmed",
                    DoctorNameSnapshot = doctor.User.FullName,
                    DepartmentNameSnapshot = doctor.Department.DepartmentName,
                    FeeSnapshot = doctor.ConsultationFee,
                    CreatedAt = DateTime.Now
                });

                // Cập nhật trạng thái Slot tương ứng
                slots[0].Status = "Booked";
                slots[1].Status = "Booked";

                context.SaveChanges();
            }
        }
    }
}