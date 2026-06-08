using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class AppDbContext : DbContext
    {
        public const string DefaultConnectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB_CodeFirst;Integrated Security=True;TrustServerCertificate=True";

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<PatientDTO> Patients { get; set; }
        public DbSet<DoctorDTO> Doctors { get; set; }
        public DbSet<AdminDTO> Admins { get; set; }
        public DbSet<DepartmentDTO> Departments { get; set; }
        public DbSet<RoomDTO> Rooms { get; set; }
        public DbSet<TimeSlotsDTO> TimeSlots { get; set; }
        public DbSet<AppointmentsDTO> Appointments { get; set; }
        public DbSet<ConversationDTO> Conversations { get; set; }
        public DbSet<MessagesDTO> Messages { get; set; }
        public DbSet<ContentDTO> Contents { get; set; }
        public DbSet<ReviewsDTO> Reviews { get; set; }
        public DbSet<DoctorCertificateDTO> DoctorCertificates { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DefaultConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDTO>().HasIndex(u => u.PhoneNumber).IsUnique();
            modelBuilder.Entity<DepartmentDTO>().HasIndex(d => d.DepartmentName).IsUnique();
            modelBuilder.Entity<RoomDTO>().HasIndex(r => r.RoomCode).IsUnique();
            modelBuilder.Entity<PatientDTO>()
                .HasIndex(p => p.MedicalCode)
                .IsUnique()
                .HasFilter("[MedicalCode] IS NOT NULL");
            modelBuilder.Entity<DoctorDTO>()
                .HasIndex(d => d.LicenseNumber)
                .IsUnique()
                .HasFilter("[LicenseNumber] IS NOT NULL");

            modelBuilder.Entity<DoctorDTO>().HasOne(d => d.User).WithOne().HasForeignKey<DoctorDTO>(d => d.UserId);
            modelBuilder.Entity<PatientDTO>().HasOne(p => p.User).WithOne().HasForeignKey<PatientDTO>(p => p.UserId);
            modelBuilder.Entity<AdminDTO>().HasOne(a => a.User).WithOne().HasForeignKey<AdminDTO>(a => a.UserId);

            modelBuilder.Entity<DoctorDTO>()
                .HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RoomDTO>()
                .HasOne(r => r.Department)
                .WithMany()
                .HasForeignKey(r => r.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomDTO>().HasIndex(r => new { r.DepartmentId, r.RoomCode });
            modelBuilder.Entity<TimeSlotsDTO>()
                .HasOne(t => t.Doctor)
                .WithMany(d => d.TimeSlots)
                .HasForeignKey(t => t.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeSlotsDTO>()
                .HasOne(t => t.Room)
                .WithMany(r => r.TimeSlots)
                .HasForeignKey(t => t.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeSlotsDTO>()
                .HasOne(t => t.CreatedByAdmin)
                .WithMany()
                .HasForeignKey(t => t.CreatedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppointmentsDTO>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppointmentsDTO>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppointmentsDTO>()
                .HasOne(a => a.TimeSlot)
                .WithMany(t => t.Appointments)
                .HasForeignKey(a => a.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppointmentsDTO>()
                .HasOne(a => a.CreatedByAdmin)
                .WithMany()
                .HasForeignKey(a => a.CreatedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppointmentsDTO>()
                .HasIndex(a => new { a.PatientId, a.TimeSlotId })
                .IsUnique();

            modelBuilder.Entity<ContentDTO>()
                .HasOne(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContentDTO>()
                .HasOne(c => c.AuthorAdmin)
                .WithMany()
                .HasForeignKey(c => c.AuthorAdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewsDTO>()
                .HasOne(r => r.Patient)
                .WithMany()
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewsDTO>()
                .HasOne(r => r.Doctor)
                .WithMany(d => d.Reviews)
                .HasForeignKey(r => r.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReviewsDTO>()
                .HasOne(r => r.Appointment)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReviewsDTO>()
                .HasIndex(r => r.AppointmentId)
                .IsUnique()
                .HasFilter("[AppointmentId] IS NOT NULL");

            modelBuilder.Entity<ConversationDTO>()
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConversationDTO>()
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ConversationDTO>()
                .HasIndex(c => new { c.PatientID, c.DoctorID })
                .IsUnique();

            modelBuilder.Entity<MessagesDTO>()
                .HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MessagesDTO>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DoctorCertificateDTO>()
                .HasOne(c => c.Doctor)
                .WithMany(d => d.Certificates)
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DoctorCertificateDTO>().HasIndex(c => c.DoctorId);

            modelBuilder.Entity<UserDTO>().Property(u => u.Status).HasDefaultValue("Active");
            modelBuilder.Entity<TimeSlotsDTO>().Property(t => t.Status).HasDefaultValue("Open");
            modelBuilder.Entity<AppointmentsDTO>().Property(a => a.Status).HasDefaultValue("Pending");
            modelBuilder.Entity<ContentDTO>().Property(c => c.Status).HasDefaultValue("Draft");

            modelBuilder.Entity<DoctorDTO>().HasIndex(d => d.DepartmentId);
            modelBuilder.Entity<TimeSlotsDTO>().HasIndex(t => new { t.WorkDate, t.DoctorId, t.RoomId });
            modelBuilder.Entity<TimeSlotsDTO>()
                .HasIndex(t => new { t.DoctorId, t.WorkDate, t.StartTime, t.EndTime })
                .IsUnique();
            modelBuilder.Entity<TimeSlotsDTO>()
                .HasIndex(t => new { t.RoomId, t.WorkDate, t.StartTime, t.EndTime })
                .IsUnique();
            modelBuilder.Entity<ContentDTO>().HasIndex(c => new { c.ContentType, c.Status, c.DepartmentId });
            modelBuilder.Entity<MessagesDTO>()
                .HasIndex(m => new { m.ConversationId, m.SentAt });
        }
    }
}
