namespace API.RomanDate.Controllers.Base.ApiResponses
{
    public class BadRequestResponse : ApiResponse
    {
        public string ErrorMessage { get; }

        public BadRequestResponse(string error)
            : base(400)
        {
            this.ErrorMessage = error;
        }
    }
}
