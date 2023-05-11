namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class LogUserInHandler : IRequestHandler<LogUserInRequest>
{
    private readonly SignInManager<User> _signInManager;

    public LogUserInHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    public async Task<Unit> Handle(LogUserInRequest request, CancellationToken cancellationToken)
    {
        await _signInManager.SignInAsync(request.user, isPersistent: false);
        return Unit.Value;
    }
}
