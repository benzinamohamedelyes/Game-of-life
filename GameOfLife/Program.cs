using System;

namespace GameOfLife
{
    public class Program
    {
        private static int rowCount;
        private static int columnCount;
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
            string[] sizeArray = stringSize.Split(" ");
            if (sizeArray.Length == 2 &&
                int.TryParse(sizeArray[0], out rowCount) &&
                int.TryParse(sizeArray[1], out columnCount))
            {

                return true;
            }
            return false;
        }

    }
}
