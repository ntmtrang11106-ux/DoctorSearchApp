using DTO_Tier;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace DAL_Tier
{
    public class DoctorDAL
    {
        public List<DoctorDTO> GetAllDoctors()
        {
            List<DoctorDTO> list = new List<DoctorDTO>();
            // Truy vấn bám sát tên bảng và cột trong file Word của bạn
            string query = @"
            SELECT d.Id, d.UserId, d.CertificateImage, d.ClinicAddress, d.ClinicName, 
                   d.Experience_Years, d.Bio, d.Price, d.WorkingTime, 
                   d.LocationId, d.SpecialtyId, d.IsApproved
            FROM Doctor d";

            DataTable dt = DBHelper.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DoctorDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    CertificateImage = row["CertificateImage"]?.ToString(),
                    ClinicAddress = row["ClinicAddress"]?.ToString(),
                    ClinicName = row["ClinicName"]?.ToString(),
                    Experience_Years = row["Experience_Years"] != DBNull.Value ? Convert.ToInt32(row["Experience_Years"]) : 0,
                    Bio = row["Bio"]?.ToString(),
                    Price = row["Price"] != DBNull.Value ? Convert.ToDecimal(row["Price"]) : 0,
                    WorkingTime = row["WorkingTime"]?.ToString(),
                    LocationId = row["LocationId"] != DBNull.Value ? Convert.ToInt32(row["LocationId"]) : (int?)null,
                    SpecialtyId = row["SpecialtyId"] != DBNull.Value ? Convert.ToInt32(row["SpecialtyId"]) : (int?)null,
                    IsApproved = row["IsApproved"] != DBNull.Value && Convert.ToBoolean(row["IsApproved"])
                });
            }
            return list;
        }

        public bool UpdateDoctor(DoctorDTO doctor)
        {
            // Cập nhật đúng các cột theo file Word
            string query = @"UPDATE Doctor SET 
                            ClinicAddress = @addr, 
                            ClinicName = @name,
                            Experience_Years = @exp, 
                            Price = @price 
                            WHERE Id = @id";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@addr", (object)doctor.ClinicAddress ?? DBNull.Value),
                new SqlParameter("@name", (object)doctor.ClinicName ?? DBNull.Value),
                new SqlParameter("@exp", (object)doctor.Experience_Years ?? DBNull.Value),
                new SqlParameter("@price", (object)doctor.Price ?? DBNull.Value),
                new SqlParameter("@id", doctor.Id)
            };
            return DBHelper.ExecuteNonQuery(query, parameters);
        }
    }
}