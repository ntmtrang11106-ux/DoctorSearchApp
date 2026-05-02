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


        // 1. Lấy danh sách lịch hẹn
        public List<AppointmentsDTO> GetAllAppointments()
        {
            try
            {
                return _context.Appointments
                    .Include(a => a.Patient).ThenInclude(p => p.User)
                    .Include(a => a.Doctor).ThenInclude(d => d.User)
                    .Include(a => a.TimeSlot)
                    .OrderByDescending(a => a.CreatedAt)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetAllAppointments: " + ex.Message);
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
    }
}