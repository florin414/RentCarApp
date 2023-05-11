namespace RentCarApplication.BusinessLogic.Requests;

public class GetCarByIdRequest : IRequest<Car>
{
    public int Id { get; set; }
}
