using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration; // Nếu bạn dùng web.config hoặc app.config

namespace DAL_Tier
{
    public class DBHelper
    {
        // Cập nhật tên Database thành DoctorSearchDB_CodeFirst cho đồng bộ với AppDbContext
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB_CodeFirst;Integrated Security=True;TrustServerCertificate=True";

        public static DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try { conn.Open(); da.Fill(dt); }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Lỗi GetDataTable: " + ex.Message); }
            }
            return dt;
        }

        public static bool ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                try { conn.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Lỗi ExecuteNonQuery: " + ex.Message); return false; }
            }
        }
    }
}