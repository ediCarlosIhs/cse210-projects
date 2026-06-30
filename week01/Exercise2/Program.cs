using System;

class Program
{
    static void Main(string[] args)
    {
        System.Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();

        int percentage = int.Parse(gradePercentage);
        string letter;
        int reminder;
        string sign = string.Empty;

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // logic to determine the grade letter
        reminder = percentage % 10;

        if (reminder >= 7)
        {
            sign = "+";
        }
        else if (reminder < 3)
        {
            sign = "-";
        }

        // Recognize that there is no A+ grade, only A and A-
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // recognize that there is no F+ or F- grades, only F
        if (letter == "F")
        {
            sign = "";
        }

        System.Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percentage >= 70)
        {
            System.Console.WriteLine("Congratullation! You passed the course.");
        }
        else
        {
            System.Console.WriteLine("Sorry, you did not pass. But don't be sad. Keep studying and the Lord will help you.");
        }
    }
}