using System.Security.Claims;
using System;
using Own.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace Own.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string CreateToken(string userId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}