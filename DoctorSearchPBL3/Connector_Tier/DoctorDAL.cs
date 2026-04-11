using DTO_Tier;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        // Chức năng lấy danh sách
        public List<DoctorDTO> GetAllDoctors()
        {
            List<DoctorDTO> list = new List<DoctorDTO>();

            string query = @"
            SELECT d.UserId, u.FullName, u.Status, d.workplace, d.SpecificAddress, d.experience_years, 
                   u.Picture, d.Price, d.bio, d.WorkingTime, s.Name AS SpecialtyName, l.Name AS LocationName,
                   (SELECT AVG(CAST(r.Rating AS FLOAT)) FROM Reviews r 
                    JOIN Appointments a ON r.AppointmentId = a.Id 
                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.UserId) AS AvgRating,
                   (SELECT COUNT(r.Id) FROM Reviews r 
                    JOIN Appointments a ON r.AppointmentId = a.Id 
                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.UserId) AS TotalReviews
            FROM Doctors d
            INNER JOIN Users u ON d.UserId = u.UserId
            INNER JOIN Locations l ON d.LocationId = l.Id
            INNER JOIN Specialties s ON d.SpecialtyId = s.Id";

            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DoctorDTO
                {

                    UserId = Convert.ToInt32(row["UserId"]),
                    FullName = row["FullName"]?.ToString() ?? "",
                    Status = row["Status"]?.ToString() ?? "Hoạt động", // Status giờ là NVARCHAR
                    Workplace = row["workplace"]?.ToString() ?? "",
                    SpecificAddress = row["SpecificAddress"]?.ToString() ?? "",
                    ExperienceYears = row["experience_years"] != DBNull.Value ? Convert.ToInt32(row["experience_years"]) : 0,

                    // Xử lý Price: Chuyển về string hoặc decimal tùy DTO bạn chọn (đang để string theo DTO trên)
                    Price = row["Price"]?.ToString() ?? "0",

                    // Cột mới thêm
                    WorkingTime = row["WorkingTime"]?.ToString() ?? "Chưa cập nhật",

                    Picture = row["Picture"]?.ToString() ?? "default.png",
                    Bio = row["bio"]?.ToString() ?? "",
                    LocationName = row["LocationName"]?.ToString() ?? "Chưa xác định",
                    SpecialtyName = row["SpecialtyName"]?.ToString() ?? "Đa khoa",

                    AverageRating = row["AvgRating"] != DBNull.Value ? Convert.ToDouble(row["AvgRating"]) : 0.0,
                    TotalReviews = row["TotalReviews"] != DBNull.Value ? Convert.ToInt32(row["TotalReviews"]) : 0
                });
            }
            return list;
        }

        // 2. Chức năng cập nhật hồ sơ bác sĩ (Sửa lại query cho đúng tên cột mới)
        public bool UpdateDoctorProfile(int userId, string cccd, string cchn, string exp, int locationId, int specId, string workingTime)
        {
            // BƯỚC 1: Cập nhật CCCD ở bảng Users
            string queryUser = "UPDATE Users SET CCCD = @cccd WHERE UserId = @userId";
            SqlParameter[] paramUser = {
                new SqlParameter("@cccd", cccd),
                new SqlParameter("@userId", userId)
            };
            DBHelper.ExecuteNonQuery(queryUser, paramUser);

            // BƯỚC 2: Cập nhật thông tin chuyên môn ở bảng Doctors
            // Lưu ý: Tên cột cchn và experience_years phải khớp với script SQL bạn vừa chạy
            string queryDoctor = @"UPDATE Doctors 
                                 SET cchn = @cchn, 
                                     experience_years = @exp, 
                                     SpecialtyId = @specId,
                                     LocationId = @locId,
                                     WorkingTime = @wt
                                 WHERE UserId = @userId";

            SqlParameter[] paramDoctor = {
                new SqlParameter("@cchn", cchn),
                new SqlParameter("@exp", exp),
                new SqlParameter("@specId", specId),
                new SqlParameter("@locId", locationId),
                new SqlParameter("@wt", (object)workingTime ?? DBNull.Value),
                new SqlParameter("@userId", userId)
            };

            return DBHelper.ExecuteNonQuery(queryDoctor, paramDoctor);
        }

        // Thêm hàm này vào class DoctorDAL của bạn
        public List<DoctorDTO> SearchDoctors(string keyword, string specialty = "", string location = "")
        {
            List<DoctorDTO> list = new List<DoctorDTO>();
            string query = @"
        SELECT d.*, s.Name AS SpecialtyName, l.Name AS LocationName
        FROM Doctors d
        JOIN Specialties s ON d.SpecialtyId = s.Id
        JOIN Locations l ON d.LocationId = l.Id
        WHERE (d.full_name LIKE @key OR s.Name LIKE @key) ";

            // Thêm điều kiện lọc nếu người dùng có chọn bộ lọc
            if (!string.IsNullOrEmpty(specialty)) query += " AND s.Name = @spec ";
            if (!string.IsNullOrEmpty(location)) query += " AND l.Name = @loc ";

            SqlParameter[] parameters = {
        new SqlParameter("@key", "%" + keyword + "%"),
        new SqlParameter("@spec", specialty),
        new SqlParameter("@loc", location)
    };

            DataTable dt = DBHelper.GetDataTable(query, parameters);
            // (Đoạn này bạn copy logic foreach gán dữ liệu từ hàm GetAllDoctors của mình sang là xong)
            return list;
        }
    }
}
///