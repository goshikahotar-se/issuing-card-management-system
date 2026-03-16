using IssuingCard.Domain.Cards;

namespace IssuingCard.Application.Cards;

public interface ICardRepository
{
    Task Add(Card card, CancellationToken ct);
    Task<Card?> Get(Guid cardId, CancellationToken ct);
}