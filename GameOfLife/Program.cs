using System;
using System.Linq;

namespace GameOfLife
{
    public class Program
    {
        private static int rowCount;
        private static int columnCount;
        public static bool[][] grid;
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
            Console.WriteLine("please provide the seed data line by line");
            for (int i = 0; i < rowCount; i++)
            {
                string seedLine;
                do
                    seedLine = Console.ReadLine();
                while (ValidateSeedLine(seedLine));
                InitializeGridRowWithDeadCells(i, seedLine);

            }
            
        }
        public static void InitializeGridRowWithDeadCells(int row, string seedLine)
        {
            for (int i = 0; i < seedLine.Length; i++)
            {
                grid[row][i] = seedLine[i] != '.';
            }
            
        }
        public static bool ValidateSeedLine(string line)
        {
            return line.Length == columnCount && line.All(c => c == '.' || c == '*');
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
