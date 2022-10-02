using MediatR;
using Own.Application.Authentication.Common;
using Own.Domain.OResult;

namespace Own.Application.Authentication.Queries.Login
{
    public class LoginQuery : IRequest<OResult<AuthenticationResult>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}