using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class RoomDAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        // Lấy danh sách tất cả các phòng chưa bị xóa và đang hoạt động
        public List<RoomDTO> GetAllRooms()
        {
            using (var _context = new AppDbContext()) // Dùng đúng tên AppDbContext của nhóm
            {
                return _context.Rooms
                    .Where(r => r.IsDeleted == false && r.IsActive == true)
                    .ToList();
            }
        }

        // Lấy thông tin một phòng cụ thể theo ID
        public RoomDTO GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.Id == id && r.IsDeleted == false);
        }
    }
}