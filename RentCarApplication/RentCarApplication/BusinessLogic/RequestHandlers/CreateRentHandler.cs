using Microsoft.CodeAnalysis;

namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class CreateRentHandler : IRequestHandler<CreateRentRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateRentRequest request, CancellationToken cancellationToken)
    {
        Rent rent = new Rent() {
            CarId = request.Rent.CarId,
            Location = request.Rent.Location,
            DateTime = request.Rent.DateTime
        };
        await _unitOfWork.RentRepository.AddAsync(rent);
        _unitOfWork.Save();
        return Unit.Value;
    }
}
