namespace RentCarApplication.Extensions;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<User, string>, BaseRepository<User, string>>();
        services.AddScoped<IBaseRepository<Comment, int>, BaseRepository<Comment, int>>();
        services.AddScoped<IBaseRepository<Rent, int>, BaseRepository<Rent, int>>();
        services.AddScoped<IBaseRepository<Car, int>, BaseRepository<Car, int>>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
