using DTO_Tier;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Tier
{
    public class LoginDAL 
    {
        public DataTable CheckLogin(string phone, string password)
        {
            // Bỏ điều kiện AND role = @role để SQL tự tìm xem tài khoản này thuộc quyền gì
            string query = "SELECT * FROM Users WHERE phone_number = @phone AND password = @pass AND status = N'Hoạt động'";

            SqlParameter[] parameters = {
            new SqlParameter("@phone", phone),
            new SqlParameter("@pass", password)
            };

            return DBHelper.GetDataTable(query, parameters);
        }

        //ĐĂNG KÝ 
        // 2. Kiểm tra SĐT đã tồn tại chưa
        public bool IsPhoneExists(string phone)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE phone_number = @phone";
            SqlParameter[] parameters = { new SqlParameter("@phone", phone) };
            DataTable dt = DBHelper.GetDataTable(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // 3. Đăng ký tài khoản (Sử dụng Transaction để đảm bảo tính toàn vẹn)
        public bool RegisterFullAccount(UserDTO user)
        {
            List<SqlCommand> commands = new List<SqlCommand>();

            // LỆNH 1: Thêm vào bảng Users (Lưu ý: Dob và Gender giờ nằm ở đây)
            string queryUser = @"INSERT INTO Users (phone_number, password, role, Status, FullName, Dob, Gender) 
                                 VALUES (@phone, @pass, @role, N'Hoạt động', @name, @dob, @gender);
                                 SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand cmd1 = new SqlCommand(queryUser);
            cmd1.Parameters.AddWithValue("@phone", user.PhoneNumber);
            cmd1.Parameters.AddWithValue("@pass", user.Password);
            cmd1.Parameters.AddWithValue("@role", user.Role);
            cmd1.Parameters.AddWithValue("@name", user.FullName);
            // Sử dụng user.Dob và user.Gender từ DTO đã sửa ở bước trước
            cmd1.Parameters.AddWithValue("@dob", (object)user.Dob ?? DBNull.Value);
            cmd1.Parameters.AddWithValue("@gender", (object)user.Gender ?? DBNull.Value);
            commands.Add(cmd1);

            // LỆNH 2: Thêm vào bảng con tương ứng để giữ liên kết UserId
            if (user.Role == "Patient")
            {
                // Bảng Patients giờ có thể để trống hoặc thêm các cột bệnh lý sau này
                string queryPat = "INSERT INTO Patients (UserId) VALUES (@uid)";
                SqlCommand cmd2 = new SqlCommand(queryPat);
                cmd2.Parameters.AddWithValue("@uid", 0); // DBHelper sẽ tự thay @uid bằng ID vừa tạo từ cmd1
                commands.Add(cmd2);
            }
            else if (user.Role == "Doctor")
            {
                // Bảng Doctors lưu UserId và chờ cập nhật CCHN, Price sau
                string queryDoc = "INSERT INTO Doctors (UserId, cchn, Price) VALUES (@uid, 'PENDING', '0')";
                SqlCommand cmd2 = new SqlCommand(queryDoc);
                cmd2.Parameters.AddWithValue("@uid", 0);
                commands.Add(cmd2);
            }

            // Gọi hàm thực thi Transaction (DBHelper cần hỗ trợ lấy ID từ lệnh trước chèn vào lệnh sau)
            return DBHelper.ExecuteTransaction(commands);
        }

        // 4. Các hàm bổ trợ chèn riêng lẻ (nếu không dùng Transaction)
        public int RegisterUserBasic(UserDTO user)
        {
            string query = @"INSERT INTO Users (phone_number, password, role, Status, FullName, Dob, Gender) 
                             VALUES (@phone, @pass, @role, N'Hoạt động', @name, @dob, @gender);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters = {
                new SqlParameter("@phone", user.PhoneNumber),
                new SqlParameter("@pass", user.Password),
                new SqlParameter("@role", user.Role),
                new SqlParameter("@name", user.FullName),
                new SqlParameter("@dob", (object)user.Dob ?? DBNull.Value),
                new SqlParameter("@gender", (object)user.Gender ?? DBNull.Value)
            };

            object result = DBHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool InsertPatientMinimal(int userId)
        {
            string query = "INSERT INTO Patients (UserId) VALUES (@uid)";
            SqlParameter[] parameters = { new SqlParameter("@uid", userId) };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }

        //public bool InsertDoctorMinimal(int userId)
        //{
        //    // CCHN và Price là NOT NULL nên cần truyền giá trị mặc định ban đầu
        //    // CCHN và Price là NOT NULL, nên phải truyền giá trị mặc định ban đầu
        //    string query = "INSERT INTO Doctors (UserId, cchn, Price) VALUES (@uid, N'Chưa cập nhật', '0')";
        //    //string query = "INSERT INTO Doctors (UserId, cchn, Price) VALUES (@uid, 'N/A', '0')";
        //    SqlParameter[] parameters = { new SqlParameter("@uid", userId) };
        //    return DBHelper.ExecuteNonQuery(query, parameters);
        //}

        public bool InsertDoctorMinimal(int userId)
        {
            // Chúng ta phải truyền cả SpecialtyId và LocationId (giả sử ID mặc định là 1)
            string query = @"INSERT INTO Doctors (UserId, SpecialtyId, LocationId, cchn, Price, experience_years, workplace, bio, SpecificAddress) 
                     VALUES (@uid, @sid, @lid, @cchn, @price, @ex, @wp, @bio, @addr)";

            SqlParameter[] parameters = {
        new SqlParameter("@uid", userId),
        new SqlParameter("@sid", 1), // ID chuyên khoa mặc định (vd: Đa khoa)
        new SqlParameter("@lid", 1), // ID khu vực mặc định
        new SqlParameter("@cchn", "PENDING"),
        new SqlParameter("@price", 0),
        new SqlParameter("@ex", 0),
        new SqlParameter("@wp", "Chưa cập nhật"),
        new SqlParameter("@bio", "Chưa có tiểu sử"),
        new SqlParameter("@addr", "Chưa có địa chỉ")
    };

            return DBHelper.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteUser(int userId)
        {
            // Lệnh xóa người dùng theo ID
            string query = "DELETE FROM Users WHERE UserId = @uid";

            SqlParameter[] parameters = {
            new SqlParameter("@uid", userId)
            };

            try
            {
                // Sử dụng hàm ExecuteNonQuery đã có trong DBHelper của bạn
                return DBHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần thiết
                System.Diagnostics.Debug.WriteLine("Lỗi khi xóa User rác: " + ex.Message);
                return false;
            }
        }
    }
}
