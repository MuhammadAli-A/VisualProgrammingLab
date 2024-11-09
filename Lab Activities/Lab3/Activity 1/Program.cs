using System;

namespace Activity_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExploringNumbers();
        }

        private static void ExploringNumbers()
        {
            Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range: \n" +
                $"{int.MinValue:N0} to {int.MaxValue:N0}\n");

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range: \n" +
                $"{double.MinValue:N0} to {double.MaxValue:N0}\n");

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range: \n" +
                $"{decimal.MinValue:N0} to {decimal.MaxValue:N0}\n");
        }
    }
}
