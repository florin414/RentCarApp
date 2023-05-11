using System.Security.Principal;

namespace RentCarApplication.BusinessLogic.Requests;
public class GetLoggedInUserRequest : IRequest<User>
{
    public IPrincipal User { get; set; }
}