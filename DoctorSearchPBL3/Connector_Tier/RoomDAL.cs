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

        public List<RoomDTO> GetRoomsByDepartment(int departmentId)
        {
            using (var context = new AppDbContext())
            {
                return context.Rooms
                    .Where(r => r.DepartmentId == departmentId && !r.IsDeleted && r.IsActive)
                    .OrderBy(r => r.RoomCode)
                    .ThenBy(r => r.RoomName)
                    .ToList();
            }
        }

        public List<RoomDTO> GetAvailableRoomsByDepartmentAndTime(int departmentId, DateTime workDate, TimeSpan startTime, TimeSpan endTime, int? excludeSlotId = null)
        {
            using (var context = new AppDbContext())
            {
                var roomsQuery = context.Rooms
                    .Where(r => r.DepartmentId == departmentId && !r.IsDeleted && r.IsActive);

                var conflictsQuery = context.TimeSlots
                    .Where(ts =>
                        !ts.IsDeleted &&
                        ts.WorkDate.Date == workDate.Date &&
                        (!excludeSlotId.HasValue || ts.Id != excludeSlotId.Value) &&
                        ((startTime >= ts.StartTime && startTime < ts.EndTime) ||
                         (endTime > ts.StartTime && endTime <= ts.EndTime) ||
                         (startTime <= ts.StartTime && endTime >= ts.EndTime)))
                    .Select(ts => ts.RoomId);

                return roomsQuery
                    .Where(r => !conflictsQuery.Contains(r.Id))
                    .OrderBy(r => r.RoomCode)
                    .ThenBy(r => r.RoomName)
                    .ToList();
            }
        }
    }
}
