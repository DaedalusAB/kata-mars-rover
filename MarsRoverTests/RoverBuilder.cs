using MarsRover;

namespace MarsRoverTests
{
    internal class RoverBuilder
    {
        private Position _position;

        public RoverBuilder ARover()
        {
            _position = new PositionBuilder()
                .At(0, 0)
                .Facing(DirectionEnum.North)
                .Build();

            return this;
        }

        public RoverBuilder AtPosition(Position initialPosition)
        {
            _position = initialPosition;

            return this;
        }

        public Rover Build()
        {
            return  new Rover(_position);
        }
    }
}