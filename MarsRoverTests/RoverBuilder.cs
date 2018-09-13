using MarsRover;

namespace MarsRoverTests
{
    internal class RoverBuilder
    {
        private Position _position;

        public RoverBuilder ARover()
        {
            _position = new PositionBuilder()
                .Build();

            return this;
        }

        public RoverBuilder AtPosition(Position position)
        {
            _position = position;

            return this;
        }

        public Rover Build()
        {
            return  new Rover(_position);
        }
    }
}