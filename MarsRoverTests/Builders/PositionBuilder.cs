using MarsRover.Positioning;

namespace MarsRoverTests.Builders
{
    public class PositionBuilder
    {
        private Coordinates _coordinates;
        private Direction _direction;
        private Grid _grid;

        public PositionBuilder DefaultPosition()
        {
            _coordinates = new Coordinates(0, 0);
            _direction = new Direction(DirectionEnum.North);
            _grid = new Grid(2, 2);

            return this;
        }

        public PositionBuilder OnGrid(Grid grid)
        {
            _grid = grid;
            return this;
        }

        public PositionBuilder WithCoordinates(Coordinates coordinates)
        {
            _coordinates = coordinates;
            return this;
        }

        public PositionBuilder Facing(DirectionEnum direction)
        {
            _direction = new Direction(direction);
            return this;
        }

        public Position Build()
        {
            return new Position(_coordinates, _direction, _grid);
        }
    }
}
