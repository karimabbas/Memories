using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Middleware
{
    public class RequestTimeMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimeMiddlware> _logger;
        public RequestTimeMiddlware(RequestDelegate next, ILogger<RequestTimeMiddlware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(httpContext);
            stopwatch.Stop();

            _logger.LogInformation($"Request {httpContext.Request.Path} took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}