using System.Security.Principal;

namespace RentCarApplication.BusinessLogic.Requests;
public class IsUserLoggedInRequest : IRequest<bool>
{
    public IPrincipal User { get; set; }
}