using System;

namespace UniLearn.Abstractions;

public interface IReviewItem
{
    int CorrectReviewStreak { get; set; }
    DateTime ReviewDate { get; set; }
    DateTime PreviousCorrectReview { get; set; }
    int DifficultyRating { get; set; }
}