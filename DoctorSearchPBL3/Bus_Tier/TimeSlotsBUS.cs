using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class TimeSlotBUS
    {
        private readonly TimeSlotDAL _dal = new TimeSlotDAL();

        // 1. Tạo một khung giờ lẻ
        public bool CreateSingleTimeSlot(TimeSlotsDTO slot)
        {
            return _dal.AddSingle(slot);
        }

        // 2. Xử lý logic tạo hàng loạt theo lịch lặp lại
        public bool CreateBulkTimeSlots(int doctorId, List<string> selectedDays, DateTime startDate, DateTime endDate, TimeSpan startT, TimeSpan endT)
        {
            List<TimeSlotsDTO> listToCreate = new List<TimeSlotsDTO>();

            // Chạy vòng lặp từ ngày bắt đầu đến ngày kết thúc
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                // Chuyển DayOfWeek (Monday, Tuesday...) sang T2, T3 để so sánh
                string currentDayStr = ConvertToVNDay(date.DayOfWeek);

                // Nếu ngày hiện tại nằm trong danh sách các thứ bác sĩ đã chọn
                if (selectedDays.Contains(currentDayStr))
                {
                    listToCreate.Add(new TimeSlotsDTO
                    {
                        DoctorId = doctorId,
                        //Date = date,
                        StartTime = startT,
                        EndTime = endT,
                        Status = "Trống" // Trạng thái ban đầu luôn là Trống
                    });
                }
            }

            if (listToCreate.Count > 0)
            {
                return _dal.AddRange(listToCreate);
            }
            return false;
        }

        // Hàm phụ chuyển đổi thứ từ Tiếng Anh sang Tiếng Việt cho khớp UI của Nhân
        private string ConvertToVNDay(DayOfWeek d)
        {
            switch (d)
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
    }
}