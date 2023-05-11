using RentCarApplication.Domain.Entities;

namespace RentCarApplication.Extensions;

public static class SeedDataExtension
{
    public static void SeedUsers(this ModelBuilder builder)
    {
        var hasher = new PasswordHasher<User>();
        builder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    UserName = "Florin",
                    NormalizedUserName = "FLORIN",
                    Email = "florin@gmail.com",
                    NormalizedEmail = "FLORIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true

                },
                new User
                {
                    Id = "9c44780-a24d-4543-9cc6-0993d048aacu7",
                    UserName = "Alin",
                    NormalizedUserName = "ALIN",
                    Email = "alin@gmail.com",
                    NormalizedEmail = "ALIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true
                },
                new User
                {
                    Id = "9a27620-a44f-4543-9dk6-0993d048sia7",
                    UserName = "Bogdan",
                    NormalizedUserName = "BOGDAN",
                    Email = "bogdan@gmail.com",
                    NormalizedEmail = "BOGDAN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true,
                }
            );
    }

    public static void SeedRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
                new IdentityRole()
                {
                    Id = "3",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                }
            );
    }

    public static void SeedUserRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    RoleId = "1"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "9c44780-a24d-4543-9cc6-0993d048aacu7",
                    RoleId = "2"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "9a27620-a44f-4543-9dk6-0993d048sia7",
                    RoleId = "3"
                }
            );
    }

    public static void SeedCars(this ModelBuilder builder)
    {
        int carId = 1;
        var cars = new Faker<Car>()
            .RuleFor(x => x.DateOfManufacture, f => f.Date.Past())
            .RuleFor(x => x.Brand, f => (CarBrand)f.Random.Int(0, 11))
            .RuleFor(x => x.Km, f => f.Random.Int(0, 1000))
            .RuleFor(x => x.Price, f => f.Random.Int(0, 100))
            .RuleFor(x => x.Type, f => (CarType)f.Random.Int(0, 3))
            .RuleFor(x => x.RegistrationNumber, f => f.Vehicle.Vin())
            .RuleFor(x => x.Id, () => carId++);
        builder.Entity<Car>().HasData(cars.Generate(40));
    }

}
