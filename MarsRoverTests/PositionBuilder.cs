using MarsRover;

namespace MarsRoverTests
{
    public class PositionBuilder
    {
        private Coordinates _coordinates = new Coordinates(0, 0);
        private Direction _direction = new Direction(DirectionEnum.North);

        public PositionBuilder At(int x, int y)
        {
            _coordinates = new Coordinates(x, y);
            return this;
        }

        public PositionBuilder Facing(DirectionEnum direction)
        {
            _direction = new Direction(direction);
            return this;
        }

        public Position Build()
        {
            return new Position(_coordinates, _direction);
        }
    }
}