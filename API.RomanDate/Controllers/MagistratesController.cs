using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MagistratesController : BaseController
    {
        public MagistratesController(IMapper mapper)
            : base(mapper)
        {

        }

        // GET Magistrates for year (need to convert to AUC year)
        // GET Ruling Magistrates for year (need to convert to AUC year)
        // GET All Unique Magistrates [paged] (also return year in which they served in each office)
        // GET All Magistrates by Office [paged]

        // POST Magistrate data for year (need to convert to AUC year)

        // PUT Magistrate data for year (need to convert to AUC year)
    }
}
