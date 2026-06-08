using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class DepartmentDAL
    {
        public List<DepartmentDTO> GetActiveDepartments()
        {
            using AppDbContext context = new AppDbContext();
            return context.Departments
                .AsNoTracking()
                .Where(d => d.IsActive && !d.IsDeleted)
                .OrderBy(d => d.DisplayOrder)
                .ToList();
        }

        public List<DepartmentDTO> GetAllDepartments()
        {
            using AppDbContext context = new AppDbContext();
            return context.Departments
                .Where(d => !d.IsDeleted)
                .OrderByDescending(d => d.DisplayOrder)
                .ToList();
        }

        public DepartmentDTO? GetDepartmentById(int id)
        {
            using AppDbContext context = new AppDbContext();
            return context.Departments.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
        }

        public bool AddDepartment(DepartmentDTO dept)
        {
            using AppDbContext context = new AppDbContext();

            int maxOrder = context.Departments.Any() ? context.Departments.Max(d => d.DisplayOrder) : 0;
            dept.DisplayOrder = maxOrder + 1;
            dept.CreatedAt = DateTime.Now;
            dept.IsDeleted = false;

            context.Departments.Add(dept);
            return context.SaveChanges() > 0;
        }

        public bool AddDepartmentWithRooms(DepartmentDTO dept, List<RoomDTO> rooms)
        {
            using AppDbContext context = new AppDbContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                List<string> roomCodes = rooms
                    .Select(r => r.RoomCode.Trim().ToUpperInvariant())
                    .ToList();

                bool hasExistingRoomCode = context.Rooms.Any(r => !r.IsDeleted && roomCodes.Contains(r.RoomCode.ToUpper()));
                if (hasExistingRoomCode)
                {
                    transaction.Rollback();
                    return false;
                }

                int maxOrder = context.Departments.Any() ? context.Departments.Max(d => d.DisplayOrder) : 0;
                dept.DisplayOrder = maxOrder + 1;
                dept.CreatedAt = DateTime.Now;
                dept.IsDeleted = false;

                context.Departments.Add(dept);
                context.SaveChanges();

                foreach (RoomDTO room in rooms)
                {
                    room.DepartmentId = dept.Id;
                    room.RoomCode = room.RoomCode.Trim().ToUpperInvariant();
                    room.RoomName = room.RoomName.Trim();
                    room.CreatedAt = DateTime.Now;
                    room.IsDeleted = false;
                    room.IsActive = true;
                }

                context.Rooms.AddRange(rooms);
                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool UpdateDepartment(DepartmentDTO dept)
        {
            using AppDbContext context = new AppDbContext();
            DepartmentDTO existing = context.Departments.Find(dept.Id);
            if (existing == null)
            {
                return false;
            }

            existing.DepartmentName = dept.DepartmentName;
            existing.Description = dept.Description;
            existing.DisplayOrder = dept.DisplayOrder;
            existing.IsActive = dept.IsActive;
            existing.UpdatedAt = DateTime.Now;

            return context.SaveChanges() > 0;
        }

        public bool DeleteDepartment(int id)
        {
            using AppDbContext context = new AppDbContext();
            DepartmentDTO existing = context.Departments.Find(id);
            if (existing == null)
            {
                return false;
            }

            existing.IsDeleted = true;
            existing.DeletedAt = DateTime.Now;
            return context.SaveChanges() > 0;
        }

        public int GetRoomCountByDepartmentId(int departmentId)
        {
            using AppDbContext context = new AppDbContext();
            return context.Rooms.Count(r => r.DepartmentId == departmentId && !r.IsDeleted && r.IsActive);
        }
    }
}
