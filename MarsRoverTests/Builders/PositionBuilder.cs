using MarsRover.Positioning;

namespace MarsRoverTests.Builders
{
    public class PositionBuilder
    {
        private Position _position;

        public PositionBuilder DefaultPosition()
        {
            _position = new Position(0, 0, DirectionEnum.North, new Grid(2, 2));
            return this;
        }

        public PositionBuilder OnGrid(Grid grid)
        {
            _position = new Position(0, 0, DirectionEnum.North, grid);
            return this;
        }

        public PositionBuilder WithCoordinates(Coordinates coordinates)
        {
            _position.Coordinates = coordinates;
            return this;
        }

        public PositionBuilder Facing(DirectionEnum direction)
        {
            _position.Direction = new Direction(direction);
            return this;
        }

        public Position Build()
        {
            return _position;
        }
    }
}
