namespace RentCarApplication.MinimalApiEndpoints;

public class CarEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/cars", GetAllCar);
    }

    internal async Task<IResult> GetAllCar(IMediator mediator)
    {
        var cars = await mediator.Send(new GetAllCarRequest());
        return Results.Ok(cars);
    }
}
