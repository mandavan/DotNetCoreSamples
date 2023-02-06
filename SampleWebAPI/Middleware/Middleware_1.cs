using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ToDoAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware_1
    {
        private readonly RequestDelegate _next;

        public Middleware_1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("MiddlewareData: Middleware 1");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Middleware_1Extensions
    {
        public static IApplicationBuilder UseMiddleware_1(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware_1>();
        }
    }
}
