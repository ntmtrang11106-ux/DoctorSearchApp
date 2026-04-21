using DTO_Tier;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DAL_Tier
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            try
            {
                if (context.Users.Any()) return;

                // 1. NẠP KHU VỰC (Location) - Đầy đủ các quận Đà Nẵng để test Filter theo vùng
                var locs = new List<LocationDTO> {
                    new LocationDTO { LocationName = "Hải Châu" },
                    new LocationDTO { LocationName = "Liên Chiểu" },
                    new LocationDTO { LocationName = "Thanh Khê" },
                    new LocationDTO { LocationName = "Sơn Trà" },
                    new LocationDTO { LocationName = "Cẩm Lệ" },
                    new LocationDTO { LocationName = "Ngũ Hành Sơn" }
                };
                context.Locations.AddRange(locs);

                // 2. NẠP CHUYÊN KHOA (Specialty) - Khớp 100% với các nút bấm trên giao diện
                var specs = new List<SpecialtyDTO> {
                    new SpecialtyDTO { SpecialtyName = "Nhi khoa", Description = "Chăm sóc sức khỏe trẻ em" },
                    new SpecialtyDTO { SpecialtyName = "Nội khoa", Description = "Khám bệnh nội khoa tổng quát" },
                    new SpecialtyDTO { SpecialtyName = "Tim mạch", Description = "Chẩn đoán bệnh lý tim mạch" },
                    new SpecialtyDTO { SpecialtyName = "Mắt", Description = "Chuyên khoa mắt" },
                    new SpecialtyDTO { SpecialtyName = "Da liễu", Description = "Điều trị các bệnh về da" },
                    new SpecialtyDTO { SpecialtyName = "Tai mũi họng", Description = "Chuyên khoa Tai Mũi Họng" },
                    new SpecialtyDTO { SpecialtyName = "Sản khoa", Description = "Sức khỏe sinh sản" },
                    new SpecialtyDTO { SpecialtyName = "Ngoại khoa", Description = "Phẫu thuật và chấn thương" }
                };
                context.Specialties.AddRange(specs);
                context.SaveChanges();

                // 3. NẠP USERS (1 Admin, 7 Bác sĩ, 2 Bệnh nhân)
                // Lưu ý: Picture, CCCD, Residential_Address, Gender, Status là NOT NULL trong SQL của bạn
                var users = new List<UserDTO>();

                // Admin
                var admin = new UserDTO { FullName = "Admin Hệ Thống", Role = "Admin", PhoneNumber = "000", Password = "123", Gender = "Nam", Status = "Active", CCCD = "999", Residential_Address = "Đà Nẵng", Picture = "admin.png" };
                users.Add(admin);

                // Danh sách Bác sĩ
                string[] docNames = { "Nguyễn Văn An", "Lê Thị Mỹ Hạnh", "Trần Thành Nhân", "Phạm Minh Tuấn", "Hoàng Đức Trung", "Võ Thị Tiến", "Đặng Văn Hùng" };
                for (int i = 0; i < docNames.Length; i++)
                {
                    users.Add(new UserDTO
                    {
                        FullName = "BS. " + docNames[i],
                        Role = "Doctor",
                        PhoneNumber = "090" + i,
                        Password = "123",
                        Gender = (i % 2 == 0 ? "Nam" : "Nữ"),
                        Status = "Active",
                        CCCD = "100" + i,
                        Residential_Address = "Đà Nẵng",
                        Picture = $"doc{i + 1}.png"
                    });
                }

                // Bệnh nhân
                var pat1 = new UserDTO { FullName = "Nguyễn Thị Mai Trang", Role = "Patient", PhoneNumber = "070", Password = "123", Gender = "Nữ", Status = "Active", CCCD = "2001", Residential_Address = "Đà Nẵng", Picture = "trang.png" };
                var pat2 = new UserDTO { FullName = "Lê Văn Tiến", Role = "Patient", PhoneNumber = "077", Password = "123", Gender = "Nam", Status = "Active", CCCD = "2002", Residential_Address = "Quảng Nam", Picture = "tien.png" };
                users.Add(pat1); users.Add(pat2);

                context.Users.AddRange(users);
                context.SaveChanges();

                // 4. NẠP CHI TIẾT BÁC SĨ (Doctor) - Bio và WorkingTime là NOT NULL
                var doctors = new List<DoctorDTO>();
                for (int i = 1; i <= 7; i++)
                {
                    doctors.Add(new DoctorDTO
                    {
                        UserId = users[i].Id,
                        CertificateImage = "CERT_" + i,
                        CertificateCode = "CCHN-00" + i,
                        ClinicName = "Phòng khám " + users[i].FullName,
                        ClinicAddress = (10 + i) + " Hàm Nghi, Đà Nẵng",
                        Bio = "Bác sĩ giàu kinh nghiệm, tận tâm với nghề.",
                        WorkingTime = "08:00 - 20:00",
                        Experience_Years = 5 + i,
                        Price = 100000 + (i * 20000),
                        IsApproved = true,
                        LocationId = locs[i % locs.Count].Id
                    });
                }
                context.Doctors.AddRange(doctors);
                context.SaveChanges();

                // 5. NẠP CHI TIẾT BỆNH NHÂN (Patient) - BHYT, Blood_Type, Medical_History NOT NULL
                context.Patients.Add(new PatientDTO { UserId = pat1.Id, BHYT = "BH001", Blood_Type = "O", Medical_History = "Bình thường" });
                context.Patients.Add(new PatientDTO { UserId = pat2.Id, BHYT = "BH002", Blood_Type = "A", Medical_History = "Viêm xoang" });

                // 6. LIÊN KẾT BÁC SĨ - CHUYÊN KHOA (Quan trọng để test lọc)
                var dsList = new List<DoctorSpecialtyDTO> {
                    new DoctorSpecialtyDTO { DoctorId = doctors[0].Id, SpecialtyId = specs[1].Id }, // An - Nội
                    new DoctorSpecialtyDTO { DoctorId = doctors[1].Id, SpecialtyId = specs[0].Id }, // Hạnh - Nhi
                    new DoctorSpecialtyDTO { DoctorId = doctors[2].Id, SpecialtyId = specs[2].Id }, // Nhân - Tim mạch
                    new DoctorSpecialtyDTO { DoctorId = doctors[3].Id, SpecialtyId = specs[3].Id }, // Tuấn - Mắt
                    new DoctorSpecialtyDTO { DoctorId = doctors[4].Id, SpecialtyId = specs[4].Id }, // Trung - Da liễu
                    new DoctorSpecialtyDTO { DoctorId = doctors[5].Id, SpecialtyId = specs[5].Id }, // Tiến - TMH
                    new DoctorSpecialtyDTO { DoctorId = doctors[6].Id, SpecialtyId = specs[7].Id }, // Hùng - Ngoại

                    // TEST: Bác sĩ An (doctors[0]) có thêm chuyên khoa Tim mạch (specs[2])
                    new DoctorSpecialtyDTO { DoctorId = doctors[0].Id, SpecialtyId = specs[2].Id }
                };
                context.DoctorSpecialties.AddRange(dsList);

                // 7. NẠP BÀI VIẾT (Articles) - NOT NULL Title, Content, Thumbnail
                var articles = new List<ArticlesDTO> {
                    new ArticlesDTO { AdminID = admin.Id, Title = "Cẩm nang phòng dịch mùa hè", Content = "Nội dung chi tiết về cách phòng dịch...", Thumbnail = "news1.jpg", Views = 150, CreatedAt = DateTime.Now },
                    new ArticlesDTO { AdminID = admin.Id, Title = "Dinh dưỡng cho trẻ biếng ăn", Content = "Cách bổ sung vitamin cho trẻ...", Thumbnail = "news2.jpg", Views = 200, CreatedAt = DateTime.Now },
                    new ArticlesDTO { AdminID = admin.Id, Title = "Dấu hiệu của bệnh đau mắt đỏ", Content = "Cách nhận biết sớm bệnh về mắt...", Thumbnail = "news3.jpg", Views = 80, CreatedAt = DateTime.Now },
                    new ArticlesDTO { AdminID = admin.Id, Title = "Tầm quan trọng của khám định kỳ", Content = "Lợi ích của việc đi khám tổng quát...", Thumbnail = "news4.jpg", Views = 120, CreatedAt = DateTime.Now },
                    new ArticlesDTO { AdminID = admin.Id, Title = "Bí quyết giữ trái tim khỏe mạnh", Content = "Chế độ tập luyện cho tim mạch...", Thumbnail = "news5.jpg", Views = 310, CreatedAt = DateTime.Now }
                };
                context.Articles.AddRange(articles);

                context.SaveChanges();
                Debug.WriteLine("=== SEED DATA HOÀN TẤT: 7 Bác sĩ, 5 Bài viết sẵn sàng! ===");


                // 8. LIÊN KẾT BÀI VIẾT - CHUYÊN KHOA
                // Phải có cái này thì lúc bấm nút Filter trên UI nó mới ra bài viết nhé Trang!
                var artSpecs = new List<ArticleSpecialtyDTO> {
                // Bài 1: Cẩm nang phòng dịch -> Chuyên khoa Nội (specs[1])
                new ArticleSpecialtyDTO { ArticleId = articles[0].Id, SpecialtyId = specs[1].Id },
    
                // Bài 2: Dinh dưỡng trẻ em -> Chuyên khoa Nhi (specs[0])
                new ArticleSpecialtyDTO { ArticleId = articles[1].Id, SpecialtyId = specs[0].Id },
    
                // Bài 3: Bệnh về mắt -> Chuyên khoa Mắt (specs[3])
                new ArticleSpecialtyDTO { ArticleId = articles[2].Id, SpecialtyId = specs[3].Id },
    
                // Bài 5: Trái tim khỏe mạnh -> Chuyên khoa Tim mạch (specs[2])
                new ArticleSpecialtyDTO { ArticleId = articles[4].Id, SpecialtyId = specs[2].Id }   
                };
                context.ArticleSpecialties.AddRange(artSpecs);
                context.SaveChanges(); // Chốt hạ lần cuối
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                while (inner?.InnerException != null) inner = inner.InnerException;
                Debug.WriteLine("=== LỖI SEED: " + (inner?.Message ?? ex.Message));
                throw;
            }
        }
    }
}