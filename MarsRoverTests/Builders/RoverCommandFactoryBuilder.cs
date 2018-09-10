using MarsRover;

namespace MarsRoverTests.Builders
{
    public class RoverCommandFactoryBuilder
    {
        private RoverCommandParser _parser;

        public RoverCommandFactoryBuilder ForRover(Rover rover)
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
