namespace RentCarApplication.Domain.Entities;

[Table("Car")]
public class Car
{
    [Key]
    public int Id { get; set; }
    public CarBrand? Brand { get; set; }
    public int? Price { get; set; }
    public CarType? Type { get; set; }
    public int? Km { get; set; }
    public string? RegistrationNumber { get; set; }
    public DateTime? DateOfManufacture { get; set; }
    public Rent? Rent { get; set; }
}
