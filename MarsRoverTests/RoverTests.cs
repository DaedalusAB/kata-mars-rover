using System.Collections.Generic;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {
        private PositionBuilder PositionBuilder { get; } = new PositionBuilder();

        private RoverBuilder RoverBuilder { get; } = new RoverBuilder();

        [Theory]
        [InlineData(0, 0, DirectionEnum.North)]
        public void CreateRoverAtPosition(int x, int y, DirectionEnum direction)
        {
            var initialPosition = PositionBuilder
                .At(x, y)
                .Facing(direction)
                .Build();

            var rover = RoverBuilder
                .AtPosition(initialPosition)
                .Build();

            Assert.Equal(initialPosition, rover.Position);
        }
    }
}
