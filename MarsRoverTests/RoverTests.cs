using MarsRover;
using MarsRover.Positioning;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {
        [Fact]
        public void CreateRoverAtPosition()
        {
            var grid = new Grid(1, 1);
            var position = new Position(1, 1, DirectionEnum.North, grid);
            var rover = new Rover(position);

            Assert.Equal(position, rover.Position);
        }
    }
}
