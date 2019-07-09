using API.RomanDate.Controllers.Base.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public override OkObjectResult Ok(object result)
        {
            return base.Ok(new OkResponse(result));
        }

        public BadRequestObjectResult BadRequest(string error)
        {
            return base.BadRequest(new BadRequestResponse(error));
        }
    }
}