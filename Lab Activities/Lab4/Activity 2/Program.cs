using Microsoft.Win32.SafeHandles;
using System;

namespace Activity_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Implement While Statement();
            ImplementDoWhileLoop();
        }

        private static void ImplementDoWhileLoop()
        {
            string password = string.Empty;
            do
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
            } 
            while (password != "secret");
            Console.WriteLine("Correct!");
                }

      
    }
}
