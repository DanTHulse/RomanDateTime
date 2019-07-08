using API.RomanDate.Controllers.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        public HealthController()
        {
        }

        [HttpGet("")]
        public ActionResult<object> Ping() => this.Ok(new OkResponse("All is okay!"));
    }
}
