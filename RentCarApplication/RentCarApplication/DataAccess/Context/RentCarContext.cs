using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

namespace RentCarApplication.DataAccess.Context;
internal class RentCarContext : IdentityDbContext<User>
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Rent>? Rents { get; set; }
    public DbSet<Comment>? Comments { get; set; }
    public DbSet<Car>? Cars { get; set; }

    public RentCarContext(DbContextOptions<RentCarContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.SeedCars();
        builder.SeedUsers();
        builder.SeedRoles();
        builder.SeedUserRoles();

        builder.Entity<User>(entity =>
        {
            entity
                .HasMany<Rent>(user => user.Rents)
                .WithOne(rent => rent.User)
                .HasForeignKey(rent => rent.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity
                .HasMany<Comment>(user => user.Comments)
                .WithOne(comment => comment.User)
                .HasForeignKey(comment => comment.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        });

        builder.Entity<Rent>(entity =>
        {
            entity
                .HasOne<Car>(rent => rent.Car)
                .WithOne(car => car.Rent)
                .HasForeignKey<Rent>(rent => rent.CarId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        });

        builder.Entity<Comment>().Property(comment => comment.Content).IsRequired();
    }
}
