using MarsRover;
using MarsRover.Commands;

namespace MarsRoverTests.Builders
{
    public class RoverCommandParserBuilder
    {
        private RoverCommandParser _parser;

        public RoverCommandParserBuilder ForRover(Rover rover)
        {
            _parser = new RoverCommandParser(rover);
            return this;
        }

        public RoverCommandParser Build()
        {
            return _parser;
        }
    }
}
