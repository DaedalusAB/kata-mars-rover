using MarsRover;
using MarsRover.Commands;
using Xunit;

namespace MarsRoverTests
{
    public class RoverCommandParserTests
    {
        [Fact]
        public void ParseForwardCommand()
        {
            var rover = new Rover();
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('f');

            Assert.True(command is RoverCommandForward);
        }

        [Fact]
        public void ParseBackwardsCommand()
        {
            var rover = new Rover();
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('B');

            Assert.True(command is RoverCommandBackwards);
        }

        [Fact]
        public void ParseTurnRightCommand()
        {
            var rover = new Rover();
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('r');

            Assert.True(command is RoverCommandTurnRight);
        }

        [Fact]
        public void ParseTurnLeftCommand()
        {
            var rover = new Rover();
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('l');

            Assert.True(command is RoverCommandTurnLeft);

        }
    }
}
