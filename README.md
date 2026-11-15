# Guessing Game and Grade Tracker

A C# console application solution containing two beginner-friendly programs: a Guessing Game and a Grade Tracker.

Both applications demonstrate fundamental C# programming concepts, including variables, arrays, loops, conditional statements, methods, input validation, exception handling, and automated testing.

## Applications

### 1. Guessing Game

A number guessing game in which the user tries to guess a randomly generated number between 1 and 100.

**Features**
- Generates a random number between 1 and 100.
- Gives the user a maximum of 7 attempts.
- Provides hints indicating whether a guess is too high or too low.
- Validates user input.
- Displays a success message when the correct number is guessed.
- Reveals the secret number when the user runs out of attempts.

### 2. Grade Tracker

A console application for recording student names and scores and displaying their academic results.

**Features**
- Adds student names and scores.
- Stores student records using arrays.
- Validates student names and scores.
- Displays each student's score and corresponding grade.
- Calculates the class average.
- Identifies the highest and lowest scores.
- Provides a repeating menu until the user chooses to exit.

**Grading scale**

| Score | Grade |
|---|---|
| 80–100 | A |
| 70–79 | B |
| 60–69 | C |
| 50–59 | D |
| 0–49 | F |

## Technologies

- C#
- .NET 9
- xUnit
- Visual Studio Code

## Project Structure

```text
GuessingGameAndGradeTracker/
├── src/
│   ├── GuessingGame/
│   │   ├── Game.cs
│   │   ├── GuessingGameService.cs
│   │   └── Program.cs
│   │
│   └── GradeTracker/
│       ├── GradeCalculator.cs
│       ├── GradeTrackerApp.cs
│       └── Program.cs
│
├── tests/
│   └── GuessingGameAndGradeTracker.Tests/
│       ├── GuessingGameServiceTests.cs
│       └── GradeCalculatorTests.cs
│
├── ConsoleApplications.sln
└── README.md
```

## Getting Started

### Prerequisites

- .NET 9 SDK or later.
- Git.
- A code editor such as Visual Studio Code.

### Clone the repository

```bash
git clone https://github.com/jacobOpintan/GuessingGameAndGradeTracker.git
```

Navigate into the project directory:

```bash
cd GuessingGameAndGradeTracker
```

### Build the solution

```bash
dotnet build
```

### Run the Guessing Game

```bash
dotnet run --project src/GuessingGame
```

### Run the Grade Tracker

```bash
dotnet run --project src/GradeTracker
```

## Running Automated Tests

Run the test suite from the repository root:

```bash
dotnet test
```

The tests cover the core application logic, including:

- Correct, incorrect, and invalid guesses.
- Remaining attempts and game completion.
- Grade calculation.
- Average, highest, and lowest score calculations.
- Invalid and out-of-range scores.

## Design and Architecture

The solution separates application logic from console interaction.

**Guessing Game**
- `Game.cs` handles the console interaction and game flow.
- `GuessingGameService.cs` contains the guessing rules and game state.
- `GuessingGameServiceTests.cs` tests the game logic independently of console input.

**Grade Tracker**
- `GradeTrackerApp.cs` manages the menu, student registration, and console interaction.
- `GradeCalculator.cs` contains the grade and score calculation logic.
- `GradeCalculatorTests.cs` tests the calculation logic independently of the console interface.

This separation makes the core logic easier to understand, maintain, and test.

## Assumptions and Limitations

- The Guessing Game generates numbers between 1 and 100 and allows a maximum of 7 attempts.
- The Grade Tracker supports a maximum of 100 students per application session.
- Student names and scores are stored in memory using arrays.
- Student records are not saved permanently; they are lost when the application closes.
- The grading scale is based on the assumptions documented above.
- Automated tests focus on the core application logic rather than the interactive console interface.

## Future Improvements

- Persist student records using a file or database.
- Allow users to edit and delete student records.
- Introduce more detailed student performance reports.
- Add configurable difficulty levels to the Guessing Game.

