namespace IssuingCard.Tests.Domain.Cards;

using Xunit;
using IssuingCard.Domain.Cards;

public class CardTests
{
    [Theory]
    [InlineData(1, 2026, true)]
    [InlineData(1, 2027, false)]
    public void Testing_IsExpired_Edge_Cases(int expiryMonth, int expiryYear, bool status)
    {
        //Arrange
        Card card = new Card(Guid.Parse("e02fd0e4-00fd-090A-ca30-0d00a0038ba0"), 
                                        "5357370005", 
                                        expiryMonth, 
                                        expiryYear,
                                        "211",
                                        CardStatus.Active,
                                        new decimal(100.00),
                                        "GBP");
        
        //Act
        var result = card.IsExpired(DateTime.Now);
        
        //Assert
        Assert.Equal(result, status);
    }

    [Fact]
    public void Invalid_Month_Should_Throw_Exception()
    {
        //Arrange
        var expiryMonth = 13;
        
        //Act
        Action act = () => new Card(
            Guid.Parse("e02fd0e4-00fd-090A-ca30-0d00a0038ba0"),
            "5357370005",
            expiryMonth,
            2027,
            "211",
            CardStatus.Active,
            100.00m,
            "GBP");
        
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}