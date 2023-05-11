namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class GetAllCommentHandler : IRequestHandler<GetAllCommentRequest, IEnumerable<Comment>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<Comment>> Handle(GetAllCommentRequest request, CancellationToken cancellationToken)
    {
        var comments = await _unitOfWork.CommentRepository.GetAll().ToListAsync(cancellationToken);
        return comments;
    }
}
