namespace DAL_Tier
{
    public class PatientDAL
    {
        // Tạm thời trả về 0 hoặc xử lý đơn giản để BUS không lỗi
        public int GetPatientIdByUserId(int userId)
        {
            using (var db = new AppDbContext())
            {
                var patient = db.Patients.FirstOrDefault(p => p.UserId == userId);
                return patient != null ? patient.Id : 0;
            }
        }
    }
}