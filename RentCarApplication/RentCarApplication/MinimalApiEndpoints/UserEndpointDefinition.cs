using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace RentCarApplication.MinimalApiEndpoints;
public class UserEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/users", CreateUser);
    }

    internal IResult CreateUser(IMediator mediator, User user, string password, UserRole role)
    {
        mediator.Send(new CreateUserRequest { User = user, Password = password, UserRole = role });
        return Results.Created($"/users/{user.Id}", user);
    }
}
