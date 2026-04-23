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
        // --- HÀM CHUNG: Xử lý logic kiểm tra và tạo đối tượng DTO ---
        private string ValidateAndCheck(int doctorId, DateTime date, TimeSpan startT, TimeSpan endT, out TimeSlotsDTO newSlot)
        {
            newSlot = null;

            if (_dal.IsSlotExisted(doctorId, date, startT, endT))
            {
                return "Existed"; // Đánh dấu là đã tồn tại
            }

            newSlot = new TimeSlotsDTO
            {
                DoctorId = doctorId,
                Date = date,
                StartTime = startT,
                EndTime = endT,
                Status = "Trống"
            };
            return "OK";
        }

        // 1. Tạo một khung giờ lẻ
        public string CreateSingleTimeSlot(TimeSlotsDTO slot)
        {
            if (slot.DoctorId <= 0) return "Lỗi: ID bác sĩ không hợp lệ!";
            if (slot.EndTime <= slot.StartTime) return "Giờ kết thúc phải lớn hơn giờ bắt đầu!";

            // Dùng hàm chung để check trùng
            string check = ValidateAndCheck(slot.DoctorId, slot.Date, slot.StartTime, slot.EndTime, out TimeSlotsDTO verifiedSlot);

            if (check == "Existed")
                return $"Khung giờ {slot.StartTime:hh\\:mm} - {slot.EndTime:hh\\:mm} ngày {slot.Date:dd/MM} đã tồn tại!";

            return _dal.AddSingle(verifiedSlot) ? "Success" : "Lỗi hệ thống khi lưu!";
        }

        // 2. Xử lý tạo hàng loạt (Bulk)
        public string CreateBulkTimeSlots(int doctorId, List<string> selectedDays, DateTime startDate, DateTime endDate, TimeSpan startT, TimeSpan endT)
        {
            // 1. Kiểm tra đầu vào cơ bản
            if (doctorId <= 0) return "Lỗi: ID bác sĩ không hợp lệ!";
            if (endDate.Date < startDate.Date) return "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!";
            if (endT <= startT) return "Giờ kết thúc phải lớn hơn giờ bắt đầu!";
            if (selectedDays == null || selectedDays.Count == 0) return "Vui lòng chọn ít nhất một thứ (T2, T3...)!";

            // LÀM SẠCH DANH SÁCH THỨ: Loại bỏ khoảng trắng và viết hoa hết để so sánh chuẩn
            var cleanSelectedDays = selectedDays.Select(d => d.Trim().ToUpper()).ToList();

            List<TimeSlotsDTO> listToCreate = new List<TimeSlotsDTO>();
            int duplicateCount = 0;
            int matchedDayCount = 0; // Biến này để kiểm tra xem có ngày nào khớp Thứ không

            // 2. Vòng lặp quét từng ngày
            for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                // Chuyển thứ hiện tại sang "T2", "T3"... và viết hoa
                string currentDayStr = ConvertToVNDay(date.DayOfWeek).Trim().ToUpper();

                // So khớp Thứ
                if (cleanSelectedDays.Contains(currentDayStr))
                {
                    matchedDayCount++;

                    // Kiểm tra trùng trong DB (Sử dụng hàm của Tiên ở DAL)
                    if (_dal.IsSlotExisted(doctorId, date, startT, endT))
                    {
                        duplicateCount++;
                        continue;
                    }

                    listToCreate.Add(new TimeSlotsDTO
                    {
                        DoctorId = doctorId,
                        Date = date.Date,
                        StartTime = startT,
                        EndTime = endT,
                        Status = "Trống"
                    });
                }
            }

            // 3. XỬ LÝ KẾT QUẢ LƯU
            if (listToCreate.Count > 0)
            {
                // Gọi xuống DAL của Tiên để thực hiện AddRange
                bool isSaved = _dal.AddRange(listToCreate);
                if (isSaved)
                {
                    return duplicateCount > 0
                        ? $"Thành công! Đã tạo {listToCreate.Count} lịch (Bỏ qua {duplicateCount} ngày trùng)."
                        : "Success";
                }
                return "Lỗi DAL: Không thể lưu danh sách vào Database. Kiểm tra chuỗi kết nối!";
            }

            // 4. BẮT BỆNH NẾU KHÔNG LƯU ĐƯỢC
            if (duplicateCount > 0)
                return "Tất cả khung giờ trong khoảng này đã tồn tại trong hệ thống!";

            if (matchedDayCount == 0)
                return "Không có ngày nào khớp với Thứ bạn đã chọn trong khoảng thời gian này!";

            return "Không có ngày phù hợp!";
        }



        // Hàm hỗ trợ dịch ngày (Nhân nhớ nhắc Trang kiểm tra hàm này nhé)
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
                case DayOfWeek.Sunday: return "CN"; // Nhân kiểm tra nút trên UI có đúng là "CN" không nhé!
                default: return "";
            }
        }
    }
}