using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL_Tier
{
    /// <summary>
    /// Helper cho raw SQL / Stored Procedure.
    /// Chỉ dùng khi EF Core không đáp ứng được (SP phức tạp, bulk operation...).
    /// Với các thao tác CRUD thông thường, hãy dùng AppDbContext trực tiếp.
    /// </summary>
    public class DBHelper
    {
        private readonly string _connectionString;

        // Inject connection string qua constructor — không hardcode
        public DBHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found in configuration.");
        }

        // Static factory nếu cần dùng nơi không có DI (ví dụ: legacy WinForms code)
        public static DBHelper Create(string connectionString) => new(connectionString);
        private DBHelper(string connectionString) { _connectionString = connectionString; }

        // 1. Lấy dữ liệu dạng DataTable (SELECT)
        public DataTable GetDataTable(string query, SqlParameter[]? parameters = null)
        {
            var dt = new DataTable();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            try { conn.Open(); new SqlDataAdapter(cmd).Fill(dt); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Lỗi GetDataTable: " + ex.Message); }
            return dt;
        }

        // 2. Thực thi lệnh không trả dữ liệu (INSERT / UPDATE / DELETE)
        public bool ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            try { conn.Open(); return cmd.ExecuteNonQuery() > 0; }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Lỗi ExecuteNonQuery: " + ex.Message); return false; }
        }

        // 3. Lấy một giá trị duy nhất (SELECT COUNT / SCOPE_IDENTITY...)
        public object? ExecuteScalar(string query, SqlParameter[]? parameters = null)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            try { conn.Open(); return cmd.ExecuteScalar(); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Lỗi ExecuteScalar: " + ex.Message); return null; }
        }

        // 4. Thực thi nhiều lệnh trong một Transaction
        // Nếu một lệnh INSERT cần trả về ID mới (SCOPE_IDENTITY),
        // đặt tên param nhận ID là @uid trong các lệnh phía sau.
        public bool ExecuteTransaction(List<SqlCommand> commands)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var transaction = conn.BeginTransaction();
            try
            {
                foreach (var cmd in commands)
                {
                    cmd.Connection = conn;
                    cmd.Transaction = transaction;
                    if (cmd.CommandText.Contains("SCOPE_IDENTITY()"))
                    {
                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        foreach (var nextCmd in commands)
                            if (nextCmd.Parameters.Contains("@uid"))
                                nextCmd.Parameters["@uid"].Value = newId;
                    }
                    else cmd.ExecuteNonQuery();
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