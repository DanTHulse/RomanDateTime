using Newtonsoft.Json;

namespace API.RomanDate.Controllers.Base.ApiResponses
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = "")
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                204 => "Success, but no content",
                400 => "An error occured, check your request and send again",
                404 => "Resource not found",
                500 => "An unhandled error occurred, contact the developer",
                _ => ""
            };
        }
    }
}
