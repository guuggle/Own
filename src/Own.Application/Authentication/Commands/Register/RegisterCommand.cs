using MediatR;
using Own.Application.Authentication.Common;
using Own.Domain.OResult;

namespace Own.Application.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<OResult<AuthenticationResult>>
    {
        public RegisterCommand(string userName, string email, string password)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}