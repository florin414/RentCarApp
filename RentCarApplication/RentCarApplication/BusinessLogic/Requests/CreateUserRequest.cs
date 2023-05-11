namespace RentCarApplication.BusinessLogic.Requests;

public class CreateUserRequest : IRequest
{
    public User User { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
}
