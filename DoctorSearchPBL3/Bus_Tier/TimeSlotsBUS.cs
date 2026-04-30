using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS_Tier
{
    public class TimeSlotBUS
    {
        private readonly TimeSlotDAL _dal = new TimeSlotDAL();

        // --- HÀM KIỂM TRA CHUNG (Validation) ---
        // Nhân đưa các kiểm tra logic vào đây để UI gọn hơn
        private string ValidateInputs(int doctorId, int roomId, TimeSpan startT, TimeSpan endT)
        {
            if (doctorId <= 0) return "Lỗi: ID bác sĩ không hợp lệ!";
            if (roomId <= 0) return "Vui lòng chọn phòng khám!";
            if (endT <= startT) return "Giờ kết thúc phải lớn hơn giờ bắt đầu!";
            return null; // Trả về null nếu hợp lệ
        }

        // 1. Tạo một khung giờ lẻ
        //public string CreateSingleTimeSlot(TimeSlotsDTO slot)
        //{
        //    // Kiểm tra các ràng buộc cơ bản
        //    string error = ValidateInputs(slot.DoctorId, slot.RoomId, slot.StartTime, slot.EndTime);
        //    if (error != null) return error;

        //    if (slot.WorkDate.Date < DateTime.Now.Date) return "Không thể tạo lịch cho quá khứ!";

        //    // Check trùng bằng WorkDate (Khớp SQL)
        //    if (_dal.IsSlotExisted(slot.DoctorId, slot.WorkDate, slot.StartTime, slot.EndTime))
        //    {
        //        return $"Khung giờ này đã tồn tại trong ngày {slot.WorkDate:dd/MM}!";
        //    }

        //    slot.Status = "Open"; // Khớp DEFAULT SQL
        //    slot.CreatedAt = DateTime.Now;
        //    slot.IsDeleted = false;

        //    return _dal.AddSingle(slot) ? "Success" : "Lỗi hệ thống khi lưu!";
        //}
        public string CreateSingleTimeSlot(TimeSlotsDTO slot)
        {
            // 1. Kiểm tra các ràng buộc cơ bản
            string error = ValidateInputs(slot.DoctorId, slot.RoomId, slot.StartTime, slot.EndTime);
            if (error != null) return error;

            if (slot.WorkDate.Date < DateTime.Now.Date) return "Không thể tạo lịch cho quá khứ!";

            // 2. LOGIC KIỂM TRA TRÙNG (Sử dụng hàm GetConflictSlot đã viết ở DAL)
            var conflict = _dal.GetConflictSlot(slot.WorkDate, slot.StartTime, slot.EndTime, slot.RoomId);

            if (conflict != null)
            {
                // Nếu trùng ID bác sĩ hiện tại
                if (conflict.DoctorId == slot.DoctorId)
                {
                    return $"Bạn đã đăng ký lịch khám này rồi ({conflict.StartTime:hh\\:mm} - {conflict.EndTime:hh\\:mm})!";
                }
                // Nếu ID bác sĩ khác đang dùng phòng này
                else
                {
                    return "Phòng này đã có bác sĩ khác đăng ký vào khung giờ này!";
                }
            }

            // 3. Thiết lập mặc định và lưu
            slot.Status = "Open";
            slot.CreatedAt = DateTime.Now;
            slot.IsDeleted = false;

            return _dal.AddSingle(slot) ? "Success" : "Lỗi hệ thống khi lưu!";
        }

        // 2. Tạo hàng loạt (Bulk)
        // Nhân thêm tham số roomId và maxApp vào đây nhé
        //public string CreateBulkTimeSlots(int doctorId, List<string> selectedDays, DateTime startDate, DateTime endDate, TimeSpan startT, TimeSpan endT, int roomId, int maxApp)
        //{
        //    // Kiểm tra các ràng buộc
        //    string error = ValidateInputs(doctorId, roomId, startT, endT);
        //    if (error != null) return error;

        //    if (endDate.Date < startDate.Date) return "Ngày kết thúc không hợp lệ!";
        //    if (selectedDays == null || selectedDays.Count == 0) return "Vui lòng chọn ít nhất một thứ (T2, T3...)!";

        //    var cleanDays = selectedDays.Select(d => d.Trim().ToUpper()).ToList();
        //    List<TimeSlotsDTO> listToCreate = new List<TimeSlotsDTO>();
        //    int duplicateCount = 0;

        //    for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
        //    {
        //        string vnDay = ConvertToVNDay(date.DayOfWeek).ToUpper();

        //        if (cleanDays.Contains(vnDay))
        //        {
        //            // Kiểm tra trùng trong DB
        //            if (_dal.IsSlotExisted(doctorId, date, startT, endT))
        //            {
        //                duplicateCount++;
        //                continue;
        //            }

        //            listToCreate.Add(new TimeSlotsDTO
        //            {
        //                DoctorId = doctorId,
        //                RoomId = roomId,        // Bổ sung RoomId
        //                WorkDate = date,
        //                StartTime = startT,
        //                EndTime = endT,
        //                MaxAppointments = maxApp, // Bổ sung số lượng tối đa
        //                BookedCount = 0,
        //                Status = "Open",
        //                IsDeleted = false,
        //                CreatedAt = DateTime.Now
        //            });
        //        }
        //    }

        //    if (listToCreate.Count > 0)
        //    {
        //        // Gọi xuống DAL (Hàm AddRange Nhân đã thêm ở bước trước)
        //        return _dal.AddRange(listToCreate)
        //            ? (duplicateCount > 0 ? $"Thành công {listToCreate.Count} lịch (Bỏ qua {duplicateCount} ngày trùng)" : "Success")
        //            : "Lỗi lưu Database!";
        //    }

        //    return duplicateCount > 0 ? "Tất cả các ngày đã chọn đều đã có lịch!" : "Không tìm thấy ngày phù hợp trong khoảng thời gian này.";
        //}

        public string CreateBulkTimeSlots(int doctorId, List<string> selectedDays, DateTime startDate, DateTime endDate, TimeSpan startT, TimeSpan endT, int roomId, int maxApp)
        {
            // 1. Kiểm tra ràng buộc cơ bản
            string error = ValidateInputs(doctorId, roomId, startT, endT);
            if (error != null) return error;

            if (endDate.Date < startDate.Date) return "Ngày kết thúc không hợp lệ!";
            if (selectedDays == null || selectedDays.Count == 0) return "Vui lòng chọn ít nhất một thứ (T2, T3...)!";

            var cleanDays = selectedDays.Select(d => d.Trim().ToUpper()).ToList();
            List<TimeSlotsDTO> listToCreate = new List<TimeSlotsDTO>();

            int myDuplicateCount = 0;    // Đếm số lịch trùng của chính mình
            int roomBusyCount = 0;       // Đếm số lịch phòng đã bị người khác chiếm

            for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                string vnDay = ConvertToVNDay(date.DayOfWeek).ToUpper();

                if (cleanDays.Contains(vnDay))
                {
                    // 2. Kiểm tra xung đột cho từng ngày
                    var conflict = _dal.GetConflictSlot(date, startT, endT, roomId);

                    if (conflict != null)
                    {
                        if (conflict.DoctorId == doctorId) myDuplicateCount++;
                        else roomBusyCount++;
                        continue; // Bỏ qua ngày này
                    }

                    // 3. Thêm vào danh sách chờ lưu
                    listToCreate.Add(new TimeSlotsDTO
                    {
                        DoctorId = doctorId,
                        RoomId = roomId,
                        WorkDate = date,
                        StartTime = startT,
                        EndTime = endT,
                        MaxAppointments = maxApp,
                        BookedCount = 0,
                        Status = "Open",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now
                    });
                }
            }

            // 4. Xử lý kết quả trả về cho UI
            if (listToCreate.Count > 0)
            {
                bool isSaved = _dal.AddRange(listToCreate);
                if (!isSaved) return "Lỗi lưu Database!";

                // Tạo câu thông báo tổng hợp
                string msg = $"Thành công {listToCreate.Count} lịch.";
                if (myDuplicateCount > 0) msg += $" (Bỏ qua {myDuplicateCount} ngày bạn đã đặt)";
                if (roomBusyCount > 0) msg += $" (Bỏ qua {roomBusyCount} ngày phòng đã bận)";

                return (myDuplicateCount == 0 && roomBusyCount == 0) ? "Success" : msg;
            }

            // Trường hợp không tạo được cái nào
            if (roomBusyCount > 0 && myDuplicateCount == 0) return "Tất cả các ngày đã chọn, phòng này đều đã có người khác dùng!";
            if (myDuplicateCount > 0) return "Bạn đã đặt lịch trùng cho tất cả các ngày này rồi!";

            return "Không tìm thấy ngày phù hợp trong khoảng thời gian này.";
        }

        private string ConvertToVNDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "T2";
                case DayOfWeek.Tuesday: return "T3";
                case DayOfWeek.Wednesday: return "T4";
                case DayOfWeek.Thursday: return "T5";
                case DayOfWeek.Friday: return "T6";
                case DayOfWeek.Saturday: return "T7";
                case DayOfWeek.Sunday: return "CN";
                default: return "";
            }
        }

        // 3. Lấy toàn bộ danh sách TimeSlots (Thường dùng cho Admin)
        public List<TimeSlotsDTO> GetAllTimeSlots()
        {
            // Gọi xuống DAL để lấy dữ liệu raw, BUS có thể xử lý thêm logic nếu cần
            return _dal.GetAll() ?? new List<TimeSlotsDTO>();
        }

        // 4. Lấy danh sách lịch khám của một bác sĩ cụ thể
        public List<TimeSlotsDTO> GetTimeSlotsByDoctor(int doctorId)
        {
            if (doctorId <= 0) return new List<TimeSlotsDTO>();

            // Sắp xếp theo ngày gần nhất và giờ sớm nhất để UI hiển thị đẹp luôn
            var list = _dal.GetByDoctorId(doctorId);
            return list.OrderByDescending(s => s.WorkDate)
                       .ThenBy(s => s.StartTime)
                       .ToList();
        }
    }
}