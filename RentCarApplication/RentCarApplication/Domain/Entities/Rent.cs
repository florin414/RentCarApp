namespace RentCarApplication.Domain.Entities;

[Table("Rent")]
public class Rent
{
    [Key]
    public int Id { get; set; }
    public string? Location { get; set; }
    public DateTime? DateTime { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public int? CarId { get; set; }
    public Car? Car { get; set; }
}
