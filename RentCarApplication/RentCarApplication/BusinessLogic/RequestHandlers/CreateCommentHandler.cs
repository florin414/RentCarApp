namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class CreateCommentHandler : IRequestHandler<CreateCommentRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CommentRepository.AddAsync(request.Comment);
        _unitOfWork.Save();
        return Unit.Value;
    }
}
