using IssuingCard.Domain.Cards;

namespace IssuingCard.Application.Cards;

public class GetCardService
{
    private readonly ICardRepository _cardRepository;
    
    public GetCardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<Card?> Handle(string cardId, CancellationToken cancellationToken)
    {
        Card? card = await _cardRepository.Get(cardId, cancellationToken);

        if (card is not null)
            return card;
        
        return null;
    }
}