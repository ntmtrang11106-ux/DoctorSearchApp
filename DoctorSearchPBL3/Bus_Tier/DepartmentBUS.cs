using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class DepartmentBUS
    {
        private readonly DepartmentDAL _deptDAL = new DepartmentDAL();

        /// <summary>
        /// Lấy danh sách các chuyên khoa để hiển thị lên UI (ComboBox)
        /// </summary>
        /// <returns>Danh sách DepartmentDTO</returns>
        public List<DepartmentDTO> GetDepartmentsForUI()
        {
            // Tầng BUS có thể thêm logic kiểm tra nếu cần
            // Ví dụ: Nếu danh sách trống thì log lỗi hoặc xử lý mặc định
            return _deptDAL.GetActiveDepartments();
        }

        ////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Lấy tên chuyên khoa khi biết ID
        /// </summary>
        public string GetDepartmentNameById(int id)
        {
            var dept = _deptDAL.GetDepartmentById(id);
            return dept != null ? dept.DepartmentName : "Không xác định";
        }
    }
}