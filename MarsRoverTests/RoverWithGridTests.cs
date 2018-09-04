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
            var grid = new Grid(5, 5);
            var startingPosition = new Position(4, 0, DirectionEnum.East, grid);
            var rover = new Rover(startingPosition);
            var roverControl = new RoverControl(rover);
            roverControl.SendCommands(new List<char>() { 'f' });
            roverControl.InvokeCommands();

            var positionAfterWrap = new Position(0, 0, DirectionEnum.East, grid);

            Assert.Equal(positionAfterWrap, rover.Position);

        }
    }
}
