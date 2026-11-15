
using GradeTracker;

namespace ConsoleApplications.Tests;

public class GradeCalculatorTests
{
    private readonly GradeCalculator _calculator = new();

    [Fact]
    public void CalculateAverage_ReturnsCorrectAverage()
    {
        // Arrange
        decimal[] scores = { 75, 80, 65, 90, 55 };

        // Act
        decimal result = _calculator.CalculateAverage(scores);

        // Assert
        Assert.Equal(73m, result);
    }

    [Fact]
    public void GetHighestScore_ReturnsHighestValue()
    {
        // Arrange
        decimal[] scores = { 75, 80, 65, 90, 55 };

        // Act
        decimal result = _calculator.GetHighestScore(scores);

        // Assert
        Assert.Equal(90m, result);
    }

    [Fact]
    public void GetLowestScore_ReturnsLowestValue()
    {
        // Arrange
        decimal[] scores = { 75, 80, 65, 90, 55 };

        // Act
        decimal result = _calculator.GetLowestScore(scores);

        // Assert
        Assert.Equal(55m, result);
    }

    [Theory]
    [InlineData(85, "A")]
    [InlineData(75, "B")]
    [InlineData(65, "C")]
    [InlineData(55, "D")]
    [InlineData(45, "F")]
    public void GetGrade_ReturnsCorrectGrade(
        decimal score,
        string expectedGrade)
    {
        // Act
        string result = _calculator.GetGrade(score);

        // Assert
        Assert.Equal(expectedGrade, result);
    }

    [Fact]
    public void CalculateAverage_WithEmptyArray_ThrowsException()
    {
        // Arrange
        decimal[] scores = [];

        // Act & Assert
        Assert.Throws<ArgumentException>(
            () => _calculator.CalculateAverage(scores)
        );
    }

    [Fact]
    public void CalculateAverage_WithOutOfRangeScore_ThrowsException()
    {
        // Arrange
        decimal[] scores = { 75, 105, 65 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _calculator.CalculateAverage(scores)
        );
    }

    [Fact]
    public void GetGrade_WithOutOfRangeScore_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _calculator.GetGrade(110)
        );
    }
}
