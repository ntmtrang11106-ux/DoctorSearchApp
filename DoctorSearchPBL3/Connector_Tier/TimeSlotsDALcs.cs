using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class TimeSlotDAL
    {
        private readonly AppDbContext _context;

        public TimeSlotDAL()
        {
            _context = new AppDbContext();
        }

        // 1. Thêm một khung giờ đơn lẻ
        public bool AddSingle(TimeSlotsDTO slot)
        {
            try
            {
                _context.TimeSlots.Add(slot);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL AddSingle: " + ex.Message);
                return false;
            }
        }

        // 2. Thêm danh sách khung giờ (Bulk Insert)
        public bool AddRange(List<TimeSlotsDTO> slots)
        {
            try
            {
                _context.TimeSlots.AddRange(slots);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL AddRange: " + ex.Message);
                return false;
            }
        }

        // 3. Kiểm tra khung giờ đã tồn tại chưa (Dựa vào CSDL thực tế)
        public bool IsSlotExisted(int doctorId, DateTime date, TimeSpan start, TimeSpan end)
        {
            // So sánh Date, StartTime, EndTime để tránh bác sĩ cài trùng giờ trong cùng 1 ngày
            return _context.TimeSlots.Any(s =>
                s.DoctorId == doctorId &&
                s.Date.Date == date.Date &&
        //s.StartTime == start &&
        //s.EndTime == end);
        // Tip: So sánh đến phút thôi để bỏ qua mấy cái mili giây lẻ cũ trong DB
        s.StartTime.Hours == start.Hours && s.StartTime.Minutes == start.Minutes &&
        s.EndTime.Hours == end.Hours && s.EndTime.Minutes == end.Minutes);
        }

        // 4. Lấy ID của khung giờ dựa trên thời gian (Dùng cho AppointmentBUS)
        public int GetSlotIdByDateTime(int doctorId, DateTime date)
        {
            // Tìm slot của bác sĩ đó trong ngày cụ thể
            // Lưu ý: Nếu 1 ngày có nhiều khung giờ, bạn cần truyền thêm StartTime/EndTime vào hàm này để lọc chính xác
            var slot = _context.TimeSlots.FirstOrDefault(s =>
                s.DoctorId == doctorId &&
                s.Date.Date == date.Date &&
                s.Status == "Trống"); // Chỉ lấy những slot còn trống

            return slot?.Id ?? 0;
        }

        // 5. Cập nhật trạng thái slot (Dùng khi hủy lịch hoặc đặt lịch)
        public bool UpdateSlotStatus(int slotId, string newStatus)
        {
            try
            {
                var slot = _context.TimeSlots.Find(slotId);
                if (slot != null)
                {
                    slot.Status = newStatus; // Cập nhật sang 'Đã đặt' hoặc 'Trống'
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}