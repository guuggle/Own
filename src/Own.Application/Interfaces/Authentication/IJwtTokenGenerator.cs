using System;
namespace Own.Application.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(string userId, string userName);
    }
}