namespace UI_Tier
{
    public static class GlobalAccount
    {
        // Biến private để lưu tạm sau khi đăng nhập
        private static int _currentId = 0;
        private static string _currentRole = "";

        // Hàm để gán ID (Gọi lúc đăng nhập)
        public static void SetLoggedInAccount(int id, string role)
        {
            _currentId = id;
            _currentRole = role;
        }

        // Hàm để lấy ID bác sĩ/bệnh nhân hiện tại
        public static int GetCurrentId()
        {
            return _currentId;
        }

        // Hàm để lấy vai trò
        public static string GetRole()
        {
            return _currentRole;
        }

        // Hàm kiểm tra xem đã đăng nhập chưa
        public static bool IsLoggedIn()
        {
            return _currentId > 0;
        }
    }
}