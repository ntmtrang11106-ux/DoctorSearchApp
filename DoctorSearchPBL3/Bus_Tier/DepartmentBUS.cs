using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BUS_Tier
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ (Business Logic Layer) của Chuyên khoa (Department).
    /// Thực hiện các ràng buộc logic nghiệp vụ như kiểm tra định dạng dữ liệu đầu vào,
    /// lọc phần tử trùng lặp trước khi gửi lệnh xuống tầng DAL.
    /// </summary>
    public class DepartmentBUS
    {
        // Ràng buộc định dạng mã phòng khám (Ví dụ: C1.202 - Chữ số viết tắt, dấu chấm và 3 số phòng)
        private static readonly Regex RoomCodePattern = new Regex(@"^[A-Za-z][A-Za-z0-9]*\.[0-9]{3}$", RegexOptions.Compiled);
        private readonly DepartmentDAL _deptDAL = new DepartmentDAL();
        private readonly RoomBUS _roomBUS = new RoomBUS();

        /// <summary>
        /// Lấy danh sách các chuyên khoa hiển thị lên UI (Chỉ lấy các khoa đang hoạt động).
        /// </summary>
        public List<DepartmentDTO> GetDepartmentsForUI()
        {
            return _deptDAL.GetActiveDepartments();
        }

        /// <summary>
        /// Lấy danh sách toàn bộ các chuyên khoa (để quản lý trong trang Admin).
        /// </summary>
        public List<DepartmentDTO> GetAllDepartments(bool includeDeleted = false)
        {
            return _deptDAL.GetAllDepartments(includeDeleted);
        }

        /// <summary>
        /// Tìm chuyên khoa theo Id.
        /// </summary>
        public DepartmentDTO GetDepartmentById(int id)
        {
            return _deptDAL.GetDepartmentById(id);
        }

        /// <summary>
        /// Lấy tên của chuyên khoa theo Id, trả về "Không xác định" nếu không tìm thấy.
        /// </summary>
        public string GetDepartmentNameById(int id)
        {
            DepartmentDTO dept = _deptDAL.GetDepartmentById(id);
            return dept != null ? dept.DepartmentName : "Không xác định";
        }

        /// <summary>
        /// Thêm chuyên khoa mới (không bao gồm danh sách phòng).
        /// Nghiệp vụ: Tên chuyên khoa không được rỗng, không được trùng lặp.
        /// </summary>
        public bool AddDepartment(DepartmentDTO dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName))
            {
                return false;
            }

            // Nghiệp vụ của BUS: Kiểm tra trùng tên trước khi thực hiện thêm mới
            if (_deptDAL.IsDepartmentNameExists(dept.DepartmentName))
            {
                throw new ArgumentException($"Tên chuyên khoa '{dept.DepartmentName}' đã tồn tại trong hệ thống. Vui lòng chọn tên khác!");
            }

            return _deptDAL.AddDepartment(dept);
        }

        /// <summary>
        /// Thêm chuyên khoa mới kèm danh sách phòng khám ban đầu.
        /// Nghiệp vụ: Tên khoa không trùng, phòng khám không rỗng, đúng định dạng mã phòng, không trùng mã phòng ở khoa khác đang hoạt động.
        /// </summary>
        public bool AddDepartmentWithRooms(DepartmentDTO dept, List<RoomDTO> rooms)
        {
            // Kiểm tra các ràng buộc cơ bản
            if (string.IsNullOrWhiteSpace(dept.DepartmentName) || rooms == null || !rooms.Any())
            {
                return false;
            }

            // Nghiệp vụ của BUS: Kiểm tra trùng tên trước khi thêm mới
            if (_deptDAL.IsDepartmentNameExists(dept.DepartmentName))
            {
                throw new ArgumentException($"Tên chuyên khoa '{dept.DepartmentName}' đã tồn tại trong hệ thống. Vui lòng chọn tên khác!");
            }

            // Lọc các phòng khám hợp lệ (không rỗng và đúng định dạng Regex mã phòng)
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

            // Nghiệp vụ của BUS: Đảm bảo không có mã phòng nào bị trùng lặp ngay trong danh sách gửi lên từ giao diện
            int distinctRoomCodes = validRooms
                .Select(r => r.RoomCode.Trim().ToUpperInvariant())
                .Distinct()
                .Count();

            if (distinctRoomCodes != validRooms.Count)
            {
                return false;
            }

            // Nghiệp vụ của BUS: Kiểm tra xem có mã phòng nào trùng và đang hoạt động ở khoa khác hay không
            List<string> roomCodes = validRooms
                .Select(r => r.RoomCode.Trim().ToUpperInvariant())
                .ToList();

            var duplicateRooms = _roomBUS.GetActiveRoomsByCodes(roomCodes);
            if (duplicateRooms.Any())
            {
                var dupInfo = string.Join(", ", duplicateRooms.Select(d => $"'{d.RoomCode}' (thuộc chuyên khoa '{d.Department?.DepartmentName ?? "Không xác định"}')"));
                throw new ArgumentException($"Mã phòng sau đây đã tồn tại và đang hoạt động trên hệ thống: {dupInfo}. Vui lòng gỡ phòng này khỏi chuyên khoa đó trước khi thêm vào chuyên khoa khác!");
            }

            // Chuyển tiếp yêu cầu xuống tầng DAL để tương tác với Cơ sở dữ liệu
            return _deptDAL.AddDepartmentWithRooms(dept, validRooms);
        }

        /// <summary>
        /// Cập nhật thông tin cơ bản chuyên khoa.
        /// Nghiệp vụ: Tên chuyên khoa không được rỗng, không trùng tên chuyên khoa của khoa khác.
        /// </summary>
        public bool UpdateDepartment(DepartmentDTO dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName))
            {
                return false;
            }

            // Nghiệp vụ của BUS: Kiểm tra trùng tên trước khi thực hiện cập nhật (loại trừ chính nó)
            if (_deptDAL.IsDepartmentNameExists(dept.DepartmentName, dept.Id))
            {
                throw new ArgumentException($"Tên chuyên khoa '{dept.DepartmentName}' đã tồn tại trong hệ thống. Vui lòng chọn tên khác!");
            }

            return _deptDAL.UpdateDepartment(dept);
        }

        /// <summary>
        /// Xóa chuyên khoa (Soft Delete) thông qua DAL.
        /// </summary>
        public bool DeleteDepartment(int id)
        {
            return _deptDAL.DeleteDepartment(id);
        }

        /// <summary>
        /// Cập nhật chuyên khoa và đồng bộ danh sách phòng khám kèm theo.
        /// Nghiệp vụ: Kiểm tra trùng tên khoa khác, định dạng mã phòng hợp lệ, kiểm tra trùng phòng đang hoạt động ở khoa khác.
        /// </summary>
        public bool UpdateDepartmentWithRooms(DepartmentDTO dept, List<RoomDTO> rooms)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName) || rooms == null)
            {
                return false;
            }

            // Nghiệp vụ của BUS: Kiểm tra trùng tên trước khi cập nhật (loại trừ chính nó)
            if (_deptDAL.IsDepartmentNameExists(dept.DepartmentName, dept.Id))
            {
                throw new ArgumentException($"Tên chuyên khoa '{dept.DepartmentName}' đã tồn tại trong hệ thống. Vui lòng chọn tên khác!");
            }

            // Lọc các phòng khám hợp lệ (không rỗng và đúng định dạng Regex mã phòng)
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

            // Nghiệp vụ của BUS: Đảm bảo không có mã phòng trùng lặp trong danh sách gửi lên từ giao diện
            int distinctRoomCodes = validRooms
                .Select(r => r.RoomCode.Trim().ToUpperInvariant())
                .Distinct()
                .Count();

            if (distinctRoomCodes != validRooms.Count)
            {
                return false;
            }

            // Nghiệp vụ của BUS: Kiểm tra trùng phòng đang hoạt động ở khoa khác
            List<string> roomCodes = validRooms
                .Select(r => r.RoomCode.Trim().ToUpperInvariant())
                .ToList();

            var duplicateRooms = _roomBUS.GetActiveRoomsByCodes(roomCodes, dept.Id);
            if (duplicateRooms.Any())
            {
                var dupInfo = string.Join(", ", duplicateRooms.Select(d => $"'{d.RoomCode}' (thuộc chuyên khoa '{d.Department?.DepartmentName ?? "Không xác định"}')"));
                throw new ArgumentException($"Mã phòng sau đây đã tồn tại và đang hoạt động trên hệ thống: {dupInfo}. Vui lòng gỡ phòng này khỏi chuyên khoa đó trước khi thêm vào chuyên khoa khác!");
            }

            // Chuyển tiếp xuống tầng DAL xử lý đồng bộ hóa CSDL
            return _deptDAL.UpdateDepartmentWithRooms(dept, validRooms);
        }
    }
}
