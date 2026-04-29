using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class RoomBUS
    {
        private readonly RoomDAL _dal = new RoomDAL();

        // Hàm này dùng để load vào ComboBox ở UI
        public List<RoomDTO> GetRoomsForComboBox()
        {
            // Nhân có thể thêm logic kiểm tra quyền ở đây nếu cần
            return _dal.GetAllRooms();
        }

        // Hàm lấy tên phòng nhanh để hiển thị
        public string GetRoomDisplayName(int id)
        {
            var room = _dal.GetRoomById(id);
            return room != null ? $"{room.RoomName} ({room.RoomCode})" : "N/A";
        }
    }
}