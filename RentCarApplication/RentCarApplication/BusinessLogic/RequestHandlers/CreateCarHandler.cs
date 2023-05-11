namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class CreateCarHandler : IRequestHandler<CreateCarRequest>
{
    public readonly IUnitOfWork _unitOfWork;

    public CreateCarHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateCarRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CarRepository.AddAsync(request.Car);
        _unitOfWork.Save();
        return Unit.Value;
    }
}
