namespace RentCarApplication.BusinessLogic.Requests;

public class LogUserInRequest : IRequest
{
    public User user { get; set; }
}
