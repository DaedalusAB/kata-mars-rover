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

        [Theory]
        [MemberData(nameof(InitRoverCase))]
        public void CreateRoverAtPosition(Position position)
        {
            var rover = new Rover(position);

            Assert.Equal(position, rover.Position);
        }

        [Theory]
        [MemberData(nameof(ExampleCommands))]
        public void RoverReceievesCommands(List<char> commands)
        {
            var rover = new Rover();
            rover.SendCommands(commands);

            Assert.True(rover.Commands.SequenceEqual(commands));
        }

        [Theory]
        [MemberData(nameof(DoubleCommands))]
        public void RoverReceievesAdditionalCommands(List<char> initialCommands, List<char> additionalCommands)
        {
            var rover = new Rover();
            rover.SendCommands(initialCommands);
            rover.SendCommands(additionalCommands);

            initialCommands.AddRange(additionalCommands);

            Assert.True(rover.Commands.SequenceEqual(initialCommands));
        }

        public static IEnumerable<object[]> InitRoverCase()
        {
            yield return new object[] { new Position(0, 0, DirectionEnum.North) };
            yield return new object[] { new Position(1, 5, DirectionEnum.East) };
        }

        public static IEnumerable<object[]> ExampleCommands()
        {
            yield return new object[] { new List<char>() { 'f' } };
            yield return new object[] { new List<char>() { 'f', 'b', 'f', 'f' } };
        }

        public static IEnumerable<object[]> DoubleCommands()
        {
            yield return new object[] { new List<char>() { 'f' }, new List<char>() { 'f' } };
            yield return new object[] { new List<char>() { 'f', 'b' }, new List<char>() { 'b', 'f' } };
        }
    }
}
