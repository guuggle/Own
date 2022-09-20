using System;
namespace Own.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(string userId, string userName);
    }
}