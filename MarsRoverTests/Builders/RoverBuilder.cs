using MarsRover;
using MarsRover.Positioning;

namespace MarsRoverTests.Builders
{
    public class RoverBuilder
    {
        private Rover _rover;

        public RoverBuilder AtPosition(Position position)
        {
            _rover = new Rover(position);
            return this;
        }

        public Rover Build()
        {
            return _rover;
        }
    }
}
