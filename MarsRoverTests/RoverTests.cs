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

        [Theory]
        [MemberData(nameof(RoverMovesForwardCases))]
        public void RoverMovesForward(Position startingPosition, Position positionAfterMovement)
        {
            var rover = new Rover(startingPosition);

            rover.MoveForward();

            Assert.Equal(positionAfterMovement, rover.Position);
        }

        [Theory]
        [MemberData(nameof(RoverMovesBackwardsCases))]
        public void RoverMovesBackwards(Position startingPosition, Position positionAfterMovement)
        {
            var rover = new Rover(startingPosition);

            rover.MoveBackwards();

            Assert.Equal(positionAfterMovement, rover.Position);
        }

        [Theory]
        [InlineData(DirectionEnum.North, DirectionEnum.East)]
        [InlineData(DirectionEnum.East, DirectionEnum.South)]
        [InlineData(DirectionEnum.South, DirectionEnum.West)]
        [InlineData(DirectionEnum.West, DirectionEnum.North)]
        public void RoverTurnsRight(DirectionEnum startingDirection, DirectionEnum directionAfterTurn)
        {
            var position = new Position(0, 0, startingDirection);
            var rover = new Rover(position);

            rover.TurnRight();

            Assert.Equal(directionAfterTurn, rover.Position.Direction.Value);
        }

        [Theory]
        [InlineData(DirectionEnum.North, DirectionEnum.West)]
        [InlineData(DirectionEnum.West, DirectionEnum.South)]
        [InlineData(DirectionEnum.South, DirectionEnum.East)]
        [InlineData(DirectionEnum.East, DirectionEnum.North)]
        public void RoverTurnsLeft(DirectionEnum startingDirection, DirectionEnum directionAfterTurn)
        {
            var position = new Position(0, 0, startingDirection);
            var rover = new Rover(position);

            rover.TurnLeft();

            Assert.Equal(directionAfterTurn, rover.Position.Direction.Value);
        }

        public static IEnumerable<object[]> RoverMovesForwardCases()
        {
            yield return new object[] { new Position(0, 0, DirectionEnum.North), new Position(0, 1, DirectionEnum.North) };
            yield return new object[] { new Position(0, 1, DirectionEnum.South), new Position(0, 0, DirectionEnum.South) };
            yield return new object[] { new Position(0, 0, DirectionEnum.East), new Position(1, 0, DirectionEnum.East) };
            yield return new object[] { new Position(1, 0, DirectionEnum.West), new Position(0, 0, DirectionEnum.West) };
        }

        public static IEnumerable<object[]> RoverMovesBackwardsCases()
        {
            yield return new object[] { new Position(0, 1, DirectionEnum.North), new Position(0, 0, DirectionEnum.North) };
            yield return new object[] { new Position(0, 0, DirectionEnum.South), new Position(0, 1, DirectionEnum.South) };
            yield return new object[] { new Position(1, 0, DirectionEnum.East), new Position(0, 0, DirectionEnum.East) };
            yield return new object[] { new Position(0, 0, DirectionEnum.West), new Position(1, 0, DirectionEnum.West) };
        }
    }
}
