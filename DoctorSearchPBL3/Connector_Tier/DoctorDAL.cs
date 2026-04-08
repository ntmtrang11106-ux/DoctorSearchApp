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
            //string query = @"
            //SELECT d.Id, u.FullName,u.Status, d.workplace, d.SpecificAddress, d.experience_years, 
            //       u.Picture, d.Price, d.bio, s.Name AS SpecialtyName, l.Name AS LocationName,
            //       (SELECT AVG(CAST(r.Rating AS FLOAT)) FROM Reviews r 
            //        JOIN Appointments a ON r.AppointmentId = a.Id 
            //        JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.Id) AS AvgRating,
            //       (SELECT COUNT(r.Id) FROM Reviews r 
            //        JOIN Appointments a ON r.AppointmentId = a.Id 
            //        JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.Id) AS TotalReviews
            //FROM Doctors d
            //INNER JOIN Users u ON d.UserId = u.UserId
            //INNER JOIN Locations l ON d.LocationId = l.Id
            //INNER JOIN Specialties s ON d.SpecialtyId = s.Id";

            string query = @"
            SELECT d.UserId, u.FullName, u.Status, d.workplace, d.SpecificAddress, d.experience_years, 
                   u.Picture, d.Price, d.bio, s.Name AS SpecialtyName, l.Name AS LocationName,
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
                    //Id = Convert.ToInt32(row["Id"]),
                    //FullName = row["FullName"].ToString(),
                    //Workplace = row["workplace"].ToString(),
                    //SpecificAddress = row["SpecificAddress"].ToString(),
                    //LocationName = row["LocationName"].ToString(),
                    //SpecialtyName = row["SpecialtyName"].ToString(),
                    //ExperienceYears = Convert.ToInt32(row["experience_years"]),
                    //Price = Convert.ToDecimal(row["Price"]),
                    //AverageRating = row["AvgRating"] != DBNull.Value ? Convert.ToDouble(row["AvgRating"]) : 0.0,
                    //TotalReviews = Convert.ToInt32(row["TotalReviews"]),
                    //Picture = row["Picture"].ToString(),
                    //Bio = row["bio"].ToString(),
                    //Status = row["status"].ToString()

                    // Đổi từ Id sang UserId theo chuẩn mới
                    UserId = Convert.ToInt32(row["UserId"]),
                    FullName = row["FullName"].ToString(),
                    Workplace = row["workplace"].ToString(),
                    SpecificAddress = row["SpecificAddress"].ToString(),
                    LocationName = row["LocationName"].ToString(),
                    SpecialtyName = row["SpecialtyName"].ToString(),
                    ExperienceYears = Convert.ToInt32(row["experience_years"]),
                    Price = Convert.ToDecimal(row["Price"]),
                    AverageRating = row["AvgRating"] != DBNull.Value ? Convert.ToDouble(row["AvgRating"]) : 0.0,
                    TotalReviews = Convert.ToInt32(row["TotalReviews"]),
                    Picture = row["Picture"].ToString(),
                    Bio = row["bio"].ToString(),
                    // Status là BIT trong SQL, chuyển về string hoặc bool tùy DTO của bạn
                    Status = row["Status"].ToString()
                });
            }
            return list;
        }

        // 2. Chức năng cập nhật hồ sơ bác sĩ (Sửa lại query cho đúng tên cột mới)
        public bool UpdateDoctorProfile(int userId, string cccd, string cchn, string exp, int locationId, int specId)
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
                                     LocationId = @locId
                                 WHERE UserId = @userId";

            SqlParameter[] paramDoctor = {
                new SqlParameter("@cchn", cchn),
                new SqlParameter("@exp", exp),
                new SqlParameter("@specId", specId),
                new SqlParameter("@locId", locationId),
                new SqlParameter("@userId", userId)
            };

            return DBHelper.ExecuteNonQuery(queryDoctor, paramDoctor);
        }
    }
}
///