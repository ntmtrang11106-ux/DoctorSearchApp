using DTO_Tier;
using System.Linq;
using System.Collections.Generic;

namespace DAL_Tier
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // 1. Kiểm tra nếu đã có dữ liệu thì không seed nữa để tránh trùng lặp
            if (context.Specialties.Any()) return;

            // 2. Thêm Chuyên khoa mẫu
            var specs = new List<SpecialtyDTO>
            {
                new SpecialtyDTO { SpecialtyName = "Nhi khoa", Description = "Chăm sóc sức khỏe trẻ em" },
                new SpecialtyDTO { SpecialtyName = "Dinh dưỡng", Description = "Tư vấn chế độ ăn uống" },
                new SpecialtyDTO { SpecialtyName = "Tim mạch", Description = "Điều trị các bệnh về tim" },
                new SpecialtyDTO { SpecialtyName = "Da liễu", Description = "Điều trị các bệnh về da" }
            };
            context.Specialties.AddRange(specs);
            context.SaveChanges();

            // 3. Thêm User mẫu (1 Admin, 2 Bác sĩ)
            var userAdmin = new UserDTO { FullName = "Admin Hệ Thống", Role = "Admin", PhoneNumber = "0905123456", Password = "123", Gender = "Nam" };
            var userDoc1 = new UserDTO { FullName = "Nguyễn Văn An", Role = "Doctor", PhoneNumber = "0905000111", Password = "123", Gender = "Nam" };
            var userDoc2 = new UserDTO { FullName = "Lê Thị Bình", Role = "Doctor", PhoneNumber = "0905000222", Password = "123", Gender = "Nữ" };

            context.Users.AddRange(userAdmin, userDoc1, userDoc2);
            context.SaveChanges();

            // 4. Thêm Bác sĩ mẫu
            var doc1 = new DoctorDTO
            {
                UserId = userDoc1.Id,
                ClinicName = "Phòng khám An Tâm",
                ClinicAddress = "123 Ngô Quyền, Đà Nẵng",
                Experience_Years = 10,
                IsApproved = true
            };
            var doc2 = new DoctorDTO
            {
                UserId = userDoc2.Id,
                ClinicName = "Bệnh viện Đa khoa",
                ClinicAddress = "456 Lê Duẩn, Đà Nẵng",
                Experience_Years = 5,
                IsApproved = true
            };
            context.Doctors.AddRange(doc1, doc2);
            context.SaveChanges();

            // 5. THIẾT LẬP QUAN HỆ NHIỀU-NHIỀU (Điểm mấu chốt)
            context.DoctorSpecialties.AddRange(
                new DoctorSpecialtyDTO { DoctorId = doc1.Id, SpecialtyId = specs[0].Id }, // Bác sĩ An - Nhi khoa
                new DoctorSpecialtyDTO { DoctorId = doc1.Id, SpecialtyId = specs[1].Id }, // Bác sĩ An - Dinh dưỡng (Đa chuyên khoa)
                new DoctorSpecialtyDTO { DoctorId = doc2.Id, SpecialtyId = specs[2].Id }  // Bác sĩ Bình - Tim mạch
            );

            // 6. Thêm Bài viết mẫu
            var article = new ArticlesDTO
            {
                Title = "Chế độ dinh dưỡng cho trẻ em mùa hè",
                Content = "Nội dung bài viết về sức khỏe nhi khoa...",
                AdminID = userAdmin.Id,
                Views = 150
            };
            context.Articles.Add(article);
            context.SaveChanges();

            // Nối bài viết với chuyên khoa Nhi và Dinh dưỡng
            context.ArticleSpecialties.AddRange(
                new ArticleSpecialtyDTO { ArticleId = article.Id, SpecialtyId = specs[0].Id },
                new ArticleSpecialtyDTO { ArticleId = article.Id, SpecialtyId = specs[1].Id }
            );

            context.SaveChanges();
        }
    }
}