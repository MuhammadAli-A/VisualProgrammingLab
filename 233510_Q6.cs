using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] testMarks = new int[5, 10]; 

            Random random = new Random();
            for (int course = 0; course < 5; course++)
            {
                for (int student = 0; student < 10; student++)
                {
                    testMarks[course, student] = random.Next(50, 101);
                }
            }

        }
        Console.WriteLine("Test Marks for 5 Courses and 10 Students:");
        for (int course = 0; course< 5; course++)
        {
            Console.Write($"Course {course + 1}: ");
            for (int student = 0; student< 10; student++)
            {
                Console.Write(testMarks[course, student] + " ");
            }
            Console.WriteLine();
        }

    }
}

