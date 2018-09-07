using System;
using MarsRover.Positioning;

namespace MarsRoverConsole
{
    public static class GridExtensions
    {
        public static char[][] ToDisplayFormat(this Grid grid)
        {
            var display = new char[grid.Height][];

            for (var i = 0; i < grid.Height; i++)
            {
                display[i] = new char[grid.Width];

                for (var j = 0; j < grid.Width; j++)
                {
                    if (grid.HasObstacle(new Coordinates(j, i)))
                        display[i][j] = '#';
                    else
                        display[i][j] = ' ';
                }
            }

            return display;
        }

        public static void AddRandomObstacles(this Grid grid, int obstacleCount)
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            while (obstacleCount > 0)
            {
                var x = random.Next(0, grid.Width);
                var y = random.Next(0, grid.Height);
                if (x == y && y == 0)
                {
                    continue;
                }

                obstacleCount--;
                grid.AddObstacle(new Coordinates(x, y));
            }
        }
    }
}
