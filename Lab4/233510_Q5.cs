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
            int decimalNumber = 45;
            string binaryNumber = "101101";

            string binaryResult = DecimalToBinary(decimalNumber);
            Console.WriteLine($"Decimal {decimalNumber} in binary is: {binaryResult}");

            int decimalResult = BinaryToDecimal(binaryNumber);
            Console.WriteLine($"Binary {binaryNumber} in decimal is: {decimalResult}");

        }
        public static string DecimalToBinary(int decimalNumber)
        {
            return Convert.ToString(decimalNumber, 2);
        }

        public static int BinaryToDecimal(string binaryNumber)
        {
            return Convert.ToInt32(binaryNumber, 2); 
        }

    }
}

