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

        public int GetPatientIdByUserId(int userId)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.UserId == userId && !p.IsDeleted);
            return patient?.Id ?? 0;
        }

        public bool UpdatePatientProfile(PatientDTO updatedPatient)
        {
            try
            {
                var existingPatient = _context.Patients
                    .Include(p => p.User)
                    .FirstOrDefault(p => p.Id == updatedPatient.Id);

                if (existingPatient == null) return false;

                // Update User info
                if (existingPatient.User != null && updatedPatient.User != null)
                {
                    existingPatient.User.FullName = updatedPatient.User.FullName;
                    existingPatient.User.PhoneNumber = updatedPatient.User.PhoneNumber;
                    existingPatient.User.Dob = updatedPatient.User.Dob;
                    existingPatient.User.Gender = updatedPatient.User.Gender;
                    existingPatient.User.CCCD = updatedPatient.User.CCCD;
                    existingPatient.User.Residential_Address = updatedPatient.User.Residential_Address;
                    existingPatient.User.Picture = updatedPatient.User.Picture;
                    existingPatient.User.UpdatedAt = DateTime.Now;
                }

                // Update Patient info
                existingPatient.MedicalCode = updatedPatient.MedicalCode;
                existingPatient.InsuranceCode = updatedPatient.InsuranceCode;
                existingPatient.EmergencyContactName = updatedPatient.EmergencyContactName;
                existingPatient.EmergencyContactPhone = updatedPatient.EmergencyContactPhone;
                existingPatient.Note = updatedPatient.Note;
                existingPatient.UpdatedAt = DateTime.Now;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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