using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HospitalAppointmentAPI.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            context.Request.EnableBuffering();
            var originalBodyStream = context.Response.Body;

            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
                context.Response.Body = originalBodyStream;

                _logger.LogInformation("HTTP {Method} {Path} responded {StatusCode} in {ElapsedMilliseconds}ms", context.Request.Method, context.Request.Path, context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
