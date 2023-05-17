namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class CreateCarHandler : IRequestHandler<CreateCarRequest, Car>
{
    public readonly IUnitOfWork _unitOfWork;

    public CreateCarHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Car> Handle(CreateCarRequest request, CancellationToken cancellationToken)
    {
        if(request.Car == null)
            throw new ArgumentNullException(nameof(request.Car));

        await _unitOfWork.CarRepository.AddAsync(request.Car);
        _unitOfWork.Save();

        return request.Car;
    }
}
