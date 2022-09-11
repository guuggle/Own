using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Own.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    public class TestController : ApiBaseController
    {
        [HttpGet]
        public string GetData2()
        {
            return "data from api v2";
        }
    }
}
