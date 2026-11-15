
using GuessingGame;

namespace ConsoleApplications.Tests;

public class GuessingGameServiceTests
{
    [Fact]
    public void MakeGuess_WhenGuessIsCorrect_ReturnsCorrect()
    {
        // Arrange
        GuessingGameService service = new(50);

        // Act
        GuessResult result = service.MakeGuess(50);

        // Assert
        Assert.Equal(GuessResult.Correct, result);
        Assert.True(service.HasGuessedCorrectly);
    }

    [Fact]
    public void MakeGuess_WhenGuessIsTooLow_ReturnsTooLow()
    {
        // Arrange
        GuessingGameService service = new(50);

        // Act
        GuessResult result = service.MakeGuess(30);

        // Assert
        Assert.Equal(GuessResult.TooLow, result);
    }

    [Fact]
    public void MakeGuess_WhenGuessIsTooHigh_ReturnsTooHigh()
    {
        // Arrange
        GuessingGameService service = new(50);

        // Act
        GuessResult result = service.MakeGuess(70);

        // Assert
        Assert.Equal(GuessResult.TooHigh, result);
    }

    [Fact]
    public void MakeGuess_WhenGuessIsOutsideRange_ReturnsInvalidGuess()
    {
        // Arrange
        GuessingGameService service = new(50);

        // Act
        GuessResult result = service.MakeGuess(150);

        // Assert
        Assert.Equal(GuessResult.InvalidGuess, result);
        Assert.Equal(7, service.AttemptsRemaining);
    }

    [Fact]
    public void MakeGuess_WhenAttemptsAreExhausted_ReturnsNoAttemptsRemaining()
    {
        // Arrange
        GuessingGameService service = new(50, 2);

        // Act
        service.MakeGuess(30);
        service.MakeGuess(70);
        GuessResult result = service.MakeGuess(50);

        // Assert
        Assert.Equal(GuessResult.NoAttemptsRemaining, result);
        Assert.Equal(0, service.AttemptsRemaining);
    }

    [Fact]
    public void MakeGuess_WhenGuessIsIncorrect_ReducesAttemptsByOne()
    {
        // Arrange
        GuessingGameService service = new(50);

        // Act
        service.MakeGuess(30);

        // Assert
        Assert.Equal(6, service.AttemptsRemaining);
    }
}
