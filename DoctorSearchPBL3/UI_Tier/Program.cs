using DAL_Tier;

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
            using (var context = new AppDbContext())
            {
                DbSeeder.Seed(context);
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Application.Run(new frmGuest());

            // test form
            //Application.Run(new frmLogin());
            //Application.Run(new frmRegister());
            Application.Run(new frmGuest());
        }

    }
}
///