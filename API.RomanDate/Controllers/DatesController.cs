using API.RomanDate.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatesController : BaseController
    {
        public DatesController()
        {

        }

        [HttpGet("current")]
        public ActionResult<object> Current()
        {
            return this.Ok();
        }
    }
}
