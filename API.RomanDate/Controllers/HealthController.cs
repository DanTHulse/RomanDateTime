using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<object> Get()
        {
            return this.Ok();
        }
    }
}
