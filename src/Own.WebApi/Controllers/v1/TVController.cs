using System;
using Microsoft.AspNetCore.Mvc;

namespace Own.WebApi.Controllers.v1
{
    [Route("tv")]
    public class TVController : ApiBaseController
    {
        [HttpGet("alltv")]
        public IActionResult ListTVs()
        {
            return Ok(Array.Empty<string>());
        }
    }
}