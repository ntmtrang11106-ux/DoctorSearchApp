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

        // Hàm cập nhật trạng thái Chấp nhận
        public bool UpdateStatusToAccept(int appointmentId)
        {
            // 1. Lấy TimeSlotId của lịch hẹn này trước để cập nhật bảng TimeSlots
            string getSlotQuery = "SELECT TimeSlotId FROM Appointments WHERE Id = @id";
            SqlParameter[] getParams = { new SqlParameter("@id", appointmentId) };
            object result = DBHelper.ExecuteScalar(getSlotQuery, getParams);

            if (result == null) return false;
            int timeSlotId = Convert.ToInt32(result);

            // 2. Tạo danh sách các lệnh thực thi trong một Transaction
            List<SqlCommand> commands = new List<SqlCommand>();

            // Lệnh 1: Cập nhật trạng thái lịch hẹn
            SqlCommand cmd1 = new SqlCommand("UPDATE Appointments SET Status = @status WHERE Id = @id");
            cmd1.Parameters.AddWithValue("@status", "Đã duyệt");
            cmd1.Parameters.AddWithValue("@id", appointmentId);
            commands.Add(cmd1);

            // Lệnh 2: Cập nhật trạng thái khung giờ thành 'Đã đặt'
            SqlCommand cmd2 = new SqlCommand("UPDATE TimeSlots SET Status = @status WHERE Id = @slotId");
            cmd2.Parameters.AddWithValue("@status", "Đã đặt");
            cmd2.Parameters.AddWithValue("@slotId", timeSlotId);
            commands.Add(cmd2);

            // 3. Gọi DBHelper thực thi transaction
            return DBHelper.ExecuteTransaction(commands);
        }

        // Hàm cập nhật trạng thái Từ chối (Nút X đỏ)
        public bool UpdateStatusToReject(int appointmentId)
        {
            // 1. Lấy TimeSlotId của lịch hẹn này trước để giải phóng khung giờ
            string getSlotQuery = "SELECT TimeSlotId FROM Appointments WHERE Id = @id";
            SqlParameter[] getParams = { new SqlParameter("@id", appointmentId) };
            object result = DBHelper.ExecuteScalar(getSlotQuery, getParams);

            if (result == null) return false;
            int timeSlotId = Convert.ToInt32(result);

            // 2. Tạo danh sách các lệnh thực thi trong một Transaction để đảm bảo tính toàn vẹn
            List<SqlCommand> commands = new List<SqlCommand>();

            // Lệnh 1: Cập nhật trạng thái lịch hẹn sang 'Đã từ chối'
            SqlCommand cmd1 = new SqlCommand("UPDATE Appointments SET Status = @status WHERE Id = @id");
            cmd1.Parameters.AddWithValue("@status", "Đã từ chối"); // Khớp với nvarchar(20) trong SQL
            cmd1.Parameters.AddWithValue("@id", appointmentId);
            commands.Add(cmd1);

            // Lệnh 2: Cập nhật trạng thái khung giờ quay về lại 'Trống'
            SqlCommand cmd2 = new SqlCommand("UPDATE TimeSlots SET Status = @status WHERE Id = @slotId");
            cmd2.Parameters.AddWithValue("@status", "Trống"); // Giải phóng khung giờ
            cmd2.Parameters.AddWithValue("@slotId", timeSlotId);
            commands.Add(cmd2);

            // 3. Thực thi transaction qua DBHelper
            return DBHelper.ExecuteTransaction(commands);
        }
    }
}
