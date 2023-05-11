namespace RentCarApplication.BusinessLogic.Requests;

public class CreateCommentRequest : IRequest
{
    public Comment Comment { get; set; }
}
