using System;
using API.RomanDate.Helpers;

namespace API.RomanDate.Controllers.ApiResponses
{
    public class InternalServerErrorResponse : ApiResponse
    {
        public string ExceptionMessage { get; set; }

        public InternalServerErrorResponse(Exception _exception)
            : base(500)
        {
            this.ExceptionMessage = _exception.GetInnermostException().Message;
        }
    }
}
