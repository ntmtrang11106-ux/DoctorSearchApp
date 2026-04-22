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
            //        DAL_Tier.DbSeeder.Seed(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        // Đây là đoạn code "thông thái" để lấy lỗi thật sự từ SQL
            //        var inner = ex.InnerException;
            //        while (inner?.InnerException != null) inner = inner.InnerException;

            //        MessageBox.Show("LỖI SQL THẬT SỰ ĐÂY NÈ TRANG:\n" + (inner?.Message ?? ex.Message));
            //    }
            //}
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Application.Run(new frmGuest());

            // test form
            //Application.Run(new frmLogin());
            //Application.Run(new frmRegister());
            //Application.Run(new frmPatient());
            Application.Run(new frmDoctor());
        }

    }
}