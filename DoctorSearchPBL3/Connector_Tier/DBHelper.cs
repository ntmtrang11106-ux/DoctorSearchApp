using Microsoft.Data.SqlClient; // Dùng thư viện Microsoft
using System.Data;

namespace DAL_Tier
{
    public class DBHelper
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB;Integrated Security=True;TrustServerCertificate=True";

        // 1. Hàm lấy dữ liệu (Dùng cho SELECT)
        public static DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    conn.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi DBHelper GetDataTable: " + ex.Message);
                }
            }
            return dt;
        }

        // 2. Hàm thực thi lệnh (Dùng cho INSERT, UPDATE, DELETE thông thường)
        // Trả về true nếu có ít nhất 1 dòng bị ảnh hưởng
        public static bool ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rows = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi DBHelper ExecuteNonQuery: " + ex.Message);
                    return false;
                }
            }
            return rows > 0;
        }

        // 3. Hàm lấy một giá trị duy nhất (Dùng cho SELECT SCOPE_IDENTITY())
        // Trả về giá trị đầu tiên của dòng đầu tiên trong kết quả truy vấn
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    try
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi DBHelper ExecuteScalar: " + ex.Message);
                        return null;
                    }
                }
            }
        }

        // 4. Hàm thực thi nhiều lệnh trong một Transaction
        public static bool ExecuteTransaction(List<SqlCommand> commands)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    foreach (var cmd in commands)
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = transaction;

                        // Nếu lệnh là INSERT và cần lấy ID (như bảng Users)
                        if (cmd.CommandText.Contains("SCOPE_IDENTITY()"))
                        {
                            object result = cmd.ExecuteScalar();
                            int newId = Convert.ToInt32(result);

                            // Cập nhật UserId cho các lệnh phía sau trong danh sách
                            foreach (var nextCmd in commands)
                            {
                                if (nextCmd.Parameters.Contains("@uid"))
                                {
                                    nextCmd.Parameters["@uid"].Value = newId;
                                }
                            }
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Debug.WriteLine("Lỗi Transaction: " + ex.Message);
                    return false;
                }
            }
        }
    }
}