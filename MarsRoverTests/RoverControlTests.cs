using System.Collections.Generic;
using System.Linq;
using MarsRover;
using MarsRover.Commands;
using MarsRover.Positioning;
using Xunit;

namespace MarsRoverTests
{
    public class RoverControlTests
    {
        [Fact]
        public void RoverReceievesCommands()
        {
            var rover = new Rover();
            var commands = new List<char>() { 'f', 'b' };
            var roverControl = new RoverControl(rover);
            roverControl.SendCommands(commands);
            
            Assert.Equal(2, roverControl.Commands.Count);
            Assert.True(roverControl.Commands.Any(command => command is RoverCommandForward));
            Assert.True(roverControl.Commands.Any(command => command is RoverCommandBackwards));
        }

        [Theory]
        [MemberData(nameof(RoverMovesForwardCases))]
        public void RoverMovesForward(Position startingPosition, Position positionAfterMovement)
        {
            var rover = new Rover(startingPosition);
            var roverControl = new RoverControl(rover);

            roverControl.SendCommands(new List<char>() { 'f' });
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterMovement, rover.Position);
        }


        [Theory]
        [MemberData(nameof(RoverMovesBackwardsCases))]
        public void RoverMovesBackwards(Position startingPosition, Position positionAfterMovement)
        {
            var rover = new Rover(startingPosition);
            var roverControl = new RoverControl(rover);

            roverControl.SendCommands(new List<char>() { 'b' });
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterMovement, rover.Position);
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
