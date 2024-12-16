using System;
namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Static_one();
        }
        static void Static_one()
        {
            int[,,] array = new int[3, 3, 3]
            {
            { { 2, 4, 8 }, { 4, 5, 2 }, { 2, 5, 2 } },
            { { 2,3,8},{ 4,5,1},{7,9,3 } },
            { { 10,4,14},{ 40,56,23},{ 12,4,24} }
            };
            int result = 0;
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        result += array[a, b, c];
                    }
                }
            }//end
            Console.WriteLine("----ORIGINAL ARRAY----");
            for (int a = 0; a < 3; a++)
            {
                Console.WriteLine($"Slice {a + 1}:");
                for (int b = 0; b < 3; b++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        Console.Write(array[a, b, c]+"\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }//end
            Console.WriteLine("\n\n"+"----RESULT ARRAY----");
            Console.WriteLine($"Result of the 3*3*3 array is: {result}");
        }
        static void user_defined()
        {
            int[,,] array = new int[3, 3, 3];
            int result = 0;
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        Console.WriteLine($"Array[{a},{b},{c}] : ");
                        array[a,b,c]=Convert.ToInt32(Console.ReadLine());
                    }
                }
            }//end

            for(int j=0; j<3; j++)
            {
                result += array[j, j, j];
            }

            Console.WriteLine("----RESULT ARRAY----");
            Console.WriteLine("\nThe sum of the diagonal elements is: " + result);
        }
    }
}