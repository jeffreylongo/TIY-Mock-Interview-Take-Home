using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = 29;
            var cols = 100;
            var stillPlaying = true;

            var seedMatrix = Services.GenerateSeed(rows, cols);

            //Create our new grid
            var newGrid = Grid.CreateTheGrid(seedMatrix);
            //Create the next gen grid
            var nextGenGrid = Grid.GetNextGenGrid(newGrid);

            //show welcome message
            Services.WelcomeMessage();
            //prompt for user input to start. 
            Console.ReadKey();

            //Show the current grid
            Grid.showGrid(newGrid);

            //make a loop so we dont have to keep creating variables and showing them. 
            while (stillPlaying == true)
            {
                var input = Console.ReadLine();
                //lets make a way out. 
                if (input.ToLower() == "q")
                {
                    stillPlaying = false;
                }
                Grid.showGrid(nextGenGrid);
                var nxt = Grid.GetNextGenGrid(nextGenGrid);
                Grid.showGrid(nxt);
                nextGenGrid = nxt;

            }
        }
    }
}
