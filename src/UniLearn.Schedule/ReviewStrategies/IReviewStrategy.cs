using UniLearn.Abstractions;

using System;

namespace UniLearn.WordEngine.ReviewStrategies
{
    public interface IReviewStrategy
    {
        DateTime NextReview(IReviewItem item);

        DifficultyRating AdjustDifficulty(IReviewItem item, ReviewOutcome outcome);
    }
}