using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    /// <summary>
    /// Lớp truy cập dữ liệu (Data Access Layer) của Chuyên khoa (Department).
    /// Chỉ thực hiện các thao tác đọc/ghi trực tiếp vào Cơ sở dữ liệu và quản lý Transaction.
    /// </summary>
    public class DepartmentDAL
    {
        /// <summary>
        /// Lấy danh sách các chuyên khoa đang hoạt động (IsActive = true và IsDeleted = false).
        /// </summary>
        public List<DepartmentDTO> GetActiveDepartments()
        {
            using AppDbContext context = new AppDbContext();
            return context.Departments
                .AsNoTracking()
                .Where(d => d.IsActive && !d.IsDeleted)
                .OrderBy(d => d.DisplayOrder)
                .ToList();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách chuyên khoa, sắp xếp theo thứ tự hiển thị giảm dần.
        /// </summary>
        public List<DepartmentDTO> GetAllDepartments(bool includeDeleted = false)
        {
            using AppDbContext context = new AppDbContext();
            IQueryable<DepartmentDTO> query = context.Departments;
            if (!includeDeleted)
            {
                query = query.Where(d => !d.IsDeleted);
            }
            return query.OrderByDescending(d => d.DisplayOrder).ToList();
        }

        /// <summary>
        /// Lấy thông tin chi tiết của chuyên khoa theo Id nếu chưa bị xóa mềm.
        /// </summary>
        public DepartmentDTO? GetDepartmentById(int id)
        {
            using AppDbContext context = new AppDbContext();
            return context.Departments.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
        }

        /// <summary>
        /// Kiểm tra xem tên chuyên khoa đã tồn tại trên hệ thống hay chưa (chưa bị xóa mềm).
        /// Nhiệm vụ của DAL: Thực hiện truy vấn SELECT ANY trực tiếp trên bảng Department.
        /// </summary>
        /// <param name="name">Tên chuyên khoa cần kiểm tra</param>
        /// <param name="excludeId">ID chuyên khoa loại trừ (khi thực hiện Update)</param>
        /// <returns>True nếu đã tồn tại, ngược lại là False</returns>
        public bool IsDepartmentNameExists(string name, int? excludeId = null)
        {
            using AppDbContext context = new AppDbContext();
            string nameUpper = name.Trim().ToUpper();
            return context.Departments.Any(d =>
                !d.IsDeleted
                && d.DepartmentName.ToUpper() == nameUpper
                && (!excludeId.HasValue || d.Id != excludeId.Value));
        }

        /// <summary>
        /// Thêm mới chuyên khoa đơn lẻ vào cơ sở dữ liệu.
        /// </summary>
        public bool AddDepartment(DepartmentDTO dept)
        {
            using AppDbContext context = new AppDbContext();

            // Tính toán thứ tự hiển thị tự động tăng
            int maxOrder = context.Departments.Any() ? context.Departments.Max(d => d.DisplayOrder) : 0;
            dept.DisplayOrder = maxOrder + 1;
            dept.CreatedAt = DateTime.Now;
            dept.IsDeleted = false;

            context.Departments.Add(dept);
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// Thêm mới chuyên khoa kèm theo danh sách phòng khám ban đầu.
        /// Sử dụng Transaction để đảm bảo tính toàn vẹn dữ liệu.
        /// Nhiệm vụ của DAL: Chỉ thực hiện ghi dữ liệu thô vào bảng Department và Room trong cùng 1 Transaction,
        /// hoàn toàn không chứa các logic nghiệp vụ kiểm tra trùng phòng hoặc trùng tên khoa (được xử lý trước ở BUS).
        /// </summary>
        public bool AddDepartmentWithRooms(DepartmentDTO dept, List<RoomDTO> rooms)
        {
            using AppDbContext context = new AppDbContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                // 1. Thêm chuyên khoa mới vào DB trước để lấy Id tự tăng
                int maxOrder = context.Departments.Any() ? context.Departments.Max(d => d.DisplayOrder) : 0;
                dept.DisplayOrder = maxOrder + 1;
                dept.CreatedAt = DateTime.Now;
                dept.IsDeleted = false;

                context.Departments.Add(dept);
                context.SaveChanges(); // Lưu để phát sinh Id của dept

                // 2. Xử lý từng phòng khám được gán vào chuyên khoa này
                foreach (RoomDTO room in rooms)
                {
                    // Kiểm tra xem phòng khám này đã từng tồn tại trong hệ thống chưa (kể cả đã bị xóa mềm)
                    var existingDbRoom = context.Rooms.FirstOrDefault(r => r.RoomCode.ToUpper() == room.RoomCode.ToUpper());
                    if (existingDbRoom != null)
                    {
                        // Tái sử dụng phòng khám hiện có: chuyển nhượng DepartmentId và khôi phục hoạt động
                        existingDbRoom.DepartmentId = dept.Id;
                        existingDbRoom.IsDeleted = false;
                        existingDbRoom.DeletedAt = null;
                        existingDbRoom.IsActive = true;
                        existingDbRoom.RoomName = room.RoomName.Trim();
                        existingDbRoom.UpdatedAt = DateTime.Now;
                    }
                    else
                    {
                        // Tạo mới phòng khám hoàn toàn nếu chưa từng tồn tại
                        room.DepartmentId = dept.Id;
                        room.RoomCode = room.RoomCode.Trim().ToUpperInvariant();
                        room.RoomName = room.RoomName.Trim();
                        room.CreatedAt = DateTime.Now;
                        room.IsDeleted = false;
                        room.IsActive = true;
                        context.Rooms.Add(room);
                    }
                }

                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Cập nhật thông tin cơ bản của một chuyên khoa.
        /// Nhiệm vụ của DAL: Chỉ cập nhật các trường dữ liệu và lưu xuống DB, không chứa nghiệp vụ trùng tên (được xử lý trước ở BUS).
        /// </summary>
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

        /// <summary>
        /// Xóa chuyên khoa (Soft Delete) và tự động xóa mềm tất cả các phòng khám thuộc chuyên khoa đó.
        /// </summary>
        public bool DeleteDepartment(int id)
        {
            using AppDbContext context = new AppDbContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                DepartmentDTO existing = context.Departments.Find(id);
                if (existing == null)
                {
                    transaction.Rollback();
                    return false;
                }

                // 1. Soft-delete chuyên khoa
                existing.IsDeleted = true;
                existing.DeletedAt = DateTime.Now;
                existing.IsActive = false;

                // 2. Soft-delete tất cả các phòng khám thuộc chuyên khoa này
                var rooms = context.Rooms.Where(r => r.DepartmentId == id && !r.IsDeleted).ToList();
                foreach (var room in rooms)
                {
                    room.IsDeleted = true;
                    room.DeletedAt = DateTime.Now;
                    room.IsActive = false;
                }

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

        /// <summary>
        /// Cập nhật chuyên khoa và đồng bộ danh sách phòng khám (thêm phòng mới, khôi phục phòng cũ, xóa phòng không còn dùng).
        /// Sử dụng Transaction để đảm bảo tính nhất quán dữ liệu.
        /// Nhiệm vụ của DAL: Thực hiện các lệnh INSERT, UPDATE, soft-delete phòng khám trên CSDL.
        /// Các nghiệp vụ validate trùng mã phòng hoặc trùng tên khoa đã được BUS xử lý trước.
        /// </summary>
        public bool UpdateDepartmentWithRooms(DepartmentDTO dept, List<RoomDTO> rooms)
        {
            using AppDbContext context = new AppDbContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                // 1. Cập nhật thông tin Chuyên khoa
                DepartmentDTO existing = context.Departments.Find(dept.Id);
                if (existing == null)
                {
                    transaction.Rollback();
                    return false;
                }

                existing.DepartmentName = dept.DepartmentName;
                existing.Description = dept.Description;
                existing.DisplayOrder = dept.DisplayOrder;
                existing.IsActive = dept.IsActive;
                existing.UpdatedAt = DateTime.Now;

                context.SaveChanges();

                // 2. Lấy danh sách phòng hiện tại chưa bị xóa của khoa này trong DB
                var existingRooms = context.Rooms
                    .Where(r => r.DepartmentId == dept.Id && !r.IsDeleted)
                    .ToList();

                // Danh sách mã phòng mới từ giao diện
                var newRoomCodes = rooms
                    .Select(r => r.RoomCode.Trim().ToUpperInvariant())
                    .Distinct()
                    .ToList();

                // Xác định danh sách phòng cần thêm mới (không nằm trong danh sách phòng hiện tại của khoa)
                var roomsToAdd = rooms
                    .Where(r => !existingRooms.Any(er => er.RoomCode.ToUpper() == r.RoomCode.Trim().ToUpper()))
                    .ToList();

                // Xác định danh sách phòng cần xóa (có trong CSDL nhưng không có trong danh sách mới từ UI)
                var roomsToDelete = existingRooms
                    .Where(er => !newRoomCodes.Contains(er.RoomCode.ToUpper()))
                    .ToList();

                // 3. Thực hiện thêm mới hoặc khôi phục/tái sử dụng phòng khám
                foreach (var room in roomsToAdd)
                {
                    // Kiểm tra xem phòng khám này từng tồn tại trong hệ thống hay chưa (kể cả đã bị xóa mềm)
                    var existingDbRoom = context.Rooms.FirstOrDefault(r => r.RoomCode.ToUpper() == room.RoomCode.ToUpper());
                    if (existingDbRoom != null)
                    {
                        // Tái sử dụng phòng khám: chuyển khoa và đặt lại trạng thái hoạt động
                        existingDbRoom.DepartmentId = dept.Id;
                        existingDbRoom.IsDeleted = false;
                        existingDbRoom.DeletedAt = null;
                        existingDbRoom.IsActive = true;
                        existingDbRoom.RoomName = room.RoomName.Trim();
                        existingDbRoom.UpdatedAt = DateTime.Now;
                    }
                    else
                    {
                        // Tạo mới hoàn toàn
                        room.DepartmentId = dept.Id;
                        room.RoomCode = room.RoomCode.Trim().ToUpperInvariant();
                        room.RoomName = room.RoomName.Trim();
                        room.CreatedAt = DateTime.Now;
                        room.IsDeleted = false;
                        room.IsActive = true;
                        context.Rooms.Add(room);
                    }
                }

                // 4. Soft-delete phòng bị gỡ bỏ khỏi chuyên khoa
                foreach (var room in roomsToDelete)
                {
                    room.IsDeleted = true;
                    room.DeletedAt = DateTime.Now;
                    room.IsActive = false;
                }

                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
