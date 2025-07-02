using System.Diagnostics;

namespace BookingSystem.API.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate next;

        public RequestTimingMiddleware(RequestDelegate next) 
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            await next(context);
            sw.Stop();
            Console.WriteLine($"{context.Request.Method} {context.Request.Path} within {sw.ElapsedMilliseconds}ms");
        }
    }
}
