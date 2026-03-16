namespace IssuingCard.Application.Cards;

public class CreateCardResult
{
    public Guid CardId { get; init; }
    public string CardNumber { get; init; }
    public int ExpiryMonth { get; init; }
    public int ExpiryYear { get; init; }
    public string Cvc { get; init; }
    public decimal AvailableLimit { get; init; }
    public string Currency { get; init; }
}