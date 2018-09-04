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

            var allCommands = initialCommands.Concat(additionalCommands);

            Assert.True(rover.Commands.SequenceEqual(allCommands));
        }

        [Theory]
        [MemberData(nameof(MoveForwardCases))]
        public void RoverMovesForward(Position position1, Position position2)
        {
            var rover = new Rover(position1);
            rover.MoveForward();

            Assert.Equal(position2, rover.Position);
        }

        [Theory]
        [MemberData(nameof(MoveForwardCases))]
        public void RoverMovesBackwards(Position position2, Position position1)
        {
            var rover = new Rover(position1);
            rover.MoveBackward();

            Assert.Equal(position2, rover.Position);
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

        public static IEnumerable<object[]> MoveForwardCases()
        {
            yield return new object[] { new Position(0, 0, DirectionEnum.East), new Position(1, 0, DirectionEnum.East) };
            yield return new object[] { new Position(0, 0, DirectionEnum.North), new Position(0, 1, DirectionEnum.North) };
            yield return new object[] { new Position(1, 0, DirectionEnum.West), new Position(0, 0, DirectionEnum.West) };
            yield return new object[] { new Position(0, 1, DirectionEnum.South), new Position(0, 0, DirectionEnum.South) };
        }
    }
}
