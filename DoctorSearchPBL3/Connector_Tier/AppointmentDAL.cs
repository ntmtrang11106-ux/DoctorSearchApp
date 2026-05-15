using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL_Tier
{
    public class AppointmentDAL
    {
        private readonly AppDbContext _context;

        public AppointmentDAL()
        {
            _context = new AppDbContext();
        }

        public bool CreateAppointment(AppointmentsDTO appointmentDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tìm TimeSlot và kiểm tra tính khả dụng
                    var timeSlot = _context.TimeSlots
                        .FirstOrDefault(ts => ts.Id == appointmentDto.TimeSlotId && !ts.IsDeleted);

                    // Kiểm tra: Slot phải tồn tại, đang Open và còn chỗ trống
                    if (timeSlot == null || timeSlot.Status != "Open" || timeSlot.BookedCount >= timeSlot.MaxAppointments)
                    {
                        return false;
                    }

                    // 2. Tăng số lượng người đặt
                    timeSlot.BookedCount += 1;

                    // 3. LOGIC QUAN TRỌNG: Nếu đủ MaxAppointments thì chuyển sang Full
                    if (timeSlot.BookedCount >= timeSlot.MaxAppointments)
                    {
                        timeSlot.Status = "Full"; // Cập nhật trạng thái theo yêu cầu của bạn
                    }

                    // 4. Tạo bản ghi Appointment với các Snapshot từ DTO
                    var appointment = new AppointmentsDTO
                    {
                        PatientId = appointmentDto.PatientId,
                        DoctorId = appointmentDto.DoctorId,
                        TimeSlotId = appointmentDto.TimeSlotId,
                        Reason = appointmentDto.Reason,
                        Status = "Pending", // Mặc định từ DB
                        DoctorNameSnapshot = appointmentDto.DoctorNameSnapshot,
                        DepartmentNameSnapshot = appointmentDto.DepartmentNameSnapshot,
                        RoomNameSnapshot = appointmentDto.RoomNameSnapshot,
                        FeeSnapshot = appointmentDto.FeeSnapshot,
                        CreatedAt = DateTime.Now
                    };

                    _context.Appointments.Add(appointment);
                    _context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        //////////////////////////////////////////////////


        public AppointmentsDTO GetById(int appointmentId)
        {
            try
            {
                return _context.Appointments.AsNoTracking().FirstOrDefault(a => a.Id == appointmentId);
            }
            catch
            {
                return null;
            }
        }

        // 1. Lấy danh sách lịch hẹn
        public List<AppointmentsDTO> GetAllAppointments()
        {
            try
            {
                return _context.Appointments
                    .AsNoTracking()
                    .Include(a => a.Patient).ThenInclude(p => p.User)
                    .Include(a => a.Doctor).ThenInclude(d => d.User)
                    .Include(a => a.Doctor).ThenInclude(d => d.Department)
                    .Include(a => a.TimeSlot).ThenInclude(ts => ts.Room)
                    .OrderByDescending(a => a.CreatedAt)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetAllAppointments: " + ex.Message);
                return new List<AppointmentsDTO>();
            }
        }

        // Lấy danh sách lịch hẹn của một bác sĩ cụ thể
        public List<AppointmentsDTO> GetAppointmentsByDoctorId(int doctorId)
        {
            try
            {
                return _context.Appointments
                    .AsNoTracking()
                    .Include(a => a.Patient).ThenInclude(p => p.User)
                    .Include(a => a.Doctor).ThenInclude(d => d.User)
                    .Include(a => a.TimeSlot)
                    .Where(a => a.DoctorId == doctorId)
                    .OrderByDescending(a => a.CreatedAt)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetAppointmentsByDoctorId: " + ex.Message);
                return new List<AppointmentsDTO>();
            }
        }

        // Lấy danh sách lịch hẹn của một bệnh nhân cụ thể
        public List<AppointmentsDTO> GetAppointmentsByPatientId(int patientId)
        {
            try
            {
                return _context.Appointments
                    .AsNoTracking()
                    .Include(a => a.Patient).ThenInclude(p => p.User)
                    .Include(a => a.Doctor).ThenInclude(d => d.User)
                    .Include(a => a.TimeSlot)
                    .Where(a => a.PatientId == patientId)
                    .OrderByDescending(a => a.CreatedAt)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetAppointmentsByPatientId: " + ex.Message);
                return new List<AppointmentsDTO>();
            }
        }

        // 2. Tạo lịch hẹn mới (Khớp với các cột Snapshot trong SQL)
        //public bool CreateAppointment(AppointmentsDTO app)
        //{
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            app.CreatedAt = DateTime.Now;
        //            // SQL mặc định là 'Pending', nếu BUS chưa gán thì để mặc định
        //            if (string.IsNullOrEmpty(app.Status)) app.Status = "Pending";

        //            // Bước 2: Kiểm tra TimeSlot
        //            var slot = _context.TimeSlots.FirstOrDefault(s => s.Id == app.TimeSlotId);
        //            if (slot == null) throw new Exception("Không tìm thấy khung giờ!");

        //            // Trong SQL của bạn Status mặc định là 'Open'
        //            if (slot.Status != "Open")
        //            {
        //                throw new Exception("Khung giờ này không còn trống!");
        //            }

        //            // Bước 3: Cập nhật slot sang 'Booked' (hoặc trạng thái bạn quy định)
        //            slot.Status = "Booked";
        //            slot.BookedCount += 1; // Tăng số lượng đã đặt

        //            _context.Appointments.Add(app);
        //            _context.SaveChanges();

        //            transaction.Commit();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            Console.WriteLine($"Lỗi CreateAppointment: {ex.Message}");
        //            return false;
        //        }
        //    }
        //}

        // 3. Duyệt lịch (Accept)
        public bool UpdateStatusToAccept(int appointmentId)
        {
            try
            {
                var app = _context.Appointments.Find(appointmentId);
                if (app == null) return false;

                app.Status = "Confirmed"; // Hoặc trạng thái tương ứng trong logic của nhóm
                app.UpdatedAt = DateTime.Now;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi UpdateStatusToAccept: " + ex.Message);
                return false;
            }
        }

        // 4. Từ chối/Hủy lịch (Giải phóng TimeSlot)
        public bool UpdateStatusToReject(int appointmentId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var app = _context.Appointments
                        .Include(a => a.TimeSlot)
                        .FirstOrDefault(a => a.Id == appointmentId);

                    if (app == null) return false;

                    app.Status = "Cancelled";
                    app.UpdatedAt = DateTime.Now;

                    if (app.TimeSlot != null)
                    {
                        app.TimeSlot.Status = "Open"; // Mở lại khung giờ
                        if (app.TimeSlot.BookedCount > 0)
                            app.TimeSlot.BookedCount -= 1;
                    }

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
        // 5. Lấy danh sách lịch hẹn của một bệnh nhân với một bác sĩ cụ thể, lọc theo ngày và giờ
        public List<AppointmentsDTO> GetPatientAppointmentsFiltered(int patientId, int doctorId, DateTime fromDate, DateTime toDate, TimeSpan fromTime, TimeSpan toTime)
        {
            try
            {
                return _context.Appointments
                    .AsNoTracking()
                    .Include(a => a.TimeSlot)
                    .Include(a => a.Doctor).ThenInclude(d => d.User)
                    .Where(a => a.PatientId == patientId && a.DoctorId == doctorId)
                    .Where(a => a.TimeSlot.WorkDate >= fromDate.Date && a.TimeSlot.WorkDate <= toDate.Date)
                    .Where(a => a.TimeSlot.StartTime >= fromTime && a.TimeSlot.EndTime <= toTime)
                    .OrderByDescending(a => a.TimeSlot.WorkDate)
                    .ThenBy(a => a.TimeSlot.StartTime)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetPatientAppointmentsFiltered: " + ex.Message);
                return new List<AppointmentsDTO>();
            }
        }
        public bool UpdateAppointment(int appointmentId, int newTimeSlotId, string newReason)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var app = _context.Appointments.Include(a => a.TimeSlot).FirstOrDefault(a => a.Id == appointmentId);
                    if (app == null) return false;

                    // Nếu đổi khung giờ
                    if (app.TimeSlotId != newTimeSlotId)
                    {
                        // 1. Giải phóng khung giờ cũ
                        if (app.TimeSlot != null)
                        {
                            app.TimeSlot.BookedCount = Math.Max(0, app.TimeSlot.BookedCount - 1);
                            // Luôn mở lại trạng thái Open nếu đã giảm số lượng đặt
                            if (app.TimeSlot.BookedCount < app.TimeSlot.MaxAppointments)
                                app.TimeSlot.Status = "Open";
                        }

                        // 2. Kiểm tra và chiếm khung giờ mới
                        var newSlot = _context.TimeSlots.FirstOrDefault(ts => ts.Id == newTimeSlotId && !ts.IsDeleted);
                        // Nếu slot mới không hợp lệ (không tồn tại hoặc đã đầy)
                        if (newSlot == null || (newSlot.Status != "Open" && newSlot.BookedCount >= newSlot.MaxAppointments)) 
                            return false;

                        newSlot.BookedCount += 1;
                        if (newSlot.BookedCount >= newSlot.MaxAppointments)
                            newSlot.Status = "Full";

                        app.TimeSlotId = newTimeSlotId;
                        
                        // 3. QUAN TRỌNG: Đổi giờ khám thì phải đưa về "Chờ duyệt" để bác sĩ duyệt lại
                        app.Status = "Pending";
                    }

                    app.Reason = newReason;
                    app.UpdatedAt = DateTime.Now;

                    _context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Lỗi UpdateAppointment: " + ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteAppointment(int appointmentId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var app = _context.Appointments.Include(a => a.TimeSlot).FirstOrDefault(a => a.Id == appointmentId);
                    if (app == null) return false;

                    // Giải phóng khung giờ
                    if (app.TimeSlot != null)
                    {
                        app.TimeSlot.BookedCount = Math.Max(0, app.TimeSlot.BookedCount - 1);
                        if (app.TimeSlot.BookedCount < app.TimeSlot.MaxAppointments)
                            app.TimeSlot.Status = "Open";
                    }

                    _context.Appointments.Remove(app);
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

        public AppointmentsDTO CheckPatientOverlap(int patientId, int timeSlotId, int excludeAppointmentId = -1)
        {
            try
            {
                var targetSlot = _context.TimeSlots.AsNoTracking().FirstOrDefault(ts => ts.Id == timeSlotId);
                if (targetSlot == null) return null;

                return _context.Appointments
                    .AsNoTracking()
                    .Include(a => a.TimeSlot)
                    .FirstOrDefault(a => a.PatientId == patientId
                                     && a.Id != excludeAppointmentId
                                     && a.Status != "Cancelled"
                                     && a.TimeSlot.WorkDate == targetSlot.WorkDate
                                     && a.TimeSlot.StartTime == targetSlot.StartTime
                                     && a.TimeSlot.EndTime == targetSlot.EndTime);
            }
            catch
            {
                return null;
            }
        }
        public bool UpdateStatus(int appointmentId, string newStatus, string note = null)
        {
            try
            {
                var app = _context.Appointments.Find(appointmentId);
                if (app == null) return false;

                app.Status = newStatus;
                if (note != null) app.Note = note;
                app.UpdatedAt = DateTime.Now;

                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
