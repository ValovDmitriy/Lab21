using System;
using System.Threading;

namespace Lab21
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Garden.Gardener2);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Garden.Gardener1();
            Garden.Print();
        }
    }
    internal class Garden
    {

        public static int[,] field = new int[100, 100];

        public Garden()
        {
            for (int i = 0; i < field.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < field.GetUpperBound(1) + 1; j++)
                {
                    field[i, j] = 0;
                }
            }
        }
        internal static void Gardener1()
        {

            for (int i = 0; i < field.GetUpperBound(0) + 1; i++)
            {

                for (int j = 0; j < field.GetUpperBound(1) + 1; j++)
                {
                    if (field[i, j] != 2)
                    {
                        field[i, j] = 1;
                    }
                    else continue;
                }
            }
        }
        internal static void Gardener2()
        {

            for (int i = field.GetUpperBound(1); i >= 0; i--)
            {

                for (int j = field.GetUpperBound(0); j >= 0; j--)
                {
                    if (field[i, j] != 1)
                    {
                        field[i, j] = 2;
                    }
                    else continue;
                }
            }
        }
        internal static void Print()
        {
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < field.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < field.GetUpperBound(1) + 1; j++)
                {
                    if (field[i, j] == 1)
                    {
                        count1++;
                    }
                    if (field[i, j] == 2)
                    {
                        count2++;
                    }

                    Console.Write($"{field[i, j]}\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine(count1);
            Console.WriteLine(count2);
        }
    }
}
