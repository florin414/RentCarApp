namespace RentCarApplication.BusinessLogic.Requests;

public class CreateCarRequest : IRequest
{
    public Car Car { get; set; }
}
