using System.Collections.Generic;
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

        [Theory]
        [MemberData(nameof(InitRoverCase))]
        public void CreateRoverAtPosition(Position position)
        {
            var rover = new Rover(position);

            Assert.Equal(position, rover.Position);
        }

        [Theory]
        [InlineData("F")]
        public void RoverReceievesCommands(string commands)
        {
            var rover = new Rover();
            rover.SendCommands(commands);

            Assert.Equal(commands, rover.Commands);
        }

        [Theory]
        [InlineData("F", "FFB")]
        public void RoverReceievesAdditionalCommands(string initialCommands, string additionalCommands)
        {
            var rover = new Rover();
            rover.SendCommands(initialCommands);
            rover.SendCommands(additionalCommands);

            Assert.Equal(initialCommands + additionalCommands, rover.Commands);
        }

        public static IEnumerable<object[]> InitRoverCase()
        {
            yield return new object[] { new Position(0, 0, DirectionEnum.North) };
            yield return new object[] { new Position(1, 5, DirectionEnum.East) };
        }
    }
}
