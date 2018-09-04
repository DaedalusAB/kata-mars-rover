using MarsRover.Positioning;

namespace MarsRoverTests.Builders
{
    public class GridBuilder
    {
        private Grid _grid;

        public GridBuilder WithDimensions(int height, int width)
        {
            _grid = new Grid(height, width);
            return this;
        }

        public GridBuilder WithObstacleAt(int x, int y)
        {
            _grid.AddObstacle(new Coordinates(x, y));
            return this;
        }

        public Grid Build()
        {
            return _grid;
        }

    }
}
