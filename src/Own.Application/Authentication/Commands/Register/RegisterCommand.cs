using MediatR;
using Own.Application.Authentication.Common;
using Own.Domain.OResult;

namespace Own.Application.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<OResult<AuthenticationResult>>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}