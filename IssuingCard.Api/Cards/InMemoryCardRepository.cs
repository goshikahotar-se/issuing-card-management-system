using System.Collections.Concurrent;
using IssuingCard.Application.Cards;
using IssuingCard.Domain.Cards;

namespace IssuingCard.Api.Cards;

public class InMemoryCardRepository : ICardRepository
{
    public Card? LastAdded { get; private set; }
    
    public int AddCallCount { get; private set; }
    
    ConcurrentDictionary<string, Card> _cards = new();
    
    public Task Add(Card card, CancellationToken ct)
    {
        LastAdded = card;
        AddCallCount++;
        
        _cards.AddOrUpdate(card.CardId, card, (key, oldCard) => card);
        
        return Task.CompletedTask;
    }

    public Task<Card?> Get(string cardId, CancellationToken ct)
    {
        if (_cards.TryGetValue(cardId, out var card))
            return Task.FromResult(card);

        return Task.FromResult<Card?>(null);
    }
}