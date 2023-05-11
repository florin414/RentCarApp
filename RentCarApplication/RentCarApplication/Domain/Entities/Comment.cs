namespace RentCarApplication.Domain.Entities;

[Table("Comment")]
public class Comment
{
    [Key]
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string? UserId { get; set; }
    public User? User { get; set; }
}
