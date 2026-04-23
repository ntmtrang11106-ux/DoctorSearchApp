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
                    // Bước 1: Gán các giá trị mặc định nếu cần
                    app.CreatedAt = DateTime.Now;
                    if (string.IsNullOrEmpty(app.Status))
                        app.Status = "Chờ duyệt";

                    // Bước 2: Thêm bản ghi vào bảng Appointments
                    _context.Appointments.Add(app);

                    // Bước 3: Tìm TimeSlot tương ứng và cập nhật trạng thái
                    var slot = _context.TimeSlots.FirstOrDefault(s => s.Id == app.TimeSlotId);
                    if (slot != null)
                    {
                        // Kiểm tra nếu slot vẫn đang 'Trống' mới cho đặt
                        if (slot.Status == "Trống")
                        {
                            slot.Status = "Đã đặt"; // Khóa khung giờ ngay khi bấm đặt
                        }
                        else
                        {
                            throw new Exception("Khung giờ này đã có người khác đặt mất rồi!");
                        }
                    }

                    // Bước 4: Lưu tất cả thay đổi
                    _context.SaveChanges();

                    // Xác nhận hoàn tất transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi thì hủy bỏ toàn bộ (không tạo lịch, không khóa giờ)
                    transaction.Rollback();
                    Console.WriteLine("Lỗi CreateAppointment: " + ex.Message);
                    return false;
                }
            }
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