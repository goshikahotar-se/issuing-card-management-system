using IssuingCard.Application.Cards;
using IssuingCard.Domain.Cards;

namespace IssuingCard.Tests.Domain.Cards;

public class FakeCardRepository : ICardRepository
{
    public Task Add(Card card, CancellationToken cancellationToken)
    {
        LastAdded = card;
        AddCallCount++;
        
        return Task.CompletedTask;
    }

    public Task<Card?> Get(Guid cardId, CancellationToken cancellationToken)
    {
        if (LastAdded == null)
            return Task.FromResult<Card?>(null);

        if (LastAdded.CardId != cardId)
            return Task.FromResult<Card?>(null);

        return Task.FromResult<Card?>(LastAdded);
    }
    
    public Card? LastAdded { get; private set; }
    
    public int AddCallCount { get; private set; }
}