using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Positioning
{
    public class Grid
    {
        public int Height { get; }
        public int Width { get; }
        public List<Coordinates> Obstacles { get; }

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            Obstacles = new List<Coordinates>();
        }

        public void AddObstacle(Coordinates coordinates) =>
            Obstacles.Add(coordinates);


        public bool HasObstacle(Coordinates coordinates) =>
            Obstacles.Any(o => o.Equals(coordinates));

    }
}
