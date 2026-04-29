using System.Security.Cryptography;
using System.Text;

namespace DAL_Tier
{
    /// <summary>
    /// Dùng chung cho DbSeeder, LoginDAL và bất kỳ nơi nào cần hash password.
    /// Không duplicate logic hash ở nhiều chỗ.
    /// </summary>
    public static class PasswordHelper
    {
        public static string Hash(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();
        }

        public static bool Verify(string inputPassword, string storedHash)
        {
            return Hash(inputPassword) == storedHash;
        }
    }
}