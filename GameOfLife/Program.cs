using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Program
    {
        public static bool[,] grid;
        private static int _rowCount;
        private static int _columnCount;

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
            for (int i = 0; i < _rowCount; i++)
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
        public static void SetLivingCell(int x, int y)
        {
            grid[x, y] = true;
        }
        public static void SetDeadCell(int x, int y)
        {
            grid[x, y] = false;
        }
        public static int CountAdjacentLivingCells(int x, int y)
        {
            int livingCells = 0;

            if (IsInTheGrid(x, y))
            {
                var listOfCoordinatesToCheck = new (int, int)[]
                {
                    (x-1, y-1),
                    (x-1, y),
                    (x-1, y+1),
                    (x, y-1),
                    (x+1, y-1),
                    (x+1, y),
                    (x+1, y+1),
                    (x, y+1)
                };
                foreach(var coordinate in listOfCoordinatesToCheck)
                {
                    if (IsInTheGrid(coordinate.Item1, coordinate.Item2) && IsAlive(coordinate.Item1, coordinate.Item2))
                    {
                        livingCells++;
                    }
                }


            }

            return livingCells;
        }
        public static bool IsAlive(int x, int y)
        {
            return grid[x,y] == true;
        }

        public static bool IsDead(int x, int y)
        {
            return grid[x,y] == false;
        }
        public static int CountLivingCells()
        {
            int nbOfLivingCells = 0;
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    if (grid[i, j]) nbOfLivingCells++;
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
            grid = new bool[_rowCount, _columnCount];
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    grid[i, j] = false;
                }
            }
        }
        public static bool ValidateSeedLine(string line)
        {
            if (line.Length == _columnCount && line.All(c => c == '.' || c == '*'))
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
                int.TryParse(sizeArray[0], out _rowCount) &&
                int.TryParse(sizeArray[1], out _columnCount))
            {

                return true;
            }
            return false;
        }
        private static void DisplayGrid()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    if (j != 0 && j < _columnCount)
                    {
                        Console.Write(' ');
                    }
                    Console.Write((grid[i, j]) ? '*' : '-');
                }
                Console.WriteLine();
            }
        }
        private static bool IsInTheGrid(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _rowCount && y < _columnCount;
        }
    }
}
