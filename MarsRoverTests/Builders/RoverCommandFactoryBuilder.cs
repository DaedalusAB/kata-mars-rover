using MarsRover;

namespace MarsRoverTests.Builders
{
    public class RoverCommandFactoryBuilder
    {
        private RoverCommandFactory _parser;

        public RoverCommandFactoryBuilder ForRover(Rover rover)
        {
            _parser = new RoverCommandFactory(rover);
            return this;
        }

        public RoverCommandFactory Build()
        {
            return _parser;
        }
    }
}
