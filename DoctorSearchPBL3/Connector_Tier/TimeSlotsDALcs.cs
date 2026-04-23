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

        // 2. Thêm danh sách khung giờ (Dùng AddRange cho nhanh)
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
    }
}