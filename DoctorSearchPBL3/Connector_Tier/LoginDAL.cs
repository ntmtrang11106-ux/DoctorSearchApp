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

        // Kiểm tra SĐT đã tồn tại chưa
        public bool IsPhoneExists(string phone)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE phone_number = @phone";
            SqlParameter[] parameters = { new SqlParameter("@phone", phone) };
            DataTable dt = DBHelper.GetDataTable(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Đăng ký tài khoản
        public bool Register(UserDTO user)
        {
            string query = "INSERT INTO Users (phone_number, password, full_name, role, status) VALUES (@phone, @pass, @name, 'Patient', 1)";
            SqlParameter[] parameters = {
                new SqlParameter("@phone", user.PhoneNumber),
                new SqlParameter("@pass", user.Password),
                new SqlParameter("@name", user.FullName)
            };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
