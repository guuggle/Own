using System;
namespace Own.Application.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(Guid userId, string firstName, string lastName);
    }
}