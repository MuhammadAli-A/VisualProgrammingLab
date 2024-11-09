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

            int number1, number2 , number3;

            Console.Write("Enter First Number: ");
            string number1_str = Console.ReadLine();
            number1 = Convert.ToInt32(number1_str);

            Console.Write("Enter Second Number: ");            
            number2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Third Number: ");
            number3 = Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("\nNumber1:{0}\nNumber2:{1}\nNumber3:{2}",number1,number2,number3);






        }
    }
}
