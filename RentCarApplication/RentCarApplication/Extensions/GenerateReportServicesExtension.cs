namespace RentCarApplication.Extensions;

public static class GenerateReportServicesExtension
{
    public static IServiceCollection AddGenerateReportServices(this IServiceCollection services)
    {
       // services.AddScoped<IGenerateReportService, GenerateReportCustomerService>();
        //services.AddScoped<IGenerateReportService, GenerateReportRentalService>();

        return services;
    }
}
