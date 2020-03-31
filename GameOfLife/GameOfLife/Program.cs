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
            for (int k = 0; k < startNum; k++)
            {
                int pattern = randomize.Next(1, 10);
                int x = randomize.Next(1, grid.GetLength(0) - 1);
                int y = randomize.Next(1, grid.GetLength(1) - 1);

                try
                {

                    switch (pattern)
                    {
                        case 1: 
                            {
                                Boat(grid, x, y);
                                break;
                            }
                        case 2:
                            {
                                Loaf(grid, x, y);
                                break;
                            }
                        case 3:
                            {
                                Square(grid, x, y);
                                break;
                            }
                        case 4:
                            {
                                Tub(grid, x, y);
                                break;
                            }
                        case 5:
                            {
                                Blinker(grid, x, y);
                                break;
                            }
                        case 6:
                            {
                                Beacon(grid, x, y);
                                break;
                            }
                        case 7:
                            {
                                Toad(grid, x, y);
                                break;
                            }
                        case 8:
                            {
                                Glider(grid, x, y);
                                break;
                            }
                        case 9:
                            {
                                MWSS(grid, x, y);
                                break;
                            }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    startNum++;
                    continue;
                }
            }
        }

        static void Boat(bool[,] grid, int x,int y)
        {
            grid[x, y] = true;
            grid[x + 1, y] = true;
            grid[x, y + 1] = true;
            grid[x + 2, y + 1] = true;
            grid[x + 1, y + 2] = true;
        }
        
        static void Square(bool[,] grid, int x, int y)
        {
            grid[x, y] = true;
            grid[x + 1, y] = true;
            grid[x, y + 1] = true;
            grid[x + 1, y + 1] = true;
        }

        static void Loaf(bool[,] grid, int x, int y)
        {
            grid[x + 1, y] = true;
            grid[x + 2, y] = true;
            grid[x, y + 1] = true;
            grid[x + 3, y + 1] = true;
            grid[x + 2, y + 2] = true;
            grid[x, y + 2] = true;
            grid[x + 1, y +3] = true;
        }
        
        static void Tub(bool[,] grid, int x, int y)
        {
            grid[x + 1, y] = true;
            grid[x, y + 1] = true;
            grid[x + 2, y + 1] = true;
            grid[x +1 , y + 2] = true;
        }

        static void Blinker(bool[,] grid, int x, int y)
        {
            grid[x -1, y] = true;
            grid[x, y] = true;
            grid[x + 1, y] = true;
        }

        static void Toad(bool[,] grid, int x, int y)
        {
            grid[x + 1, y] = true;
            grid[x + 2, y] = true;
            grid[x + 3, y] = true;
            grid[x, y + 1] = true;
            grid[x + 1, y + 1] = true;
            grid[x + 2, y + 1] = true;
        }

        static void Beacon(bool[,] grid, int x, int y)
        {
            Square(grid, x, y);
            Square(grid, x + 2, y + 2);
        }

        static void Glider(bool[,] grid, int x, int y)
        {
            grid[x + 1, y] = true;
            grid[x + 2, y + 1] = true;
            grid[x, y + 2] = true;
            grid[x + 1, y + 2] = true;
            grid[x + 2, y + 2] = true;
        }

        static void LWSS(bool[,] grid, int x, int y)
        {
            grid[x, y] = true;
            grid[x + 3, y] = true;
            grid[x + 4, y + 1] = true;
            grid[x, y + 2] = true;
            grid[x + 4 , y + 2] = true;
            grid[x + 1, y + 3] = true;
            grid[x + 2, y + 3] = true;
            grid[x +3 , y + 3] = true;
            grid[x + 4, y + 3] = true;
        }

        static void MWSS(bool[,] grid, int x, int y)
        {
            grid[x + 1, y] = true;
            grid[x + 2, y] = true;
            grid[x + 3, y] = true;
            grid[x + 4, y] = true;
            grid[x + 5, y] = true;
            grid[x, y + 1] = true;
            grid[x + 5, y + 1] = true;
            grid[x + 5, y + 2] = true;
            grid[x, y + 3] = true;
            grid[x + 4, y + 3] = true;
            grid[x + 2, y + 4] = true;
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
                Console.WriteLine("How big should the grid be in length ?"); // 210 for fullhd
                IsInt = int.TryParse(Console.ReadLine(), out gridX);
            } while (!IsInt);

            do
            {
                Console.WriteLine("How big should the grid be in width ?"); // 46 for fullhd
                IsInt = int.TryParse(Console.ReadLine(), out gridY);
            } while (!IsInt);

            bool[,] grid = new bool[gridX + 2, gridY + 2]; 

            do
            {
                Console.WriteLine("How many patterns you want to be generated ?");
                IsInt = int.TryParse(Console.ReadLine(), out startNum);
            } while (!IsInt || startNum < 0);

            RandomizeGrid(grid, startNum);

            int n = 1;
            while (n <= 1000)
            {
                printBoard(grid, generation);
                Thread.Sleep(10);
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