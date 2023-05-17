namespace RentCar.Tests.HandlerTests;
public class GetCarByIdHandlerTests
{
    private readonly IUnitOfWork _unitOfWorkFake;
    private CancellationToken _cancellationToken;

    // SetUp 
    public GetCarByIdHandlerTests()
    {
        _unitOfWorkFake = A.Fake<IUnitOfWork>();
        _cancellationToken = CancellationToken.None;
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public async Task When_NullCreateCarRequestProvided_Expect_NullReferenceExceptionThrownAsync(GetCarByIdRequest request)
    {
        // Arrange
        var handler = new GetCarByIdHandler(_unitOfWorkFake);

        // Act
        Func<Task> action = async () => await handler.Handle(request, _cancellationToken);

        // Assert
        await action.Should().ThrowAsync<NullReferenceException>();
    }
}
