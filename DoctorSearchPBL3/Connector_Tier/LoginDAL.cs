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
        public bool InsertPatientFull(int userId, string bhyt, string bloodType = "Chưa cập nhật", string medicalHistory = "None")
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

        // 5. Đăng ký chi tiết Bác sĩ và Chuyên khoa(Hàm bạn đang thiếu trong BUS)
        public bool InsertDoctorFull(int userId, string allCertCodes, string allCertImages, string clinicAddr, string clinicName, string bio, int? locationId, List<int> specialtyIds)
        {
            // Câu lệnh SQL: Dựa trên schema NOT NULL của bạn
            // Cột Experience_Years, Price, LocationId cho phép NULL nên dùng giá trị mặc định hoặc null
            // Các cột khác là NOT NULL nên phải đảm bảo có giá trị (dùng N'' nếu trống)
            string queryDoc = @"INSERT INTO Doctor 
                            (UserId, CertificateCode, CertificateImage, ClinicAddress, ClinicName, 
                             Experience_Years, Bio, Price, WorkingTime, LocationId, IsApproved) 
                            VALUES 
                            (@uid, @codes, @images, @addr, @name, @exp, @bio, @price, @workTime, @locId, @approved);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters = {
                new SqlParameter("@uid", userId),
                // CertificateCode: NOT NULL -> nếu trống để chuỗi rỗng
                new SqlParameter("@codes", string.IsNullOrEmpty(allCertCodes) ? "" : allCertCodes), 
                // CertificateImage: NOT NULL -> nếu trống để ảnh mặc định
                new SqlParameter("@images", string.IsNullOrEmpty(allCertImages) ? "" : allCertImages),
                new SqlParameter("@addr", string.IsNullOrEmpty(clinicAddr) ? "Chưa cập nhật" : clinicAddr),
                new SqlParameter("@name", string.IsNullOrEmpty(clinicName) ? "Phòng khám tư nhân" : clinicName),
                new SqlParameter("@exp", DBNull.Value), // Cho phép NULL trong DB
                new SqlParameter("@bio", string.IsNullOrEmpty(bio) ? "Chưa có thông tin giới thiệu" : bio),
                new SqlParameter("@price", DBNull.Value), // Cho phép NULL trong DB
                new SqlParameter("@workTime", "Chưa cập nhật"), // NOT NULL nên cần giá trị mặc định
                new SqlParameter("@locId", (object)locationId ?? DBNull.Value),
                new SqlParameter("@approved", false) // Mặc định là chưa duyệt (bit -> false)
        };

            try
            {
                // Thực thi lấy ID của Doctor vừa chèn
                object result = DBHelper.ExecuteScalar(queryDoc, parameters);
                if (result == null) return false;

                int doctorTableId = Convert.ToInt32(result);

                // Chèn vào bảng trung gian Doctor_Specialty (Nếu có chọn chuyên khoa)
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
                System.Diagnostics.Debug.WriteLine("Lỗi InsertDoctorFull: " + ex.Message);
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