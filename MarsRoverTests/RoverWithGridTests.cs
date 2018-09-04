using System.Collections.Generic;
using MarsRover;
using MarsRover.Positioning;
using Xunit;

namespace MarsRoverTests
{
    public class RoverWithGridTests
    {
        [Fact]
        public void RoverWrapsGridToTheRight()
        {
            var startingPosition = new Position(4, 0, DirectionEnum.East);
            var grid = new Grid(5, 5);
            var rover = new Rover(grid, startingPosition);
            var roverControl = new RoverControl(rover);
            roverControl.SendCommands(new List<char>() { 'f' });
            roverControl.InvokeCommands();

            var positionAfterWrap = new Position(0, 0, DirectionEnum.East);

            Assert.Equal(positionAfterWrap, rover.Position);

        }
    }
}
