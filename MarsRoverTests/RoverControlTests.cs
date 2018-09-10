using System.Collections.Generic;
using Xunit;

using MarsRover.Commands;
using MarsRover.Positioning;
using MarsRoverTests.Builders;

namespace MarsRoverTests
{
    public class RoverControlTests
    {
        [Fact]
        public void RoverReceievesCommands()
        {
            var rover = new RoverBuilder()
                .AtDefaultPosition()
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();

            roverControl.SendCommands("fblr");

            Assert.Equal(4, roverControl.Commands.Count);
            Assert.Contains(roverControl.Commands, command => command is RoverCommandForward);
            Assert.Contains(roverControl.Commands, command => command is RoverCommandBackwards);
            Assert.Contains(roverControl.Commands, command => command is RoverCommandTurnLeft);
            Assert.Contains(roverControl.Commands, command => command is RoverCommandTurnRight);
        }

        [Theory]
        [MemberData(nameof(RoverMovesForwardCases))]
        public void RoverMovesForward(Position startingPosition, Position positionAfterMovement)
        {
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();


            roverControl.SendCommands("f");
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterMovement, rover.Position);
        }

        [Theory]
        [MemberData(nameof(RoverMovesBackwardsCases))]
        public void RoverMovesBackwards(Position startingPosition, Position positionAfterMovement)
        {
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();

            roverControl.SendCommands("B");
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterMovement, rover.Position);
        }

        public static IEnumerable<object[]> RoverMovesForwardCases()
        {
            yield return new object[] {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.North), new Grid(2, 2)),
                new Position(new Coordinates(0, 1), new Direction(DirectionEnum.North), new Grid(2, 2))
            };
            yield return new object[] {
                new Position(new Coordinates(0, 1),  new Direction(DirectionEnum.South), new Grid(2, 2)),
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.South), new Grid(2, 2))

            };
            yield return new object[] {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.East), new Grid(2, 2)),
                new Position(new Coordinates(1, 0),  new Direction(DirectionEnum.East), new Grid(2, 2))
            };
            yield return new object[] {
                new Position(new Coordinates(1, 0),  new Direction(DirectionEnum.West), new Grid(2, 2)),
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.West), new Grid(2, 2))

            };
        }

        public static IEnumerable<object[]> RoverMovesBackwardsCases()
        {
            yield return new object[] {
                new Position(new Coordinates(0, 1), new Direction(DirectionEnum.North), new Grid(2, 2)),
                new Position(new Coordinates(0, 0), new Direction(DirectionEnum.North), new Grid(2, 2))

            };
            yield return new object[] {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.South), new Grid(2, 2)),
                new Position(new Coordinates(0, 1),  new Direction(DirectionEnum.South), new Grid(2, 2))
            };
            yield return new object[] {
                new Position(new Coordinates(1, 0),  new Direction(DirectionEnum.East), new Grid(2, 2)),
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.East), new Grid(2, 2))
            };
            yield return new object[] {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.West), new Grid(2, 2)),
                new Position(new Coordinates(1, 0),  new Direction(DirectionEnum.West), new Grid(2, 2))
            };
        }
    }
}
