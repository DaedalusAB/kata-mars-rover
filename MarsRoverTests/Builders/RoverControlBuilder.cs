using MarsRover;

namespace MarsRoverTests.Builders
{
    public class RoverControlBuilder
    {
        private RoverControl _roverControl;

        public RoverControlBuilder ForRover(Rover rover)
        {
            _roverControl = new RoverControl(rover);
            return this;
        }

        public RoverControl Build()
        {
            return _roverControl;
        }
    }
}
