using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Own.Application.Services.Authentication;
using Own.Contracts.Authentication;
using Own.Domain.OResult;

namespace Own.WebApi.Controllers.v1
{
    public class AuthenticationController : ApiBaseController
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            this._service = service;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _service.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapResults(authResult)),
                errors => Problem(errors)
            );
        }

        private static AuthenticationResponse MapResults(AuthenticationResult result)
        {
            return new AuthenticationResponse()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                Token = result.Token
            };
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _service.Login(
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapResults(authResult)),
                errors => Problem(errors)
            );
        }

    }
}
