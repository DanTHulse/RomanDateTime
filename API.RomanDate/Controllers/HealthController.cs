using API.RomanDate.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : BaseController
    {
        public HealthController()
        {
        }

        [HttpGet("")]
        public ActionResult<object> Ping() => this.Ok("All is okay!");
    }
}
