using System;

namespace Activity_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AssignLocalvariables();
        }

        private static void AssignLocalvariables()
        {
            int population = 66_000_000; // 66 million in UK
            double weight = 1.88; // in kilograms
            decimal price = 4.99M; // in pounds sterling
            string fruit = "Apples"; // strings use double-quotes
            char letter = 'A'; // chars use single-quotes
            bool happy = true; // Booleans have value of true or false

            // Print the values to the console
            Console.WriteLine($"Population: {population}");
            Console.WriteLine($"Weight: {weight} kg");
            Console.WriteLine($"Price: £{price}");
            Console.WriteLine($"Fruit: {fruit}");
            Console.WriteLine($"Letter: {letter}");
            Console.WriteLine($"Happy: {happy}");
        }
    }
}
