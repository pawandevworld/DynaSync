using System.Net;
using System.Text.Json;

namespace DevPulse;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
    IHostEnvironment env)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = env.IsDevelopment()
                //Error handeling for development
                ? new DevPulseException( context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                //Error handeling for production
                : new DevPulseException( context.Response.StatusCode,  ex.Message, "Internal server error");

            var options = new JsonSerializerOptions
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    } 
}