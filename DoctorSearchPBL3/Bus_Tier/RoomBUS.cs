using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class RoomBUS
    {
        private readonly RoomDAL _dal = new RoomDAL();

        public List<RoomDTO> GetRoomsForComboBox()
        {
            return _dal.GetAllRooms();
        }

        public string GetRoomDisplayName(int id)
        {
            var room = _dal.GetRoomById(id);
            return room != null ? $"{room.RoomName} ({room.RoomCode})" : "N/A";
        }

        public List<RoomDTO> GetRoomsByDepartment(int departmentId)
        {
            if (departmentId <= 0)
            {
                return new List<RoomDTO>();
            }

            return _dal.GetRoomsByDepartment(departmentId);
        }

        public List<RoomDTO> GetAvailableRoomsByDepartmentAndTime(int departmentId, DateTime workDate, TimeSpan startTime, TimeSpan endTime, int? excludeSlotId = null)
        {
            if (departmentId <= 0 || endTime <= startTime)
            {
                return new List<RoomDTO>();
            }

            return _dal.GetAvailableRoomsByDepartmentAndTime(departmentId, workDate, startTime, endTime, excludeSlotId);
        }

        /// <summary>
        /// Lấy số lượng phòng khám của một chuyên khoa.
        /// </summary>
        /// <param name="departmentId">ID chuyên khoa</param>
        /// <param name="includeDeleted">Nếu true, đếm cả các phòng đã bị xóa mềm</param>
        /// <returns>Số lượng phòng khám hợp lệ</returns>
        public int GetRoomCountByDepartmentId(int departmentId, bool includeDeleted = false)
        {
            if (departmentId <= 0)
            {
                return 0;
            }

            return _dal.GetRoomCountByDepartmentId(departmentId, includeDeleted);
        }

        /// <summary>
        /// Lấy danh sách các phòng khám đang hoạt động trùng mã trong danh sách cho trước.
        /// Nghiệp vụ của BUS: Lọc danh sách mã phòng đầu vào trống/null, sau đó gọi tầng DAL tìm kiếm trong CSDL.
        /// </summary>
        /// <param name="roomCodes">Danh sách mã phòng cần kiểm tra</param>
        /// <param name="excludeDepartmentId">ID chuyên khoa loại trừ (nếu có)</param>
        /// <returns>Danh sách phòng khám trùng mã đang hoạt động ở chuyên khoa khác</returns>
        public List<RoomDTO> GetActiveRoomsByCodes(List<string> roomCodes, int? excludeDepartmentId = null)
        {
            if (roomCodes == null || roomCodes.Count == 0)
            {
                return new List<RoomDTO>();
            }

            // Chuẩn hóa danh sách mã phòng thành chữ in hoa và loại bỏ khoảng trắng dư thừa
            List<string> cleanCodes = roomCodes
                .Where(code => !string.IsNullOrWhiteSpace(code))
                .Select(code => code.Trim().ToUpperInvariant())
                .Distinct()
                .ToList();

            if (cleanCodes.Count == 0)
            {
                return new List<RoomDTO>();
            }

            return _dal.GetActiveRoomsByCodes(cleanCodes, excludeDepartmentId);
        }
    }
}
