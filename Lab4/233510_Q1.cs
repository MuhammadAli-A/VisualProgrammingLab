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
            string[] stringArray = { "hello ", "and ", "welcome ", "to ", "this ", "demo!" };

            
            string result = Merger(stringArray);

            Console.WriteLine("Merged String: " + result);
        }
        public static string Merger(string[] array)
        {
            return string.Concat(array);
        }

    }
    }
}
