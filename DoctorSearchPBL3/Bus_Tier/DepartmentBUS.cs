using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BUS_Tier
{
    public class DepartmentBUS
    {
        private static readonly Regex RoomCodePattern = new Regex(@"^[A-Za-z][A-Za-z0-9]*\.[0-9]{3}$", RegexOptions.Compiled);
        private readonly DepartmentDAL _deptDAL = new DepartmentDAL();

        public List<DepartmentDTO> GetDepartmentsForUI()
        {
            return _deptDAL.GetActiveDepartments();
        }

        public List<DepartmentDTO> GetAllDepartments()
        {
            return _deptDAL.GetAllDepartments();
        }

        public DepartmentDTO GetDepartmentById(int id)
        {
            return _deptDAL.GetDepartmentById(id);
        }

        public string GetDepartmentNameById(int id)
        {
            DepartmentDTO dept = _deptDAL.GetDepartmentById(id);
            return dept != null ? dept.DepartmentName : "Không xác định";
        }

        public bool AddDepartment(DepartmentDTO dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName))
            {
                return false;
            }

            return _deptDAL.AddDepartment(dept);
        }

        public bool AddDepartmentWithRooms(DepartmentDTO dept, List<RoomDTO> rooms)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName) || rooms == null || !rooms.Any())
            {
                return false;
            }

            List<RoomDTO> validRooms = rooms
                .Where(r =>
                    !string.IsNullOrWhiteSpace(r.RoomCode) &&
                    !string.IsNullOrWhiteSpace(r.RoomName) &&
                    RoomCodePattern.IsMatch(r.RoomCode.Trim()))
                .ToList();

            if (validRooms.Count == 0)
            {
                return false;
            }

            int distinctRoomCodes = validRooms
                .Select(r => r.RoomCode.Trim().ToUpperInvariant())
                .Distinct()
                .Count();

            if (distinctRoomCodes != validRooms.Count)
            {
                return false;
            }

            return _deptDAL.AddDepartmentWithRooms(dept, validRooms);
        }

        public bool UpdateDepartment(DepartmentDTO dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName))
            {
                return false;
            }

            return _deptDAL.UpdateDepartment(dept);
        }

        public bool DeleteDepartment(int id)
        {
            return _deptDAL.DeleteDepartment(id);
        }

        public int GetRoomCountByDepartmentId(int departmentId)
        {
            if (departmentId <= 0)
            {
                return 0;
            }

            return _deptDAL.GetRoomCountByDepartmentId(departmentId);
        }
    }
}
