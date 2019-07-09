using System;
using API.RomanDate.Controllers.Base.ApiResponses;
using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public new OkObjectResult Ok() => base.Ok(new OkResponse());

        public override OkObjectResult Ok(object result) => base.Ok(new OkResponse(result));

        public OkObjectResult Ok<T>(object result)
        {
            var mappedResult = this._mapper.Map<T>(result);

            if (mappedResult == null)
                throw new ArgumentNullException("Results were returned but an error occurred when mapping to view model");

            return base.Ok(new OkResponse(mappedResult));
        }

        public BadRequestObjectResult BadRequest(string error) => base.BadRequest(new BadRequestResponse(error));
    }
}