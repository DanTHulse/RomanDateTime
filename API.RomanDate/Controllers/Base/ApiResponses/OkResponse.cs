namespace API.RomanDate.Controllers.Base.ApiResponses
{
    public class OkResponse : ApiResponse
    {
        public object Result { get; }

        public OkResponse(object result)
            : base(200)
        {
            Result = result;
        }

        public OkResponse()
            : base(200)
        {
            Result = new { };
        }
    }
}
