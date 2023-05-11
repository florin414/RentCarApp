namespace RentCarApplication.BusinessLogic.Requests;

public class UpdateCarRequest : IRequest
{
    public Car Car { get; set; }
}
