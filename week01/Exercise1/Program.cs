using System;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        // HI grader! Using var instead of string type.
        System.Console.Write("What is your first name? ");
        var firstName = Console.ReadLine();

        System.Console.Write("What is your last name? ");
        var lastName = Console.ReadLine();

        System.Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}