using System.Net;
using System.Text.Json;
using HospitalAppointmentAPI.Dtos.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HospitalAppointmentAPI.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred while processing request");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = ApiResponseDto<object>.Failure("An unexpected error occurred. Please try again later.");
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
