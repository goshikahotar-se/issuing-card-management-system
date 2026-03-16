using IssuingCard.Domain.Cards;

namespace IssuingCard.Application.Cards;

public class CreateCardService
{
    private readonly ICardRepository _cardRepository;
    
    public CreateCardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
    
    public async Task<CreateCardResult> Handle(CreateCardCommand command, CancellationToken cancellationToken)
    {
        Guid id = Guid.NewGuid();
        string cardNumber = GenerateCardNumber();
        int expiryMonth = DateTime.UtcNow.Month;
        int expiryYear = DateTime.UtcNow.AddYears(3).Year;
        string cvc = GenerateCvc();
        CardStatus cardStatus = CardStatus.Active;
        decimal limit = command.InitialLimit;
        string currency = command.Currency;
        
        Card card = new Card(id, cardNumber, expiryMonth,  expiryYear, cvc, cardStatus, limit, currency);
        
        await _cardRepository.Add(card, cancellationToken);

        return new CreateCardResult()
        {
            CardId = card.CardId,
            CardNumber = card.CardNumber,
            ExpiryMonth = card.ExpiryMonth,
            ExpiryYear = card.ExpiryYear,
            Cvc = card.Cvc,
            AvailableLimit = card.AvailableLimit,
            Currency = card.Currency
        };
    }

    private static string GenerateCardNumber()
    {
        long CardNumber = Random.Shared.NextInt64(1000000000000000L, 9999999999999999L);
        
        return CardNumber.ToString();
    }

    private static string GenerateCvc()
    {
        return Random.Shared.Next(100, 1000).ToString();
    }
}