using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL_Tier
{
    public class SpecialtyDAL
    {
        public DataTable GetAllSpecialties()
        {
            // Câu lệnh SQL lấy dữ liệu từ bảng bạn đã chụp
            string query = "SELECT Id, SpecialtyName FROM Specialtie";

            // Sử dụng đúng hàm GetDataTable từ bộ DBHelper bạn vừa gửi
            return DBHelper.GetDataTable(query);
        }
    }
}