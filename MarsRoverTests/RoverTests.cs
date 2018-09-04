using System.Collections.Generic;
using System.Linq;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {

        [Fact]
        public void CreateRoverWithDefaultPosition()
        {
            var rover = new Rover();
            var defaultPosition = new Position(0, 0, DirectionEnum.North);

            Assert.Equal(defaultPosition, rover.Position);
        }

        [Fact]
        public void CreateRoverAtPosition()
        {
            var position = new Position(1, 1, DirectionEnum.North);
            var rover = new Rover(position);

            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void RoverReceievesCommands()
        {
            var commands = new List<char>() { 'f', 'f', 'b' };
            var rover = new Rover();
            rover.SendCommands(commands);

            Assert.True(rover.Commands.SequenceEqual(commands));
        }

        [Fact]
        public void RoverReceievesAdditionalCommands()
        {
            var initialCommands = new List<char>() { 'f', 'b', 'b' };
            var additionalCommands = new List<char>() { 'b', 'f', 'b' };

            var rover = new Rover();
            rover.SendCommands(initialCommands);
            rover.SendCommands(additionalCommands);

            var allCommands = initialCommands.Concat(additionalCommands);

            Assert.True(rover.Commands.SequenceEqual(allCommands));
        }
    }
}
