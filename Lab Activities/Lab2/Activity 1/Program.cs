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
Console.WriteLine($"There are {args.Length} arguments.");



            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }


           


        }
    }
}
