using System.Collections.Generic;
using MarsRover;

namespace MarsRoverTests
{
    public class GridBuilder
    {
        private int _width;
        private int _hegiht;
        private readonly ISet<Coordinates> _obstacles = new HashSet<Coordinates>();

        public GridBuilder Width(int width)
        {
            _width = width;
            return this;
        }

        public GridBuilder Height(int height)
        {
            _hegiht = height;
            return this;
        }

        public GridBuilder ObstacleAt(int x, int y)
        {
            _obstacles.Add(new Coordinates(x, y));
            return this;
        }

        public Grid Build()
        {
            return new Grid(_width, _hegiht, _obstacles);
        }
    }
}