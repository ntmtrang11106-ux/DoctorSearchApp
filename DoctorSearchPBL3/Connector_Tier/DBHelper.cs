using Microsoft.Data.SqlClient; // Dùng thư viện Microsoft
using System.Data;

namespace DAL_Tier
{
    public class DBHelper
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB;Integrated Security=True;TrustServerCertificate=True";

        // Hàm lấy dữ liệu (Dùng cho SELECT)
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

        // Hàm thực thi lệnh (Dùng cho INSERT, UPDATE, DELETE)
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
    }
}