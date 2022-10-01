using System;
using Microsoft.AspNetCore.Mvc;

namespace Own.WebApi.Controllers.v1
{
    public class TVController : ApiBaseController
    {
        [HttpGet("tv")]
        public IActionResult ListTVs()
        {
            return Ok(Array.Empty<string>());
        }
    }
}