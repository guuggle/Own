using System;
using Own.Domain.Errors;
using Own.Domain.OResult;

namespace Own.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public OResult<AuthenticationResult> Login(string email, string password)
        {
            return new AuthenticationResult()
            {
                Id = Guid.NewGuid(),
                FirstName = "firstName",
                LastName = "lastName",
                Email = email,
                Token = "token"
            };
        }

        public OResult<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            throw new ArgumentOutOfRangeException("out of range!~!!!!");
            // return Errors.User.EmailIsTaken;

            // return new AuthenticationResult()
            // {
            //     Id = Guid.NewGuid(),
            //     FirstName = firstName,
            //     LastName = lastName,
            //     Email = email,
            //     Token = "token"
            // };
        }
    }
}