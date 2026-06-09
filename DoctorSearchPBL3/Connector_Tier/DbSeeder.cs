using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DAL_Tier
{
    public static class DbSeeder
    {
        private const string DemoPassword = "Demo@2026";

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
            SeedAdmins(context);
            SeedDoctors(context);
            SeedPatients(context);
            SeedDoctorCertificates(context);
            SeedTimeSlots(context);
            SeedAppointments(context);
            SeedReviews(context);
            SeedContents(context);
            SeedConversations(context);
        }

        private static void SeedDepartments(AppDbContext context)
        {
            var departments = new[]
            {
                new DepartmentSeed("Nội khoa", "Khám và điều trị bệnh lý nội khoa tổng quát.", 1),
                new DepartmentSeed("Tim mạch", "Khám, tầm soát và điều trị bệnh tim mạch.", 2),
                new DepartmentSeed("Nhi khoa", "Chăm sóc sức khỏe trẻ em và thanh thiếu niên.", 3),
                new DepartmentSeed("Da liễu", "Khám và điều trị bệnh lý da, tóc, móng.", 4),
                new DepartmentSeed("Sản phụ khoa", "Theo dõi thai kỳ và chăm sóc sức khỏe phụ nữ.", 5),
                new DepartmentSeed("Tai mũi họng", "Khám và điều trị tai, mũi, họng.", 6),
                new DepartmentSeed("Cơ xương khớp", "Khám đau nhức, chấn thương và bệnh cơ xương khớp.", 7),
                new DepartmentSeed("Tâm lý", "Tư vấn sức khỏe tinh thần và trị liệu tâm lý.", 8)
            };

            foreach (var item in departments)
            {
                var department = context.Departments.FirstOrDefault(d => d.DepartmentName == item.Name);
                if (department == null)
                {
                    context.Departments.Add(new DepartmentDTO
                    {
                        DepartmentName = item.Name,
                        Description = item.Description,
                        DisplayOrder = item.DisplayOrder,
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    });
                    continue;
                }

                department.Description = item.Description;
                department.DisplayOrder = item.DisplayOrder;
                department.IsActive = true;
                department.IsDeleted = false;
                department.UpdatedAt = DateTime.Now;
            }

            context.SaveChanges();
        }

        private static void SeedRooms(AppDbContext context)
        {
            var departments = context.Departments
                .Where(d => !d.IsDeleted)
                .ToDictionary(d => d.DepartmentName, d => d.Id);

            var rooms = new[]
            {
                new RoomSeed("NOI.101", "Phòng khám Nội khoa 1", "Nội khoa"),
                new RoomSeed("NOI.102", "Phòng khám Nội khoa 2", "Nội khoa"),
                new RoomSeed("TIM.201", "Phòng khám Tim mạch 1", "Tim mạch"),
                new RoomSeed("TIM.202", "Phòng siêu âm tim", "Tim mạch"),
                new RoomSeed("NHI.301", "Phòng khám Nhi 1", "Nhi khoa"),
                new RoomSeed("NHI.302", "Phòng khám Nhi 2", "Nhi khoa"),
                new RoomSeed("DAL.401", "Phòng khám Da liễu 1", "Da liễu"),
                new RoomSeed("DAL.402", "Phòng soi da", "Da liễu"),
                new RoomSeed("SAN.501", "Phòng khám Sản phụ khoa", "Sản phụ khoa"),
                new RoomSeed("SAN.502", "Phòng tư vấn thai kỳ", "Sản phụ khoa"),
                new RoomSeed("TMH.601", "Phòng khám Tai mũi họng", "Tai mũi họng"),
                new RoomSeed("TMH.602", "Phòng nội soi tai mũi họng", "Tai mũi họng"),
                new RoomSeed("CXK.701", "Phòng khám Cơ xương khớp", "Cơ xương khớp"),
                new RoomSeed("CXK.702", "Phòng vật lý trị liệu", "Cơ xương khớp"),
                new RoomSeed("TLY.801", "Phòng tư vấn Tâm lý 1", "Tâm lý"),
                new RoomSeed("TLY.802", "Phòng tư vấn Tâm lý 2", "Tâm lý")
            };

            foreach (var item in rooms)
            {
                if (!departments.TryGetValue(item.DepartmentName, out int departmentId))
                {
                    continue;
                }

                var room = context.Rooms.FirstOrDefault(r => r.RoomCode == item.Code);
                if (room == null)
                {
                    context.Rooms.Add(new RoomDTO
                    {
                        RoomCode = item.Code,
                        RoomName = item.Name,
                        DepartmentId = departmentId,
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    });
                    continue;
                }

                room.RoomName = item.Name;
                room.DepartmentId = departmentId;
                room.IsActive = true;
                room.IsDeleted = false;
                room.UpdatedAt = DateTime.Now;
            }

            context.SaveChanges();
        }

        private static void SeedAdmins(AppDbContext context)
        {
            var admins = new[]
            {
                new UserSeed("Admin Hệ Thống", "Admin", "0900000000", "Nam", new DateTime(1988, 1, 15), "049088000001", "01 Nguyễn Văn Linh, Hải Châu, Đà Nẵng", "Active"),
                new UserSeed("Quản Trị Viên MediFar", "Admin", "0900000001", "Nữ", new DateTime(1990, 5, 20), "049090000002", "15 Lê Duẩn, Hải Châu, Đà Nẵng", "Active")
            };

            foreach (var seed in admins)
            {
                var user = context.Users.FirstOrDefault(u => u.PhoneNumber == seed.PhoneNumber);
                if (user == null)
                {
                    user = CreateUser(seed);
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    UpdateUser(user, seed);
                    context.SaveChanges();
                }

                var admin = context.Admins.FirstOrDefault(a => a.UserId == user.Id);
                if (admin == null)
                {
                    context.Admins.Add(new AdminDTO
                    {
                        UserId = user.Id,
                        Position = "Quản trị hệ thống",
                        IsActive = true,
                        CreatedAt = user.CreatedAt
                    });
                }
                else
                {
                    admin.Position = "Quản trị hệ thống";
                    admin.IsActive = true;
                    admin.UpdatedAt = DateTime.Now;
                }
            }

            context.SaveChanges();
        }

        private static void SeedDoctors(AppDbContext context)
        {
            var departments = context.Departments
                .Where(d => !d.IsDeleted)
                .ToDictionary(d => d.DepartmentName, d => d.Id);

            var doctors = new[]
            {
                new DoctorSeed(new UserSeed("BS. Nguyễn Văn An", "Doctor", "0910000001", "Nam", new DateTime(1981, 3, 14), "049181000001", "25 Nguyễn Tri Phương, Thanh Khê, Đà Nẵng", "Active", "bs1.jpg"), "Nội khoa", "Bác sĩ chuyên khoa", "100001/DNG-CCHN", 12, 150000m, true, true, "Có kinh nghiệm khám nội tổng quát, bệnh tiêu hóa và tư vấn sức khỏe định kỳ."),
                new DoctorSeed(new UserSeed("BS. Lê Thị Mỹ Hạnh", "Doctor", "0910000002", "Nữ", new DateTime(1984, 7, 20), "049184000002", "83 Hải Phòng, Hải Châu, Đà Nẵng", "Active", "bs2.jpg"), "Tim mạch", "Bác sĩ chuyên khoa", "100002/DNG-CCHN", 10, 180000m, true, true, "Tập trung điều trị tăng huyết áp, rối loạn nhịp tim và tư vấn phòng ngừa bệnh tim."),
                new DoctorSeed(new UserSeed("BS. Trần Thành Nhân", "Doctor", "0910000003", "Nam", new DateTime(1979, 11, 5), "049179000003", "12 Trần Phú, Hải Châu, Đà Nẵng", "Active", "bs3.jpg"), "Nhi khoa", "Bác sĩ chuyên khoa", "100003/DNG-CCHN", 15, 160000m, true, true, "Chuyên khám nhi tổng quát, dinh dưỡng trẻ em và theo dõi phát triển."),
                new DoctorSeed(new UserSeed("BS. Phạm Minh Tuấn", "Doctor", "0910000004", "Nam", new DateTime(1986, 2, 2), "049186000004", "48 Nguyễn Hữu Thọ, Cẩm Lệ, Đà Nẵng", "Active", "bs4.jpg"), "Da liễu", "Bác sĩ chuyên khoa", "100004/DNG-CCHN", 9, 170000m, true, true, "Khám mụn, viêm da cơ địa, dị ứng da và chăm sóc da y khoa."),
                new DoctorSeed(new UserSeed("BS. Võ Thu Hà", "Doctor", "0910000005", "Nữ", new DateTime(1982, 9, 18), "049182000005", "67 Điện Biên Phủ, Thanh Khê, Đà Nẵng", "Active", "bs5.jpg"), "Sản phụ khoa", "Bác sĩ chuyên khoa", "100005/DNG-CCHN", 13, 200000m, true, true, "Theo dõi thai kỳ, tư vấn sức khỏe phụ nữ và khám phụ khoa định kỳ."),
                new DoctorSeed(new UserSeed("BS. Hoàng Đức Long", "Doctor", "0910000006", "Nam", new DateTime(1980, 12, 8), "049180000006", "29 Lê Lợi, Hải Châu, Đà Nẵng", "Active", "bs6.jpg"), "Tai mũi họng", "Bác sĩ chuyên khoa", "100006/DNG-CCHN", 14, 155000m, true, true, "Khám viêm xoang, viêm họng, viêm tai giữa và nội soi tai mũi họng."),
                new DoctorSeed(new UserSeed("BS. Đặng Ngọc Mai", "Doctor", "0910000007", "Nữ", new DateTime(1987, 4, 25), "049187000007", "102 Núi Thành, Hải Châu, Đà Nẵng", "Active", "bs7.jpg"), "Cơ xương khớp", "Bác sĩ chuyên khoa", "100007/DNG-CCHN", 8, 165000m, true, true, "Tư vấn đau lưng, thoái hóa khớp, chấn thương vận động và phục hồi chức năng."),
                new DoctorSeed(new UserSeed("BS. Bùi Khánh Linh", "Doctor", "0910000008", "Nữ", new DateTime(1989, 6, 12), "049189000008", "36 Ông Ích Khiêm, Hải Châu, Đà Nẵng", "Active", "bs8.jpg"), "Tâm lý", "Bác sĩ chuyên khoa", "100008/DNG-CCHN", 7, 190000m, true, true, "Tư vấn căng thẳng, lo âu, rối loạn giấc ngủ và chăm sóc sức khỏe tinh thần."),
                new DoctorSeed(new UserSeed("BS. Nguyễn Quốc Huy", "Doctor", "0910000009", "Nam", new DateTime(1978, 8, 3), "049178000009", "19 Nguyễn Công Trứ, Sơn Trà, Đà Nẵng", "Active", "bs9.jpg"), "Nội khoa", "Thạc sĩ bác sĩ", "100009/BYT-CCHN", 17, 220000m, true, true, "Nhiều năm kinh nghiệm trong điều trị bệnh nội khoa mạn tính."),
                new DoctorSeed(new UserSeed("BS. Trương An Nhiên", "Doctor", "0910000010", "Nữ", new DateTime(1991, 10, 29), "049191000010", "55 Phan Châu Trinh, Hải Châu, Đà Nẵng", "Active", "bs10.jpg"), "Tim mạch", "Bác sĩ chuyên khoa", "100010/BYT-CCHN", 5, 145000m, true, true, "Tư vấn tầm soát tim mạch, dinh dưỡng và vận động cho người trẻ."),
                new DoctorSeed(new UserSeed("BS. Phan Hoài Nam", "Doctor", "0910000011", "Nam", new DateTime(1985, 1, 9), "049185000011", "78 Nguyễn Văn Thoại, Sơn Trà, Đà Nẵng", "Blocked", "bs11.jpg"), "Da liễu", "Bác sĩ chuyên khoa", "100011/HCM-CCHN", 11, 150000m, true, false, "Tài khoản mẫu ở trạng thái bị khóa để kiểm thử nghiệp vụ chặn người dùng."),
                new DoctorSeed(new UserSeed("BS. Vũ Minh Khang", "Doctor", "0910000012", "Nam", new DateTime(1993, 5, 6), "049193000012", "31 Hà Huy Tập, Thanh Khê, Đà Nẵng", "Active", "bs12.jpg"), "Nhi khoa", "Bác sĩ chuyên khoa", "100012/HCM-CCHN", 3, 130000m, false, false, "Tài khoản mẫu chờ duyệt để kiểm thử luồng duyệt bác sĩ."),
                new DoctorSeed(new UserSeed("BS. Đỗ Lan Chi", "Doctor", "0910000013", "Nữ", new DateTime(1992, 2, 16), "049192000013", "44 Hoàng Diệu, Hải Châu, Đà Nẵng", "Active", "bs14.jpg"), "Sản phụ khoa", "Bác sĩ chuyên khoa", "100013/HCM-CCHN", 4, 135000m, false, false, "Tài khoản mẫu chờ duyệt cho màn hình quản lý bác sĩ.")
            };

            foreach (var seed in doctors)
            {
                if (!departments.TryGetValue(seed.DepartmentName, out int departmentId))
                {
                    continue;
                }

                var existingUser = context.Users.FirstOrDefault(u => u.PhoneNumber == seed.User.PhoneNumber);
                if (existingUser != null)
                {
                    UpdateUser(existingUser, seed.User);
                    context.SaveChanges();
                    continue;
                }

                if (context.Doctors.Any(d => d.LicenseNumber == seed.LicenseNumber))
                {
                    continue;
                }

                var user = CreateUser(seed.User);
                context.Users.Add(user);
                context.SaveChanges();

                context.Doctors.Add(new DoctorDTO
                {
                    UserId = user.Id,
                    DepartmentId = departmentId,
                    Position = seed.Position,
                    LicenseNumber = seed.LicenseNumber,
                    Biography = seed.Biography,
                    ConsultationFee = seed.ConsultationFee,
                    ExperienceYears = seed.ExperienceYears,
                    IsApproved = seed.IsApproved,
                    IsActive = seed.IsActive,
                    JoinDate = DateTime.Today.AddYears(-Math.Max(1, Math.Min(seed.ExperienceYears, 12))),
                    NotesInternal = seed.IsApproved ? "Dữ liệu mẫu đã được duyệt." : "Dữ liệu mẫu đang chờ admin duyệt.",
                    CreatedAt = user.CreatedAt,
                    IsDeleted = false
                });
                context.SaveChanges();
            }
        }

        private static void SeedPatients(AppDbContext context)
        {
            var patients = new[]
            {
                new PatientSeed(new UserSeed("Nguyễn Thị Thu", "Patient", "0703000001", "Nữ", new DateTime(1989, 2, 1), "079189000001", "120 Trưng Nữ Vương, Hải Châu, Đà Nẵng", "Active"), "BN001", "BHYT-DN-000001", "AB", "Trần Văn Minh", "0905000001", "Dị ứng hải sản nhẹ."),
                new PatientSeed(new UserSeed("Trần Văn Bình", "Patient", "0703000002", "Nam", new DateTime(1994, 8, 22), "079194000002", "35 Nguyễn Lương Bằng, Liên Chiểu, Đà Nẵng", "Active"), "BN002", "BHYT-DN-000002", "O+", "Nguyễn Thị Hòa", "0905000002", "Tiền sử viêm dạ dày."),
                new PatientSeed(new UserSeed("Lê Minh Châu", "Patient", "0703000003", "Nữ", new DateTime(2001, 4, 10), "079201000003", "68 Lê Thanh Nghị, Hải Châu, Đà Nẵng", "Active"), "BN003", "BHYT-DN-000003", "A+", "Lê Văn Hùng", "0905000003", "Không ghi nhận bệnh nền."),
                new PatientSeed(new UserSeed("Phạm Gia Bảo", "Patient", "0703000004", "Nam", new DateTime(2012, 9, 5), "Chưa đủ tuổi", "22 Duy Tân, Hải Châu, Đà Nẵng", "Active"), "BN004", "BHYT-DN-000004", "B+", "Phạm Thị Lan", "0905000004", "Bệnh nhi dưới 16 tuổi, chưa đủ tuổi cấp CCCD."),
                new PatientSeed(new UserSeed("Hoàng Thanh Tâm", "Patient", "0703000005", "Nữ", new DateTime(1976, 12, 19), "079176000005", "17 Nguyễn Chí Thanh, Hải Châu, Đà Nẵng", "Active"), "BN005", "BHYT-DN-000005", "O-", "Hoàng Đức Nam", "0905000005", "Theo dõi huyết áp định kỳ."),
                new PatientSeed(new UserSeed("Đặng Quốc Việt", "Patient", "0703000006", "Nam", new DateTime(1982, 6, 30), "079182000006", "91 Tôn Đức Thắng, Liên Chiểu, Đà Nẵng", "Active"), "BN006", "BHYT-DN-000006", "A-", "Đặng Ngọc Anh", "0905000006", "Tiền sử đau lưng khi vận động mạnh."),
                new PatientSeed(new UserSeed("Bùi Khánh Ngân", "Patient", "0703000007", "Nữ", new DateTime(1998, 3, 27), "079198000007", "10 Pasteur, Hải Châu, Đà Nẵng", "Active"), "BN007", "BHYT-DN-000007", "B-", "Bùi Quốc Dũng", "0905000007", "Dễ kích ứng da khi dùng mỹ phẩm mới."),
                new PatientSeed(new UserSeed("Võ Thành Đạt", "Patient", "0703000008", "Nam", new DateTime(1990, 11, 14), "079190000008", "42 Võ Văn Kiệt, Sơn Trà, Đà Nẵng", "Blocked"), "BN008", "BHYT-DN-000008", "AB+", "Võ Thị Cẩm", "0905000008", "Tài khoản mẫu bị khóa để kiểm thử nghiệp vụ chặn bệnh nhân."),
                new PatientSeed(new UserSeed("Huỳnh Mai Anh", "Patient", "0703000009", "Nữ", new DateTime(2005, 1, 18), "079205000009", "76 Nguyễn Tất Thành, Thanh Khê, Đà Nẵng", "Active"), "BN009", "BHYT-DN-000009", "O+", "Huỳnh Minh Quân", "0905000009", "Không ghi nhận dị ứng thuốc."),
                new PatientSeed(new UserSeed("Ngô Đức Phúc", "Patient", "0703000010", "Nam", new DateTime(1987, 7, 7), "079187000010", "30 Hùng Vương, Hải Châu, Đà Nẵng", "Active"), "BN010", "BHYT-DN-000010", "A+", "Ngô Thị Kim", "0905000010", "Cần tư vấn chế độ ăn giảm mỡ máu."),
                new PatientSeed(new UserSeed("Đỗ Mỹ Duyên", "Patient", "0703000011", "Nữ", new DateTime(1996, 5, 13), "079196000011", "59 Lý Thường Kiệt, Hải Châu, Đà Nẵng", "Active"), "BN011", "BHYT-DN-000011", "B+", "Đỗ Văn Sơn", "0905000011", "Từng bị viêm xoang theo mùa."),
                new PatientSeed(new UserSeed("Mai Nhật Linh", "Patient", "0703000012", "Nữ", new DateTime(2014, 10, 2), "Chưa đủ tuổi", "11 Hồ Nghinh, Sơn Trà, Đà Nẵng", "Active"), "BN012", "BHYT-DN-000012", "O+", "Mai Quốc Tuấn", "0905000012", "Bệnh nhi dưới 16 tuổi, cần người giám hộ khi đặt lịch.")
            };

            foreach (var seed in patients)
            {
                if (context.Users.Any(u => u.PhoneNumber == seed.User.PhoneNumber)
                    || context.Patients.Any(p => p.MedicalCode == seed.MedicalCode))
                {
                    continue;
                }

                var user = CreateUser(seed.User);
                context.Users.Add(user);
                context.SaveChanges();

                context.Patients.Add(new PatientDTO
                {
                    UserId = user.Id,
                    MedicalCode = seed.MedicalCode,
                    InsuranceCode = seed.InsuranceCode,
                    BloodType = seed.BloodType,
                    EmergencyContactName = seed.EmergencyContactName,
                    EmergencyContactPhone = seed.EmergencyContactPhone,
                    Note = seed.Note,
                    CreatedAt = user.CreatedAt,
                    IsDeleted = false
                });
                context.SaveChanges();
            }
        }

        private static void SeedDoctorCertificates(AppDbContext context)
        {
            string placeholderCertificatePath = Path.Combine(AppContext.BaseDirectory, "Resources_Images", "default.jpg");
            if (!File.Exists(placeholderCertificatePath))
            {
                return;
            }

            var doctors = context.Doctors
                .Include(d => d.User)
                .Where(d => !d.IsDeleted)
                .OrderBy(d => d.Id)
                .ToList();

            foreach (var doctor in doctors)
            {
                if (context.DoctorCertificates.Any(c => c.DoctorId == doctor.Id && !c.IsDeleted))
                {
                    continue;
                }

                string safeLicense = (doctor.LicenseNumber ?? $"doctor-{doctor.Id}")
                    .Replace("/", "-")
                    .Replace("\\", "-");

                context.DoctorCertificates.Add(new DoctorCertificateDTO
                {
                    DoctorId = doctor.Id,
                    FilePath = placeholderCertificatePath,
                    FileName = $"ChungChi-{safeLicense}.jpg",
                    IsPrimary = true,
                    UploadedAt = doctor.CreatedAt.AddMinutes(30),
                    IsDeleted = false
                });
            }

            context.SaveChanges();
        }

        private static void SeedTimeSlots(AppDbContext context)
        {
            if (context.TimeSlots.Any())
            {
                return;
            }

            var admin = context.Admins.OrderBy(a => a.Id).FirstOrDefault();
            if (admin == null)
            {
                return;
            }

            var doctors = context.Doctors
                .Include(d => d.User)
                .Where(d => d.IsApproved
                    && d.IsActive
                    && !d.IsDeleted
                    && d.User != null
                    && d.User.Status == "Active"
                    && !d.User.IsDeleted)
                .OrderBy(d => d.Id)
                .ToList();

            var roomsByDepartment = context.Rooms
                .Where(r => r.IsActive && !r.IsDeleted)
                .OrderBy(r => r.Id)
                .ToList()
                .GroupBy(r => r.DepartmentId)
                .ToDictionary(g => g.Key, g => g.ToList());

            var timeBlocks = new[]
            {
                (Start: new TimeSpan(8, 0, 0), End: new TimeSpan(8, 45, 0)),
                (Start: new TimeSpan(9, 0, 0), End: new TimeSpan(9, 45, 0)),
                (Start: new TimeSpan(10, 0, 0), End: new TimeSpan(10, 45, 0)),
                (Start: new TimeSpan(14, 0, 0), End: new TimeSpan(14, 45, 0)),
                (Start: new TimeSpan(15, 0, 0), End: new TimeSpan(15, 45, 0))
            };

            for (int doctorIndex = 0; doctorIndex < doctors.Count; doctorIndex++)
            {
                var doctor = doctors[doctorIndex];
                if (!roomsByDepartment.TryGetValue(doctor.DepartmentId, out var departmentRooms) || departmentRooms.Count == 0)
                {
                    continue;
                }

                for (int slotIndex = 0; slotIndex < 5; slotIndex++)
                {
                    var block = timeBlocks[(doctorIndex + slotIndex) % timeBlocks.Length];
                    var room = departmentRooms[slotIndex % departmentRooms.Count];

                    TryAddTimeSlot(
                        context,
                        doctor.Id,
                        room.Id,
                        admin.Id,
                        DateTime.Today.AddDays(slotIndex + 1 + doctorIndex % 3),
                        block.Start,
                        block.End,
                        maxAppointments: 4);
                }

                for (int slotIndex = 0; slotIndex < 2; slotIndex++)
                {
                    var block = timeBlocks[(doctorIndex + slotIndex + 2) % timeBlocks.Length];
                    var room = departmentRooms[(slotIndex + 1) % departmentRooms.Count];

                    TryAddTimeSlot(
                        context,
                        doctor.Id,
                        room.Id,
                        admin.Id,
                        DateTime.Today.AddDays(-slotIndex - 1 - doctorIndex % 4),
                        block.Start,
                        block.End,
                        maxAppointments: 4);
                }
            }

            context.SaveChanges();
        }

        private static void SeedAppointments(AppDbContext context)
        {
            if (context.Appointments.Any())
            {
                return;
            }

            var admin = context.Admins.OrderBy(a => a.Id).FirstOrDefault();
            if (admin == null)
            {
                return;
            }

            var patients = context.Patients
                .Include(p => p.User)
                .Where(p => !p.IsDeleted && p.User != null && p.User.Status == "Active")
                .OrderBy(p => p.Id)
                .ToList();

            var doctors = context.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted && d.User != null && d.User.Status == "Active")
                .OrderBy(d => d.Id)
                .ToList();

            var slots = context.TimeSlots
                .Include(s => s.Room)
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.WorkDate)
                .ThenBy(s => s.StartTime)
                .ToList();

            if (patients.Count == 0 || doctors.Count == 0 || slots.Count == 0)
            {
                return;
            }

            string[] reasons =
            {
                "Khám sức khỏe định kỳ",
                "Tư vấn kết quả xét nghiệm",
                "Đau đầu và mất ngủ",
                "Đau dạ dày kéo dài",
                "Kiểm tra huyết áp",
                "Khám da liễu",
                "Tái khám sau điều trị",
                "Tư vấn dinh dưỡng"
            };

            int appointmentIndex = 0;
            foreach (var doctor in doctors.Take(8))
            {
                var doctorSlots = slots.Where(s => s.DoctorId == doctor.Id).ToList();
                if (doctorSlots.Count == 0)
                {
                    continue;
                }

                var completedSlot = doctorSlots.FirstOrDefault(s => s.WorkDate < DateTime.Today);
                if (completedSlot != null)
                {
                    AddAppointment(
                        context,
                        patients[appointmentIndex % patients.Count],
                        doctor,
                        completedSlot,
                        admin.Id,
                        reasons[appointmentIndex % reasons.Length],
                        "Completed",
                        DateTime.Now.AddDays(-7 - appointmentIndex),
                        completedAt: completedSlot.WorkDate.Date.Add(completedSlot.EndTime).AddHours(1));
                    appointmentIndex++;
                }

                var futureSlots = doctorSlots.Where(s => s.WorkDate >= DateTime.Today).Take(2).ToList();
                foreach (var slot in futureSlots)
                {
                    string status = appointmentIndex % 3 == 0 ? "Pending" : "Confirmed";
                    AddAppointment(
                        context,
                        patients[appointmentIndex % patients.Count],
                        doctor,
                        slot,
                        admin.Id,
                        reasons[appointmentIndex % reasons.Length],
                        status,
                        DateTime.Now.AddDays(-(appointmentIndex % 5)));
                    appointmentIndex++;
                }
            }

            context.SaveChanges();
        }

        //private static void SeedReviews(AppDbContext context)
        //{
        //    var completedAppointments = context.Appointments
        //        .Where(a => a.Status == "Completed")
        //        .OrderBy(a => a.CreatedAt)
        //        .AsEnumerable()
        //        .Where(a => a.AppointmentIdHasNoReview(context))
        //        .Take(10)
        //        .ToList();

        //    string[] comments =
        //    {
        //        "Bác sĩ tư vấn rõ ràng, thái độ nhẹ nhàng.",
        //        "Quy trình đặt lịch nhanh, đến khám không phải chờ lâu.",
        //        "Bác sĩ khám kỹ và giải thích dễ hiểu.",
        //        "Dịch vụ ổn, nhân viên hỗ trợ nhiệt tình.",
        //        "Rất hài lòng với buổi khám và hướng dẫn điều trị."
        //    };

        //    for (int i = 0; i < completedAppointments.Count; i++)
        //    {
        //        var appointment = completedAppointments[i];
        //        context.Reviews.Add(new ReviewsDTO
        //        {
        //            PatientId = appointment.PatientId,
        //            DoctorId = appointment.DoctorId,
        //            AppointmentId = appointment.Id,
        //            Rating = 4 + i % 2,
        //            Comment = comments[i % comments.Length],
        //            IsVisible = true,
        //            CreatedAt = appointment.CompletedAt?.AddDays(1) ?? DateTime.Now.AddDays(-i - 1),
        //            IsDeleted = false
        //        });
        //    }

        //    context.SaveChanges();
        //}

        private static void SeedReviews(AppDbContext context)
        {
            var reviewedAppointmentIds = context.Reviews
                .Where(r => r.AppointmentId != null)
                .Select(r => r.AppointmentId)
                .ToList();

            var completedAppointments = context.Appointments
                .Where(a => a.Status == "Completed")
                .OrderBy(a => a.CreatedAt)
                .ToList()
                .Where(a => !reviewedAppointmentIds.Contains(a.Id))
                .Take(10)
                .ToList();

            string[] comments =
            {
        "Bác sĩ tư vấn rõ ràng, thái độ nhẹ nhàng.",
        "Quy trình đặt lịch nhanh, đến khám không phải chờ lâu.",
        "Bác sĩ khám kỹ và giải thích dễ hiểu.",
        "Dịch vụ ổn, nhân viên hỗ trợ nhiệt tình.",
        "Rất hài lòng với buổi khám và hướng dẫn điều trị."
    };

            for (int i = 0; i < completedAppointments.Count; i++)
            {
                var appointment = completedAppointments[i];

                context.Reviews.Add(new ReviewsDTO
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    AppointmentId = appointment.Id,
                    Rating = 4 + i % 2,
                    Comment = comments[i % comments.Length],
                    IsVisible = true,
                    CreatedAt = appointment.CompletedAt?.AddDays(1) ?? DateTime.Now.AddDays(-i - 1),
                    IsDeleted = false
                });
            }

            context.SaveChanges();
        }
        private static void SeedContents(AppDbContext context)
        {
            var admin = context.Admins.OrderBy(a => a.Id).FirstOrDefault();
            if (admin == null)
            {
                return;
            }

            var departments = context.Departments
                .Where(d => !d.IsDeleted)
                .ToDictionary(d => d.DepartmentName, d => d.Id);

            var contents = new[]
            {
                new ContentSeed(null, "Thông báo lịch khám cuối tuần", "Bệnh viện mở thêm khung giờ khám cuối tuần cho một số chuyên khoa.", "Bệnh viện thông báo bổ sung khung giờ khám vào sáng thứ bảy nhằm hỗ trợ bệnh nhân đặt lịch thuận tiện hơn.", "HospitalNotice", "Published", true, 10),
                new ContentSeed(null, "Quy trình đặt lịch khám trực tuyến", "Các bước đặt lịch khám qua hệ thống DoctorSearch.", "Người dùng chọn bác sĩ, chọn khung giờ còn trống, nhập lý do khám và theo dõi trạng thái lịch hẹn trong tài khoản cá nhân.", "HospitalNotice", "Published", true, 9),
                new ContentSeed("Nội khoa", "Khi nào nên khám Nội khoa", "Dấu hiệu cần đặt lịch khám nội tổng quát.", "Người bệnh nên khám nội khoa khi có biểu hiện mệt mỏi kéo dài, đau bụng, sốt không rõ nguyên nhân hoặc cần kiểm tra sức khỏe định kỳ.", "DepartmentGuide", "Published", false, 8),
                new ContentSeed("Tim mạch", "Tầm soát tim mạch cho người trẻ", "Các yếu tố nguy cơ tim mạch cần quan tâm.", "Kiểm tra huyết áp, mỡ máu và duy trì vận động đều đặn giúp phát hiện sớm nguy cơ tim mạch.", "HealthArticle", "Published", false, 7),
                new ContentSeed("Nhi khoa", "Chuẩn bị trước khi đưa trẻ đi khám", "Phụ huynh nên chuẩn bị thông tin gì trước buổi khám.", "Phụ huynh cần ghi lại triệu chứng, thuốc đã dùng, tiền sử dị ứng và giấy tờ y tế của trẻ trước khi đến khám.", "DepartmentGuide", "Published", false, 6),
                new ContentSeed("Da liễu", "Chăm sóc da khi thời tiết thay đổi", "Lưu ý để giảm kích ứng và khô da.", "Dưỡng ẩm phù hợp, chống nắng và tránh tự ý dùng thuốc bôi mạnh giúp hạn chế kích ứng da.", "HealthArticle", "Published", false, 5),
                new ContentSeed("Sản phụ khoa", "Lịch khám thai định kỳ", "Các mốc khám thai quan trọng.", "Thai phụ nên theo dõi lịch khám định kỳ theo hướng dẫn bác sĩ để đánh giá sức khỏe mẹ và bé.", "DepartmentGuide", "Published", false, 4),
                new ContentSeed("Tai mũi họng", "Phòng ngừa viêm xoang tái phát", "Thói quen giúp giảm nguy cơ viêm xoang.", "Giữ ấm đường hô hấp, vệ sinh mũi đúng cách và khám khi triệu chứng kéo dài giúp kiểm soát viêm xoang.", "HealthArticle", "Published", false, 3),
                new ContentSeed("Cơ xương khớp", "Đau lưng khi ngồi lâu", "Cách nhận biết và phòng ngừa đau lưng văn phòng.", "Thay đổi tư thế, vận động nhẹ và khám chuyên khoa khi đau kéo dài là các bước cần thiết.", "HealthArticle", "Draft", false, 2),
                new ContentSeed("Tâm lý", "Chăm sóc giấc ngủ", "Một vài gợi ý giúp cải thiện giấc ngủ.", "Duy trì giờ ngủ ổn định, hạn chế thiết bị điện tử trước khi ngủ và tìm hỗ trợ khi mất ngủ kéo dài.", "HealthArticle", "Published", false, 1)
            };

            foreach (var seed in contents)
            {
                int? departmentId = null;
                if (!string.IsNullOrWhiteSpace(seed.DepartmentName)
                    && departments.TryGetValue(seed.DepartmentName, out int id))
                {
                    departmentId = id;
                }

                var content = context.Contents.FirstOrDefault(c => c.Title == seed.Title);
                if (content == null)
                {
                    context.Contents.Add(new ContentDTO
                    {
                        DepartmentId = departmentId,
                        AuthorAdminId = admin.Id,
                        Title = seed.Title,
                        Summary = seed.Summary,
                        Body = seed.Body,
                        ContentType = seed.ContentType,
                        Status = seed.Status,
                        Priority = seed.Priority,
                        IsPinned = seed.IsPinned,
                        ViewCount = seed.Priority * 12,
                        PublishedAt = seed.Status == "Published" ? DateTime.Now.AddDays(-seed.Priority) : null,
                        CreatedAt = DateTime.Now.AddDays(-seed.Priority),
                        IsDeleted = false
                    });
                    continue;
                }

                content.DepartmentId = departmentId;
                content.AuthorAdminId = admin.Id;
                content.Summary = seed.Summary;
                content.Body = seed.Body;
                content.ContentType = seed.ContentType;
                content.Status = seed.Status;
                content.Priority = seed.Priority;
                content.IsPinned = seed.IsPinned;
                content.PublishedAt = seed.Status == "Published" ? content.PublishedAt ?? DateTime.Now.AddDays(-seed.Priority) : null;
                content.IsDeleted = false;
                content.UpdatedAt = DateTime.Now;
            }

            context.SaveChanges();
        }

        private static void SeedConversations(AppDbContext context)
        {
            var appointments = context.Appointments
                .Include(a => a.Patient).ThenInclude(p => p!.User)
                .Include(a => a.Doctor).ThenInclude(d => d!.User)
                .Include(a => a.TimeSlot)
                .Where(a => a.Patient != null
                    && a.Patient.User != null
                    && a.Doctor != null
                    && a.Doctor.User != null
                    && a.Status != "Cancelled")
                .OrderByDescending(a => a.CreatedAt)
                .Take(8)
                .ToList();

            foreach (var appointment in appointments)
            {
                if (context.Conversations.Any(c => c.PatientID == appointment.PatientId && c.DoctorID == appointment.DoctorId))
                {
                    continue;
                }

                var conversation = new ConversationDTO
                {
                    PatientID = appointment.PatientId,
                    DoctorID = appointment.DoctorId,
                    LastMessage = "Cảm ơn bác sĩ, tôi đã nhận thông tin lịch hẹn.",
                    LastActive = DateTime.Now.AddHours(-appointment.Id % 12),
                    CreatedAt = appointment.CreatedAt,
                    IsActive = true,
                    IsDeleted = false
                };

                context.Conversations.Add(conversation);
                context.SaveChanges();

                int patientUserId = appointment.Patient!.UserId;
                int doctorUserId = appointment.Doctor!.UserId;

                context.Messages.AddRange(
                    new MessagesDTO
                    {
                        ConversationId = conversation.Id,
                        SenderID = patientUserId,
                        Content = $"Chào bác sĩ, tôi muốn hỏi thêm về lịch khám ngày {appointment.TimeSlot?.WorkDate:dd/MM/yyyy}.",
                        MessageType = "Text",
                        SentAt = conversation.CreatedAt.AddMinutes(10),
                        IsRead = true,
                        ReadAt = conversation.CreatedAt.AddMinutes(30),
                        IsDeleted = false
                    },
                    new MessagesDTO
                    {
                        ConversationId = conversation.Id,
                        SenderID = doctorUserId,
                        Content = "Chào anh/chị, mình vui lòng đến trước giờ hẹn khoảng 10 phút nhé.",
                        MessageType = "Text",
                        SentAt = conversation.CreatedAt.AddMinutes(40),
                        IsRead = true,
                        ReadAt = conversation.CreatedAt.AddMinutes(45),
                        IsDeleted = false
                    },
                    new MessagesDTO
                    {
                        ConversationId = conversation.Id,
                        SenderID = patientUserId,
                        Content = conversation.LastMessage,
                        MessageType = "Text",
                        SentAt = conversation.LastActive,
                        IsRead = false,
                        IsDeleted = false
                    });
            }

            context.SaveChanges();
        }

        private static UserDTO CreateUser(UserSeed seed)
        {
            return new UserDTO
            {
                FullName = seed.FullName,
                Role = seed.Role,
                PhoneNumber = seed.PhoneNumber,
                Password = HashPassword(DemoPassword),
                Dob = seed.Dob,
                Gender = seed.Gender,
                CCCD = seed.CCCD,
                Residential_Address = seed.Address,
                Picture = "Resources_Images/default.jpg",
                Status = seed.Status,
                CreatedAt = DateTime.Now.AddDays(-Math.Abs(seed.PhoneNumber.GetHashCode()) % 45),
                IsDeleted = false
            };
        }

        private static void UpdateUser(UserDTO user, UserSeed seed)
        {
            user.FullName = seed.FullName;
            user.Role = seed.Role;
            user.PhoneNumber = seed.PhoneNumber;
            user.Dob = seed.Dob;
            user.Gender = seed.Gender;
            user.CCCD = seed.CCCD;
            user.Residential_Address = seed.Address;
            user.Picture ??= "Resources_Images/default.jpg";
            user.Status = seed.Status;
            user.IsDeleted = false;
            user.UpdatedAt = DateTime.Now;
        }

        private static void TryAddTimeSlot(
            AppDbContext context,
            int doctorId,
            int roomId,
            int adminId,
            DateTime workDate,
            TimeSpan startTime,
            TimeSpan endTime,
            int maxAppointments)
        {
            bool doctorConflict = context.TimeSlots.Any(t =>
                t.DoctorId == doctorId
                && t.WorkDate == workDate.Date
                && t.StartTime == startTime
                && t.EndTime == endTime
                && !t.IsDeleted);

            bool roomConflict = context.TimeSlots.Any(t =>
                t.RoomId == roomId
                && t.WorkDate == workDate.Date
                && t.StartTime == startTime
                && t.EndTime == endTime
                && !t.IsDeleted);

            if (doctorConflict || roomConflict)
            {
                return;
            }

            context.TimeSlots.Add(new TimeSlotsDTO
            {
                DoctorId = doctorId,
                RoomId = roomId,
                CreatedByAdminId = adminId,
                WorkDate = workDate.Date,
                StartTime = startTime,
                EndTime = endTime,
                MaxAppointments = maxAppointments,
                BookedCount = 0,
                Status = "Open",
                CreatedAt = DateTime.Now,
                IsDeleted = false
            });
        }

        private static void AddAppointment(
            AppDbContext context,
            PatientDTO patient,
            DoctorDTO doctor,
            TimeSlotsDTO slot,
            int adminId,
            string reason,
            string status,
            DateTime createdAt,
            DateTime? completedAt = null)
        {
            if (context.Appointments.Any(a => a.PatientId == patient.Id && a.TimeSlotId == slot.Id))
            {
                return;
            }

            context.Appointments.Add(new AppointmentsDTO
            {
                PatientId = patient.Id,
                DoctorId = doctor.Id,
                TimeSlotId = slot.Id,
                CreatedByAdminId = adminId,
                Reason = reason,
                Status = status,
                Note = status == "Completed" ? "Đã hoàn tất buổi khám." : "Dữ liệu lịch hẹn mẫu.",
                DoctorNameSnapshot = doctor.User?.FullName,
                DepartmentNameSnapshot = doctor.Department?.DepartmentName,
                RoomNameSnapshot = slot.Room?.RoomName,
                FeeSnapshot = doctor.ConsultationFee,
                CreatedAt = createdAt,
                CompletedAt = completedAt
            });

            if (status is "Pending" or "Confirmed" or "Completed")
            {
                slot.BookedCount = Math.Min(slot.BookedCount + 1, slot.MaxAppointments);
                if (slot.BookedCount >= slot.MaxAppointments)
                {
                    slot.Status = "Full";
                }
            }
        }

        private static bool AppointmentIdHasNoReview(this AppointmentsDTO appointment, AppDbContext context)
            => !context.Reviews.Any(r => r.AppointmentId == appointment.Id);

        private sealed record DepartmentSeed(string Name, string Description, int DisplayOrder);
        private sealed record RoomSeed(string Code, string Name, string DepartmentName);
        private sealed record UserSeed(string FullName, string Role, string PhoneNumber, string Gender, DateTime Dob, string CCCD, string Address, string Status, string AvatarUrl = "");
        private sealed record DoctorSeed(UserSeed User, string DepartmentName, string Position, string LicenseNumber, int ExperienceYears, decimal ConsultationFee, bool IsApproved, bool IsActive, string Biography);
        private sealed record PatientSeed(UserSeed User, string MedicalCode, string InsuranceCode, string BloodType, string EmergencyContactName, string EmergencyContactPhone, string Note);
        private sealed record ContentSeed(string? DepartmentName, string Title, string Summary, string Body, string ContentType, string Status, bool IsPinned, int Priority);
    }
}
