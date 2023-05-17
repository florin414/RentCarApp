namespace RentCar.Tests.HandlerTests;

public class CreateCarHandlerTests
{
    private Car _carDummy;
    private readonly IUnitOfWork _unitOfWorkFake;
    private CancellationToken _cancellationToken;

    // SetUp 
    public CreateCarHandlerTests()
    {
        _unitOfWorkFake = A.Fake<IUnitOfWork>();
        _cancellationToken = CancellationToken.None;

        var carFaker = new Faker<Car>();
        _carDummy = carFaker.Generate();
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public async Task When_NullCarIsProvided_Expect_ArgumentNullExceptionThrownAsync(Car car)
    {
        // Arrange
        var (request, handler) = GetCreateCarRequestAndHandler(car);

        // Act
        Func<Task> action = async () => await handler.Handle(request, _cancellationToken);

        // Assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task When_CarIsProvided_Expect_AddAsyncIsCalledAndCarCreatedAsync()
    {
        // Arrange
        var (request, handler) = GetCreateCarRequestAndHandler(_carDummy);

        // Act
        var actualCar = await handler.Handle(request, _cancellationToken);

        // Assert
        A.CallTo(() =>_unitOfWorkFake.CarRepository.AddAsync(_carDummy)).MustHaveHappened();
        A.CallTo(() => _unitOfWorkFake.Save()).MustHaveHappened();

        actualCar.Should().BeEquivalentTo(_carDummy);
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public async Task When_NullCreateCarRequestProvided_Expect_NullReferenceExceptionThrownAsync(CreateCarRequest request)
    {
        // Arrange
        var handler = new CreateCarHandler(_unitOfWorkFake);

        // Act
        Func<Task> action = async () => await handler.Handle(request, _cancellationToken);

        // Assert
        await action.Should().ThrowAsync<NullReferenceException>();
    }

    private Tuple<CreateCarRequest, CreateCarHandler> GetCreateCarRequestAndHandler(Car car)
    {
        var request = new CreateCarRequest { Car = car };
        var handler = new CreateCarHandler(_unitOfWorkFake);

        return Tuple.Create(request, handler);
    }
}
