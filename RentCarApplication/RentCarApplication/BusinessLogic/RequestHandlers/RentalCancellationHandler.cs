namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class RentalCancellationHandler : IRequestHandler<RentalCancellationRequest>
{
    public readonly IUnitOfWork _unitOfWork;

    public RentalCancellationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(RentalCancellationRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RentRepository.RemoveAsync(request.Id);
        _unitOfWork.Save();
        return Unit.Value;
    }
}
