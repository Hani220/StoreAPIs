using Store.Service.ResponseHandling;
using System.Net;
using System.Text.Json;

namespace Store.Web.NewFolder.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment environment;

        public ExceptionMiddleware(RequestDelegate Next ,ILogger<ExceptionMiddleware> logger ,IHostEnvironment environment)
        {
             next= Next;
            this.logger = logger;
            this.environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var responsEnv = environment.IsDevelopment() ? new CustomException(500, ex.Message, ex.StackTrace.ToString())
                    : new CustomException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var jsonResponse = JsonSerializer.Serialize(responsEnv, options);

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
