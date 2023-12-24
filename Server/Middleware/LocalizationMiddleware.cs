using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Middleware
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var userLang = context.Request.Headers["Accept-Language"].FirstOrDefault();
            var route = context.Request.Path.Value.StartsWith("/GetAllPosts");

            if (route)
            {
                context.Response.Redirect("/department/all");
                return;
            }

            CultureInfo culture;

            if (!string.IsNullOrEmpty(userLang))
            {
                culture = new CultureInfo(userLang);
            }
            else
            {
                culture = new CultureInfo("en-US");
            }
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            var timezone = context.Request.Headers["TimeZone"].FirstOrDefault();
            if (!string.IsNullOrEmpty(timezone))
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            }
            await _next(context);
        }
    }

    public static class LocalizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseLocalizationMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LocalizationMiddleware>();
        }
    }
}