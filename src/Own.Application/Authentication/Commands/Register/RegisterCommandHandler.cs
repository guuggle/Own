using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Own.Application.Authentication.Common;
using Own.Application.Common.Interfaces.Authentication;
using Own.Application.Common.Interfaces.Persistence;
using Own.Domain.Entites;
using Own.Domain.Errors;
using Own.Domain.OResult;

namespace Own.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, OResult<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<OResult<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            // validate the user doesn't exist
            if (await _userRepository.GetUserByEmail(command.Email) != null)
            {
                return Errors.User.EmailIsTaken;
            }

            // create user
            var user = new SysUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = command.UserName,
                Email = command.Email,
                Password = command.Password
            };

            await _userRepository.AddUser(user);

            // create jwt token
            var token = _jwtTokenGenerator.CreateToken(user.Id, user.UserName);

            return new AuthenticationResult()
            {
                User = user,
                Token = token
            };
        }
    }
}