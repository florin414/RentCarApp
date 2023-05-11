using Microsoft.Extensions.DependencyInjection;

namespace RentCarApplication.Extensions;

public static class IdentityExtension
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<User>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<RentCarContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = false;
            options.Password.RequiredUniqueChars = 6;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = true;

            options.User.RequireUniqueEmail = true;
        });

        return services;
    }
}
