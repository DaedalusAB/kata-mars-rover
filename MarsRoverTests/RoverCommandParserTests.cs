using MarsRover;
using MarsRover.Commands;
using MarsRover.Positioning;
using MarsRoverTests.Builders;
using Xunit;

namespace MarsRoverTests
{
    public class RoverCommandParserTests
    {
        [Fact]
        public void ParseForwardCommand()
        {
            var startingPosition = new PositionBuilder()
                .DefaultPosition()
                .Build();
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
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
            var startingPosition = new PositionBuilder()
                .DefaultPosition()
                .Build();
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
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

            var startingPosition = new PositionBuilder()
                .DefaultPosition()
                .Build();
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
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
            var startingPosition = new PositionBuilder()
                .DefaultPosition()
                .Build();
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverCommandParser = new RoverCommandParserBuilder()
                .ForRover(rover)
                .Build();

            var command = roverCommandParser.Parse('l');

            Assert.True(command is RoverCommandTurnLeft);
        }
    }
}
