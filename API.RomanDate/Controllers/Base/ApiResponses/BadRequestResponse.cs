using System.Collections.Generic;

namespace API.RomanDate.Controllers.Base.ApiResponses
{
    public class BadRequestResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }

        public BadRequestResponse(string errorMessage)
            : base(400)
        {
            this.Errors = new string[] { errorMessage };
        }
    }
}
