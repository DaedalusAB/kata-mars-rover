using MarsRover;

namespace MarsRoverTests
{
    internal class RoverBuilder
    {
        private Position _position;

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