using Microsoft.EntityFrameworkCore;

using UniLearn.Data.Context;
using UniLearn.Data.Entities;
using UniLearn.Data.Exceptions;

namespace UniLearn.Data.Repositories;

/// <summary>
/// Repository for managing card decks and cards.
/// </summary>
public class CardDeckRepository : ICardDeckRepository
{
	private readonly UniLearnDbContext _dbContext;

	/// <summary>
	/// Initializes a new instance of the <see cref="CardDeckRepository"/> class.
	/// </summary>
	/// <param name="dbContext">The database context.</param>
	public CardDeckRepository(UniLearnDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	///  <inheritdoc/>
	public async Task<IEnumerable<CardDeck>> GetAllCardDesks()
	{
		return await _dbContext.CardDecks.OrderBy(c => c.Name).ToListAsync();
	}

	///  <inheritdoc/>
	public async Task<int> GetCardCount(Guid cardDeckId)
	{
		return await _dbContext.Cards.CountAsync(c => c.CardDeck.CardDeckId == cardDeckId);
	}

	///  <inheritdoc/>
	public async Task<CardDeck?> GetCardDeck(Guid cardDeckId)
	{
		return await _dbContext.CardDecks.FindAsync(cardDeckId);
	}

	///  <inheritdoc/>
	public async ValueTask AddCardDeck(CardDeck cardDeck)
	{
		await _dbContext.CardDecks.AddAsync(cardDeck);
	}

	///  <inheritdoc/>
	public async Task DeleteCardDeck(Guid cardDeckId)
	{
		var cardDeck = await GetCardDeck(cardDeckId);
		if (cardDeck is null)
		{
			throw new EntityNotFoundException($"Unable to find a card deck with the Id {cardDeckId}.");
		}

		_dbContext.CardDecks.Remove(cardDeck);
	}

	///  <inheritdoc/>
	public async Task<IEnumerable<Card>> GetCardsInDeck(Guid cardDeckId)
	{
		return await _dbContext.Cards.Where(c => c.CardDeck.CardDeckId == cardDeckId)
			.OrderBy(w => w.Front).ToListAsync();
	}

	///  <inheritdoc/>
	public async Task<IEnumerable<Card>> GetCardsOrderedByReviewDate(Guid cardDeckId)
	{
		return await _dbContext.Cards.Where(c => c.CardDeck.CardDeckId == cardDeckId)
			.OrderBy(w => w.ReviewDate).ToListAsync();
	}

	///  <inheritdoc/>
	public async Task<IEnumerable<Card>> GetCardsToReview(Guid cardDeckId, DateTime now)
	{
		return await _dbContext.Cards.Where(c => c.CardDeck.CardDeckId == cardDeckId && c.ReviewDate <= now)
			.OrderBy(w => w.ReviewDate).ToListAsync();
	}

	/// <summary>
	/// Gets a card by card deck ID and card ID.
	/// </summary>
	/// <param name="cardDeckId">The card deck ID.</param>
	/// <param name="cardId">The card ID.</param>
	///  <inheritdoc/>
	public Task<Card?> GetCard(Guid cardDeckId, Guid cardId)
	{
		return _dbContext.Cards.SingleOrDefaultAsync(c => c.CardDeck.CardDeckId == cardDeckId && c.CardId == cardId);
	}

	/// <summary>
	/// Adds a new card to a card deck.
	/// </summary>
	/// <param name="cardDeckId">The card deck ID.</param>
	///  <inheritdoc/>
	public async ValueTask AddCardToDeck(Guid cardDeckId, Card card)
	{
		var cardDeck = await GetCardDeck(cardDeckId);
		if (cardDeck is null)
		{
			throw new EntityNotFoundException($"Unable to find a card deck with the Id {cardDeckId}.");
		}
		card.CardDeck = cardDeck;
		await _dbContext.Cards.AddAsync(card);
	}

	///  <inheritdoc/>
	public async Task DeleteCardFromDeck(Guid cardDeckId, Guid cardId)
	{
		var card = await this.GetCard(cardDeckId, cardId);
		if (card is null)
		{
			throw new EntityNotFoundException($"Unable to find a word with the Id {cardId}.");
		}

		_dbContext.Cards.Remove(card);
	}
}
