using System;

class Program
{

    static void Main(string[] args)
    {

        DisplayWelcome();

        string userName = PromptUserName();

        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);

    }

    static void DisplayWelcome()
    {
        System.Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        System.Console.Write("What is your name? ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        System.Console.Write("What is your favorite number? ");
        int favoriteNumber = int.Parse(Console.ReadLine());

        return favoriteNumber;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        System.Console.WriteLine($"Your name is: {userName}");

        System.Console.WriteLine($"The squared number is {squaredNumber}");
    }
}