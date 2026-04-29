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
            using var transaction = context.Database.BeginTransaction();
            try
            {
                // 1. Kiểm tra TimeSlot
                var slot = context.TimeSlots.FirstOrDefault(t => t.Id == app.TimeSlotId && !t.IsDeleted);
                if (slot == null) throw new Exception("Khung giờ không tồn tại.");

                // 2. Kiểm tra xem còn chỗ không
                if (slot.BookedCount >= slot.MaxAppointments) throw new Exception("Khung giờ này đã đầy.");

                // 3. Kiểm tra trùng lặp (1 bệnh nhân không đặt 2 lần vào 1 khung giờ)
                bool isDuplicate = context.Appointments.Any(a =>
                    a.PatientId == app.PatientId &&
                    a.TimeSlotId == app.TimeSlotId &&
                    a.Status != "Cancelled");

                if (isDuplicate) throw new Exception("Bạn đã có lịch hẹn ở khung giờ này.");

                // Cập nhật trạng thái
                app.Status = string.IsNullOrWhiteSpace(app.Status) ? "Pending" : app.Status;
                app.CreatedAt = DateTime.Now;

                // Lưu Appointment
                context.Appointments.Add(app);

                // Cập nhật TimeSlot
                slot.BookedCount++;
                if (slot.BookedCount >= slot.MaxAppointments)
                {
                    slot.Status = "Full";
                }
                slot.UpdatedAt = DateTime.Now;

                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                System.Diagnostics.Debug.WriteLine("Lỗi CreateAppointment: " + ex.Message);
                return false;
            }
        }
    }
}