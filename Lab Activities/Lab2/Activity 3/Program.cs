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
            string name;
            int rollno;
            int age;

            Console.Write("Enter your Name: ");
            name = Console.ReadLine();

            Console.Write("Enter your Roll#: ");
            rollno = int.Parse(Console.ReadLine());

            Console.Write("Enter your Age: ");
            age = int.Parse(Console.ReadLine());

            Console.WriteLine("\nName = " + name);
            Console.WriteLine("Roll# = " + rollno);
            Console.WriteLine("Age = " + age);





        }
    }
}
