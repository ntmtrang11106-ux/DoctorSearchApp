using DAL_Tier;
using DTO_Tier;
using static Microsoft.Data.SqlClient.Internal.SqlClientEventSource;

namespace BUS_Tier
{
    public class DoctorBUS
    {
        private readonly DoctorDAL doctorDAL = new DoctorDAL();

        /// <summary>
        /// Lấy toàn bộ danh sách bác sĩ đã được lọc (Active, Approved, Not Deleted)
        /// </summary>
        //public List<DoctorDTO> GetListDoctors()
        //{
        //    return doctorDAL.GetAllDoctors();
        //}

        public List<DoctorDTO> GetListDoctors()
        {
            try
            {
                // 1. Gọi DAL để lấy dữ liệu
                var list = doctorDAL.GetAllDoctors();

                // 2. Kiểm tra nếu danh sách trả về bị null
                if (list == null)
                {
                    // Trả về danh sách rỗng thay vì null để UI không bị lỗi Crash (NullReferenceException)
                    return new List<DoctorDTO>();
                }

                // 3. Bạn có thể thực hiện kiểm tra thêm tại đây 
                // Ví dụ: Chỉ trả về bác sĩ nếu có thông tin User đi kèm (đề phòng dữ liệu rác)
                var validatedList = list.Where(d => d.User != null).ToList();

                return validatedList;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu có hệ thống log) và trả về danh sách rỗng để bảo vệ ứng dụng
                // Console.WriteLine(ex.Message);
                return new List<DoctorDTO>();
            }
        }

        /////////////////////////////////////////////////



            /// <summary>
            /// Tìm kiếm bác sĩ nâng cao: lọc theo tên, chuyên khoa, giới tính và sắp xếp.
            /// Sử dụng trực tiếp hàm SearchDoctors của DAL để tối ưu hiệu năng (Filter tại Database).
            /// </summary>
       public List<DoctorDTO> SearchDoctors(string? keyword, List<string>? departments, string? gender, string? sortType)
       {
            // Tầng BUS có thể xử lý chuẩn hóa dữ liệu đầu vào trước khi gọi DAL
            string? normalizedKeyword = string.IsNullOrWhiteSpace(keyword) ? null : keyword.Trim();
            
            return doctorDAL.SearchDoctors(normalizedKeyword, departments, gender, sortType);
       }

        //public List<DoctorDTO> SearchDoctorsByName(string name)
        //{
        //    return doctorDAL.GetAllDoctors()
        //        .Where(d => d.User != null && d.User.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
        //        .ToList();
        //}

        /// <summary>
        /// Cập nhật thông tin bác sĩ với các ràng buộc nghiệp vụ (Validation)
        /// </summary>
        public string UpdateDoctorInfo(DoctorDTO doctor)
        {
            if ((doctor.ExperienceYears ?? 0) < 0)
            {
                return "Số năm kinh nghiệm không hợp lệ!";
            }

            if (doctor.User == null || string.IsNullOrWhiteSpace(doctor.User.FullName))
            {
                return "Tên bác sĩ không được để trống!";
            }

            bool result = doctorDAL.UpdateDoctor(doctor);
            return result ? "Cập nhật thành công!" : "Cập nhật thất bại, vui lòng kiểm tra lại!";
        }

        /// <summary>
        /// Lấy DoctorId dựa trên UserId của tài khoản đang đăng nhập
        /// </summary>
        public void CalculateDoctorStats(DoctorDTO doctor)
        {
            if (doctor.Reviews == null || !doctor.Reviews.Any())
            {
                doctor.TotalReviews = 0;
                doctor.AverageRating = 0;
                return;
            }

            var validReviews = doctor.Reviews.Where(r => r.IsVisible && !r.IsDeleted).ToList();
            doctor.TotalReviews = validReviews.Count;
            doctor.AverageRating = validReviews.Any() ? Math.Round(validReviews.Average(r => r.Rating), 1) : 0;
        }
    }
}