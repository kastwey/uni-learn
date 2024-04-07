using UniLearn.Abstractions;
using UniLearn.WordEngine;

using System;

namespace UniLearn.WordEngine.ReviewStrategies;
/// <summary>
/// Implementation of the SuperMemo2 algorithm described here: http://www.supermemo.com/english/ol/sm2.htm
/// </summary>
public class SuperMemo2ReviewStrategy : IReviewStrategy
{
	private readonly IClock _clock;

	public SuperMemo2ReviewStrategy() : this(new Clock())
	{
	}

	public SuperMemo2ReviewStrategy(IClock clock)
	{
		_clock = clock;
	}

	public DateTime NextReview(IReviewItem item)
	{
		var random = new Random();
		var randomSecs = random.Next(1, 60);
		var now = _clock.Now();
		
		// If the review streak is 0, ten minutes are added until the next review, adding a few random seconds to avoid a predictable order.
		if (item.CorrectReviewStreak == 0)
		{
			return now.AddMinutes(10).AddSeconds(randomSecs);
		}

		// If the streak is 1, three days are added for the next review.
		if (item.CorrectReviewStreak == 1)
		{
			return item.ReviewDate.AddDays(3).AddSeconds(randomSecs);
		}

		var easinessFactor = DifficultyRatingToEasinessFactor(item.DifficultyRating);
		var daysSincePreviousReview = (now - item.PreviousCorrectReview).Days;
		var daysUntilNextReview = Math.Max(0, daysSincePreviousReview - 1) * easinessFactor;

		return item.ReviewDate.AddDays(daysUntilNextReview).AddSeconds(randomSecs);
	}

	public DifficultyRating AdjustDifficulty(IReviewItem item, ReviewOutcome outcome)
	{
		//EF':=EF+(0.1-(5-q)*(0.08+(5-q)*0.02))
		//where:
		//EF' - new value of the E-Factor,
		//EF - old value of the E-Factor,
		//q - quality of the response in the 0-3 grade scale.
		//If EF is less than 1.3 then let EF be 1.3.

		var currentEasinessFactor = DifficultyRatingToEasinessFactor(item.DifficultyRating);
		var newEasinessFactor = currentEasinessFactor + (0.1 - (3 - (int)outcome) * (0.08 + (3 - (int)outcome) * 0.02));
		var newDifficultyRating = EasinessFactorToDifficultyRating(newEasinessFactor);

		if (newDifficultyRating > 100)
			newDifficultyRating = 100;
		if (newDifficultyRating < 0)
			newDifficultyRating = 0;

		return new DifficultyRating(newDifficultyRating);
	}

	private double DifficultyRatingToEasinessFactor(int difficultyRating)
	{
		// using a linear equation - y = mx + b
		return (-0.012 * difficultyRating) + 2.5;
	}

	private int EasinessFactorToDifficultyRating(double easinessFactor)
	{
		// using a linear equation - x = (y - b)/m
		return (int)((easinessFactor - 2.5) / -0.012);
	}
}