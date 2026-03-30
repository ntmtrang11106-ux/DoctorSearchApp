using Microsoft.Data.SqlClient; // Dùng thư viện Microsoft

namespace DAL_Tier
{
    public class DbConnector
    {
        // Thay "Ten_Server_Cua_Nhan" bằng tên SQL Server của bạn (ví dụ: .\SQLEXPRESS)
        private string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DoctorSearchDB;Integrated Security=True;TrustServerCertificate=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }
    }
}