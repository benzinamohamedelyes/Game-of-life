using System;

namespace GameOfLife
{
    public class Program
    {
        private int rowCount;
        private int columnCount;
        static void Main(string[] args)
        {
            int generation = 1;
            string size;
            do
            {
                Console.WriteLine($"Please provide the size of the grid (nb of lines x nb of colomns) separated by a space, exemple: 4 5 for a 4x5 grid");
                size = Console.ReadLine();
            }
            while (VerifyGridSize(size));
            Console.WriteLine($"Generation {generation}");
        }
        public static bool VerifyGridSize(string stringSize)
        {
            return false;
        }

    }
}
