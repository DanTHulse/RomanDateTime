using System.Linq;
using API.RomanDate.Controllers.Base;
using API.RomanDate.Controllers.Base.ApiResponses;
using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RomanDate.Enums;
using RomanDate.Helpers.RomanNumerals;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumeralsController : BaseController
    {
        public NumeralsController(IMapper mapper)
            : base(mapper)
        {

        }

        /// <summary>
        /// Converts to Roman Numerals the number passed up
        /// </summary>
        /// <param name="number">The number to convert to Roman Numerals</param>
        /// <param name="numeralStyle">The numeral style to use when converting to numerals</param>
        /// <returns>The Roman Numerals for the number passed up</returns>
        [HttpGet("to/{number}")]
        public ActionResult<ApiResponse> ConvertToNumerals([FromRoute]int number, [FromQuery]NumeralStyles numeralStyle = NumeralStyles.Subtractive)
        {
            if (number < 1 || number > 9999)
                return this.BadRequest("Number provided must be between 1-9999");

            return this.Ok(RomanNumerals.ToRomanNumerals(number, numeralStyle));
        }

        /// <summary>
        /// Converts from Roman Numerals to a number
        /// </summary>
        /// <param name="numerals">The Roman Numerals to convert to a number</param>
        /// <returns>The number represented by the Roman Numerals</returns>
        [HttpGet("from/{numerals}")]
        public ActionResult<ApiResponse> ConvertFromNumerals([FromRoute]string numerals)
        {
            if (string.IsNullOrEmpty(numerals))
                return this.BadRequest("Must not be an empty string");

            if (!numerals.All(a => "IVXCDLM".Contains(a)))
                return this.BadRequest("Value contains non-Numeral characters, only I,V,X,L,C,D, and M");

            return this.Ok(RomanNumerals.ToInt(numerals));
        }
    }
}
