using Newtonsoft.Json;

namespace API.RomanDate.Controllers.ApiResponses
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = "")
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                204 => "Success, but no content",
                404 => "Resource not found",
                500 => "An unhandled error occurred",
                _ => ""
            };
        }
    }
}
