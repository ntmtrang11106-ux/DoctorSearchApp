using Microsoft.Data.SqlClient;
using DTO_Tier;
using System.Collections.Generic;
using System.Data;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        DbConnector db = new DbConnector();

        public List<DoctorDTO> GetAllDoctors()
        {
            List<DoctorDTO> list = new List<DoctorDTO>();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT d.Id, d.full_name, s.Name as SpecName, l.Name as LocName, d.experience_years " +
                             "FROM Doctors d " +
                             "JOIN Specialties s ON d.SpecialtyId = s.Id " +
                             "JOIN Locations l ON d.LocationId = l.Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DoctorDTO
                    {
                        Id = (int)dr["Id"],
                        FullName = dr["full_name"].ToString(),
                        SpecialtyName = dr["SpecName"].ToString(),
                        LocationName = dr["LocName"].ToString(),
                        ExperienceYears = (int)dr["experience_years"]
                    });
                }
            }
            return list;
        }
    }
}