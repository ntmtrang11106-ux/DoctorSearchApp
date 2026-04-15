using DTO_Tier;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DAL_Tier
{
    public class LoginDAL
    {
        // 1. Kiểm tra đăng nhập
        public DataTable CheckLogin(string phone, string password)
        {
            // Sử dụng [User] và PhoneNumber theo thiết kế mới
            string query = "SELECT * FROM [User] WHERE PhoneNumber = @phone AND Password = @pass AND Status = N'Hoạt động'";

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

        // 3. Đăng ký tài khoản (Sử dụng Transaction)
        public bool RegisterFullAccount(UserDTO user)
        {
            List<SqlCommand> commands = new List<SqlCommand>();

            // LỆNH 1: Thêm vào bảng [User]
            // Bổ sung Residential_Address vì thuộc tính này trong DB của bạn là NOT NULL
            string queryUser = @"INSERT INTO [User] (Role, PhoneNumber, FullName, Password, Dob, Gender, Residential_Address, Status, Created_At) 
                                 VALUES (@role, @phone, @name, @pass, @dob, @gender, @address, @status, GETDATE());
                                 SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand cmd1 = new SqlCommand(queryUser);
            cmd1.Parameters.AddWithValue("@role", user.Role);
            cmd1.Parameters.AddWithValue("@phone", user.PhoneNumber);
            cmd1.Parameters.AddWithValue("@name", user.FullName);
            cmd1.Parameters.AddWithValue("@pass", user.Password);
            cmd1.Parameters.AddWithValue("@dob", (object)user.Dob ?? DBNull.Value);
            cmd1.Parameters.AddWithValue("@gender", (object)user.Gender ?? DBNull.Value);
            cmd1.Parameters.AddWithValue("@address", (object)user.Residential_Address ?? "Chưa cập nhật");
            // Doctor thì chờ duyệt (Pending), Patient thì Active luôn
            cmd1.Parameters.AddWithValue("@status", user.Role == "Doctor" ? "Pending" : "Active");
            commands.Add(cmd1);

            // LỆNH 2: Thêm vào bảng con tương ứng
            if (user.Role == "Patient")
            {
                string queryPat = "INSERT INTO Patient (UserId) VALUES (@uid)";
                SqlCommand cmd2 = new SqlCommand(queryPat);
                cmd2.Parameters.AddWithValue("@uid", 0); // @uid sẽ được DBHelper thay bằng ID vừa tạo
                commands.Add(cmd2);
            }
            else if (user.Role == "Doctor")
            {
                // CertificateImage và ClinicAddress là NOT NULL nên cần giá trị mặc định ban đầu
                string queryDoc = @"INSERT INTO Doctor (UserId, CertificateImage, ClinicAddress, ClinicName, IsApproved, Experience_Years, Price) 
                                   VALUES (@uid, @cert, @addr, @clinic, 0, 0, 0)";
                SqlCommand cmd2 = new SqlCommand(queryDoc);
                cmd2.Parameters.AddWithValue("@uid", 0);
                cmd2.Parameters.AddWithValue("@cert", "PENDING_" + user.PhoneNumber);
                cmd2.Parameters.AddWithValue("@addr", "Chưa cập nhật");
                cmd2.Parameters.AddWithValue("@clinic", "Chưa cập nhật");
                commands.Add(cmd2);
            }

            return DBHelper.ExecuteTransaction(commands);
        }

        // 4. Các hàm hỗ trợ chèn riêng lẻ (nếu không dùng Transaction)
        public int RegisterUserBasic(UserDTO user)
        {
            // 1. Khai báo biến result ở ngoài để đảm bảo luôn có giá trị trả về
            int newId = 0;

            string query = @"INSERT INTO [User] (Role, PhoneNumber, FullName, Password, Dob, Gender, Residential_Address, Status, Created_At) 
                     VALUES (@role, @phone, @name, @pass, @dob, @gender, @address, @status, GETDATE());
                     SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters = {
            new SqlParameter("@role", user.Role),
            new SqlParameter("@phone", user.PhoneNumber),
            new SqlParameter("@name", user.FullName),
            new SqlParameter("@pass", user.Password),
            new SqlParameter("@dob", (object)user.Dob ?? DBNull.Value),
            new SqlParameter("@gender", (object)user.Gender ?? DBNull.Value),
            new SqlParameter("@address", (object)user.Residential_Address ?? "Chưa cập nhật"),
            new SqlParameter("@status", user.Role == "Doctor" ? "Pending" : "Active")
            };

            try 
            {
                // 2. Thực thi và gán giá trị
                object result = DBHelper.ExecuteScalar(query, parameters);
                if (result != null)
                {
                    newId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
            // Ghi log lỗi nếu cần
            System.Diagnostics.Debug.WriteLine("Lỗi RegisterUserBasic: " + ex.Message);
            newId = 0; // Đảm bảo thất bại thì trả về 0
            }

            // 3. QUAN TRỌNG: Luôn phải có return ở cuối cùng của hàm
            return newId;
            }

        public bool InsertPatientMinimal(int userId)
        {
            string query = "INSERT INTO Patient (UserId) VALUES (@uid)";
            SqlParameter[] parameters = { new SqlParameter("@uid", userId) };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }

        public bool InsertDoctorMinimal(int userId)
        {
            // Đảm bảo truyền đủ các cột NOT NULL (CertificateImage, ClinicAddress)
            string query = @"INSERT INTO Doctor (UserId, CertificateImage, ClinicAddress, ClinicName, Experience_Years, Price, IsApproved) 
                             VALUES (@uid, @cert, @addr, @clinic, 0, 0, 0)";

            SqlParameter[] parameters = {
                new SqlParameter("@uid", userId),
                new SqlParameter("@cert", "TEMP_" + userId),
                new SqlParameter("@addr", "Chưa cập nhật"),
                new SqlParameter("@clinic", "Chưa cập nhật")
            };

            return DBHelper.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteUser(int userId)
        {
            // Tên cột khóa chính trong Code-First là Id
            string query = "DELETE FROM [User] WHERE Id = @uid";
            SqlParameter[] parameters = { new SqlParameter("@uid", userId) };

            try
            {
                return DBHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi khi xóa User: " + ex.Message);
                return false;
            }
        }
    }
}