namespace RentCarApplication.BusinessLogic.Requests;

public class CreateRentRequest : IRequest
{
    public Rent Rent { get; set; }
}
