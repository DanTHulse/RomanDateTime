﻿using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : BaseController
    {
        public HealthController(IMapper mapper)
            : base(mapper)
        {
        }

        [HttpGet("")]
        public ActionResult<object> Ping() => this.Ok("All is okay!");
    }
}