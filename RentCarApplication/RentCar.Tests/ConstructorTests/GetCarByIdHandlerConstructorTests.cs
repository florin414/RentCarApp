namespace RentCar.Tests.ConstructorTests;
public class GetCarByIdHandlerConstructorTests
{
    private readonly IUnitOfWork _unitOfWorkFake;

    // SetUp
    public GetCarByIdHandlerConstructorTests()
    {
        _unitOfWorkFake = A.Fake<IUnitOfWork>();
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public void When_UnitOfWorkIsNull_Expect_ArgumentNullExceptionThrown(IUnitOfWork unitOfWork)
    {
        // Act
        Action action = () => _ = new GetCarByIdHandler(unitOfWork);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    [Trait("Category", "NoException")]
    public void When_UnitOfWorkIsNotNull_Expect_NoExceptionThrown()
    {
        // Act
        Action action = () => _ = new GetCarByIdHandler(_unitOfWorkFake);

        // Assert
        action.Should().NotBeNull();
    }
}
