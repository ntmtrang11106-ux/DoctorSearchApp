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

        // 1. Thêm khung giờ (Dùng WorkDate theo SQL)
        public bool AddSingle(TimeSlotsDTO slot)
        {
            try
            {
                if (slot.CreatedAt == default) slot.CreatedAt = DateTime.Now;
                _context.TimeSlots.Add(slot);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi AddSingle: " + ex.Message);
                return false;
            }
        }

        // 2. Kiểm tra trùng lịch (So sánh WorkDate)
        //public bool IsSlotExisted(int doctorId, DateTime date, TimeSpan start, TimeSpan end)
        //{
        //    return _context.TimeSlots.Any(s =>
        //        s.DoctorId == doctorId &&
        //        s.WorkDate.Date == date.Date && // Đổi thành WorkDate cho khớp SQL
        //        s.StartTime == start &&
        //        s.EndTime == end &&
        //        s.IsDeleted == false);
        //}
        // Hàm này tìm xem có lịch nào trùng ngày, trùng phòng và giao thoa giờ không
        public TimeSlotsDTO GetConflictSlot(DateTime date, TimeSpan start, TimeSpan end, int roomId)
        {
            // Kiểm tra trùng: Cùng ngày, cùng phòng và (Giờ bắt đầu hoặc Giờ kết thúc nằm trong khoảng đã có)
            return _context.TimeSlots.FirstOrDefault(s =>
                s.WorkDate.Date == date.Date &&
                s.RoomId == roomId &&
                s.IsDeleted == false &&
                ((start >= s.StartTime && start < s.EndTime) ||
                 (end > s.StartTime && end <= s.EndTime) ||
                 (start <= s.StartTime && end >= s.EndTime)));
        }

        // 3. Lấy danh sách khung giờ trống của bác sĩ
        public List<TimeSlotsDTO> GetAvailableSlots(int doctorId, DateTime date)
        {
            return _context.TimeSlots
                .Where(s => s.DoctorId == doctorId
                         && s.WorkDate.Date == date.Date
                         && s.Status == "Open" // Khớp với DEFAULT trong SQL
                         && s.IsDeleted == false)
                .ToList();
        }

        // 4. Cập nhật trạng thái slot
        public bool UpdateSlotStatus(int slotId, string newStatus)
        {
            try
            {
                var slot = _context.TimeSlots.Find(slotId);
                if (slot == null) return false;

                slot.Status = newStatus;
                slot.UpdatedAt = DateTime.Now;
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        // 5. Xóa mềm (Soft Delete) theo thiết kế có IsDeleted trong SQL
        public bool SoftDeleteSlot(int slotId)
        {
            try
            {
                var slot = _context.TimeSlots.Find(slotId);
                if (slot == null) return false;

                slot.IsDeleted = true;
                slot.DeletedAt = DateTime.Now;
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        // 6. Lấy ID của khung giờ dựa trên bác sĩ và ngày (Dùng cho đặt lịch lặp lại)
        public int GetSlotIdByDateTime(int doctorId, DateTime date)
        {
            try
            {
                // Lưu ý: SQL của bạn dùng cột WorkDate
                var slot = _context.TimeSlots.FirstOrDefault(s =>
                    s.DoctorId == doctorId &&
                    s.WorkDate.Date == date.Date &&
                    s.Status == "Open" && // Chỉ lấy khung giờ còn trống
                    s.IsDeleted == false);

                return slot?.Id ?? 0; // Trả về Id nếu tìm thấy, không thì trả về 0
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetSlotIdByDateTime: " + ex.Message);
                return 0;
            }
        }

        // Trong TimeSlotDAL.cs
        // Thêm hàm này để xử lý tạo hàng loạt lịch cho bác sĩ
        public bool AddRange(List<TimeSlotsDTO> list)
        {
            try
            {
                // Gán thời gian tạo cho từng phần tử trong danh sách nếu chưa có
                foreach (var item in list)
                {
                    if (item.CreatedAt == default) item.CreatedAt = DateTime.Now;
                }

                // Dùng AddRange của Entity Framework để nạp cả danh sách vào Context
                _context.TimeSlots.AddRange(list);

                // Lưu tất cả xuống SQL Server cùng một lúc (Tối ưu hơn là lưu từng cái)
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi AddRange (DAL): " + ex.Message);
                return false;
            }
        }
    }
}