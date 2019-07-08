﻿namespace API.RomanDate.Controllers.ApiResponses
{
    public class OkResponse : ApiResponse
    {
        public object Result { get; }

        public OkResponse(object result)
            : base(200)
        {
            Result = result;
        }
    }
}
