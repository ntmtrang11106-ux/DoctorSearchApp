using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class DashboardBUS
    {
        private readonly DashboardDAL _dashboardDAL;

        public DashboardBUS()
        {
            _dashboardDAL = new DashboardDAL();
        }

        public Dictionary<string, (int current, double growth)> GetDashboardSummary(DateTime targetDate)
        {
            var current = _dashboardDAL.GetMonthStats(targetDate);
            var previous = _dashboardDAL.GetMonthStats(targetDate.AddMonths(-1));
            
            var result = new Dictionary<string, (int current, double growth)>();
            
            foreach (var key in current.Keys)
            {
                int currVal = current[key];
                int prevVal = previous.ContainsKey(key) ? previous[key] : 0;
                
                double growth = 0;
                if (prevVal > 0)
                {
                    growth = ((double)(currVal - prevVal) / prevVal) * 100;
                }
                else if (currVal > 0)
                {
                    growth = 100;
                }
                
                result[key] = (currVal, Math.Round(growth, 1));
            }
            
            return result;
        }

        public List<ReviewsDTO> GetRecentReviews(int count = 5)
        {
            return _dashboardDAL.GetRecentReviews(count);
        }

        public Dictionary<string, int> GetDepartmentStats()
        {
            return _dashboardDAL.GetDepartmentStats();
        }
        public Dictionary<int, int> GetYearlyAppointmentStats(int year)
        {
            return _dashboardDAL.GetYearlyAppointmentStats(year);
        }

        public (List<double> doctors, List<double> patients) GetYearlyUserGrowthStats(int year)
        {
            var docStats = _dashboardDAL.GetYearlyUserStats(year, "Doctor");
            var patStats = _dashboardDAL.GetYearlyUserStats(year, "Patient");

            var doctors = new List<double>();
            var patients = new List<double>();

            for (int m = 1; m <= 12; m++)
            {
                doctors.Add(docStats[m]);
                patients.Add(patStats[m]);
            }

            return (doctors, patients);
        }
    }
}
