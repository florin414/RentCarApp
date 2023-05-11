namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class LogUserOutHandler : IRequestHandler<LogUserOutRequest>
{
    private readonly SignInManager<User> _signInManager;

    public LogUserOutHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    public async Task<Unit> Handle(LogUserOutRequest request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
        return Unit.Value;
    }
}
