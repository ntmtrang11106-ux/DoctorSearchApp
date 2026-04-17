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


        // Trong AppointmentDAL.cs
        public List<AppointmentsDTO> GetAllAppointments()
        {
            List<AppointmentsDTO> list = new List<AppointmentsDTO>();

            // Sửa lại Query: Thay INNER thành LEFT và đảm bảo khoảng trắng
            string query = @"
            SELECT 
                a.Id, a.PatientId, a.DoctorId, a.TimeSlotId, a.Symptoms, a.Status, a.CreatedAt,
                u.FullName, u.PhoneNumber, 
                t.Date, t.StartTime, t.EndTime
            FROM Appointments a
            LEFT JOIN Patient p ON a.PatientId = p.Id
            LEFT JOIN [User] u ON p.UserId = u.Id
            LEFT JOIN TimeSlots t ON a.TimeSlotId = t.Id
            ORDER BY a.CreatedAt DESC"; // Sắp xếp theo lịch mới nhất

            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new AppointmentsDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    PatientId = row["PatientId"] != DBNull.Value ? Convert.ToInt32(row["PatientId"]) : 0,
                    DoctorId = row["DoctorId"] != DBNull.Value ? Convert.ToInt32(row["DoctorId"]) : 0,
                    TimeSlotId = row["TimeSlotId"] != DBNull.Value ? Convert.ToInt32(row["TimeSlotId"]) : 0,
                    Symptoms = row["Symptoms"]?.ToString() ?? "Không có triệu chứng",
                    Status = row["Status"]?.ToString() ?? "Chờ duyệt",
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),

                    // Đổ dữ liệu vào đối tượng lồng nhau (Navigation Properties)
                    Patient = new PatientDTO
                    {
                        User = new UserDTO
                        {
                            FullName = row["FullName"] != DBNull.Value ? row["FullName"].ToString() : "N/A",
                            PhoneNumber = row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : "N/A"
                        }
                    },
                    TimeSlot = new TimeSlotsDTO
                    {
                        Date = row["Date"] != DBNull.Value ? Convert.ToDateTime(row["Date"]) : DateTime.Now,
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
            // Tên bảng và cột khớp với SQL của bạn ([User], Patient, Appointments)
            string query = @"
                INSERT INTO Appointments (PatientId, DoctorId, TimeSlotId, Symptoms, Status, CreatedAt)
                VALUES (@PatientId, @DoctorId, @TimeSlotId, @Symptoms, @Status, @CreatedAt)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PatientId", app.PatientId),
                new SqlParameter("@DoctorId", app.DoctorId),
                new SqlParameter("@TimeSlotId", app.TimeSlotId),
                new SqlParameter("@Symptoms", (object)app.Symptoms ?? DBNull.Value),
                new SqlParameter("@Status", app.Status ?? "Chờ duyệt"),
                new SqlParameter("@CreatedAt", DateTime.Now)
            };

            // Tận dụng hàm ExecuteNonQuery từ DBHelper của bạn
            return DBHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
