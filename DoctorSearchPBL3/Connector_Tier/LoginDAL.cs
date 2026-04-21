using DTO_Tier;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL_Tier
{
    public class LoginDAL
    {
        // 1. Kiểm tra đăng nhập
        public DataTable CheckLogin(string phone, string password)
        {
            string query = "SELECT * FROM [User] WHERE PhoneNumber = @phone AND Password = @pass AND Status = N'Active'";
            SqlParameter[] parameters = {
                new SqlParameter("@phone", phone),
                new SqlParameter("@pass", password)
            };
            return DBHelper.GetDataTable(query, parameters);
        }

        // 2. Kiểm tra SĐT đã tồn tại chưa
        public bool IsPhoneExists(string phone)
        {
            string query = "SELECT COUNT(*) FROM [User] WHERE PhoneNumber = @phone";
            SqlParameter[] parameters = { new SqlParameter("@phone", phone) };
            DataTable dt = DBHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // 3. Đăng ký thông tin cơ bản vào bảng [User]
        public int RegisterUserBasic(UserDTO user)
        {
            int newId = 0;
            // Đảm bảo có CCCD và Residential_Address (địa chỉ gộp từ UI)
            string query = @"INSERT INTO [User] (Role, PhoneNumber, FullName, Password, Dob, Gender, CCCD, Residential_Address, Picture, Status, Created_At) 
                             VALUES (@role, @phone, @name, @pass, @dob, @gender, @cccd, @address, @pic, @status, GETDATE());
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters = {
                new SqlParameter("@role", user.Role),
                new SqlParameter("@phone", user.PhoneNumber),
                new SqlParameter("@name", user.FullName),
                new SqlParameter("@pass", user.Password),
                new SqlParameter("@dob", (object)user.Dob ?? DBNull.Value),
                new SqlParameter("@gender", user.Gender ?? (object)DBNull.Value),
                new SqlParameter("@cccd", user.CCCD ?? ""),
                new SqlParameter("@address", user.Residential_Address ?? ""),
                // Xử lý Picture null thì dùng default
                new SqlParameter("@pic", (object)user.Picture ?? "default.jpg"),
                new SqlParameter("@status", user.Role == "Doctor" ? "Pending" : "Active")
            };

            try
            {
                object result = DBHelper.ExecuteScalar(query, parameters);
                if (result != null) newId = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi RegisterUserBasic: " + ex.Message);
                newId = 0;
            }
            return newId;
        }

        // 4. Đăng ký chi tiết Bệnh nhân (Hàm bạn đang thiếu trong BUS)
        public bool InsertPatientFull(int userId, string bhyt, string bloodType = "N/A", string medicalHistory = "None")
        {
            // BHYT lấy từ ảnh mẫu Nhân gửi
            string query = @"INSERT INTO Patient (UserId, BHYT, Blood_Type, Medical_History) 
                             VALUES (@uid, @bhyt, @blood, @history)";
            SqlParameter[] parameters = {
                new SqlParameter("@uid", userId),
                new SqlParameter("@bhyt", bhyt),
                new SqlParameter("@blood", bloodType),
                new SqlParameter("@history", medicalHistory)
            };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }

        // 5. Đăng ký chi tiết Bác sĩ và Chuyên khoa (Hàm bạn đang thiếu trong BUS)
        public bool InsertDoctorFull(int userId, string allCertCodes, string allCertImages, string clinicAddr, string clinicName, string bio, int? locationId, List<int> specialtyIds)
        {
            // Sử dụng câu lệnh INSERT cho CSDL DoctorSearchDB_CodeFirst
            string queryDoc = @"INSERT INTO Doctor 
                        (UserId, CertificateCode, CertificateImage, ClinicAddress, ClinicName, 
                         Experience_Years, Bio, Price, WorkingTime, LocationId, IsApproved) 
                        VALUES 
                        (@uid, @codes, @images, @addr, @name, 0, @bio, 0, N'Chưa cập nhật', @locId, 0);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters = {
            new SqlParameter("@uid", userId),
            new SqlParameter("@codes", allCertCodes ?? ""), // Lưu chuỗi "T123, T456"
            new SqlParameter("@images", allCertImages ?? "default.jpg"), // Lưu chuỗi "img1.jpg, img2.jpg"
            new SqlParameter("@addr", clinicAddr),
            new SqlParameter("@name", clinicName),
            new SqlParameter("@bio", bio ?? ""),
            new SqlParameter("@locId", (object)locationId ?? DBNull.Value)
         };

            try
            {
                // Sử dụng Microsoft.Data.SqlClient cho .NET development
                object result = DBHelper.ExecuteScalar(queryDoc, parameters);
                if (result == null) return false;
                int doctorTableId = Convert.ToInt32(result);

                // Chèn vào bảng trung gian Doctor_Specialty
                if (specialtyIds != null && specialtyIds.Count > 0)
                {
                    foreach (int specId in specialtyIds)
                    {
                        string querySpec = "INSERT INTO Doctor_Specialty (DoctorId, SpecialtyId) VALUES (@did, @sid)";
                        SqlParameter[] specParams = {
                    new SqlParameter("@did", doctorTableId),
                    new SqlParameter("@sid", specId)
                };
                        DBHelper.ExecuteNonQuery(querySpec, specParams);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Nếu có lỗi SQL, hàm sẽ trả về false và kích hoạt thông báo lỗi ở UI
                return false;
            }
        }

        // 6. Xóa User (Dùng khi lưu bảng con bị lỗi để hoàn tác)
        public bool DeleteUser(int userId)
        {
            string query = "DELETE FROM [User] WHERE Id = @uid";
            SqlParameter[] parameters = { new SqlParameter("@uid", userId) };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }
    }
}