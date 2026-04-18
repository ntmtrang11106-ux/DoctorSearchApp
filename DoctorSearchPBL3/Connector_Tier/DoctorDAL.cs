//using DTO_Tier;
//using Microsoft.Data.SqlClient;
//using System.Data;
//using System.Collections.Generic;
//using System;

//namespace DAL_Tier
//{
//    public class DoctorDAL
//    {
//        public List<DoctorDTO> GetAllDoctors()
//        {
//            List<DoctorDTO> list = new List<DoctorDTO>();

//            string query = @"
//            SELECT d.UserId, u.FullName, u.Status, d.workplace, d.SpecificAddress, d.experience_years, 
//                   u.Picture, d.Price, d.bio, d.WorkingTime, s.Name AS SpecialtyName, l.Name AS LocationName,
//                   (SELECT AVG(CAST(r.Rating AS FLOAT)) FROM Reviews r 
//                    JOIN Appointments a ON r.AppointmentId = a.Id 
//                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.UserId) AS AvgRating,
//                   (SELECT COUNT(r.Id) FROM Reviews r 
//                    JOIN Appointments a ON r.AppointmentId = a.Id 
//                    JOIN TimeSlots ts ON a.TimeSlotId = ts.Id WHERE ts.DoctorId = d.UserId) AS TotalReviews
//            FROM Doctors d
//            INNER JOIN Users u ON d.UserId = u.UserId
//            INNER JOIN Locations l ON d.LocationId = l.Id
//            INNER JOIN Specialties s ON d.SpecialtyId = s.Id";
////=======
////            // Truy vấn bám sát tên bảng và cột trong file Word của bạn
////            string query = @"
////            SELECT d.Id, d.UserId, d.CertificateImage, d.ClinicAddress, d.ClinicName, 
////                   d.Experience_Years, d.Bio, d.Price, d.WorkingTime, 
////                   d.LocationId, d.SpecialtyId, d.IsApproved
////            FROM Doctor d";
////>>>>>>> Trang_codefirst

//            DataTable dt = DBHelper.GetDataTable(query);

//            foreach (DataRow row in dt.Rows)
//            {
//                list.Add(new DoctorDTO
//                {
//<<<<<<< HEAD

//                    UserId = Convert.ToInt32(row["UserId"]),
//                    FullName = row["FullName"]?.ToString() ?? "",
//                    Status = row["Status"]?.ToString() ?? "Hoạt động", // Status giờ là NVARCHAR
//                    Workplace = row["workplace"]?.ToString() ?? "",
//                    SpecificAddress = row["SpecificAddress"]?.ToString() ?? "",
//                    ExperienceYears = row["experience_years"] != DBNull.Value ? Convert.ToInt32(row["experience_years"]) : 0,

//                    // Xử lý Price: Chuyển về string hoặc decimal tùy DTO bạn chọn (đang để string theo DTO trên)
//                    Price = row["Price"]?.ToString() ?? "0",

//                    // Cột mới thêm
//                    WorkingTime = row["WorkingTime"]?.ToString() ?? "Chưa cập nhật",

//                    Picture = row["Picture"]?.ToString() ?? "default.png",
//                    Bio = row["bio"]?.ToString() ?? "",
//                    LocationName = row["LocationName"]?.ToString() ?? "Chưa xác định",
//                    SpecialtyName = row["SpecialtyName"]?.ToString() ?? "Đa khoa",

//                    AverageRating = row["AvgRating"] != DBNull.Value ? Convert.ToDouble(row["AvgRating"]) : 0.0,
//                    TotalReviews = row["TotalReviews"] != DBNull.Value ? Convert.ToInt32(row["TotalReviews"]) : 0
//=======
//                    Id = Convert.ToInt32(row["Id"]),
//                    UserId = Convert.ToInt32(row["UserId"]),
//                    CertificateImage = row["CertificateImage"]?.ToString(),
//                    ClinicAddress = row["ClinicAddress"]?.ToString(),
//                    ClinicName = row["ClinicName"]?.ToString(),
//                    Experience_Years = row["Experience_Years"] != DBNull.Value ? Convert.ToInt32(row["Experience_Years"]) : 0,
//                    Bio = row["Bio"]?.ToString(),
//                    Price = row["Price"] != DBNull.Value ? Convert.ToDecimal(row["Price"]) : 0,
//                    WorkingTime = row["WorkingTime"]?.ToString(),
//                    LocationId = row["LocationId"] != DBNull.Value ? Convert.ToInt32(row["LocationId"]) : (int?)null,
//                    SpecialtyId = row["SpecialtyId"] != DBNull.Value ? Convert.ToInt32(row["SpecialtyId"]) : (int?)null,
//                    IsApproved = row["IsApproved"] != DBNull.Value && Convert.ToBoolean(row["IsApproved"])
//>>>>>>> Trang_codefirst
//                });
//            }
//            return list;
//        }

//<<<<<<< HEAD
//        // 2. Chức năng cập nhật hồ sơ bác sĩ (Sửa lại query cho đúng tên cột mới)
//        public bool UpdateDoctorProfile(int userId, string cccd, string cchn, string exp, int locationId, int specId, string workingTime)
//        {
//            // BƯỚC 1: Cập nhật CCCD ở bảng Users
//            string queryUser = "UPDATE Users SET CCCD = @cccd WHERE UserId = @userId";
//            SqlParameter[] paramUser = {
//                new SqlParameter("@cccd", cccd),
//                new SqlParameter("@userId", userId)
//=======
//        public bool UpdateDoctor(DoctorDTO doctor)
//        {
//            // Cập nhật đúng các cột theo file Word
//            string query = @"UPDATE Doctor SET 
//                            ClinicAddress = @addr, 
//                            ClinicName = @name,
//                            Experience_Years = @exp, 
//                            Price = @price 
//                            WHERE Id = @id";

//            SqlParameter[] parameters = new SqlParameter[] {
//                new SqlParameter("@addr", (object)doctor.ClinicAddress ?? DBNull.Value),
//                new SqlParameter("@name", (object)doctor.ClinicName ?? DBNull.Value),
//                new SqlParameter("@exp", (object)doctor.Experience_Years ?? DBNull.Value),
//                new SqlParameter("@price", (object)doctor.Price ?? DBNull.Value),
//                new SqlParameter("@id", doctor.Id)
//>>>>>>> Trang_codefirst
//            };
//            DBHelper.ExecuteNonQuery(queryUser, paramUser);

//            // BƯỚC 2: Cập nhật thông tin chuyên môn ở bảng Doctors
//            // Lưu ý: Tên cột cchn và experience_years phải khớp với script SQL bạn vừa chạy
//            string queryDoctor = @"UPDATE Doctors 
//                                 SET cchn = @cchn, 
//                                     experience_years = @exp, 
//                                     SpecialtyId = @specId,
//                                     LocationId = @locId,
//                                     WorkingTime = @wt
//                                 WHERE UserId = @userId";

//            SqlParameter[] paramDoctor = {
//                new SqlParameter("@cchn", cchn),
//                new SqlParameter("@exp", exp),
//                new SqlParameter("@specId", specId),
//                new SqlParameter("@locId", locationId),
//                new SqlParameter("@wt", (object)workingTime ?? DBNull.Value),
//                new SqlParameter("@userId", userId)
//            };

//            return DBHelper.ExecuteNonQuery(queryDoctor, paramDoctor);
//        }
//    }
//}

using DTO_Tier;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        public List<DoctorDTO> GetAllDoctors()
        {
            List<DoctorDTO> list = new List<DoctorDTO>();

            // Cập nhật Query để tính toán AvgRating và TotalCount từ bảng Reviews 
            string query = @"
            SELECT 
                d.*, 
                u.FullName, u.PhoneNumber, u.Picture, u.Status, u.CCCD,
                s.SpecialtyName,
                l.LocationName,
                -- Tính trung bình số sao từ bảng Reviews, nếu không có thì trả về 0 
                ISNULL((SELECT AVG(CAST(Rating AS FLOAT)) FROM Reviews r WHERE r.DoctorID = d.Id AND r.IsVisible = 1), 0) AS AvgRating,
                -- Đếm tổng số lượt đánh giá công khai 
                (SELECT COUNT(*) FROM Reviews r WHERE r.DoctorID = d.Id AND r.IsVisible = 1) AS TotalCount
            FROM Doctor d
            INNER JOIN [User] u ON d.UserId = u.Id
            LEFT JOIN Specialtie s ON d.SpecialtyId = s.Id
            LEFT JOIN Location l ON d.LocationId = l.Id";

            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                DoctorDTO doctor = new DoctorDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    CertificateImage = row["CertificateImage"]?.ToString(),
                    ClinicAddress = row["ClinicAddress"]?.ToString(),
                    ClinicName = row["ClinicName"]?.ToString(),
                    Experience_Years = row["Experience_Years"] != DBNull.Value ? Convert.ToInt32(row["Experience_Years"]) : 0,
                    Bio = row["Bio"]?.ToString(),
                    Price = row["Price"] != DBNull.Value ? Convert.ToDecimal(row["Price"]) : 0,
                    WorkingTime = row["WorkingTime"]?.ToString(),
                    IsApproved = row["IsApproved"] != DBNull.Value && Convert.ToBoolean(row["IsApproved"]),

                    // Gán giá trị đã tính toán vào các thuộc tính DTO 

                    AverageRating = row["AvgRating"] != DBNull.Value ? Convert.ToDouble(row["AvgRating"]) : 0,
                    TotalReviews = row["TotalCount"] != DBNull.Value ? Convert.ToInt32(row["TotalCount"]) : 0,

                    User = new UserDTO
                    {
                        FullName = row["FullName"]?.ToString(),
                        Picture = row["Picture"]?.ToString()
                    },
                    Location = new LocationDTO
                    {
                        LocationName = row["LocationName"]?.ToString() ?? "N/A"
                    },
                    Specialty = new SpecialtyDTO
                    {
                        SpecialtyName = row["SpecialtyName"]?.ToString() ?? "N/A"
                    }
                };
                list.Add(doctor);
            }
            return list;
        }

        public bool UpdateDoctor(DoctorDTO doctor)
        {
            // Cập nhật thông tin User nếu có thay đổi [cite: 11]
            if (doctor.User != null)
            {
                string queryUser = "UPDATE [User] SET FullName = @name WHERE Id = @userId";
                SqlParameter[] paramUser = {
                    new SqlParameter("@name", doctor.User.FullName),
                    new SqlParameter("@userId", doctor.UserId)
                };
                DBHelper.ExecuteNonQuery(queryUser, paramUser);
            }

            string queryDoctor = @"UPDATE Doctor SET 
                                 ClinicAddress = @addr, ClinicName = @name,
                                 Experience_Years = @exp, Price = @price, 
                                 WorkingTime = @wt WHERE Id = @id"; 

            SqlParameter[] paramDoctor = {
                new SqlParameter("@addr", doctor.ClinicAddress),
                new SqlParameter("@name", (object)doctor.ClinicName ?? DBNull.Value),
                new SqlParameter("@exp", (object)doctor.Experience_Years ?? DBNull.Value),
                new SqlParameter("@price", (object)doctor.Price ?? DBNull.Value),
                new SqlParameter("@wt", (object)doctor.WorkingTime ?? DBNull.Value),
                new SqlParameter("@id", doctor.Id)
            };

            return DBHelper.ExecuteNonQuery(queryDoctor, paramDoctor);
        }
    }
}