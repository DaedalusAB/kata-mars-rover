using MarsRover;
using MarsRover.Commands;
using MarsRover.Positioning;
using Xunit;

namespace MarsRoverTests
{
    public class RoverCommandParserTests
    {
        [Fact]
        public void ParseForwardCommand()
        {
            var startingPosition = new Position(0, 0, DirectionEnum.East, new Grid(2, 2));
            var rover = new Rover(startingPosition);
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('f');

            Assert.True(command is RoverCommandForward);
        }

        [Fact]
        public void ParseBackwardsCommand()
        {
            var startingPosition = new Position(0, 0, DirectionEnum.East, new Grid(2, 2));
            var rover = new Rover(startingPosition);
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('B');

            Assert.True(command is RoverCommandBackwards);
        }

        [Fact]
        public void ParseTurnRightCommand()
        {
            var startingPosition = new Position(0, 0, DirectionEnum.East, new Grid(2, 2));
            var rover = new Rover(startingPosition);
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('r');

            Assert.True(command is RoverCommandTurnRight);
        }

        [Fact]
        public void ParseTurnLeftCommand()
        {
            var startingPosition = new Position(0, 0, DirectionEnum.East, new Grid(2, 2));
            var rover = new Rover(startingPosition);
            var roverCommandParser = new RoverCommandParser(rover);
            var command = roverCommandParser.Parse('l');

            Assert.True(command is RoverCommandTurnLeft);

        }
    }
}
