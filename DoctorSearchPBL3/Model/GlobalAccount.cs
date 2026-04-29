namespace DTO_Tier
{
    public static class GlobalAccount
    {
        private static int _userId = 0;
        private static int _profileId = 0;
        private static string _role = "";
        private static string _fullName = "";

        public static void SetLoggedInAccount(int userId, int profileId, string role, string fullName)
        {
            _userId = userId;
            _profileId = profileId;
            _role = role;
            _fullName = fullName;
        }

        // Các hàm lấy dữ liệu mới
        public static int GetUserId() => _userId;
        public static int GetProfileId() => _profileId;
        public static string GetRole() => _role;
        public static string GetFullName() => _fullName;

        // Nếu bạn muốn Code cũ không bị lỗi ngay lập tức, 
        // bạn có thể thêm hàm "tạm thời" này để nó trỏ về ProfileId
        public static int GetCurrentId() => _profileId;

        public static void Logout()
        {
            _userId = 0; _profileId = 0; _role = ""; _fullName = "";
        }
    }
}