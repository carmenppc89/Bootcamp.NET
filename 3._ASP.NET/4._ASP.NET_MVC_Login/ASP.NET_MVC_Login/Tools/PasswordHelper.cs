using System.Security.Cryptography;
using System.Text;

namespace ASP.NET_MVC_Login.Tools
{
    public class PasswordHelper
    {
        public static void CreatePasswordHash(string pwd, out byte[] hash, out byte[] salt)
        {

            using (var hmac = new HMACSHA512())
            {

                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pwd));

            }

        }

        public static bool VerifyPasswordHash(string pwd, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                return computedHash.SequenceEqual(storedHash);

            }
        }
    }
}
