using System;
using Own.Application.Interfaces.Authentication;

namespace Own.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string CreateToken(string userId, string userName)
        {
            return "123123123";
        }
    }
}