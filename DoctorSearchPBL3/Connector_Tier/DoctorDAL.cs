using DTO_Tier;
using Microsoft.Data.SqlClient;
using System.Data;

public class DoctorDAL
{
    private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB;Integrated Security=True;TrustServerCertificate=True";

    //    public List<DoctorDTO> GetAllDoctors()
    //    {
    //        List<DoctorDTO> list = new List<DoctorDTO>();
    //        using (SqlConnection conn = new SqlConnection(connectionString))
    //        {
    //            // Query chuẩn theo các bảng bạn vừa INSERT dữ liệu
    //            string query = @"

    //            SELECT 
    //                d.Id, 
    //                d.full_name, 
    //                d.workplace, 
    //                l.Name AS LocationName, 
    //                d.experience_years, 
    //                s.Name AS SpecialtyName
    //            FROM Doctors d
    //            INNER JOIN Locations l ON d.LocationId = l.Id
    //            INNER JOIN Specialties s ON d.SpecialtyId = s.Id";


    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            try
    //            {
    //                conn.Open();
    //                using (SqlDataReader reader = cmd.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        list.Add(new DoctorDTO
    //                        {
    //                            // QUAN TRỌNG: Tên trong ngoặc [""] phải khớp chính xác với SELECT ở trên
    //                            Id = Convert.ToInt32(reader["Id"]),
    //                            full_name = reader["full_name"].ToString(),
    //                            Workplace = reader["workplace"].ToString(),
    //                            LocationName = reader["LocationName"].ToString(),
    //                            SpecialtyName = reader["SpecialtyName"].ToString(),
    //                            ExperienceYears = Convert.ToInt32(reader["experience_years"]),
    //                            AvgRating = 0, // Tạm thời để 0 để hiện thị giao diện trước
    //                            TotalReviews = 0
    //                        });
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                System.Diagnostics.Debug.WriteLine("Lỗi DAL: " + ex.Message);
    //            }
    //        }
    //        return list;
    //    }



    public List<DoctorDTO> GetAllDoctors()
    {
        List<DoctorDTO> list = new List<DoctorDTO>();

        // Query sử dụng Subquery để tính AvgRating và TotalReviews trực tiếp từ bảng Reviews
        string query = @"
        SELECT 
            d.Id, 
            d.full_name, 
            d.workplace, 
            d.SpecificAddress, 
            d.experience_years, 
            d.Picture, 
            d.Price,
            d.status,
            d.bio,
            s.Name AS SpecialtyName,
            l.Name AS LocationName,
            (SELECT AVG(CAST(r.Rating AS FLOAT)) 
             FROM Reviews r 
             JOIN Appointments a ON r.AppointmentId = a.Id 
             JOIN TimeSlots ts ON a.TimeSlotId = ts.Id 
             WHERE ts.DoctorId = d.Id) AS AvgRating,
            (SELECT COUNT(r.Id) 
             FROM Reviews r 
             JOIN Appointments a ON r.AppointmentId = a.Id 
             JOIN TimeSlots ts ON a.TimeSlotId = ts.Id 
             WHERE ts.DoctorId = d.Id) AS TotalReviews
        FROM Doctors d
        INNER JOIN Locations l ON d.LocationId = l.Id
        INNER JOIN Specialties s ON d.SpecialtyId = s.Id";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DoctorDTO doctor = new DoctorDTO
                        {
                            Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                            FullName = reader["full_name"]?.ToString() ?? "",
                            Workplace = reader["workplace"]?.ToString() ?? "",

                            // Cập nhật trường địa chỉ chi tiết mới thêm
                            SpecificAddress = reader["SpecificAddress"]?.ToString() ?? "",

                            LocationName = reader["LocationName"]?.ToString() ?? "",
                            SpecialtyName = reader["SpecialtyName"]?.ToString() ?? "",
                            ExperienceYears = reader["experience_years"] != DBNull.Value ? Convert.ToInt32(reader["experience_years"]) : 0,
                            Bio = reader["bio"]?.ToString() ?? "",
                            Status = reader["status"]?.ToString() ?? "",
                            Picture = reader["Picture"] != DBNull.Value ? reader["Picture"].ToString() : "default.png",

                            // Đọc giá tiền (Decimal)
                            Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0,

                            // Đọc dữ liệu đánh giá từ Subquery
                            AverageRating = reader["AvgRating"] != DBNull.Value ? Convert.ToDouble(reader["AvgRating"]) : 0.0,
                            TotalReviews = reader["TotalReviews"] != DBNull.Value ? Convert.ToInt32(reader["TotalReviews"]) : 0
                        };
                        list.Add(doctor);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi DAL tại GetAllDoctors: " + ex.Message);
                throw;
            }
        }
        return list;
    }
}

