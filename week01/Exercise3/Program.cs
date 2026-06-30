using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber = new Random();
        int magicNumber = randomNumber.Next(1, 100);

        string shot = string.Empty;

        int guesses = 1;

        string keepPlaying = "yes";

        while (keepPlaying == "yes")
        {
            do
            {
                System.Console.Write("What is your guess? ");
                shot = Console.ReadLine();

                if (magicNumber > int.Parse(shot))
                {
                    System.Console.WriteLine("Higher");
                }
                else if (magicNumber < int.Parse(shot))
                {
                    System.Console.WriteLine("Lower");
                }
                else
                {
                    System.Console.WriteLine("You guessed it!");

                    string text = guesses > 1 ? "Times" : "time";

                    System.Console.WriteLine($"You tried {guesses} {text}.");
                }

                guesses++;
            }
            while (magicNumber != int.Parse(shot));

            System.Console.Write("Do you want do keep playing? (write yes other word for not) ");
            keepPlaying = Console.ReadLine();

            keepPlaying = keepPlaying.ToLower();
        }

    }
}