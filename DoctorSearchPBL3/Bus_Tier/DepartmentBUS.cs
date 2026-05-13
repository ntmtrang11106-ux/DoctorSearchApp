using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class DepartmentBUS
    {
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
            var dept = _deptDAL.GetDepartmentById(id);
            return dept != null ? dept.DepartmentName : "Không xác định";
        }

        public bool AddDepartment(DepartmentDTO dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName)) return false;
            return _deptDAL.AddDepartment(dept);
        }

        public bool UpdateDepartment(DepartmentDTO dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName)) return false;
            return _deptDAL.UpdateDepartment(dept);
        }

        public bool DeleteDepartment(int id)
        {
            return _deptDAL.DeleteDepartment(id);
        }
    }
}