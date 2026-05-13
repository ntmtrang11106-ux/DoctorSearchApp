using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DAL_Tier
{
    public class DepartmentDAL
    {
        public List<DepartmentDTO> GetActiveDepartments()
        {
            using var context = new AppDbContext();
            return context.Departments
                .AsNoTracking()
                .Where(d => d.IsActive == true && d.IsDeleted == false)
                .OrderBy(d => d.DisplayOrder)
                .ToList();
        }

        public List<DepartmentDTO> GetAllDepartments()
        {
            using var context = new AppDbContext();
            return context.Departments
                .Where(d => !d.IsDeleted)
                .OrderByDescending(d => d.DisplayOrder) // Mới nhất lên đầu
                .ToList();
        }

        public DepartmentDTO? GetDepartmentById(int id)
        {
            using var context = new AppDbContext();
            return context.Departments.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
        }

        public bool AddDepartment(DepartmentDTO dept)
        {
            using var context = new AppDbContext();
            
            // Tự động tính DisplayOrder tiếp theo
            int maxOrder = 0;
            if (context.Departments.Any())
            {
                maxOrder = context.Departments.Max(d => d.DisplayOrder);
            }
            dept.DisplayOrder = maxOrder + 1;
            
            dept.CreatedAt = DateTime.Now;
            dept.IsDeleted = false;
            context.Departments.Add(dept);
            return context.SaveChanges() > 0;
        }

        public bool UpdateDepartment(DepartmentDTO dept)
        {
            using var context = new AppDbContext();
            var existing = context.Departments.Find(dept.Id);
            if (existing == null) return false;

            existing.DepartmentName = dept.DepartmentName;
            existing.Description = dept.Description;
            existing.DisplayOrder = dept.DisplayOrder;
            existing.IsActive = dept.IsActive;
            existing.UpdatedAt = DateTime.Now;

            return context.SaveChanges() > 0;
        }

        public bool DeleteDepartment(int id)
        {
            using var context = new AppDbContext();
            var existing = context.Departments.Find(id);
            if (existing == null) return false;

            existing.IsDeleted = true;
            existing.DeletedAt = DateTime.Now;
            return context.SaveChanges() > 0;
        }
    }
}