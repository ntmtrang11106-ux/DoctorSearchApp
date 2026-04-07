using DTO_Tier;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Tier
{
    public class LoginDAL // 3. Tên class phải khớp hoàn toàn (không viết sai chính tả)
    {
        // Kiểm tra đăng nhập
        public DataTable CheckLogin(string phone, string password, string role)
        {
            string query = "SELECT * FROM Users WHERE phone_number = @phone AND password = @pass AND role = @role AND status = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@phone", phone),
                new SqlParameter("@pass", password),
                new SqlParameter("@role", role)
            };
            return DBHelper.GetDataTable(query, parameters);
        }

        // 1. Kiểm tra SĐT đã tồn tại chưa
        public bool IsPhoneExists(string phone)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE phone_number = @phone";
            SqlParameter[] parameters = { new SqlParameter("@phone", phone) };
            DataTable dt = DBHelper.GetDataTable(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // 2. Đăng ký tài khoản cơ bản vào bảng Users
        public int RegisterUser(UserDTO user)
        {
            // Lệnh SELECT SCOPE_IDENTITY() dùng để lấy ID tự tăng vừa được tạo ra
            string query = @"INSERT INTO Users (phone_number, password, role, Status, FullName) 
                     VALUES (@phone, @pass, @role, 1, @name);
                     SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
        new SqlParameter("@phone", user.PhoneNumber),
        new SqlParameter("@pass", user.Password),
        new SqlParameter("@role", user.Role),
        new SqlParameter("@name", user.FullName)
    };

            try
            {
                // Dùng ExecuteScalar để lấy giá trị ID (kiểu object) rồi ép sang int
                object result = DBHelper.ExecuteNonQuery(query, parameters);
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
            catch { return 0; }
        }
        // Hàm lưu vào bảng Patients (Bệnh nhân)
        public bool InsertPatient(int userId, DateTime dob, string gender)
        {
            string query = "INSERT INTO Patients (UserId, dob, gender) VALUES (@uid, @dob, @gen)";
            SqlParameter[] parameters = {
            new SqlParameter("@uid", userId),
            new SqlParameter("@dob", dob),
            new SqlParameter("@gen", gender)
    };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }

        // Hàm lưu vào bảng Doctors (Bác sĩ - Chỉ lưu ID trước, các thông tin khác cập nhật sau)
        public bool InsertDoctor(int userId)
        {
            string query = "INSERT INTO Doctors (UserId) VALUES (@uid)";
            SqlParameter[] parameters = { new SqlParameter("@uid", userId) };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }

    }
}
