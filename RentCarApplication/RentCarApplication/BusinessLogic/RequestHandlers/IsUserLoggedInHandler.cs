namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class IsUserLoggedInHandler : IRequestHandler<IsUserLoggedInRequest, bool>
{
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger<IsUserLoggedInHandler> _logger;

    public IsUserLoggedInHandler(
        SignInManager<User> signInManager,
        ILogger<IsUserLoggedInHandler> logger
    )
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task<bool> Handle(IsUserLoggedInRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug(
            "Check if the user {UserName} is logged in!",
             request.User.Identity.Name
        );

        return Task.FromResult(_signInManager.IsSignedIn(request.User as ClaimsPrincipal));
    }
}
