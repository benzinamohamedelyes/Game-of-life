using System;
using System.Linq;

namespace GameOfLife
{
    public class Program
    {
        private static int rowCount;
        private static int columnCount;
        public static bool[,] grid;
        static void Main(string[] args)
        {
            int generation = 1;
            string size;
            do
            {
                Console.WriteLine($"Please provide the size of the grid (nb of lines x nb of colomns) separated by a space, exemple: 4 5 for a 4x5 grid");
                size = Console.ReadLine();
            }
            while (!VerifyGridSize(size));

            InitializeGridWithDeadCells();

            Console.WriteLine("please provide the seed data line by line");
            for (int i = 0; i < rowCount; i++)
            {
                string seedLine;
                do
                    seedLine = Console.ReadLine();
                while (!ValidateSeedLine(seedLine));
                InitializeGridRowWithSeedLine(i, seedLine);

            }
            char continuing;
            do
            {
                Console.WriteLine($"Generation {generation}:");
                DisplayGrid();
                Console.WriteLine("Would you like to continue? (Y/N)");
                continuing = Console.ReadKey().KeyChar;
                generation++;
            }
            while (continuing == 'Y' || continuing == 'y');
        }

        private static void DisplayGrid()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (j != 0 && j < columnCount)
                    {
                        Console.Write(' ');
                    }
                    Console.Write((grid[i, j]) ? '*' : '-');
                }
                Console.WriteLine();
            }
        }
        public static int CountLivingCells()
        {
            int nbOfLivingCells = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (grid[i, j]) i++ ;
                }
            }
            return nbOfLivingCells;
        }
        public static void InitializeGridRowWithSeedLine(int row, string seedLine)
        {
            for (int i = 0; i < seedLine.Length; i++)
            {
                grid[row, i] = seedLine[i] != '.';
            }

        }
        public static void InitializeGridWithDeadCells()
        {
            grid = new bool[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    grid[i, j] = false;
                }
            }
        }
        public static bool ValidateSeedLine(string line)
        {
            if (line.Length == columnCount && line.All(c => c == '.' || c == '*'))
            {
                return true;
            }
            Console.WriteLine("invalid data line");
            return false;
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
