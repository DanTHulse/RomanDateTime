namespace API.RomanDate.Controllers.Base.ApiResponses
{
    public class NotFoundResponse : ApiResponse
    {
        public string ErrorMessage { get; set; }

        public NotFoundResponse(string error)
            : base(404)
        {
            this.ErrorMessage = error;
        }
    }
}
