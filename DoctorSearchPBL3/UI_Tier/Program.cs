using DAL_Tier;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace UI_Tier
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var context = new AppDbContext();
            if (!TryInitializeDatabase(context, out var errorMessage))
            {
                MessageBox.Show(
                    errorMessage,
                    "Database Sync Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new frmGuest());
            //Application.Run(new frmAdmin());
        }

        private static bool TryInitializeDatabase(AppDbContext context, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                var databaseExists = DatabaseExists(context, out var databaseName, out var dataSource, out var builder);

                if (!databaseExists)
                {
                    EnsureEmptyDatabaseExists(builder, databaseName);
                }

                if (databaseExists && HasSchemaDriftBeforeMigration(builder, out var driftMessage))
                {
                    errorMessage = driftMessage;
                    return false;
                }

                DbSeeder.Seed(context, false);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = BuildDatabaseErrorMessage(ex, context);
                return false;
            }
        }

        private static bool DatabaseExists(
            AppDbContext context,
            out string databaseName,
            out string dataSource,
            out SqlConnectionStringBuilder builder)
        {
            builder = new SqlConnectionStringBuilder(AppDbContext.DefaultConnectionString);
            databaseName = builder.InitialCatalog;
            dataSource = builder.DataSource;

            var masterBuilder = new SqlConnectionStringBuilder(builder.ConnectionString)
            {
                InitialCatalog = "master"
            };

            using var connection = new SqlConnection(masterBuilder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(1) FROM sys.databases WHERE name = @dbName";
            command.Parameters.AddWithValue("@dbName", databaseName);

            var result = command.ExecuteScalar();
            return Convert.ToInt32(result) > 0;
        }

        private static void EnsureEmptyDatabaseExists(SqlConnectionStringBuilder builder, string databaseName)
        {
            var masterBuilder = new SqlConnectionStringBuilder(builder.ConnectionString)
            {
                InitialCatalog = "master"
            };

            using var connection = new SqlConnection(masterBuilder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                $"IF DB_ID(N'{databaseName}') IS NULL CREATE DATABASE [{databaseName}]";
            command.ExecuteNonQuery();
        }

        private static bool HasSchemaDriftBeforeMigration(SqlConnectionStringBuilder builder, out string message)
        {
            message = string.Empty;

            using var connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            bool hasDepartmentTable = TableExists(connection, "Department");
            bool hasMigrationHistory = TableExists(connection, "__EFMigrationsHistory");
            bool hasAppliedMigrations = hasMigrationHistory && HistoryHasRows(connection);

            if (hasDepartmentTable && !hasAppliedMigrations)
            {
                message =
                    "CSDL hiện tại đã có bảng nghiệp vụ như 'Department' nhưng không có lịch sử migration hợp lệ.\n\n" +
                    "Điều này cho thấy database local đang lệch với schema trong repo.\n\n" +
                    "Việc cần làm lúc này:\n" +
                    "1. Người phụ trách DB reset hoặc làm sạch DB local theo baseline hiện tại.\n" +
                    "2. Chạy lại migration/schema từ repo.\n" +
                    "3. Seed lại dữ liệu mẫu.\n\n" +
                    "Trong lúc DB chưa sạch, frontend và backend không nên tiếp tục test trên database này vì kết quả sẽ sai hoặc phát sinh NullReference.";
                return true;
            }

            return false;
        }

        private static bool TableExists(DbConnection connection, string tableName)
        {
            using var command = connection.CreateCommand();
            command.CommandText =
                "SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableName";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@tableName";
            parameter.Value = tableName;
            command.Parameters.Add(parameter);

            var result = command.ExecuteScalar();
            return Convert.ToInt32(result) > 0;
        }

        private static bool HistoryHasRows(DbConnection connection)
        {
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(1) FROM [__EFMigrationsHistory]";
            var result = command.ExecuteScalar();
            return Convert.ToInt32(result) > 0;
        }

        private static string BuildDatabaseErrorMessage(Exception ex, AppDbContext context)
        {
            var root = ex;
            while (root.InnerException != null)
            {
                root = root.InnerException;
            }

            var builder = new SqlConnectionStringBuilder(AppDbContext.DefaultConnectionString);
            var databaseName = builder.InitialCatalog;
            var dataSource = builder.DataSource;
            var sqlMessage = root.Message;

            if (sqlMessage.Contains("already an object named 'Department'", StringComparison.OrdinalIgnoreCase))
            {
                return
                    "Lỗi khởi tạo CSDL: bảng 'Department' đã tồn tại nhưng migration hiện tại vẫn đang cố tạo lại.\n\n" +
                    $"Database: {databaseName}\n" +
                    $"Data Source: {dataSource}\n\n" +
                    "Đây là dấu hiệu DB local không còn đồng bộ với schema trong repo.\n\n" +
                    "Hướng xử lý dành cho người phụ trách DB:\n" +
                    "1. Kiểm tra DB local có phải DB cũ/DB tạo thủ công hay không.\n" +
                    "2. Reset hoặc làm sạch DB local theo baseline migration hiện tại.\n" +
                    "3. Chạy lại migration và seed dữ liệu mẫu.\n\n" +
                    "Trong thời gian đó, frontend và backend nên tạm dừng test trên DB này để tránh lỗi dây chuyền.\n\n" +
                    "Chi tiết SQL:\n" + sqlMessage;
            }

            if (sqlMessage.Contains("CREATE DATABASE permission denied", StringComparison.OrdinalIgnoreCase))
            {
                return
                    "Khởi tạo CSDL thất bại vì tài khoản hiện tại không có quyền tạo database mới trên SQL Server.\n\n" +
                    $"Database: {databaseName}\n" +
                    $"Data Source: {dataSource}\n\n" +
                    "Bạn có thể xử lý theo một trong hai cách:\n" +
                    "1. Tự tạo thủ công database rỗng đúng tên 'DoctorSearchDB_CodeFirst', rồi chạy lại app để migration tạo bảng.\n" +
                    "2. Dùng tài khoản SQL Server/Windows có quyền tạo database.\n\n" +
                    "Chi tiết SQL:\n" + sqlMessage;
            }

            if (sqlMessage.Contains($"Cannot open database \"{databaseName}\"", StringComparison.OrdinalIgnoreCase))
            {
                return
                    "Khởi tạo CSDL thất bại vì ứng dụng chưa mở được database đích.\n\n" +
                    $"Database: {databaseName}\n" +
                    $"Data Source: {dataSource}\n\n" +
                    "Nếu bạn vừa xóa DB cũ, khả năng cao tài khoản hiện tại chưa có quyền tạo DB mới.\n" +
                    "Hãy thử tạo thủ công một database rỗng đúng tên rồi chạy lại app.\n\n" +
                    "Chi tiết SQL:\n" + sqlMessage;
            }

            return
                "Khởi tạo CSDL thất bại.\n\n" +
                $"Database: {databaseName}\n" +
                $"Data Source: {dataSource}\n\n" +
                "Chi tiết lỗi:\n" + sqlMessage;
        }
    }
}
