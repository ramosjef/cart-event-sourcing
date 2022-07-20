using System;
using System.Net;
using System.Threading.Tasks;
using Cart.Application.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cart.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                var result = new MessageError("500", ex);

                _logger.LogError(exception: ex, message: ex.Message, null);

                await httpContext.Response.WriteAsync(result.ToString());
            }
        }
    }
}
