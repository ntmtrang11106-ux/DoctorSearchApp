using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<PatientDTO> Patients { get; set; }
        public DbSet<DoctorDTO> Doctors { get; set; }
        public DbSet<AdminDTO> Admins { get; set; }
        public DbSet<LocationDTO> Locations { get; set; }
        public DbSet<SpecialtyDTO> Specialties { get; set; }
        public DbSet<DoctorSpecialtyDTO> DoctorSpecialties { get; set; }
        public DbSet<ArticleSpecialtyDTO> ArticleSpecialties { get; set; }
        public DbSet<TimeSlotsDTO> TimeSlots { get; set; }
        public DbSet<AppointmentsDTO> Appointments { get; set; }
        public DbSet<ConversationDTO> Conversations { get; set; }
        public DbSet<MessagesDTO> Messages { get; set; }
        public DbSet<CallLogsDTO> CallLogs { get; set; }
        public DbSet<MedicalRecordsDTO> MedicalRecords { get; set; }
        public DbSet<ArticlesDTO> Articles { get; set; }
        public DbSet<ReviewsDTO> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB_CodeFirst;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Ràng buộc UNIQUE
            modelBuilder.Entity<UserDTO>().HasIndex(u => u.PhoneNumber).IsUnique();
            // Chứng chỉ đã được di chuyển sang DoctorSpecialtyDTO, không còn index UNIQUE ở DoctorDTO

            // 2. Thiết lập quan hệ 1-1 MỘT CHIỀU
            modelBuilder.Entity<DoctorDTO>().HasOne(d => d.User).WithOne().HasForeignKey<DoctorDTO>(d => d.UserId);
            modelBuilder.Entity<PatientDTO>().HasOne(p => p.User).WithOne().HasForeignKey<PatientDTO>(p => p.UserId);
            modelBuilder.Entity<AdminDTO>().HasOne(a => a.User).WithOne().HasForeignKey<AdminDTO>(a => a.UserId);
            // --- 2. CẤU HÌNH QUAN HỆ NHIỀU-NHIỀU (BÁC SĨ - CHUYÊN KHOA) ---
            // Thiết lập khóa chính cho bảng DoctorSpecialtyDTO
            modelBuilder.Entity<DoctorSpecialtyDTO>()
                .HasKey(ds => ds.Id);

            // Đồng thời đảm bảo một Doctor không duplicate cùng một Specialty
            modelBuilder.Entity<DoctorSpecialtyDTO>()
                .HasIndex(ds => new { ds.DoctorId, ds.SpecialtyId }).IsUnique();

            modelBuilder.Entity<DoctorSpecialtyDTO>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecialties)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<DoctorSpecialtyDTO>()
                .HasOne(ds => ds.Specialty)
                .WithMany() // Một chuyên khoa có nhiều bác sĩ
                .HasForeignKey(ds => ds.SpecialtyId);

            // --- 3. CẤU HÌNH QUAN HỆ NHIỀU-NHIỀU (BÀI VIẾT - CHUYÊN KHOA) ---
            modelBuilder.Entity<ArticleSpecialtyDTO>()
                .HasKey(aspec => new { aspec.ArticleId, aspec.SpecialtyId });

            modelBuilder.Entity<ArticleSpecialtyDTO>()
                .HasOne(aspec => aspec.Article)
                .WithMany(a => a.ArticleSpecialties)
                .HasForeignKey(aspec => aspec.ArticleId);

            modelBuilder.Entity<ArticleSpecialtyDTO>()
                .HasOne(aspec => aspec.Specialty)
                .WithMany() // Một chuyên khoa có nhiều bài viết
                .HasForeignKey(aspec => aspec.SpecialtyId);

            // 3. GIẢI PHÁP TỔNG LỰC: Chặn Cascade Delete cho TOÀN BỘ Database
            // Đoạn code này sẽ tự động cấu hình cho tất cả 14 bảng, dứt điểm lỗi Multiple Cascade Paths
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // 4. Giá trị mặc định
            modelBuilder.Entity<TimeSlotsDTO>().Property(t => t.Status).HasDefaultValue("Trống");
            modelBuilder.Entity<AppointmentsDTO>().Property(a => a.Status).HasDefaultValue("Chờ duyệt");

            // Indexes to speed up location-based filtering
            modelBuilder.Entity<LocationDTO>().HasIndex(l => l.Province);
            modelBuilder.Entity<LocationDTO>().HasIndex(l => new { l.Province, l.LocationName });

            // Index to speed up sorting by experience summary on doctors
            modelBuilder.Entity<DoctorDTO>().HasIndex(d => d.ExperienceSummary);
        }
    }
}