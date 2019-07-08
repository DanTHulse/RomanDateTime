using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        public DataController()
        {

        }

        [HttpPost("consular/{year}")]
        public async Task<ActionResult> PostConsularData([FromRoute]int year, [FromBody]object data) => this.Ok();
    }
}
