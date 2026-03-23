namespace IssuingCard.Domain.Cards;

public class Card
{
    public string CardId { get; }
    public string CardNumber { get; }
    public int ExpiryMonth { get; }
    public int ExpiryYear { get; }
    public string Cvc { get; }
    public CardStatus Status { get; }
    public decimal AvailableLimit { get; }
    public string Currency { get; }

    public Card(string cardId, string cardNumber, int expiryMonth, int expiryYear, string cvc,
        CardStatus status, decimal availableLimit, string currency)
    {
        if (expiryMonth < 1 || expiryMonth > 12)
            throw new ArgumentOutOfRangeException(nameof(expiryMonth), "ExpiryMonth must be between 1 and 12");
        
        if (expiryYear < 1900 || expiryYear > 3000)
            throw new ArgumentOutOfRangeException(nameof(expiryYear), "ExpiryYear must be between 1900 and 3000");
        
        if ((int.Parse(cvc) < 100) || (int.Parse(cvc) > 999))
            throw new ArgumentOutOfRangeException(nameof(cvc), "Cvc must be between 100 and 999");
        
        CardId = cardId;
        CardNumber = cardNumber;
        ExpiryMonth = expiryMonth;
        ExpiryYear = expiryYear;
        Cvc = cvc;
        Status = status;
        AvailableLimit = availableLimit;
        Currency = currency;
    }

    public bool IsExpired(DateTime now)
    {
        if (ExpiryYear < now.Year)
        {
            return true;
        }

        if (ExpiryYear == now.Year  && ExpiryMonth < now.Month)
        {
            return true;
        }
        return false;
    }
}