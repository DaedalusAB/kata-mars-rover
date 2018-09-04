using MarsRover;
using MarsRover.Positioning;

namespace MarsRoverTests.Builders
{
    public class RoverBuilder
    {
        private Rover _rover;
        
        public RoverBuilder AtDefaultPosition()
        {
            _rover = new Rover(new Position(0, 0, DirectionEnum.North, new Grid(2 ,2)));
            return this;
        }

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
