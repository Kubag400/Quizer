using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Server.Helpers
{
    public class HttpMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpMiddleware> _logger;

        public HttpMiddleware(RequestDelegate next, ILogger<HttpMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            _logger.LogInformation("Works just fine!");
            await _next(context);

        }
    }
}
