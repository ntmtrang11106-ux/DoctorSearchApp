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
        public List<AppointmentDTO> GetAllAppointments()
        {
            List<AppointmentDTO> list = new List<AppointmentDTO>();
            string query = @"SELECT 
                                a.Id AS Id,
                                u.FullName AS full_name, 
                                u.phone_number AS phone_number, 
                                t.Date AS Date, 
                                t.StartTime, 
                                t.EndTime, 
                                a.Symptoms, 
                                a.Status,
                                a.CreatedAt 
                            FROM Appointments a 
                            LEFT JOIN Patients p ON a.PatientId = p.Id 
                            LEFT JOIN Users u ON p.UserId = u.UserId 
                            LEFT JOIN TimeSlots t ON a.TimeSlotId = t.Id
                            ORDER BY t.Date DESC;"; // Sắp xếp theo ngày mới nhất
            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                // Giả sử row là DataRow từ DataTable
                list.Add(new AppointmentDTO
                {
                    // 1. Lấy ID để sau này còn bấm Duyệt/Hủy
                    Id = Convert.ToInt32(row["Id"]),

                    // 2. Thông tin Patient (JOIN từ bảng Patients)
                    PatientName = row["full_name"].ToString(),

                    // 3. Số điện thoại (JOIN từ bảng Users)
                    PhoneNumber = row["phone_number"].ToString(),

                    // 4. Triệu chứng (Check NULL cho chắc ăn)
                    Symptoms = row["Symptoms"] != DBNull.Value ? row["Symptoms"].ToString() : "Không có triệu chứng",

                    // 5. Trạng thái (Thành công, Chờ duyệt...)
                    Status = row["Status"].ToString(),

                    // 6. Ngày tháng (Convert sang dd/MM/yyyy cho đẹp)
                    AppointmentDate = row["Date"] != DBNull.Value
                        ? Convert.ToDateTime(row["Date"]).ToString("dd/MM/yyyy")
                        : "Chưa xác định",

                    // 7. Khung giờ (Ghép StartTime và EndTime)
                    TimeRange = $"{Convert.ToDateTime(row["StartTime"].ToString()).ToString("HH'h':mm")} - {Convert.ToDateTime(row["EndTime"].ToString()).ToString("HH'h':mm")}",
                    // Kết quả sẽ ra: 08h:30 - 09h:15

                    // 8. Ngày tạo (Để biết ai đặt trước)
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                });
            }
            return list;
        }
    }
}
