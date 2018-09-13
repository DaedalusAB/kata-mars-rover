using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }
        public ISet<Coordinates> Obstacles { get; }

        public Grid(int width, int height, ISet<Coordinates> obstacles)
        {
            Width = width;
            Height = height;
            Obstacles = obstacles;
        }

        public bool HasObstacleAt(Coordinates coordinatesToCheck)
        {
            return Obstacles.Any(o => o.Equals(coordinatesToCheck));
        }
    }
}