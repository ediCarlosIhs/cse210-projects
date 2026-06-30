using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        System.Console.Write("Enter a list of numbers, type 0 when finished. ");
        int numberInformed = int.Parse(Console.ReadLine());
        int sum = 0;
        double average;

        while (numberInformed != 0)
        {
            numbers.Add(numberInformed);

            System.Console.Write("Enter a list of numbers, type 0 when finished. ");
            try
            {
                numberInformed = int.Parse(Console.ReadLine());
            }
            catch (FormatException error)
            {
                System.Console.WriteLine($"Error: {error.GetType()}. You did not type a correct number. Please, restart the program and try again!");
            }

        }

        if (numberInformed != 0)
        {
            foreach (int number in numbers)
            {
                sum += number;
            }

            System.Console.WriteLine();
            System.Console.WriteLine($"The sum is: {sum}");

            average = (double)sum / numbers.Count;
            System.Console.WriteLine($"The average is: {average}");

            System.Console.WriteLine($"The largest number is: {numbers.Max()}");

            // Stretch Challenge
            numbers.Sort();

            // The smallest positive number
            int smallestPositive = numbers.Find(number =>
            {
                return number > 0 && number > numbers.Min();
            });

            System.Console.WriteLine($"The smallest positive number is: {smallestPositive}");

            // Sort the numbers in the list and display the new, sorted list. 
            System.Console.WriteLine("The sorted list is:");
            System.Console.Write("[ ");
            foreach (int number in numbers)
            {
                System.Console.Write($"{number} ");
            }
            System.Console.Write("]");
        }


    }
}