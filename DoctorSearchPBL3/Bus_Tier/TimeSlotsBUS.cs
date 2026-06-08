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
        private readonly DoctorDAL _doctorDal = new DoctorDAL();
        private readonly RoomDAL _roomDal = new RoomDAL();

        public List<TimeSlotsDTO> GetFilteredSlotsForPatient(int doctorId, DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date > toDate.Date)
            {
                return new List<TimeSlotsDTO>();
            }

            return _dal.GetAvailableSlots(doctorId, fromDate, toDate);
        }

        private string? ValidateInputs(int doctorId, int roomId, TimeSpan startT, TimeSpan endT, int maxAppointments, int adminId)
        {
            if (adminId <= 0) return "Không xác định được tài khoản admin tạo lịch.";
            if (doctorId <= 0) return "Lỗi: ID bác sĩ không hợp lệ!";
            if (roomId <= 0) return "Vui lòng chọn phòng khám!";
            if (endT <= startT) return "Giờ kết thúc phải lớn hơn giờ bắt đầu!";
            if (maxAppointments <= 0) return "Số lượng bệnh nhân tối đa phải lớn hơn 0!";
            return null;
        }

        private string? ValidateDoctorRoomRule(int doctorId, int roomId)
        {
            var doctor = _doctorDal.GetDoctorById(doctorId);
            if (doctor == null || doctor.DepartmentId <= 0)
            {
                return "Không tìm thấy bác sĩ hoặc bác sĩ chưa được gán khoa.";
            }

            var room = _roomDal.GetRoomById(roomId);
            if (room == null || room.IsDeleted || !room.IsActive)
            {
                return "Phòng khám không tồn tại hoặc đang ngừng hoạt động.";
            }

            if (room.DepartmentId != doctor.DepartmentId)
            {
                return "Phòng khám phải thuộc cùng khoa với bác sĩ.";
            }

            return null;
        }

        private string? ValidateTimeConflicts(int doctorId, int roomId, DateTime workDate, TimeSpan startT, TimeSpan endT, int? excludeSlotId = null)
        {
            var doctorConflict = _dal.GetDoctorConflictSlot(workDate, startT, endT, doctorId, excludeSlotId);
            if (doctorConflict != null)
            {
                string roomName = doctorConflict.Room?.RoomCode ?? doctorConflict.Room?.RoomName ?? "phòng khác";
                return $"Bác sĩ này đã có lịch trùng khung giờ tại {roomName}.";
            }

            var roomConflict = _dal.GetConflictSlot(workDate, startT, endT, roomId, excludeSlotId);
            if (roomConflict != null)
            {
                string doctorName = roomConflict.Doctor?.User?.FullName ?? "bác sĩ khác";
                return $"Phòng này đã được {doctorName} sử dụng trong khung giờ đã chọn.";
            }

            return null;
        }

        public string CreateSingleTimeSlot(TimeSlotsDTO slot)
        {
            return CreateSingleTimeSlot(slot, slot.CreatedByAdminId);
        }

        public string CreateSingleTimeSlot(TimeSlotsDTO slot, int adminId)
        {
            string? error = ValidateInputs(slot.DoctorId, slot.RoomId, slot.StartTime, slot.EndTime, slot.MaxAppointments, adminId);
            if (error != null) return error;

            if (slot.WorkDate.Date < DateTime.Now.Date) return "Không thể tạo lịch cho quá khứ!";

            error = ValidateDoctorRoomRule(slot.DoctorId, slot.RoomId);
            if (error != null) return error;

            error = ValidateTimeConflicts(slot.DoctorId, slot.RoomId, slot.WorkDate, slot.StartTime, slot.EndTime);
            if (error != null) return error;

            slot.Status = "Open";
            slot.CreatedAt = DateTime.Now;
            slot.IsDeleted = false;
            slot.BookedCount = 0;
            slot.CreatedByAdminId = adminId;

            return _dal.AddSingle(slot) ? "Success" : "Lỗi hệ thống khi lưu!";
        }

        public string CreateBulkTimeSlots(int doctorId, List<string> selectedDays, DateTime startDate, DateTime endDate, TimeSpan startT, TimeSpan endT, int roomId, int maxApp, int adminId = 0)
        {
            string? error = ValidateInputs(doctorId, roomId, startT, endT, maxApp, adminId);
            if (error != null) return error;

            if (endDate.Date < startDate.Date) return "Ngày kết thúc không hợp lệ!";
            if (selectedDays == null || selectedDays.Count == 0) return "Vui lòng chọn ít nhất một thứ trong tuần!";

            error = ValidateDoctorRoomRule(doctorId, roomId);
            if (error != null) return error;

            var cleanDays = selectedDays
                .Where(d => !string.IsNullOrWhiteSpace(d))
                .Select(d => d.Trim().ToUpperInvariant())
                .ToList();

            List<TimeSlotsDTO> listToCreate = new List<TimeSlotsDTO>();
            int doctorConflictCount = 0;
            int roomConflictCount = 0;

            for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                string vnDay = ConvertToVNDay(date.DayOfWeek).ToUpperInvariant();
                if (!cleanDays.Contains(vnDay))
                {
                    continue;
                }

                var doctorConflict = _dal.GetDoctorConflictSlot(date, startT, endT, doctorId);
                if (doctorConflict != null)
                {
                    doctorConflictCount++;
                    continue;
                }

                var roomConflict = _dal.GetConflictSlot(date, startT, endT, roomId);
                if (roomConflict != null)
                {
                    roomConflictCount++;
                    continue;
                }

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
                    CreatedAt = DateTime.Now,
                    CreatedByAdminId = adminId
                });
            }

            if (listToCreate.Count == 0)
            {
                if (doctorConflictCount > 0 && roomConflictCount == 0)
                {
                    return "Bác sĩ đã có lịch trùng trong tất cả các ngày đã chọn.";
                }

                if (roomConflictCount > 0 && doctorConflictCount == 0)
                {
                    return "Phòng đã bận trong tất cả các ngày đã chọn.";
                }

                if (roomConflictCount > 0 || doctorConflictCount > 0)
                {
                    return "Không thể tạo lịch do bị trùng bác sĩ hoặc trùng phòng ở toàn bộ các ngày đã chọn.";
                }

                return "Không tìm thấy ngày phù hợp trong khoảng thời gian đã chọn.";
            }

            bool isSaved = _dal.AddRange(listToCreate);
            if (!isSaved) return "Lỗi lưu Database!";

            if (doctorConflictCount == 0 && roomConflictCount == 0)
            {
                return "Success";
            }

            string message = $"Thành công {listToCreate.Count} lịch.";
            if (doctorConflictCount > 0) message += $" Bỏ qua {doctorConflictCount} ngày vì bác sĩ đã có lịch trùng.";
            if (roomConflictCount > 0) message += $" Bỏ qua {roomConflictCount} ngày vì phòng đã bận.";
            return message;
        }

        private string ConvertToVNDay(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday => "T2",
                DayOfWeek.Tuesday => "T3",
                DayOfWeek.Wednesday => "T4",
                DayOfWeek.Thursday => "T5",
                DayOfWeek.Friday => "T6",
                DayOfWeek.Saturday => "T7",
                DayOfWeek.Sunday => "CN",
                _ => ""
            };
        }

        public List<TimeSlotsDTO> GetAllTimeSlots()
        {
            return _dal.GetAll() ?? new List<TimeSlotsDTO>();
        }

        public List<TimeSlotsDTO> GetTimeSlotsByDoctor(int doctorId)
        {
            if (doctorId <= 0) return new List<TimeSlotsDTO>();

            var list = _dal.GetByDoctorId(doctorId);
            return list.OrderByDescending(s => s.WorkDate)
                       .ThenBy(s => s.StartTime)
                       .ToList();
        }

        public List<TimeSlotsDTO> GetSlotsByDoctorAndDate(int doctorId, DateTime date)
        {
            if (doctorId <= 0) return new List<TimeSlotsDTO>();
            return _dal.GetSlotsByDoctorAndDate(doctorId, date);
        }

        public bool DeleteTimeSlot(int slotId)
        {
            if (slotId <= 0) return false;

            var slot = _dal.GetById(slotId);
            if (slot == null) return false;

            if (slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Confirmed"))
            {
                return false;
            }

            if (slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Pending"))
            {
                AppointmentDAL appDal = new AppointmentDAL();
                foreach (var app in slot.Appointments.Where(a => a.Status == "Pending"))
                {
                    appDal.UpdateStatus(app.Id, "Cancelled", "Lịch khám đã bị Admin hủy.");
                }
                _dal.ResetBookedCount(slotId);
            }

            return _dal.SoftDeleteSlot(slotId);
        }

        public bool UpdateSlotStatus(int slotId, string newStatus)
        {
            if (slotId <= 0 || string.IsNullOrEmpty(newStatus)) return false;
            return _dal.UpdateSlotStatus(slotId, newStatus);
        }

        public string HideTimeSlot(int slotId)
        {
            if (slotId <= 0) return "ID không hợp lệ.";
            var slot = _dal.GetById(slotId);
            if (slot == null) return "Không tìm thấy lịch.";

            if (slot.Status == "Hidden")
            {
                _dal.UpdateSlotStatus(slotId, "Open");
                return "Success";
            }

            if (slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Confirmed"))
                return "ConfirmedExists";

            if (slot.Appointments != null && slot.Appointments.Any(a => a.Status == "Pending"))
                return "PendingExists";

            return _dal.UpdateSlotStatus(slotId, "Hidden") ? "Success" : "Lỗi khi cập nhật.";
        }

        public bool ForceHideTimeSlot(int slotId)
        {
            var slot = _dal.GetById(slotId);
            if (slot == null) return false;

            if (slot.Appointments != null)
            {
                AppointmentDAL appDal = new AppointmentDAL();
                foreach (var app in slot.Appointments.Where(a => a.Status == "Pending"))
                {
                    appDal.UpdateStatus(app.Id, "Cancelled", "Lịch khám đã bị Admin ẩn.");
                }
                _dal.ResetBookedCount(slotId);
            }
            return _dal.UpdateSlotStatus(slotId, "Hidden");
        }

        public bool HasPendingAppointments(int slotId)
        {
            var slot = _dal.GetById(slotId);
            return slot?.Appointments?.Any(a => a.Status == "Pending") ?? false;
        }

        public string UpdateTimeSlot(TimeSlotsDTO slot)
        {
            return UpdateTimeSlot(slot, slot.CreatedByAdminId);
        }

        public string UpdateTimeSlot(TimeSlotsDTO slot, int adminId)
        {
            string? error = ValidateInputs(slot.DoctorId, slot.RoomId, slot.StartTime, slot.EndTime, slot.MaxAppointments, adminId);
            if (error != null) return error;

            error = ValidateDoctorRoomRule(slot.DoctorId, slot.RoomId);
            if (error != null) return error;

            error = ValidateTimeConflicts(slot.DoctorId, slot.RoomId, slot.WorkDate, slot.StartTime, slot.EndTime, slot.Id);
            if (error != null) return error;

            var fullSlot = _dal.GetById(slot.Id);
            if (fullSlot == null) return "Không tìm thấy lịch hẹn để cập nhật!";

            if (fullSlot.Appointments != null && fullSlot.Appointments.Any())
            {
                if (fullSlot.Appointments.Any(a => a.Status == "Confirmed"))
                {
                    return "Lịch này đã có bệnh nhân được duyệt khám, không thể chỉnh sửa!";
                }

                var pendingApps = fullSlot.Appointments.Where(a => a.Status == "Pending").ToList();
                if (pendingApps.Any())
                {
                    AppointmentBUS appBus = new AppointmentBUS();
                    foreach (var app in pendingApps)
                    {
                        appBus.UpdateStatus(app.Id, "Cancelled", "Lịch khám đã được Admin thay đổi khung giờ/phòng.");
                    }
                }
            }

            try
            {
                if (!_dal.SoftDeleteSlot(slot.Id))
                {
                    return "Không thể xóa mềm lịch cũ. Vui lòng kiểm tra lại.";
                }

                TimeSlotsDTO newSlot = new TimeSlotsDTO
                {
                    DoctorId = slot.DoctorId,
                    RoomId = slot.RoomId,
                    WorkDate = slot.WorkDate,
                    StartTime = slot.StartTime,
                    EndTime = slot.EndTime,
                    MaxAppointments = slot.MaxAppointments,
                    BookedCount = 0,
                    Status = "Open",
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedByAdminId = adminId
                };

                if (!_dal.AddSingle(newSlot))
                {
                    return "Lỗi khi lưu khung giờ mới vào CSDL.";
                }

                return "Success";
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null) msg += "\nChi tiết: " + ex.InnerException.Message;
                return "Lỗi phát sinh: " + msg;
            }
        }
    }
}
