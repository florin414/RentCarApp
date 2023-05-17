namespace RentCarApplication.BusinessLogic.Requests;

public class CreateCarRequest : IRequest<Car>
{
    public Car Car { get; set; }
}
