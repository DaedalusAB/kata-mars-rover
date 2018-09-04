using MarsRover;
using MarsRover.Positioning;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {
        [Fact]
        public void CreateRoverWithDefaultPosition()
        {
            var rover = new Rover(new Grid(1, 1));
            var defaultPosition = new Position(0, 0, DirectionEnum.North);

            Assert.Equal(defaultPosition, rover.Position);
        }

        [Fact]
        public void CreateRoverAtPosition()
        {
            var position = new Position(1, 1, DirectionEnum.North);
            var rover = new Rover(new Grid(1, 1), position);

            Assert.Equal(position, rover.Position);
        }
    }
}
