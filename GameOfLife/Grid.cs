using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Grid
    {
        //Create a Grid for the data
        public static int[,] CreateTheGrid(int[,] seedData)
        {
            var rows = seedData.GetUpperBound(0) + 1;
            var columns = seedData.GetUpperBound(1) + 1;
            var grid = new int[rows, columns];

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    grid[row, column] = seedData[row, column];
                }
            }
            return grid;
        }

        //Figure out what cells are alive
        public static int GetLiveNeighborCell(int[,] grid, int row, int col)
        {
            var total = 0;
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if (grid[row + i, col + j] == 1)
                    {
                        total++;
                    }
                }
            }
            return grid[row, col] == 1 ? total - 1 : total;
        }

        //generate the next grid depending on the layout of the grid
        public static int[,] GetNextGenGrid(int[,] grid)
        {
            var gridRows = grid.GetUpperBound(0);
            var gridCols = grid.GetUpperBound(1);
            var nextGrid = new int[gridRows + 1, gridCols + 1];

            for (int i = 1; i < gridRows; i++)
            {
                for (int j = 1; j < gridCols; j++)
                {
                    var liveNeighbors = Grid.GetLiveNeighborCell(grid, i, j);

                    if (grid[i, j] == 1)
                    {
                        nextGrid[i, j] = liveNeighbors == 2 || liveNeighbors == 3 ? 1 : 0;
                    }
                    else
                    {
                        nextGrid[i, j] = liveNeighbors == 3 ? 1 : 0;
                    }
                }
            }
            return nextGrid;
        }

        //Actually Display the Grid
        public static void showGrid(int[,] grid)
        {
            var rowCount = grid.GetUpperBound(0);
            var colCount = grid.GetUpperBound(1);

            for (int i = 0; i <= rowCount; i++)
            {
                for (int j = 0; j <= colCount; j++)
                {
                    Console.Write(grid[i, j] == 0 ? "0" : "1");
                }
                Console.Write("0");
                Console.WriteLine("");
            }
        }
    }
}
