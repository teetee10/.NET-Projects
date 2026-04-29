using DentalManagementSystem.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace DentalManagementSystem.API.Middlewares
{
    // This middleware is responsible for handling exceptions that occur during the processing of HTTP requests and returning appropriate HTTP responses.
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        // This method is called for each HTTP request and is responsible for invoking the next middleware in the pipeline and catching any exceptions that occur.
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        // This method handles exceptions and returns appropriate HTTP responses based on the exception type.
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case CustomValidationException customValidationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(customValidationException.ValidationErrors);
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            if (string.IsNullOrEmpty(result))
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }

    // Extension method to add the middleware to the HTTP request pipeline
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
