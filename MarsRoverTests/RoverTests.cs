using Xunit;

using MarsRover;
using MarsRoverTests.Builders;

namespace MarsRoverTests
{
    public class RoverTests
    {
        [Fact]
        public void CreateRoverAtPosition()
        {
            var position = new PositionBuilder()
                .DefaultPosition()
                .Build();

            var rover = new Rover(position);

            Assert.Equal(position, rover.Position);
        }
    }
}
