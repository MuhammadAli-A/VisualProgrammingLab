using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize a two-dimensional array of integers
            int[,] array = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            // Call the method to print the array
            Print2DArray(array);
        }

        // Method to print the elements of a two-dimensional array
        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
