using System.Security.Cryptography;
using System.Text;

namespace Project.AVIew.Logic
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var byted = Encoding.UTF8.GetBytes(password);
            var sha1 = SHA1CryptoServiceProvider.Create();
            var hashedBytes = sha1.ComputeHash(byted);
            return Encoding.UTF8.GetString(hashedBytes);
        }

        public static bool IsCorrectPassword(string userpassword, string password)
        {
            var passwordHash = HashPassword(password);
            return passwordHash == userpassword;
        }
    }
}
