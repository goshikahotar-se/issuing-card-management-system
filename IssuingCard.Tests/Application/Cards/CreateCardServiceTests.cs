using IssuingCard.Application.Cards;
using IssuingCard.Tests.Domain.Cards;

namespace IssuingCard.Tests.Application.Cards;

public class CreateCardServiceTests
{
    [Fact]
    public async void CreateCard_Should_Successfully_Return_Card()
    {
        //Arrange
        var repo = new FakeCardRepository();
        var service = new CreateCardService(repo);
        var command = new CreateCardCommand{InitialLimit = 100m, Currency = "EUR"};

        //Act
        var result = await service.Handle(command, CancellationToken.None);

        //Assert
        Assert.Equal(100m, result.AvailableLimit);
        Assert.Equal("EUR", result.Currency);
        Assert.Equal(1, repo.AddCallCount);
        Assert.NotNull(repo.LastAdded);
        Assert.Equal(result.CardId, repo.LastAdded!.CardId);
    }
}