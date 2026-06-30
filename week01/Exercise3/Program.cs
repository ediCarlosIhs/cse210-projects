using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {

        System.Console.Write("What is the magic number? ");
        string magicNumber = Console.ReadLine();


        string shot = string.Empty;

        do
        {
            System.Console.Write("What is your guess? ");
            shot = Console.ReadLine();

            if (int.Parse(magicNumber) > int.Parse(shot))
            {
                System.Console.WriteLine("Higher");
            }
            else if (int.Parse(magicNumber) < int.Parse(shot))
            {
                System.Console.WriteLine("Lower");
            }
            else
            {
                System.Console.WriteLine("You guessed it!");
            }
        }
        while (int.Parse(magicNumber) != int.Parse(shot));



    }
}