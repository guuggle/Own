using System;
using System.Threading.Tasks;
using Own.Application.Common.Interfaces.Authentication;
using Own.Application.Common.Interfaces.Persistence;
using Own.Domain.Entites;
using Own.Domain.Errors;
using Own.Domain.OResult;

namespace Own.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(
            IJwtTokenGenerator tokenGenerator,
            IUserRepository userRepository)
        {
            this._jwtTokenGenerator = tokenGenerator;
            this._userRepository = userRepository;
        }
        public async Task<OResult<AuthenticationResult>> Login(string email, string password)
        {
            var a = Guid.NewGuid().ToString();
            // query user
            var user = await _userRepository.GetUserByEmail(email);
            if (user is null)
            {
                return Errors.User.UserNotExist;
            }

            if (user.Password != password)
            {
                return Errors.User.InvalidPassword;
            }

            // create token
            var token = _jwtTokenGenerator.CreateToken(user.Id, user.UserName);

            return new AuthenticationResult()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = email,
                Token = token
            };
        }

        public async Task<OResult<AuthenticationResult>> Register(string userName, string email, string password)
        {
            // validate the user doesn't exist
            if (await _userRepository.GetUserByEmail(email) != null)
            {
                return Errors.User.EmailIsTaken;
            }

            // create user
            var user = new SysUser
            {
                UserName = userName,
                Email = email,
                Password = password
            };

            await _userRepository.AddUser(user);

            // create jwt token
            var token = _jwtTokenGenerator.CreateToken(user.Id, user.UserName);

            return new AuthenticationResult()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = user.UserName,
                Email = email,
                Token = token
            };
        }
    }
}