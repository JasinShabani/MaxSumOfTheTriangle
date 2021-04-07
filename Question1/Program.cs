using System;
using System.IO;
namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "../../../read.txt");
            var triangleLength = File.ReadAllLines(path).Length;

            int[,] triangle2D = new int[triangleLength, triangleLength];

            using (var readFile = new StreamReader(path))
            {
                int row = 1;
                while (!readFile.EndOfStream)
                {
                    var line = readFile.ReadLine().Trim();
                    var values = line.Split(' ');

                    for (int i = 0; i < row; i++)
                    {
                        triangle2D[(row - 1), i] = Int32.Parse(values.GetValue(i).ToString());
                    }
                    row++;
                }
            }
            int maxNum = findMax(triangle2D, triangleLength);
            Console.WriteLine("The Max sum of Triangle from Top to Bottom is : "+maxNum);
        }
        public static int findMax(int[,] variableArray, int lineCount)
        {
            for (int i = (lineCount - 2); i >= 0; i--)
            {
                for (int j = 0; j < (lineCount - 1); j++)
                {
                    if (isNumPrime(variableArray[i, j]))
                    {
                        variableArray[i, j] = 0;
                    }
                    else
                    {
                        variableArray[i, j] = Math.Max(variableArray[i, j] + variableArray[i + 1, j], variableArray[i, j] + variableArray[i + 1, j + 1]);
                    }
                }
            }
        
            return variableArray[0, 0];
        }
        public static bool isNumPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            if (number == 1 || number == 0)
            {
                return false;
            }
            return true;
        }
    }
}
