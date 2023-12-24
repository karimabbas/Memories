using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Middleware
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.StatusCode == 404)
                {
                    context.Response.Redirect("/GetAllPosts");
                }
                else if (context.Response.StatusCode == 401)
                {
                    context.Response.Redirect("/GetAllPosts");
                }
                else
                {
                    await context.Response.WriteAsync(ex.Message);

                }
            }
        }
    }


    public static class ErrorHandleMiddlewareExtensions
    {

        public static IApplicationBuilder UseErrorHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandleMiddleware>();
        }
    }
}