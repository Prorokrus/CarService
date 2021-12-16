using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Helpers
{
    public static class HashHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder passwordHash = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    passwordHash.Append(bytes[i].ToString("x2"));
                }

                return passwordHash.ToString();
            }
        }
    }
}
