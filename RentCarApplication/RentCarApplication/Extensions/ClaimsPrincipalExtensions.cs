using System.Security.Claims;

namespace RentCarApplication.Extensions;
public static class ClaimsPrincipalExtensions
{
    public static bool IsCustomer(this ClaimsPrincipal user)
    {
        return user.IsInRole(UserRole.Customer.ToString());
    }

    public static bool IsEmployee(this ClaimsPrincipal user)
    {
        return user.IsInRole(UserRole.Employee.ToString());
    }

    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.IsInRole(UserRole.Admin.ToString());
    }
}
