namespace RentCar.Tests.HandlerTests;

public class GetAllCarHandlerTests
{
    private readonly IUnitOfWork _unitOfWorkFake;
    private CancellationToken _cancellationToken;

    // SetUp
    public GetAllCarHandlerTests()
    {
        _unitOfWorkFake = A.Fake<IUnitOfWork>();
        _cancellationToken = CancellationToken.None;
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public async Task When_NullGetAllCarRequestProvided_Expect_InvalidOperationExceptionThrownAsync(
        GetAllCarRequest request
    )
    {
        // Arrange
        var handler = new GetAllCarHandler(_unitOfWorkFake);

        // Act
        Func<Task> action = async () => await handler.Handle(request, _cancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidOperationException>();
    }
}
