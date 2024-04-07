using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniLearn.Abstractions.Services;
using UniLearn.Data.Entities;
using UniLearn.Data.Repositories;

namespace UniLearn.Services
{
    /// <summary>
	///  Encapsulates the logic for managing card decks and cards.
	/// </summary>
	public class CardDeckService : ICardDeckService
	{
		private readonly ICardDeckRepository _cardDeckRepository;
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		///  Initializes a new instance of the <see cref="CardDeckService"/> class.
		/// </summary>
		/// <param name="cardDeckRepository">The card deck repository</param>
		/// <param name="unitOfWork">The unit of work to persist changes in the database.</param>
		public CardDeckService(ICardDeckRepository cardDeckRepository, IUnitOfWork unitOfWork)
		{
			_cardDeckRepository = cardDeckRepository;
			_unitOfWork = unitOfWork;
		}

		///  <inheritdoc/>
		public Task<IEnumerable<CardDeck>> GetAllCardDesks()
		{
			return _cardDeckRepository.GetAllCardDesks();
		}

		///  <inheritdoc/>
		public Task<int> GetCardCount(Guid cardDeckId)
		{
			return _cardDeckRepository.GetCardCount(cardDeckId);
		}

		///  <inheritdoc/>
		public Task<CardDeck?> GetCardDeck(Guid cardDeckId)
		{
			return _cardDeckRepository.GetCardDeck(cardDeckId);
		}

		///  <inheritdoc/>
		public async ValueTask AddCardDeck(CardDeck cardDeck)
		{
			await _cardDeckRepository.AddCardDeck(cardDeck);
			await _unitOfWork.Commit();
		}

		///  <inheritdoc/>
		public async Task DeleteCardDeck(Guid cardDeckId)
		{
			await _cardDeckRepository.DeleteCardDeck(cardDeckId);
			await _unitOfWork.Commit();
		}

		///  <inheritdoc/>
		public Task<IEnumerable<Card>> GetCardsInDeck(Guid cardDeckId)
		{
			return _cardDeckRepository.GetCardsInDeck(cardDeckId);
		}

		///  <inheritdoc/>
		public Task<IEnumerable<Card>> GetCardsOrderedByReviewDate(Guid cardDeckId)
		{
			return _cardDeckRepository.GetCardsOrderedByReviewDate(cardDeckId);
		}

		///  <inheritdoc/>
		public Task<IEnumerable<Card>> GetCardsToReview(Guid cardDeckId, DateTime now)
		{
			return _cardDeckRepository.GetCardsToReview(cardDeckId, now);
		}

		///  <inheritdoc/>
		public Task<Card?> GetCard(Guid cardDeckId, Guid cardId)
		{
			return _cardDeckRepository.GetCard(cardDeckId, cardId);
		}

		///  <inheritdoc/>
		public async ValueTask AddCardToDeck(Guid cardDeckId, Card card)
		{
			await _cardDeckRepository.AddCardToDeck(cardDeckId, card);
			await _unitOfWork.Commit();
		}

		///  <inheritdoc/>
		public async Task DeleteCardFromDeck(Guid cardDeckId, Guid cardId)
		{
			await _cardDeckRepository.DeleteCardFromDeck(cardDeckId, cardId);
			await _unitOfWork.Commit();
		}
	}
}
