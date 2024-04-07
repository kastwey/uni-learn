using UniLearn.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLearn.Data.Enums;

namespace UniLearn.Data.Entities;

public class Card : IReviewItem
{

	public Guid CardId { get; set; }

	public CardType CardType { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime LastModifiedDate { get; set; }

	public bool UserCanTypeAnswer { get; set; }

	public required string Front { get; set; }

	public required string Back { get; set; }

	public int CorrectReviewStreak { get; set; }

	public DateTime ReviewDate { get; set; }

	public DateTime PreviousCorrectReview { get; set; }

	public int DifficultyRating { get; set; }

	public required CardDeck CardDeck { get; set; }

}
