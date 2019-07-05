using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("")]
        public void Get()
        {
            //return this.Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
