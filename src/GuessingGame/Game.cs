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
            int guess = GetValidGuess();

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

    private int GetValidGuess()
    {
        while (true)
        {
            Console.Write("\nEnter your guess: ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Invalid input. Enter a whole number.");
                continue;
            }

            if (guess < MinimumNumber || guess > MaximumNumber)
            {
                Console.WriteLine("Enter a number between 1 and 100.");
                continue;
            }

            return guess;
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
