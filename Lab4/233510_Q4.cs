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
            int[] responses = { 2, 3, 4, 5, 3, 2, 4, 3, 4, 2,
                            1, 5, 2, 3, 4, 4, 5, 3, 2, 4,
                            2, 3, 5, 4, 3, 4, 2, 2, 1, 3,
                            4, 5, 4, 3, 2, 2, 5, 3, 4, 3 };

            int[] frequency = new int[5];

            foreach (int response in responses)
            {
                if (response >= 1 && response <= 5)
                {
                    frequency[response - 1]++;
                }
            }

            for (int i = 0; i < frequency.Length; i++)
            {
                Console.WriteLine($"Response {i + 1} given by: {frequency[i]} people");
            }
        }

    }
    }

