using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class DepartmentDAL
    {
        private readonly AppDbContext _context;

        public DepartmentDAL() => _context = new AppDbContext();
        public DepartmentDAL(AppDbContext context) => _context = context;

        /// <summary>
        /// Lấy danh sách các chuyên khoa đang hoạt động để hiển thị lên ComboBox
        /// </summary>
        public List<DepartmentDTO> GetActiveDepartments()
        {
            return _context.Departments
                .AsNoTracking() // Tối ưu hiệu năng vì chỉ đọc dữ liệu
                .Where(d => d.IsActive == true && d.IsDeleted == false)
                .OrderBy(d => d.DisplayOrder) // Sắp xếp theo thứ tự hiển thị trong SQL
                .ToList();
        }

        /// <summary>
        /// Lấy thông tin chi tiết một chuyên khoa theo ID
        /// </summary>
        public DepartmentDTO? GetDepartmentById(int id)
        {
            return _context.Departments
                .FirstOrDefault(d => d.Id == id && !d.IsDeleted);
        }
    }
}