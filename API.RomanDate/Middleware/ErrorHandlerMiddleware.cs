using System;
using System.Net;
using System.Threading.Tasks;
using API.RomanDate.Controllers.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.RomanDate.Middleware
{
    /// <summary>
    /// Middleware for handling errors and exceptions in the API
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        /// <summary>
        /// The next request
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next request.</param>
        /// <param name="logger">The logger</param>
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            this.next = next;
            this._logger = logger;
        }

        /// <summary>
        /// Invokes the middleware for the context.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <returns>An instenace of <see cref="Task"/>.</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                this._logger.LogCritical(ex.Message, ex);
            }
        }

        /// <summary>
        /// Handles exceptions thrown when processing requests.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="exception">The exception thrown when processing the request.</param>
        /// <returns>An instance of <see cref="Task"/>.</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = JsonConvert.SerializeObject(new InternalServerErrorResponse(exception));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
