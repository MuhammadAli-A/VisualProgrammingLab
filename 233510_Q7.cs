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
            int[,] matrixA = new int[3, 3];
            int[,] matrixB = new int[3, 3];
            int[,] resultMatrix = new int[3, 3];

        
            Console.WriteLine("Enter elements for Matrix A (3x3):");
            InputMatrix(matrixA);

            Console.WriteLine("Enter elements for Matrix B (3x3):");
            InputMatrix(matrixB);

            resultMatrix = MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("Resultant Matrix after Multiplication (A * B):");
            DisplayMatrix(resultMatrix);

        }
        public static void InputMatrix(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Enter element at [{i + 1}, {j + 1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public static int[,] MultiplyMatrices(int[,] A, int[,] B)
        {
            int[,] result = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return result;
        }

        public static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}

