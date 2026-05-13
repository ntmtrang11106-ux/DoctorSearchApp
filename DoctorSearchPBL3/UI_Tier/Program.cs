using DAL_Tier;
using Microsoft.EntityFrameworkCore;

namespace UI_Tier
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var context = new DAL_Tier.AppDbContext())
            //{
            //    // 1. LỆNH NÀY SẼ CHO TRANG BIẾT THẬT SỰ APP ĐANG CHẠY VÀO ĐÂU
            //    var connectionString = context.Database.GetDbConnection().ConnectionString;
            //    var dbLocation = context.Database.GetDbConnection().DataSource;

            //    // In ra cửa sổ Output để kiểm tra
            //    System.Diagnostics.Debug.WriteLine($"DB THỰC SỰ: {connectionString}");

            //    // Hiện thông báo để Trang nhìn thấy tận mắt
            //    MessageBox.Show($"App đang nối vào: {dbLocation}\nDatabase: {context.Database.GetDbConnection().Database}");

            //    try
            //    {
            //        // If you want to force re-seed, pass true. Be careful in production.
            //        DAL_Tier.DbSeeder.Seed(context, false);
            //    }
            //    catch (Exception ex)
            //    {
            //        // Đây là đoạn code "thông thái" để lấy lỗi thật sự từ SQL
            //        var inner = ex.InnerException;
            //        while (inner?.InnerException != null) inner = inner.InnerException;

            //        MessageBox.Show("LỖI SQL THẬT SỰ ĐÂY NÈ TRANG:\n" + (inner?.Message ?? ex.Message));
            //    }
            //// Diagnostic: show counts of key tables so we can confirm seeding
            //try
            //{
            //    int users = context.Users.Count();
            //    int doctors = context.Doctors.Count();
            //        int specs = context.Departments.Count();
            //        //int locs = context.Locations.Count();
            //    //int ds = context.DoctorSpecialties.Count();
            //    int arts = context.Contents.Count();

            //    MessageBox.Show($"Seed check:\nUsers: {users}\nDoctors: {doctors}\nSpecialties: {specs}\nArticles: {arts}");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi kiểm tra dữ liệu: " + ex.Message);
            //}
            //}

            using (var context = new DAL_Tier.AppDbContext())
            {
                try
                {
                    // Tự động cập nhật Database Schema và Seed dữ liệu (chỉ thêm nếu thiếu)
                    DAL_Tier.DbSeeder.Seed(context, false);
                }
                catch (Exception ex)
                {
                    var inner = ex.InnerException;
                    while (inner?.InnerException != null) inner = inner.InnerException;
                    MessageBox.Show("LỖI KHỞI TẠO CSDL:\n" + (inner?.Message ?? ex.Message), "Database Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmGuest());
        }
    }
}
