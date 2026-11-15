
namespace GuessingGame;

public enum GuessResult
{
    TooLow,
    TooHigh,
    Correct,
    InvalidGuess,
    NoAttemptsRemaining
}

public class GuessingGameService
{
    private const int MinimumNumber = 1;
    private const int MaximumNumber = 100;

    private readonly int _secretNumber;

    public int AttemptsRemaining { get; private set; }

    public bool HasGuessedCorrectly { get; private set; }

    public GuessingGameService(int secretNumber, int maximumAttempts = 7)
    {
        if (secretNumber < MinimumNumber || secretNumber > MaximumNumber)
        {
            throw new ArgumentOutOfRangeException(nameof(secretNumber));
        }

        if (maximumAttempts <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumAttempts));
        }

        _secretNumber = secretNumber;
        AttemptsRemaining = maximumAttempts;
    }

    public GuessResult MakeGuess(int guess)
    {
        if (AttemptsRemaining <= 0 || HasGuessedCorrectly)
        {
            return GuessResult.NoAttemptsRemaining;
        }

        if (guess < MinimumNumber || guess > MaximumNumber)
        {
            return GuessResult.InvalidGuess;
        }

        AttemptsRemaining--;

        if (guess == _secretNumber)
        {
            HasGuessedCorrectly = true;
            return GuessResult.Correct;
        }

        return guess < _secretNumber
            ? GuessResult.TooLow
            : GuessResult.TooHigh;
    }
}
