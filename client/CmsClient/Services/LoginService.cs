using CmsClient.Models;
using System;
using System.Threading.Tasks;

namespace CmsClient.Services
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException(string message) : base(message)
        {
        }
    }

    public class LoginService
    {
        public Task<LoginCredential> Login(string userId, string password)
        {
            return Task.FromResult(LoginCredential.Create(userId, password));
        }

        public Task<LoginCredential> ValidateLogin(string userId, string passwordHash)
        {
            return Task.FromResult(new LoginCredential(userId, passwordHash));
        }
    }
}
