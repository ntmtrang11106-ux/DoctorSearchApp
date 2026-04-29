using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class PatientDAL
    {
        private readonly AppDbContext _context;
        public PatientDAL() => _context = new AppDbContext();

        public int GetPatientIdByUserId(int userId)
        {
            using (var db = new AppDbContext())
            {
                // Tìm bệnh nhân dựa trên UserId và đảm bảo bệnh nhân chưa bị xóa (IsDeleted)
                var patient = db.Patients.FirstOrDefault(p => p.UserId == userId && !p.IsDeleted);

                // Nếu tìm thấy trả về Id của Patient, ngược lại trả về 0
                return patient != null ? patient.Id : 0;
            }
        }

        public PatientDTO? GetPatientProfile(int patientId)
        {
            return _context.Patients
                .Include(p => p.User)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == patientId && !p.IsDeleted);
        }

        public List<AppointmentsDTO> GetPatientAppointments(int patientId)
        {
            return _context.Appointments
                .AsNoTracking()
                .Include(a => a.TimeSlot)
                .Include(a => a.Doctor).ThenInclude(d => d.User)
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.CreatedAt)
                .ToList();
        }

        public bool CreateAppointment(AppointmentsDTO app)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var slot = _context.TimeSlots.Find(app.TimeSlotId);
                if (slot == null || slot.BookedCount >= slot.MaxAppointments || slot.Status == "Full")
                    return false;

                app.CreatedAt = DateTime.Now;
                app.Status = "Pending";
                _context.Appointments.Add(app);

                slot.BookedCount++;
                if (slot.BookedCount == slot.MaxAppointments) slot.Status = "Full";

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}