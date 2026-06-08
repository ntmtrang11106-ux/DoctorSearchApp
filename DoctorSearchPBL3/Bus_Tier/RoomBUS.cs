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
    }
}
