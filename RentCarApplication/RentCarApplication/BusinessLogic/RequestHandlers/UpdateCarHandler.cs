namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class UpdateCarHandler : IRequestHandler<UpdateCarRequest>
{
    public readonly IUnitOfWork _unitOfWork;

    public UpdateCarHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public Task<Unit> Handle(UpdateCarRequest request, CancellationToken cancellationToken)
    {
        _unitOfWork.CarRepository.Update(request.Car);
        _unitOfWork.Save();
        return Unit.Task;
    }
}
