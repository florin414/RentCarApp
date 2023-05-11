namespace RentCarApplication.Domain.Entities;

[Table("User")]
public class User : IdentityUser
{
    public ICollection<Rent>? Rents { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}
