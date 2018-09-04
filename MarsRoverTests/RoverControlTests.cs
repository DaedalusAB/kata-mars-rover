using System.Collections.Generic;
using System.Linq;
using MarsRover;
using MarsRover.Commands;
using MarsRover.Positioning;
using MarsRoverTests.Builders;
using Xunit;

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

            var commands = new List<char>() { 'f', 'b' };
            roverControl.SendCommands(commands);
            
            Assert.Equal(2, roverControl.Commands.Count);
            Assert.Contains(roverControl.Commands, command => command is RoverCommandForward);
            Assert.Contains(roverControl.Commands, command => command is RoverCommandBackwards);
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

            roverControl.SendCommands(new List<char>() { 'f' });
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

            roverControl.SendCommands(new List<char>() { 'b' });
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterMovement, rover.Position);
        }

        public static IEnumerable<object[]> RoverMovesForwardCases()
        {
            yield return new object[] { new Position(0, 0, DirectionEnum.North, new Grid(2, 2)), new Position(0, 1, DirectionEnum.North, new Grid(2, 2)) };
            yield return new object[] { new Position(0, 1, DirectionEnum.South, new Grid(2, 2)), new Position(0, 0, DirectionEnum.South, new Grid(2, 2)) };
            yield return new object[] { new Position(0, 0, DirectionEnum.East, new Grid(2, 2)), new Position(1, 0, DirectionEnum.East, new Grid(2, 2)) };
            yield return new object[] { new Position(1, 0, DirectionEnum.West, new Grid(2, 2)), new Position(0, 0, DirectionEnum.West, new Grid(2, 2)) };
        }

        public static IEnumerable<object[]> RoverMovesBackwardsCases()
        {
            yield return new object[] { new Position(0, 1, DirectionEnum.North, new Grid(2, 2)), new Position(0, 0, DirectionEnum.North, new Grid(2, 2)) };
            yield return new object[] { new Position(0, 0, DirectionEnum.South, new Grid(2, 2)), new Position(0, 1, DirectionEnum.South, new Grid(2, 2)) };
            yield return new object[] { new Position(1, 0, DirectionEnum.East, new Grid(2, 2)), new Position(0, 0, DirectionEnum.East, new Grid(2, 2)) };
            yield return new object[] { new Position(0, 0, DirectionEnum.West, new Grid(2, 2)), new Position(1, 0, DirectionEnum.West, new Grid(2, 2)) };
        }
    }
}
