namespace RentCar.Tests.ConstructorTests;

// Unit Test Naming Convention - When_StateUnderTest_Expect_ExpectedBehavior
// Structure a unit test: the Arrange-Act-Assert pattern

public class CreateCarHandlerConstructorTests
{
    private readonly IUnitOfWork _unitOfWorkFake;

    // SetUp
    public CreateCarHandlerConstructorTests()
    {
        _unitOfWorkFake = A.Fake<IUnitOfWork>();
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public void When_UnitOfWorkIsNull_Expect_ArgumentNullExceptionThrown(IUnitOfWork unitOfWork)
    {
        // Act
        Action action = () => _ = new CreateCarHandler(unitOfWork);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    [Trait("Category", "NoException")]
    public void When_UnitOfWorkIsNotNull_Expect_NoExceptionThrown()
    {
        // Act
        Action action = () => _ = new CreateCarHandler(_unitOfWorkFake);

        // Assert
        action.Should().NotBeNull();
    }
}
