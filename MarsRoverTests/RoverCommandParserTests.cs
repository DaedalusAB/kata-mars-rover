using Xunit;

using MarsRover.Commands;
using MarsRoverTests.Builders;

namespace MarsRoverTests
{
    public class RoverCommandParserTests
    {
        [Fact]
        public void ParseForwardCommand()
        {
            var rover = new RoverBuilder()
                .AtDefaultPosition()
                .Build();
            var roverCommandParser = new RoverCommandParserBuilder()
                .ForRover(rover)
                .Build();

            var command = roverCommandParser.Parse('f');

            Assert.True(command is RoverCommandForward);
        }

        [Fact]
        public void ParseBackwardsCommand()
        {
            var rover = new RoverBuilder()
                .AtDefaultPosition()
                .Build();
            var roverCommandParser = new RoverCommandParserBuilder()
                .ForRover(rover)
                .Build();

            var command = roverCommandParser.Parse('B');

            Assert.True(command is RoverCommandBackwards);
        }

        [Fact]
        public void ParseTurnRightCommand()
        {

            var rover = new RoverBuilder()
                .AtDefaultPosition()
                .Build();
            var roverCommandParser = new RoverCommandParserBuilder()
                .ForRover(rover)
                .Build();

            var command = roverCommandParser.Parse('r');

            Assert.True(command is RoverCommandTurnRight);
        }

        [Fact]
        public void ParseTurnLeftCommand()
        {
            var rover = new RoverBuilder()
                .AtDefaultPosition()
                .Build();
            var roverCommandParser = new RoverCommandParserBuilder()
                .ForRover(rover)
                .Build();

            var command = roverCommandParser.Parse('l');

            Assert.True(command is RoverCommandTurnLeft);
        }
    }
}
