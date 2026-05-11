using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DTO_Tier;

namespace DAL_Tier
{
    public class DashboardDAL
    {
        public Dictionary<string, int> GetMonthStats(DateTime targetDate)
        {
            using (var context = new AppDbContext())
            {
                var startOfMonth = new DateTime(targetDate.Year, targetDate.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1);
                
                return new Dictionary<string, int>
                {
                    // Activity count specifically FOR THAT month
                    { "Patients", context.Patients.Count(p => !p.IsDeleted && p.CreatedAt >= startOfMonth && p.CreatedAt < endOfMonth) },
                    { "Doctors", context.Doctors.Count(d => !d.IsDeleted && d.CreatedAt >= startOfMonth && d.CreatedAt < endOfMonth) },
                    { "Reviews", context.Reviews.Count(r => !r.IsDeleted && r.CreatedAt >= startOfMonth && r.CreatedAt < endOfMonth) },
                    { "Appointments", context.Appointments.Count(a => a.CreatedAt >= startOfMonth && a.CreatedAt < endOfMonth) }
                };
            }
        }

        public List<ReviewsDTO> GetRecentReviews(int count = 5)
        {
            using (var context = new AppDbContext())
            {
                return context.Reviews
                    .Include(r => r.Patient).ThenInclude(p => p.User)
                    .Include(r => r.Doctor).ThenInclude(d => d.User)
                    .Where(r => !r.IsDeleted && r.IsVisible)
                    .OrderByDescending(r => r.CreatedAt)
                    .Take(count)
                    .ToList();
            }
        }

        public Dictionary<string, int> GetDepartmentStats()
        {
            using (var context = new AppDbContext())
            {
                var result = context.Departments
                    .Where(d => !d.IsDeleted && d.IsActive)
                    .Select(d => new
                    {
                        Name = d.DepartmentName,
                        Count = context.Doctors.Count(doc => doc.DepartmentId == d.Id && !doc.IsDeleted)
                    })
                    .ToList();

                return result
                    .OrderByDescending(x => x.Count)
                    .ToDictionary(x => x.Name, x => x.Count);
            }
        }
        public Dictionary<int, int> GetYearlyAppointmentStats(int year)
        {
            using (var context = new AppDbContext())
            {
                // Truy vấn SQL: Nhóm theo tháng và đếm số lịch hẹn trong năm chỉ định
                var stats = context.Appointments
                    .Where(a => a.CreatedAt.Year == year)
                    .GroupBy(a => a.CreatedAt.Month)
                    .Select(g => new { Month = g.Key, Count = g.Count() })
                    .ToDictionary(x => x.Month, x => x.Count);

                // Đảm bảo trả về đủ 12 tháng (tháng nào không có dữ liệu thì bằng 0)
                var result = new Dictionary<int, int>();
                for (int m = 1; m <= 12; m++)
                {
                    result[m] = stats.ContainsKey(m) ? stats[m] : 0;
                }
                return result;
            }
        }
        public Dictionary<int, int> GetYearlyUserStats(int year, string role)
        {
            using (var context = new AppDbContext())
            {
                var stats = context.Users
                    .Where(u => u.CreatedAt.Year == year && u.Role == role && !u.IsDeleted)
                    .GroupBy(u => u.CreatedAt.Month)
                    .Select(g => new { Month = g.Key, Count = g.Count() })
                    .ToDictionary(x => x.Month, x => x.Count);

                var result = new Dictionary<int, int>();
                for (int m = 1; m <= 12; m++)
                {
                    result[m] = stats.ContainsKey(m) ? stats[m] : 0;
                }
                return result;
            }
        }
    }
}
