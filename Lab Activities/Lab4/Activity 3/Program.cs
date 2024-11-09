using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ImplementForStatement
            ImplementForeachStatement();

        }

        private static void ImplementForeachStatement()
        {
            string[] names = { "Ali", "Hassan", "Jinnah" };
            foreach (string name in names)
            {
                Console.WriteLine($"{name} has {name.Length} characters.");

            }

        }
    }
}