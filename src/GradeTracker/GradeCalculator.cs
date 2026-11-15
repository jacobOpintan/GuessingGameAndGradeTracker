
namespace GradeTracker;

public class GradeCalculator
{
    public decimal CalculateAverage(decimal[] scores)
    {
        ValidateScores(scores);

        decimal total = 0;

        foreach (decimal score in scores)
        {
            total += score;
        }

        return total / scores.Length;
    }

    public decimal GetHighestScore(decimal[] scores)
    {
        ValidateScores(scores);

        decimal highest = scores[0];

        foreach (decimal score in scores)
        {
            if (score > highest)
            {
                highest = score;
            }
        }

        return highest;
    }

    public decimal GetLowestScore(decimal[] scores)
    {
        ValidateScores(scores);

        decimal lowest = scores[0];

        foreach (decimal score in scores)
        {
            if (score < lowest)
            {
                lowest = score;
            }
        }

        return lowest;
    }

    public string GetGrade(decimal score)
    {
        if (score < 0 || score > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(score),
                "Score must be between 0 and 100."
            );
        }

        if (score >= 80)
        {
            return "A";
        }

        if (score >= 70)
        {
            return "B";
        }

        if (score >= 60)
        {
            return "C";
        }

        if (score >= 50)
        {
            return "D";
        }

        return "F";
    }

    private void ValidateScores(decimal[] scores)
    {
        ArgumentNullException.ThrowIfNull(scores);

        if (scores.Length == 0)
        {
            throw new ArgumentException(
                "At least one score is required.",
                nameof(scores)
            );
        }

        foreach (decimal score in scores)
        {
            if (score < 0 || score > 100)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(scores),
                    "Every score must be between 0 and 100."
                );
            }
        }
    }
}
