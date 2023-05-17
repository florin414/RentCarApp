﻿namespace RentCar.Tests.ConstructorTests;
public class GetAllCarHandlerConstructor
{
    private readonly IUnitOfWork _unitOfWorkFake;

    // SetUp
    public GetAllCarHandlerConstructor()
    {
        _unitOfWorkFake = A.Fake<IUnitOfWork>();
    }

    [Theory]
    [InlineData(null)]
    [Trait("Category", "Exception")]
    public void When_UnitOfWorkIsNull_Expect_ArgumentNullExceptionThrown(IUnitOfWork unitOfWork)
    {
        // Act
        Action action = () => _ = new GetAllCarHandler(unitOfWork);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    [Trait("Category", "NoException")]
    public void When_UnitOfWorkIsNotNull_Expect_NoExceptionThrown()
    {
        // Act
        Action action = () => _ = new GetAllCarHandler(_unitOfWorkFake);

        // Assert
        action.Should().NotBeNull();
    }
}
