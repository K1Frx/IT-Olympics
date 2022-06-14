using System;

namespace PLA
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] buildings = new int[270000];
            int height, width, n, result = 0, size = 0;

            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                width = Convert.ToInt32(input[0]);
                height = Convert.ToInt32(input[1]);

                while ((size > 0) && (buildings[size - 1] > height))
                {
                    size--;
                }

                if ((size == 0) || (buildings[size - 1] < height))
                {
                    result++;
                    buildings[size] = height;
                    size++;

                }
            }

            Console.Write(result);
        }

    }

}

