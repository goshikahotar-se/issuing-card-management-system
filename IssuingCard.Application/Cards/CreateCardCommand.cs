namespace IssuingCard.Application.Cards;

public class CreateCardCommand
{
    public decimal InitialLimit { get; init; }
    public string Currency { get; init; }
}