namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class GetCarByIdHandler : IRequestHandler<GetCarByIdRequest, Car>
{
    public readonly IUnitOfWork _unitOfWork;

    public GetCarByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Car> Handle(GetCarByIdRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.CarRepository.GetByIdAsync(request.Id);
    }
}
