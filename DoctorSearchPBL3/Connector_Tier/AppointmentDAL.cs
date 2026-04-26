using DTO_Tier;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Tier
{
    public class AppointmentDAL
    {
        //public List<AppointmentDTO> GetAllAppointments()
        //{
        //    List<AppointmentDTO> list = new List<AppointmentDTO>();

        //    string query = @"SELECT 
        //                        a.Id AS Id,
        //                        u.FullName AS FullName, 
        //                        u.phone_number AS phone_number, 
        //                        t.Date AS AppointmentDate, 
        //                        t.StartTime, 
        //                        t.EndTime, 
        //                        a.Symptoms, 
        //                        a.Status,
        //                        a.CreatedAt 
        //                    FROM Appointments a 
        //                    LEFT JOIN Patients p ON a.PatientId = p.Id 
        //                    LEFT JOIN Users u ON p.UserId = u.Id 
        //                    LEFT JOIN TimeSlots t ON a.TimeSlotId = t.Id
        //                    ORDER BY t.Date DESC;"; // Sắp xếp theo ngày mới nhất
        //    DataTable dt = DBHelper.GetDataTable(query);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        // Giả sử row là DataRow từ DataTable
        //        list.Add(new AppointmentDTO
        //        {
        //            // 1. Lấy ID để sau này còn bấm Duyệt/Hủy
        //            Id = Convert.ToInt32(row["Id"]),

        //            // 2. Thông tin Patient (JOIN từ bảng Patients)
        //            PatientName = row["FullName"].ToString(),

        //            // 3. Số điện thoại (JOIN từ bảng Users)
        //            PhoneNumber = row["PhoneNumber"].ToString(),

        //            // Sử dụng Symptoms từ bảng Appointments
        //            // 4. Triệu chứng (Check NULL cho chắc ăn)
        //            Symptoms = row["Symptoms"] != DBNull.Value ? row["Symptoms"].ToString() : "Không có triệu chứng",

        //            // 5. Trạng thái (Thành công, Chờ duyệt...)
        //            Status = row["Status"].ToString(),

        //            // Format ngày theo dd/MM/yyyy từ bảng TimeSlots
        //            // 6. Ngày tháng (Convert sang dd/MM/yyyy cho đẹp)
        //            AppointmentDate = row["AppointmentDate"] != DBNull.Value
        //                ? Convert.ToDateTime(row["AppointmentDate"]).ToString("dd/MM/yyyy")
        //                : "Chưa xác định",

        //            // 7. Khung giờ (Ghép StartTime và EndTime)
        //            TimeRange = $"{Convert.ToDateTime(row["StartTime"].ToString()).ToString("HH'h':mm")} - {Convert.ToDateTime(row["EndTime"].ToString()).ToString("HH'h':mm")}",
        //            // Kết quả sẽ ra: 08h:30 - 09h:15

        //            // 8. Ngày tạo (Để biết ai đặt trước)
        //            CreatedAt = Convert.ToDateTime(row["CreatedAt"])
        //        });
        //    }


        //    return list;
        //}


        public List<AppointmentsDTO> GetAllAppointments()
        {
            List<AppointmentsDTO> list = new List<AppointmentsDTO>();

            // Query lấy 'Full combo': Thông tin Appointment + Patient + Doctor + TimeSlot
            string query = @"
                            SELECT 
                                a.Id, a.PatientId, a.DoctorId, a.TimeSlotId, a.Symptoms, a.Status, a.CreatedAt,
                                up.FullName AS PatientName, up.PhoneNumber AS PatientPhone,
                                ud.FullName AS DoctorName,
                                t.Date, t.StartTime, t.EndTime
                            FROM Appointments a
                            LEFT JOIN Patient p ON a.PatientId = p.Id
                            LEFT JOIN [User] up ON p.UserId = up.Id
                            LEFT JOIN Doctor d ON a.DoctorId = d.Id
                            LEFT JOIN [User] ud ON d.UserId = ud.Id
                            LEFT JOIN TimeSlots t ON a.TimeSlotId = t.Id
                            ORDER BY a.CreatedAt DESC";

            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                // Hàm phụ check null và chuyển đổi để code chính nhìn cho gọn
                list.Add(new AppointmentsDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    PatientId = Convert.ToInt32(row["PatientId"]),
                    DoctorId = Convert.ToInt32(row["DoctorId"]),
                    TimeSlotId = Convert.ToInt32(row["TimeSlotId"]),
                    Symptoms = row["Symptoms"]?.ToString() ?? "Không có triệu chứng",
                    Status = row["Status"]?.ToString() ?? "Chờ duyệt",
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),

                    // Đổ dữ liệu Bệnh nhân
                    Patient = new PatientDTO
                    {
                        User = new UserDTO
                        {
                            FullName = row["PatientName"] != DBNull.Value ? row["PatientName"].ToString() : "N/A",
                            PhoneNumber = row["PatientPhone"] != DBNull.Value ? row["PatientPhone"].ToString() : "N/A"
                        }
                    },

                    // Đổ dữ liệu Bác sĩ (Nhớ thêm property Doctor vào AppointmentsDTO nếu chưa có)
                    Doctor = new DoctorDTO
                    {
                        User = new UserDTO
                        {
                            FullName = row["DoctorName"] != DBNull.Value ? row["DoctorName"].ToString() : "BS. Chưa xác định"
                        }
                    },

                    // Đổ dữ liệu Khung giờ
                    TimeSlot = new TimeSlotsDTO
                    {
                        Date = row["Date"] != DBNull.Value ? Convert.ToDateTime(row["Date"]) : DateTime.MinValue,
                        StartTime = row["StartTime"] != DBNull.Value ? (TimeSpan)row["StartTime"] : TimeSpan.Zero,
                        EndTime = row["EndTime"] != DBNull.Value ? (TimeSpan)row["EndTime"] : TimeSpan.Zero
                    }
                });
            }
            return list;
        }

        //Tạo lịch hẹn mới
        public bool CreateAppointment(AppointmentsDTO app)
        {
            // Cẩn thận với các bảng có tên trùng từ khóa như [User] (nếu sau này có đụng tới)
            string query = @"
            INSERT INTO Appointments (PatientId, DoctorId, TimeSlotId, Symptoms, Status, CreatedAt)
            VALUES (@PatientId, @DoctorId, @TimeSlotId, @Symptoms, @Status, @CreatedAt)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@PatientId", app.PatientId),
                    new SqlParameter("@DoctorId", app.DoctorId),
                    new SqlParameter("@TimeSlotId", app.TimeSlotId),
                    // Nếu Symptoms null thì đẩy DBNull xuống database
                    new SqlParameter("@Symptoms", (object)app.Symptoms ?? DBNull.Value),
                    // Ưu tiên Status từ app, nếu không có thì để mặc định 'Chờ duyệt'
                    new SqlParameter("@Status", string.IsNullOrEmpty(app.Status) ? "Chờ duyệt" : app.Status),
                    // Luôn lấy thời điểm hiện tại của hệ thống để làm thời gian tạo
                    new SqlParameter("@CreatedAt", DateTime.Now)
                };

                try
                {
                    return DBHelper.ExecuteNonQuery(query, parameters);
                }
                catch (Exception ex)
                {
                    // Debug nhẹ nếu có lỗi xảy ra (ví dụ lỗi khóa ngoại)
                    Console.WriteLine("Lỗi khi tạo Appointment: " + ex.Message);
                    return false;
                }
        }
    }
}
