using DTO_Tier;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class AppointmentDAL
    {
        public List<AppointmentsDTO> GetAllAppointments()
        {
            using var context = new AppDbContext();
            return context.Appointments
                .Include(a => a.Patient)
                    .ThenInclude(p => p.User)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Include(a => a.TimeSlot)
                .OrderByDescending(a => a.CreatedAt)
                .ToList();
        }

        public bool CreateAppointment(AppointmentsDTO app)
        {
            using var context = new AppDbContext();
            try
            {
                app.Status = string.IsNullOrWhiteSpace(app.Status) ? "Pending" : app.Status;
                app.CreatedAt = DateTime.Now;
                context.Appointments.Add(app);
                return context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
