
namespace GradeTracker;

public class GradeTrackerApp
{
    private const int MaximumStudents = 100;

    private readonly string[] _studentNames =
        new string[MaximumStudents];

    private readonly decimal[] _studentScores =
        new decimal[MaximumStudents];

    private readonly GradeCalculator _calculator = new();

    private int _studentCount = 0;

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            DisplayMenu();

            int option = GetMenuOption();

            switch (option)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    DisplayStudentResults();
                    break;

                case 3:
                    DisplayClassStatistics();
                    break;

                case 4:
                    isRunning = false;
                    Console.WriteLine("Thank you for using Grade Tracker!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Select 1, 2, 3 or 4.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\n================================");
        Console.WriteLine("          GRADE TRACKER");
        Console.WriteLine("================================");

        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Display Student Results");
        Console.WriteLine("3. Display Class Statistics");
        Console.WriteLine("4. Exit");

        Console.WriteLine("================================");
    }

    private int GetMenuOption()
    {
        Console.Write("Select an option: ");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int option))
        {
            return option;
        }

        return -1;
    }

    private void AddStudent()
    {
        if (_studentCount >= MaximumStudents)
        {
            Console.WriteLine("Student capacity has been reached.");
            return;
        }

        Console.Write("Enter student name: ");

        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Student name cannot be empty.");
            return;
        }

        decimal score = GetValidScore();

        _studentNames[_studentCount] = name.Trim();
        _studentScores[_studentCount] = score;

        _studentCount++;

        Console.WriteLine("Student added successfully!");
    }

    private decimal GetValidScore()
    {
        while (true)
        {
            Console.Write("Enter student score (0-100): ");

            string? input = Console.ReadLine();

            if (!decimal.TryParse(input, out decimal score))
            {
                Console.WriteLine("Invalid input. Enter a valid score.");
                continue;
            }

            if (score < 0 || score > 100)
            {
                Console.WriteLine("Score must be between 0 and 100.");
                continue;
            }

            return score;
        }
    }

    private void DisplayStudentResults()
    {
        if (_studentCount == 0)
        {
            Console.WriteLine("No students have been registered yet.");
            return;
        }

        Console.WriteLine("\n================================");
        Console.WriteLine("         STUDENT RESULTS");
        Console.WriteLine("================================");

        Console.WriteLine("{0,-20} {1,-10} {2,-10}",
            "Name", "Score", "Grade");

        Console.WriteLine("--------------------------------");

        for (int i = 0; i < _studentCount; i++)
        {
            string grade = _calculator.GetGrade(_studentScores[i]);

            Console.WriteLine("{0,-20} {1,-10:F2} {2,-10}",
                _studentNames[i],
                _studentScores[i],
                grade);
        }

        Console.WriteLine("--------------------------------");
    }

    private void DisplayClassStatistics()
    {
        if (_studentCount == 0)
        {
            Console.WriteLine("No student records available.");
            return;
        }

        decimal[] recordedScores = GetRecordedScores();

        decimal average = _calculator.CalculateAverage(recordedScores);
        decimal highest = _calculator.GetHighestScore(recordedScores);
        decimal lowest = _calculator.GetLowestScore(recordedScores);

        Console.WriteLine("\n================================");
        Console.WriteLine("         CLASS STATISTICS");
        Console.WriteLine("================================");

        Console.WriteLine($"Number of students: {_studentCount}");
        Console.WriteLine($"Class average: {average:F2}");
        Console.WriteLine($"Highest score: {highest:F2}");
        Console.WriteLine($"Lowest score: {lowest:F2}");
    }

    private decimal[] GetRecordedScores()
    {
        decimal[] recordedScores = new decimal[_studentCount];

        Array.Copy(
            _studentScores,
            recordedScores,
            _studentCount
        );

        return recordedScores;
    }
}
