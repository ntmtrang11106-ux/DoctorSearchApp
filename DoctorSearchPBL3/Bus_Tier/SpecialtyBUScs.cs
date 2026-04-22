using DAL_Tier;
using System.Data;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class SpecialtyBUS
    {
        // Khai báo DAL tương ứng
        private SpecialtyDAL _specialtyDAL = new SpecialtyDAL();

        /// <summary>
        /// Lấy danh sách tất cả chuyên khoa để đổ vào ComboBox
        /// </summary>
        /// <returns>DataTable chứa Id và SpecialtyName</returns>
        public DataTable GetListSpecialties()
        {
            // Gọi xuống DAL để truy vấn dữ liệu
            DataTable dt = _specialtyDAL.GetAllSpecialties();

            // Bạn có thể xử lý thêm logic ở đây nếu cần
            // Ví dụ: Kiểm tra nếu dt null thì trả về một DataTable trống để tránh lỗi UI
            if (dt == null)
            {
                return new DataTable();
            }

            return dt;
        }
    }
}