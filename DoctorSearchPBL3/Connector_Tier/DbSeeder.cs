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
        public static void Seed(AppDbContext context, bool force = false)
        {
            try
            {
                // If force=true, recreate database to ensure clean seed
                if (force)
                {
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }

                // Idempotent seeding: insert missing data only

                // 1. NẠP KHU VỰC (Location)
                if (!context.Locations.Any())
                {
                    var locs = new List<LocationDTO> {
                        new LocationDTO { LocationName = "Hải Châu", Province = "Đà Nẵng" },
                        new LocationDTO { LocationName = "Liên Chiểu", Province = "Đà Nẵng" },
                        new LocationDTO { LocationName = "Thanh Khê", Province = "Đà Nẵng" },
                        new LocationDTO { LocationName = "Sơn Trà", Province = "Đà Nẵng" },
                        new LocationDTO { LocationName = "Cẩm Lệ", Province = "Đà Nẵng" },
                        new LocationDTO { LocationName = "Ngũ Hành Sơn", Province = "Đà Nẵng" }
                    };
                    context.Locations.AddRange(locs);
                    context.SaveChanges();
                }

                // 2. NẠP CHUYÊN KHOA (Specialty)
                if (!context.Specialties.Any())
                {
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
                }

                // 3. NẠP USERS (Admin/Doctors/Patients) - insert if missing
                // Admin
                if (!context.Users.Any(u => u.Role == "Admin" && u.PhoneNumber == "000"))
                {
                    var admin = new UserDTO { FullName = "Admin Hệ Thống", Role = "Admin", PhoneNumber = "000", Password = "123", Gender = "Nam", Status = "Active", CCCD = "999", Residential_Address = "Đà Nẵng", Picture = "admin.png", Dob = new DateTime(1990, 1, 1) };
                    context.Users.Add(admin);
                    context.SaveChanges();
                }

                // Doctors list
                string[] docNames = { "Nguyễn Văn An", "Lê Thị Mỹ Hạnh", "Trần Thành Nhân", "Phạm Minh Tuấn", "Hoàng Đức Trung", "Võ Thị Tiến", "Đặng Văn Hùng" };
                for (int i = 0; i < docNames.Length; i++)
                {
                    string phone = "090" + i;
                    if (!context.Users.Any(u => u.PhoneNumber == phone))
                    {
                        var user = new UserDTO
                        {
                            FullName = "BS. " + docNames[i],
                            Role = "Doctor",
                            PhoneNumber = phone,
                            Password = "123",
                            Gender = (i % 2 == 0 ? "Nam" : "Nữ"),
                            Status = "Active",
                            CCCD = "100" + i,
                            Residential_Address = "Đà Nẵng",
                            Picture = $"doc{i + 1}.png",
                            Dob = new DateTime(1985 + i, 1, 1)
                        };
                        context.Users.Add(user);
                    }
                }

                // Patients
                if (!context.Users.Any(u => u.PhoneNumber == "070"))
                    context.Users.Add(new UserDTO { FullName = "Nguyễn Thị Mai Trang", Role = "Patient", PhoneNumber = "070", Password = "123", Gender = "Nữ", Status = "Active", CCCD = "2001", Residential_Address = "Đà Nẵng", Picture = "trang.png", Dob = new DateTime(1995, 5, 5) });
                if (!context.Users.Any(u => u.PhoneNumber == "077"))
                    context.Users.Add(new UserDTO { FullName = "Lê Văn Tiến", Role = "Patient", PhoneNumber = "077", Password = "123", Gender = "Nam", Status = "Active", CCCD = "2002", Residential_Address = "Quảng Nam", Picture = "tien.png", Dob = new DateTime(1992, 2, 2) });

                context.SaveChanges();

                // 4. NẠP CHI TIẾT BÁC SĨ (Doctor)
                // Ensure we have Locations and Specialties to reference
                var allLocs = context.Locations.ToList();
                var allSpecs = context.Specialties.ToList();

                // Create doctors for users with Role = Doctor if missing
                var doctorUsers = context.Users.Where(u => u.Role == "Doctor").ToList();
                var doctors = new List<DoctorDTO>();
                foreach (var u in doctorUsers)
                {
                    if (!context.Doctors.Any(d => d.UserId == u.Id))
                    {
                        var doc = new DoctorDTO
                        {
                            UserId = u.Id,
                            ClinicName = "Phòng khám " + u.FullName,
                            ClinicAddress = "Chưa xác định",
                            Bio = "Bác sĩ giàu kinh nghiệm, tận tâm với nghề.",
                            WorkingTime = "08:00 - 20:00",
                            Price = 150000,
                            IsApproved = true,
                            LocationId = allLocs.FirstOrDefault()?.Id
                        };
                        doctors.Add(doc);
                        context.Doctors.Add(doc);
                    }
                }
                context.SaveChanges();

                // 5. NẠP CHI TIẾT BỆNH NHÂN (Patient) - if missing
                var patientUsers = context.Users.Where(u => u.Role == "Patient").ToList();
                foreach (var u in patientUsers)
                {
                    if (!context.Patients.Any(p => p.UserId == u.Id))
                    {
                        context.Patients.Add(new PatientDTO { UserId = u.Id, BHYT = "BH" + u.Id, Blood_Type = "O", Medical_History = "Bình thường" });
                    }
                }
                context.SaveChanges();

                // 6. LIÊN KẾT BÁC SĨ - CHUYÊN KHOA: seed DoctorSpecialty if none
                // 6. LIÊN KẾT BÁC SĨ - CHUYÊN KHOA: Seed DoctorSpecialty if none
                if (!context.DoctorSpecialties.Any())
                {
                    // Không dùng 'var' cho allSpecs nữa vì nó đã được khai báo ở Bước 4 rồi
                    var docList = context.Doctors.ToList();

                    // Đảm bảo có ít nhất 1 bác sĩ và đủ chuyên khoa để test đa chuyên khoa
                    if (docList.Count >= 1 && allSpecs.Count >= 3)
                    {
                        var dsList = new List<DoctorSpecialtyDTO> {
            // --- TRƯỜNG HỢP TEST: 1 BÁC SĨ CÓ 2 CHUYÊN KHOA RIÊNG BIỆT ---
            // Bác sĩ đầu tiên (Nguyễn Văn An) có 2 chuyên khoa: Nội khoa và Tim mạch
            new DoctorSpecialtyDTO {
                DoctorId = docList[0].Id,
                SpecialtyId = allSpecs[1].Id, // Nội khoa
                CertificateImage = "CERT_AN_NOI_KHOA.png",
                CertificateCode = "CC-AN-NOI-001",
                Experience_Years = 10
            },
            new DoctorSpecialtyDTO {
                DoctorId = docList[0].Id,
                SpecialtyId = allSpecs[2].Id, // Tim mạch
                CertificateImage = "CERT_AN_TIM_MACH.png",
                CertificateCode = "CC-AN-TIM-002",
                Experience_Years = 5
            },

            // --- Các bác sĩ khác mỗi người 1 chuyên khoa để đủ data ---
new DoctorSpecialtyDTO { DoctorId = docList[1].Id, SpecialtyId = allSpecs[0].Id, CertificateImage = "CERT_HANH_NHI.png", CertificateCode = "CC-HANH-003", Experience_Years = 7 },
            new DoctorSpecialtyDTO { DoctorId = docList[2].Id, SpecialtyId = allSpecs[3].Id, CertificateImage = "CERT_NHAN_MAT.png", CertificateCode = "CC-NHAN-004", Experience_Years = 8 },
            new DoctorSpecialtyDTO { DoctorId = docList[3].Id, SpecialtyId = allSpecs[4].Id, CertificateImage = "CERT_TUAN_DA.png", CertificateCode = "CC-TUAN-005", Experience_Years = 9 },
            new DoctorSpecialtyDTO { DoctorId = docList[4].Id, SpecialtyId = allSpecs[5].Id, CertificateImage = "CERT_TRUNG_TMH.png", CertificateCode = "CC-TRUNG-006", Experience_Years = 12 },
            new DoctorSpecialtyDTO { DoctorId = docList[5].Id, SpecialtyId = allSpecs[7].Id, CertificateImage = "CERT_TIEN_NGOAI.png", CertificateCode = "CC-TIEN-007", Experience_Years = 15 }
        };

                        context.DoctorSpecialties.AddRange(dsList);
                        context.SaveChanges();

                        // Cập nhật ExperienceSummary cho từng Doctor (Lấy năm kinh nghiệm cao nhất)
                        foreach (var doc in context.Doctors.ToList())
                        {
                            var maxExp = context.DoctorSpecialties
                                .Where(ds => ds.DoctorId == doc.Id)
                                .Max(ds => (int?)ds.Experience_Years) ?? 0; // Đã sửa lỗi LINQ Translation

                            doc.ExperienceSummary = maxExp > 0 ? (int?)maxExp : null; //
                            context.Doctors.Update(doc);
                        }
                        context.SaveChanges();
                        Debug.WriteLine("=== SEED DOCTOR_SPECIALTY HOÀN TẤT: BS An đã có 2 chuyên khoa ===");
                    }
                }

                // 7. NẠP BÀI VIẾT (Articles) - NOT NULL Title, Content, Thumbnail
                var adminUser = context.Users.FirstOrDefault(u => u.Role == "Admin");
                if (adminUser != null)
                {
                    var articles = new List<ArticlesDTO> {
                        new ArticlesDTO { AdminID = adminUser.Id, Title = "Cẩm nang phòng dịch mùa hè", Content = "Nội dung chi tiết về cách phòng dịch...", Thumbnail = "news1.jpg", Views = 150, CreatedAt = DateTime.Now },
                        new ArticlesDTO { AdminID = adminUser.Id, Title = "Dinh dưỡng cho trẻ biếng ăn", Content = "Cách bổ sung vitamin cho trẻ...", Thumbnail = "news2.jpg", Views = 200, CreatedAt = DateTime.Now },
                        new ArticlesDTO { AdminID = adminUser.Id, Title = "Dấu hiệu của bệnh đau mắt đỏ", Content = "Cách nhận biết sớm bệnh về mắt...", Thumbnail = "news3.jpg", Views = 80, CreatedAt = DateTime.Now },
new ArticlesDTO { AdminID = adminUser.Id, Title = "Tầm quan trọng của khám định kỳ", Content = "Lợi ích của việc đi khám tổng quát...", Thumbnail = "news4.jpg", Views = 120, CreatedAt = DateTime.Now },
                        new ArticlesDTO { AdminID = adminUser.Id, Title = "Bí quyết giữ trái tim khỏe mạnh", Content = "Chế độ tập luyện cho tim mạch...", Thumbnail = "news5.jpg", Views = 310, CreatedAt = DateTime.Now }
                    };
                    context.Articles.AddRange(articles);
                    context.SaveChanges();
                    Debug.WriteLine("=== SEED DATA HOÀN TẤT: Doctors, Articles inserted ===");

                    // 8. LIÊN KẾT BÀI VIẾT - CHUYÊN KHOA
                    var artSpecs = new List<ArticleSpecialtyDTO> {
                        new ArticleSpecialtyDTO { ArticleId = articles[0].Id, SpecialtyId = allSpecs[1].Id },
                        new ArticleSpecialtyDTO { ArticleId = articles[1].Id, SpecialtyId = allSpecs[0].Id },
                        new ArticleSpecialtyDTO { ArticleId = articles[2].Id, SpecialtyId = allSpecs[3].Id },
                        new ArticleSpecialtyDTO { ArticleId = articles[4].Id, SpecialtyId = allSpecs[2].Id }
                    };
                    context.ArticleSpecialties.AddRange(artSpecs);
                    context.SaveChanges(); // Chốt hạ lần cuối
                }
                    Visit_Date = DateTime.Now,
                    Diagnosis = "Viêm họng cấp",
                    Treatment = "Uống thuốc đúng liều và súc miệng nước muối"
                });

                // 9. LIÊN KẾT CHUYÊN KHOA (Doctor_Specialty)
                context.DoctorSpecialties.Add(new DoctorSpecialtyDTO { DoctorId = doctors[0].Id, SpecialtyId = specs[1].Id });

                context.SaveChanges();
                Debug.WriteLine("=== SEED DATA HOÀN TẤT ===");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("=== LỖI SEED: " + ex.Message);
                throw;
            }
        }
    }
}