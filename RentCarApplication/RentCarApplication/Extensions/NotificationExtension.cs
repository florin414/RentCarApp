namespace RentCarApplication.Extensions;

public static class NotificationExtension
{
    public static IServiceCollection AddNotification(this IServiceCollection services)
    {
        services.AddNotyf(config =>
        {
            config.DurationInSeconds = 5;
            config.IsDismissable = true;
            config.Position = NotyfPosition.TopRight;
        });

        return services;
    }
}
