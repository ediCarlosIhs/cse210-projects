using System.IO;

public class GoalManager
{
    private int _score;

    private List<Goal> _goals;

    public GoalManager()
    {
        _score = 0;
        _goals = [];
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Greate New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent(); ; ; ;
                    break;

                default:
                    Console.WriteLine("Wrong choice. Please choose from 1 to 6");
                    break;

            }

        }

        Console.WriteLine("\nBye bye!\n");

    }

    public void RecordEvent()
    {
        ListGoalDetails();

        if (_goals.Count == 0)
        {
            return;
        }

        Console.Write("Which goal did you accomplish? ");
        string goalAccomplished = Console.ReadLine();

        if (int.TryParse(goalAccomplished, out int response))
        {
            if (response > 0 && response <= _goals.Count)
            {
                Goal accomplishedGoal = _goals[response - 1];
                accomplishedGoal.RecordEvent();
                _score += accomplishedGoal.GetPoints();

                Console.WriteLine($"Congratulations! You earned {accomplishedGoal.GetPoints()} points");

                SaveGoals();
            }
            else
            {
                Console.WriteLine("Invalid selection. Number out of range.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the name of the file? ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("\nFile not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");

            string type = parts[0].Trim();

            string[] goalsString = parts[1].Split("|");

            string name = goalsString[0].Trim();
            string description = goalsString[1].Trim(); ;
            int points = int.Parse(goalsString[2].Trim());

            if (type == "SimpleGoal")
            {
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                bool wasFinished = bool.Parse(goalsString[3].Trim());

                if (wasFinished)
                {
                    simpleGoal.SetComplete();
                }

                _goals.Add(simpleGoal);
            }
            else if (type == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
            }
            else if (type == "ChecklistGoal")
            {
                int accomplishmentQuantity = int.Parse(goalsString[4].Trim());
                int bonus = int.Parse(goalsString[3].Trim());
                int amountCompleted = int.Parse(goalsString[5].Trim());
                
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, accomplishmentQuantity, bonus);
                checklistGoal.SetAmountCompleted(amountCompleted);

                _goals.Add(checklistGoal);


            }

        }

        Console.WriteLine("\nGoals loaded...");
    }

    public void SaveGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Please create a goal first!");
            return;
        }

        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully");
    }

    public void ListGoalDetails()
    {

        if (_goals.Count == 0)
        {
            Console.WriteLine("There is no goals.");
            return;
        }

        int index = 0;

        Console.WriteLine("\nThe Goals are:");

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index + 1}. {goal.GetDetailsString()}");
            index++;
        }

    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void CreateGoal()
    {

        Console.WriteLine("\nThe type of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. ChecklistGoal");

        Console.Write("Which type of goal would you like to create? ");
        string typeGoal = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goals? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeGoal)
        {
            case "1":
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);
                break;

            case "2":
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int accomplishmentQuantity = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, accomplishmentQuantity, bonus);
                _goals.Add(checklistGoal);
                break;

            default:
                Console.WriteLine("Invalid goal. Please type 1, 2 or 3.");
                break;
        }
    }

}