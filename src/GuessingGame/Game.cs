using System;

namespace GuessingGame;

public class Game
{
    private readonly Random _random = new();

    private const int MinimumNumber = 1;
    private const int MaximumNumber = 100;
    private const int MaximumAttempts = 7;

    public void Start()
    {
        int secretNumber = _random.Next(
            MinimumNumber,
            MaximumNumber + 1
        );

        GuessingGameService gameService = new(
            secretNumber,
            MaximumAttempts
        );

        DisplayWelcomeMessage();

        while (gameService.AttemptsRemaining > 0 &&
               !gameService.HasGuessedCorrectly)
        {
            if (!TryGetValidGuess(out int guess))
            {
                return;
            }

            GuessResult result = gameService.MakeGuess(guess);

            DisplayGuessResult(result, gameService.AttemptsRemaining);
        }

        DisplayFinalResult(gameService,secretNumber);
    }

    private void DisplayWelcomeMessage()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("      NUMBER GUESSING GAME");
        Console.WriteLine("==============================");

        Console.WriteLine("Guess a number between 1 and 100.");
        Console.WriteLine($"You have {MaximumAttempts} attempts.");
    }

    
private bool TryGetValidGuess(out int guess)
{
    guess = 0;

    while (true)
    {
        Console.Write("Enter your guess (1-100): ");

        string? input = Console.ReadLine();

        if (input is null)
        {
            Console.WriteLine("\nInput stream closed.");
            return false;
        }

        if (!int.TryParse(input, out guess))
        {
            Console.WriteLine("Invalid input. Enter a number.");
            continue;
        }

        if (guess < 1 || guess > 100)
        {
            Console.WriteLine("Guess must be between 1 and 100.");
            continue;
        }

        return true;
    }
}

    private void DisplayGuessResult(
        GuessResult result,
        int attemptsRemaining)
    {
        switch (result)
        {
            case GuessResult.Correct:
                Console.WriteLine("Congratulations! You guessed correctly!");
                break;

            case GuessResult.TooLow:
                Console.WriteLine("Too low!");
                break;

            case GuessResult.TooHigh:
                Console.WriteLine("Too high!");
                break;

            case GuessResult.InvalidGuess:
                Console.WriteLine("Invalid guess.");
                break;

            case GuessResult.NoAttemptsRemaining:
                Console.WriteLine("No attempts remaining.");
                break;
        }

        if (result != GuessResult.Correct &&
            result != GuessResult.NoAttemptsRemaining)
        {
            Console.WriteLine($"Attempts remaining: {attemptsRemaining}");
        }
    }

    private void DisplayFinalResult(
    GuessingGameService gameService,
    int secretNumber)
    {
    if (!gameService.HasGuessedCorrectly)
       {
        Console.WriteLine(
            $"Game over! The secret number was {secretNumber}."
        );
       }  
    }
}
