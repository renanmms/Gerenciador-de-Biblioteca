using System;

namespace LibraryManager.Infrastructure.AuthServices
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}