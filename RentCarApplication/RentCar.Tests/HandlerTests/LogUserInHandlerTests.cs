namespace RentCar.Tests.HandlerTests;
public class LogUserInHandlerTests
{
    private readonly SignInManager<User> _signInManagerFake;
    private User _userDummy;
    private CancellationToken _cancellationToken;

    // SetUp
    public LogUserInHandlerTests()
    {
        _signInManagerFake = A.Fake<SignInManager<User>>();
        _cancellationToken = CancellationToken.None;

        var userFaker = new Faker<User>()
            .RuleFor(x => x.EmailConfirmed, true);

        _userDummy = userFaker.Generate();
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public async Task When_UserIsNull_Expect_NullReferenceExceptionThrownAsync(User user)
    {
        // Arrange
        var (request, handler) = GetLogUserInRequestAndHandler(user);

        // Act
        Func<Task> action = async () => await handler.Handle(request, _cancellationToken);

        // Assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Theory]
    [InlineData(false)]
    public async Task When_EmailNotConfirmed_Expect_EmailNotConfirmedExceptionThrownAsync(bool statusEmailConfirmed)
    {
        // Arrange
        _userDummy.EmailConfirmed = statusEmailConfirmed;
        var (request, handler) = GetLogUserInRequestAndHandler(_userDummy);

        // Act
        Func<Task> action = async () => await handler.Handle(request, _cancellationToken);

        // Assert
        await action.Should().ThrowAsync<EmailNotConfirmedException>();
        statusEmailConfirmed.Should().BeFalse();
    }

    [Fact]
    public async Task When_EmailConfirmed_Expect_SignInAsyncIsCalledAndSuccesfulLogIn()
    {
        // Arrange
        var (request, handler) = GetLogUserInRequestAndHandler(_userDummy);

        // Act
        var result = await handler.Handle(request, _cancellationToken);
        // Assert
        A.CallTo(() => _signInManagerFake.SignInAsync(_userDummy, false, null));
        result.Should().BeEquivalentTo(Unit.Value);
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public async Task When_LogUserInRequestProvided_Expect_NullReferenceExceptionThrownAsync(LogUserInRequest request)
    {
        // Arrange
        var handler = new LogUserInHandler(_signInManagerFake);

        // Act
        Func<Task> action = async () => await handler.Handle(request, _cancellationToken);

        // Assert
        await action.Should().ThrowAsync<NullReferenceException>();
    }

    private Tuple<LogUserInRequest, LogUserInHandler> GetLogUserInRequestAndHandler(User user)
    {
        var request = new LogUserInRequest { user = user };
        var handler = new LogUserInHandler(_signInManagerFake);

        return Tuple.Create(request, handler);
    }
}
