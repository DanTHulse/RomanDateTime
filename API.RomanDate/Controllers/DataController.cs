using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : BaseController
    {
        public DataController(IMapper mapper)
            : base(mapper)
        {

        }
    }
}
