using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Own.Application.Authentication.Common;
using Own.Application.Common.Interfaces.Authentication;
using Own.Application.Common.Interfaces.Persistence;
using Own.Domain.Errors;
using Own.Domain.OResult;

namespace Own.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, OResult<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<OResult<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            // query user
            var user = await _userRepository.GetUserByEmail(query.Email);
            if (user is null)
            {
                return Errors.User.UserNotExist;
            }

            if (user.Password != query.Password)
            {
                return Errors.User.InvalidPassword;
            }

            // create token
            var token = _jwtTokenGenerator.CreateToken(user.Id, user.UserName);

            return new AuthenticationResult()
            {
                User = user,
                Token = token
            };
        }
    }
}