namespace RentCar.Tests.ConstructorTests;
public class LogUserInHandlerConstructorTests
{
    private readonly SignInManager<User> _signInManagerFake;

    // SetUp
    public LogUserInHandlerConstructorTests()
    {
        _signInManagerFake = A.Fake<SignInManager<User>>();
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public void When_SignInManagerIsNull_Expect_ArgumentNullExceptionThrown(SignInManager<User> signInManager)
    {
        // Act
        Action action = () => _ = new LogUserInHandler(signInManager);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    [Trait("Category", "NoException")]
    public void When_SignInManagerIsNotNull_Expect_NoExceptionThrown()
    {
        // Act
        Action action = () => _ = new LogUserInHandler(_signInManagerFake);

        // Assert
        action.Should().NotBeNull();
    }
}
