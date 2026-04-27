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

        // 1. Lấy danh sách lịch hẹn (Nạp kèm thông tin Patient, Doctor, TimeSlot)
        public List<AppointmentsDTO> GetAllAppointments()
        {
            try
            {
                // Dùng Include để Join các bảng liên quan (Eager Loading)
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

        // 2. Tạo lịch hẹn mới
        public bool CreateAppointment(AppointmentsDTO app)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Bước 1: Gán các giá trị mặc định nếu BUS chưa gán
                    app.CreatedAt = DateTime.Now;
                    if (string.IsNullOrEmpty(app.Status)) app.Status = "Chờ duyệt";

                    // Xử lý Symptoms để tránh lỗi NOT NULL trong CSDL
                    if (string.IsNullOrWhiteSpace(app.Symptoms))
                    {
                        app.Symptoms = "Chưa cập nhật";
                    }

                    // Bước 2: Tìm và kiểm tra trạng thái TimeSlot trong DB
                    var slot = _context.TimeSlots.FirstOrDefault(s => s.Id == app.TimeSlotId);
                    if (slot == null)
                    {
                        throw new Exception("Không tìm thấy khung giờ (TimeSlot) tương ứng!");
                    }

                    // Kiểm tra xem slot có còn 'Trống' không (Tránh trùng lịch thực tế trong DB)
                    if (slot.Status != "Trống")
                    {
                        throw new Exception("Khung giờ này đã bị chiếm dụng!");
                    }

                    // Bước 3: Cập nhật trạng thái slot và thêm lịch hẹn
                    slot.Status = "Đã đặt";
                    _context.Appointments.Add(app);

                    // Bước 4: Lưu thay đổi đồng bộ
                    _context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Log chi tiết để nhóm (Nhân, Trang, Tiên) dễ theo dõi
                    Console.WriteLine($"Lỗi DAL CreateAppointment: {ex.Message}");
                    return false;
                }
            }
        }

        // Hàm bổ trợ để tầng BUS gọi kiểm tra nhanh mà không cần mở transaction
        public bool IsSlotBooked(int timeSlotId)
        {
            return _context.Appointments.Any(a => a.TimeSlotId == timeSlotId && a.Status != "Đã hủy");
        }

        // 3. Hàm cập nhật trạng thái Chấp nhận (Duyệt lịch)
        public bool UpdateStatusToAccept(int appointmentId)
        {
            try
            {
                // Tìm lịch hẹn và khung giờ cùng lúc
                var app = _context.Appointments
                    .Include(a => a.TimeSlot)
                    .FirstOrDefault(a => a.Id == appointmentId);

                if (app == null || app.TimeSlot == null) return false;

                // Cập nhật trạng thái cho cả 2 bảng
                app.Status = "Đã duyệt";
                app.TimeSlot.Status = "Đã đặt"; // Khớp với SQL của Nhân

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi UpdateStatusToAccept: " + ex.Message);
                return false;
            }
        }

        // 4. Hàm cập nhật trạng thái Từ chối (Giải phóng khung giờ)
        public bool UpdateStatusToReject(int appointmentId)
        {
            try
            {
                var app = _context.Appointments
                    .Include(a => a.TimeSlot)
                    .FirstOrDefault(a => a.Id == appointmentId);

                if (app == null || app.TimeSlot == null) return false;

                app.Status = "Đã hủy";
                app.TimeSlot.Status = "Trống"; // Trả khung giờ về trạng thái tự do

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi UpdateStatusToReject: " + ex.Message);
                return false;
            }
        }
    }
}