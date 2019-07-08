using System.Linq;
using API.RomanDate.Controllers.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using RomanDate;
using RomanDate.Enums;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/numerals")]
    public class NumeralsController : ControllerBase
    {
        public NumeralsController()
        {

        }

        /// <summary>
        /// Converts to Roman Numerals the number passed up
        /// </summary>
        /// <param name="number">The number to convert to Roman Numerals</param>
        /// <param name="numeralStyle">The numeral style to use when converting to numerals</param>
        /// <returns>The Roman Numerals for the number passed up</returns>
        [HttpGet("to/{int:number}")]
        public ActionResult<ApiResponse> GetRomanNumeralsForNumber([FromRoute]int number, [FromQuery]NumeralStyles numeralStyle = NumeralStyles.Subtractive)
        {
            if (number < 1 || number > 9999)
                return this.BadRequest(new BadRequestResponse("Number provided must be between 1-9999"));

            return this.Ok(new OkResponse(RomanNumerals.ToRomanNumerals(number, numeralStyle)));
        }

        /// <summary>
        /// Converts from Roman Numerals to a number
        /// </summary>
        /// <param name="numerals">The Roman Numerals to convert to a number</param>
        /// <returns>The number represented by the Roman Numerals</returns>
        [HttpGet("from/{string:numerals}")]
        public ActionResult<ApiResponse> GetNumberFromRomanNumerals([FromRoute]string numerals)
        {
            if (string.IsNullOrEmpty(numerals))
                return this.BadRequest(new BadRequestResponse("Must not be an empty string"));

            if (!numerals.All(a => "IVXCDLM".Contains(a)))
                return this.BadRequest(new BadRequestResponse("Value contains non-Numeral characters, only I,V,X,L,C,D, and M"));

            return this.Ok(new OkResponse(RomanNumerals.ToInt(numerals)));
        }
    }
}
