using UniLearn.Data.Entities;

namespace UniLearn.Data.Repositories;
/// <summary>
/// Represents the interface for accessing and manipulating card decks.
/// </summary>
public interface ICardDeckRepository
{
	/// <summary>
	/// Adds a new card deck.
	/// </summary>
	/// <param name="cardDeck">The card deck to add.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	ValueTask AddCardDeck(CardDeck cardDeck);

	/// <summary>
	/// Adds a card to a specific card deck.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <param name="card">The card to add.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	ValueTask AddCardToDeck(Guid cardDeckId, Card card);

	/// <summary>
	/// Deletes a card deck.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck to delete.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task DeleteCardDeck(Guid cardDeckId);

	/// <summary>
	/// Deletes a card from a specific card deck.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <param name="cardId">The ID of the card to delete.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task DeleteCardFromDeck(Guid cardDeckId, Guid cardId);

	/// <summary>
	/// Gets all card decks.
	/// </summary>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<IEnumerable<CardDeck>> GetAllCardDesks();

	/// <summary>
	/// Gets a specific card from a card deck.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <param name="cardId">The ID of the card.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<Card?> GetCard(Guid cardDeckId, Guid cardId);

	/// <summary>
	/// Gets the number of cards in a card deck.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<int> GetCardCount(Guid cardDeckId);

	/// <summary>
	/// Gets a specific card deck.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<CardDeck?> GetCardDeck(Guid cardDeckId);

	/// <summary>
	/// Gets all cards in a card deck.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<IEnumerable<Card>> GetCardsInDeck(Guid cardDeckId);

	/// <summary>
	/// Gets all cards in a card deck ordered by review date.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<IEnumerable<Card>> GetCardsOrderedByReviewDate(Guid cardDeckId);

	/// <summary>
	/// Gets the cards in a card deck that are due for review.
	/// </summary>
	/// <param name="cardDeckId">The ID of the card deck.</param>
	/// <param name="now">The current date and time.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<IEnumerable<Card>> GetCardsToReview(Guid cardDeckId, DateTime now);
}
