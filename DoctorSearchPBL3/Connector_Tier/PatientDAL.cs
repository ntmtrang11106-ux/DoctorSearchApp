using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class PatientDAL
    {
        private readonly AppDbContext _context;
        public PatientDAL() => _context = new AppDbContext();

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