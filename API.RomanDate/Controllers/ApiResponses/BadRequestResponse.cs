﻿using System.Collections.Generic;

namespace API.RomanDate.Controllers.ApiResponses
{
    public class BadRequestResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }

        public BadRequestResponse(string errorMessage)
            : base(400)
        {
            Errors = new string[] { errorMessage };
        }
    }
}
