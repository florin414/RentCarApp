namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class GetAllCarHandler : IRequestHandler<GetAllCarRequest, IEnumerable<Car>>
{
    public readonly IUnitOfWork _unitOfWork;

    public GetAllCarHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<Car>> Handle(GetAllCarRequest request, CancellationToken cancellationToken)
    {
        var cars = await _unitOfWork.CarRepository.GetAll().ToListAsync(cancellationToken);
        return cars;
    }
}
