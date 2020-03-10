using System;

namespace Program
{
    class Program
    {

        static int alive(int x, int y, bool[,] grid)
        {
            int alivenum = 0;
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (grid[j, i] == true)
                    {
                        if (i == y && x == j) alivenum--;
                        alivenum++;
                    }
                }
            }
            return alivenum;
        }
        static void NextGeneration(bool[,] grid)
        {

            bool[,] tempGrid = new bool[22, 22];

            for (int i = 1; i <= 20; i++)
            {
                for (int j = 1; j <= 20; j++)
                {
                    tempGrid[j, i] = grid[j, i];
                }

            }

            for (int i = 1; i <= 20; i++)
            {
                for (int j = 1; j <= 20; j++)
                {
                    grid[j, i] = alive(j, i, tempGrid) == 2 ? tempGrid[j, i] : (alive(j, i, tempGrid) == 3 ? true : false);
                }
            }
        }

        static void printBoard(bool[,] grid)
        {
            for (int i = 1; i <= 20; i++)
            {
                for (int j = 1; j <= 20; j++)
                {
                    Console.Write(grid[j, i] ? "X" : ".");
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Convay’s Game of Life!");
            bool[,] grid = new bool[22, 22]; // GAME BOARD 20x20 WITH EXTRA LAYER ON EACH SIDE (INPUT ONLY NUMBERS 1-20)

            grid[2, 1] = true;
            grid[3, 2] = true;
            grid[1, 3] = true;
            grid[2, 3] = true;
            grid[3, 3] = true;
            Console.WriteLine();

            int n = 1;

            while (n <= 100)
            {
                printBoard(grid);
                NextGeneration(grid);
                n++;
            }

        }
    }
}