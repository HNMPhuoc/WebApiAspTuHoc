using System.Net;
using System.Text.Json;
using TestApi1.DTO.Response;
using TestApi1.Enums;

namespace TestApi1.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>((int)ErrorCode.InternalServerError, "Internal Server Error", ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}