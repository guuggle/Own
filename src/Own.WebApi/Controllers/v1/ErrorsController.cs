using System.Data.SqlTypes;
using System.Net.Cache;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Own.Domain.OResult;

namespace Own.WebApi.Controllers.v1
{
    public class ErrorsController : ApiBaseController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            Console.WriteLine(exception?.Message);
            return Problem(OError.Unexpected());
        }
    }
}