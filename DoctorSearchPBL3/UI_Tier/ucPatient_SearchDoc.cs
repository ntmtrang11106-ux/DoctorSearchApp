//public List<DoctorDTO> SearchDoctors(string? keyword, List<string>? departmentNames, string? gender, string? sortType)
//{
//    // Dùng context cục bộ để đảm bảo an toàn dữ liệu và hiệu năng
//    using var context = new AppDbContext();

//    // 1. Khởi tạo truy vấn cơ bản với các điều kiện bắt buộc
//    var query = context.Doctors
//        .Include(d => d.User)
//        .Include(d => d.Department)
//        .Include(d => d.Reviews)
//        .Where(d => d.IsApproved && d.IsActive && !d.IsDeleted)
//        .AsQueryable();

//    // 2. Lọc theo TỪ KHÓA (Nâng cấp: Tìm trên nhiều trường)
//    if (!string.IsNullOrWhiteSpace(keyword))
//    {
//        string k = keyword.Trim().ToLower();
//        query = query.Where(d => d.User.FullName.ToLower().Contains(k)
//                              || d.Department.DepartmentName.ToLower().Contains(k)
//                              || d.Biography.ToLower().Contains(k));
//    }

//    // 3. Lọc theo GIỚI TÍNH
//    if (!string.IsNullOrWhiteSpace(gender) && gender != "Tất cả")
//        query = query.Where(d => d.User.Gender == gender);

//    // 4. Lọc theo KHOA (Department)
//    if (departmentNames != null && departmentNames.Any() && !departmentNames.Contains("Tất cả"))
//        query = query.Where(d => d.Department != null && departmentNames.Contains(d.Department.DepartmentName));

//    // Thực thi truy vấn và đưa về RAM để xử lý logic phức tạp (Client-side)
//    var result = query.ToList();

//    // 5. Tính toán Rating và Review (Logic nghiệp vụ)
//    foreach (var doctor in result)
//    {
//        var visibleReviews = doctor.Reviews?.Where(r => r.IsVisible && !r.IsDeleted).ToList() ?? new List<ReviewsDTO>();
//        doctor.TotalReviews = visibleReviews.Count;
//        doctor.AverageRating = visibleReviews.Any() ? Math.Round(visibleReviews.Average(r => r.Rating), 1) : 0;
//    }

//    // 6. Sắp xếp THÔNG MINH và tránh xung đột
//    return sortType switch
//    {
//        "Giá khám thấp đến cao" => result.OrderBy(d => d.ConsultationFee ?? decimal.MaxValue).ToList(),
//        "Giá khám cao đến thấp" => result.OrderByDescending(d => d.ConsultationFee ?? 0).ToList(),
//        "Năm kinh nghiệm cao đến thấp" => result.OrderByDescending(d => d.ExperienceYears ?? 0).ToList(),
//        "Rating cao đến thấp" => result.OrderByDescending(d => d.AverageRating).ToList(),

//        // MẶC ĐỊNH hoặc Sắp xếp theo ĐỘ LIÊN QUAN khi có keyword
//        _ => !string.IsNullOrWhiteSpace(keyword)
//             ? result.OrderByDescending(d => d.User.FullName.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
//                     .ThenByDescending(d => d.User.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
//                     .ToList()
//             : result.OrderByDescending(d => d.CreatedAt).ToList()
//    };
//}