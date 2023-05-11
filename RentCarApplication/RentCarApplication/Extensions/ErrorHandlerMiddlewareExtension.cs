using RentCarApplication.Middlewares;

namespace RentCarApplication.Extensions;
public static class ErrorHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
