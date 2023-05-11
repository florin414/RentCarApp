namespace RentCarApplication.BusinessLogic.RequestHandlers;

public class CreateUserHandler : IRequestHandler<CreateUserRequest>
{
    private readonly UserManager<User> _userManager;

    public CreateUserHandler(UserManager<User> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await _userManager.CreateAsync(request.User, request.Password);
        await _userManager.AddToRoleAsync(request.User, Enum.GetName(request.UserRole));
        return Unit.Value;
    }
}
