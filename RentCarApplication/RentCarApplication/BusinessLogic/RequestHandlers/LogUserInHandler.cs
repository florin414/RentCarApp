using RentCarApplication.Exceptions;

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
        if(request.user == null)
            throw new ArgumentNullException(nameof(request.user));
        if (request.user.EmailConfirmed == false)
            throw new EmailNotConfirmedException();

        await _signInManager.SignInAsync(request.user, isPersistent: false);
        return Unit.Value;
    }
}
