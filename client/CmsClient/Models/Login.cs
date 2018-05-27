using System;

namespace CmsClient.Models
{
    public class LoginCredential
    {
        public string UserId { get; }
        public string PasswordHash { get; }

        public LoginCredential(string userId, string passwordHash)
        {
            UserId = userId;
            PasswordHash = passwordHash;
        }

        public static LoginCredential Create(string userId, string password)
        {
            return new LoginCredential(userId, Encode(password));
        }

        private static string Encode(string value)
        {
            return value;
        }
    }
}
