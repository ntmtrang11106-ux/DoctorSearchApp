//using DTO_Tier;
//using Microsoft.Data.SqlClient;
//using System.Data;

//public class DoctorDAL
//{
//    private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB;Integrated Security=True;TrustServerCertificate=True";
//    public List<DoctorDTO> GetAllDoctors()
//    {
//        List<DoctorDTO> list = new List<DoctorDTO>();

//        // Query sử dụng Subquery để tính AvgRating và TotalReviews trực tiếp từ bảng Reviews
//        string query = @"
//        SELECT 
//            d.Id, 
//            d.full_name, 
//            d.workplace, 
//            d.SpecificAddress, 
//            d.experience_years, 
//            d.Picture, 
//            d.Price,
//            d.status,
//            d.bio,
//            s.Name AS SpecialtyName,
//            l.Name AS LocationName,
//            (SELECT AVG(CAST(r.Rating AS FLOAT)) 
//             FROM Reviews r 
//             JOIN Appointments a ON r.AppointmentId = a.Id 
//             JOIN TimeSlots ts ON a.TimeSlotId = ts.Id 
//             WHERE ts.DoctorId = d.Id) AS AvgRating,
//            (SELECT COUNT(r.Id) 
//             FROM Reviews r 
//             JOIN Appointments a ON r.AppointmentId = a.Id 
//             JOIN TimeSlots ts ON a.TimeSlotId = ts.Id 
//             WHERE ts.DoctorId = d.Id) AS TotalReviews
//        FROM Doctors d
//        INNER JOIN Locations l ON d.LocationId = l.Id
//        INNER JOIN Specialties s ON d.SpecialtyId = s.Id";

//        using (SqlConnection conn = new SqlConnection(connectionString))
//        {
//            SqlCommand cmd = new SqlCommand(query, conn);
//            try
//            {
//                conn.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        DoctorDTO doctor = new DoctorDTO
//                        {
//                            Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
//                            FullName = reader["full_name"]?.ToString() ?? "",
//                            Workplace = reader["workplace"]?.ToString() ?? "",

//                            // Cập nhật trường địa chỉ chi tiết mới thêm
//                            SpecificAddress = reader["SpecificAddress"]?.ToString() ?? "",

//                            LocationName = reader["LocationName"]?.ToString() ?? "",
//                            SpecialtyName = reader["SpecialtyName"]?.ToString() ?? "",
//                            ExperienceYears = reader["experience_years"] != DBNull.Value ? Convert.ToInt32(reader["experience_years"]) : 0,
//                            Bio = reader["bio"]?.ToString() ?? "",
//                            Status = reader["status"]?.ToString() ?? "",
//                            Picture = reader["Picture"] != DBNull.Value ? reader["Picture"].ToString() : "default.png",

//                            // Đọc giá tiền (Decimal)
//                            Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0,

//                            // Đọc dữ liệu đánh giá từ Subquery
//                            AverageRating = reader["AvgRating"] != DBNull.Value ? Convert.ToDouble(reader["AvgRating"]) : 0.0,
//                            TotalReviews = reader["TotalReviews"] != DBNull.Value ? Convert.ToInt32(reader["TotalReviews"]) : 0
//                        };
//                        list.Add(doctor);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("Lỗi DAL tại GetAllDoctors: " + ex.Message);
//                throw;
//            }
//        }
//        return list;
//    }
//}


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
            SELECT d.Id, d.full_name, d.workplace, d.SpecificAddress, d.experience_years, 
                   d.Picture, d.Price, d.status, d.bio, s.Name AS SpecialtyName, l.Name AS LocationName,
                   (SELECT AVG(CAST(r.Rating AS FLOAT)) FROM Reviews r 
                    JOIN Appointments a ON r.AppointmentId = a.Id 
                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.Id) AS AvgRating,
                   (SELECT COUNT(r.Id) FROM Reviews r 
                    JOIN Appointments a ON r.AppointmentId = a.Id 
                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.Id) AS TotalReviews
            FROM Doctors d
            INNER JOIN Locations l ON d.LocationId = l.Id
            INNER JOIN Specialties s ON d.SpecialtyId = s.Id";

            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DoctorDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FullName = row["full_name"].ToString(),
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
                    Status = row["status"].ToString()
                });
            }
            return list;
        }

        // Chức năng cập nhật bác sĩ
        public bool UpdateDoctor(DoctorDTO doctor)
        {
            string query = "UPDATE Doctors SET full_name = @name, workplace = @work, experience_years = @exp, Price = @price WHERE Id = @id";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@name", doctor.FullName),
                new SqlParameter("@work", doctor.Workplace),
                new SqlParameter("@exp", doctor.ExperienceYears),
                new SqlParameter("@price", doctor.Price),
                new SqlParameter("@id", doctor.Id)
            };
            return DBHelper.ExecuteNonQuery(query, parameters);
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