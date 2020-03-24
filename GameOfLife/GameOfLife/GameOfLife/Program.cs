using System;
using System.Threading;

namespace Program
{
    class Program
    {
        static int aliveNeighbours(int x, int y, bool[,] grid)
        {
            int aliveNeighbours = 0;
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (grid[j, i] == true)
                    {
                        if (i == y && x == j) aliveNeighbours--;
                        aliveNeighbours++;
                    }
                }
            }
            return aliveNeighbours;
        }

        static int aliveCells(bool[,] grid)
        {
            int aliveCells = 0;
            for (int i = 1; i <= grid.GetLength(1) - 2; i++)
            {
                for (int j = 1; j <= grid.GetLength(0) - 2; j++)
                {
                    if (grid[j, i] == true)
                    {
                        aliveCells++;
                    }
                }

            }

            return aliveCells;
        }

        static void RandomizeGrid(bool[,] grid, int startNum)
        {
            Random randomize = new Random();
            for (int i = 1; i < startNum; i++)
            {
                int x = randomize.Next(1, grid.GetLength(0) - 1);
                int y = randomize.Next(1, grid.GetLength(1) - 1);

                grid[x, y] = true;

            }
        }
        static void NextGeneration(bool[,] grid, ref int generation)
        {

            bool[,] tempGrid = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 1; i <= grid.GetLength(1) - 2; i++)
            {
                for (int j = 1; j <= grid.GetLength(0) - 2; j++)
                {
                    tempGrid[j, i] = grid[j, i];
                }

            }

            for (int i = 1; i <= grid.GetLength(1) - 2; i++)
            {
                for (int j = 1; j <= grid.GetLength(0) - 2; j++)
                {
                    grid[j, i] = aliveNeighbours(j, i, tempGrid) == 2 ? tempGrid[j, i] : (aliveNeighbours(j, i, tempGrid) == 3 ? true : false);
                }
            }
            generation++;
        }

        static void printBoard(bool[,] grid, int generation)
        {
            Console.WriteLine($"Generation {generation}");
            Console.WriteLine($"Alive cells: {aliveCells(grid)}");
            for (int i = 1; i <= grid.GetLength(1) - 2; i++)
            {
                for (int j = 1; j <= grid.GetLength(0) - 2; j++)
                {
                    Console.Write(grid[j, i] ? "X" : ".");
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int gridX, gridY;         // sizes of grid
            int generation = 1;       // Generation counter (increases in NextGeneration)
            int startNum;             // Starting number of alive cells
            bool IsInt = false;       // For checking is startNum integer number

            Console.WriteLine("Welcome to Convay’s Game of Life!");

            do
            {
                Console.WriteLine("How big should the grid be in length ?");
                IsInt = int.TryParse(Console.ReadLine(), out gridX);
            } while (!IsInt);

            do
            {
                Console.WriteLine("How big should the grid be in width ?");
                IsInt = int.TryParse(Console.ReadLine(), out gridY);
            } while (!IsInt);

            bool[,] grid = new bool[gridX + 2, gridY + 2];

            do
            {
                Console.WriteLine("How many alive cells you want to be generated ?");
                IsInt = int.TryParse(Console.ReadLine(), out startNum);
            } while (!IsInt || startNum < 0);

            RandomizeGrid(grid, startNum);

            int n = 1;
            while (n <= 1000)
            {
                printBoard(grid, generation);
                Thread.Sleep(50);
                if (aliveCells(grid) == 0)
                {
                    Console.WriteLine("No more cells are alive");
                    break;
                }
                Console.Clear();
                NextGeneration(grid, ref generation);
                n++;
            }
        }
    }
}