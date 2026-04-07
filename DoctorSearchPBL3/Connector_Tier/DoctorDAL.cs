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
            SELECT d.Id, u.FullName,u.Status, d.workplace, d.SpecificAddress, d.experience_years, 
                   d.Picture, d.Price, d.bio, s.Name AS SpecialtyName, l.Name AS LocationName,
                   (SELECT AVG(CAST(r.Rating AS FLOAT)) FROM Reviews r 
                    JOIN Appointments a ON r.AppointmentId = a.Id 
                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.Id) AS AvgRating,
                   (SELECT COUNT(r.Id) FROM Reviews r 
                    JOIN Appointments a ON r.AppointmentId = a.Id 
                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.Id) AS TotalReviews
            FROM Doctors d
            INNER JOIN Users u ON d.UserId = u.UserId
            INNER JOIN Locations l ON d.LocationId = l.Id
            INNER JOIN Specialties s ON d.SpecialtyId = s.Id";

            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DoctorDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
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
                    Status = row["status"].ToString()
                });
            }
            return list;
        }

        // Chức năng cập nhật bác sĩ
        public bool UpdateDoctorProfile(int userId, string cccd, string cchn, string exp, int clinicId, int specId)
        {
            string query = @"INSERT INTO Doctors (user_id, cccd, practicing_certificate_number, experience_years, clinic_id, specialization_id) 
                     VALUES (@userId, @cccd, @cchn, @exp, @clinicId, @specId)";

            SqlParameter[] parameters = {
        new SqlParameter("@userId", userId),
        new SqlParameter("@cccd", cccd),
        new SqlParameter("@cchn", cchn),
        new SqlParameter("@exp", exp),
        new SqlParameter("@clinicId", clinicId),
        new SqlParameter("@specId", specId)
    };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
///