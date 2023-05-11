namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class GetLoggedInUserHandler : IRequestHandler<GetLoggedInUserRequest, User>
{
    private readonly ILogger<GetLoggedInUserHandler> _logger;
    private readonly UserManager<User> _userManager;

    public GetLoggedInUserHandler(
        ILogger<GetLoggedInUserHandler> logger,
        UserManager<User> userManager
    )
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<User> Handle(
        GetLoggedInUserRequest request,
        CancellationToken cancellationToken
    )
    {
        _logger.LogDebug(
            "The user with name {Name} has been requested",
             request.User.Identity.Name
        );

        return await _userManager.GetUserAsync(request.User as ClaimsPrincipal).WaitAsync(cancellationToken);
    }
}