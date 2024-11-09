using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("There are no arguments.");
            }
            else
            {
                Console.WriteLine("There is at least one argument.");
                if (args.Length < 3)
                {
                    Console.WriteLine("Not Enough Arguments.");



                }
            }
        }
    }
        }