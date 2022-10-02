using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Own.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Own.Application.Authentication.Commands.Register;
using Own.Application.Authentication.Common;
using Own.Application.Authentication.Queries.Login;

namespace Own.WebApi.Controllers.v1
{
    [AllowAnonymous]
    [Route("auth")]
    public class AuthenticationController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authResult = await _mediator.Send(new RegisterCommand(request.UserName,
                request.Email,
                request.Password));

            return authResult.Match(
                authResult => Ok(MapResults(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authResult = await _mediator.Send(
                new LoginQuery(
                    request.Email,
                    request.Password));

            return authResult.Match(
                authResult => Ok(MapResults(authResult)),
                errors => Problem(errors)
            );
        }


        private static AuthenticationResponse MapResults(AuthenticationResult result)
        {
            return new AuthenticationResponse()
            {
                Id = result.User.Id,
                UserName = result.User.UserName,
                Email = result.User.Email,
                Token = result.Token
            };
        }
    }
}
