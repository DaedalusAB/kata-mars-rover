using System.Collections.Generic;
using System.Linq;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {
        private PositionBuilder PositionBuilder => new PositionBuilder();

        private RoverBuilder RoverBuilder => new RoverBuilder();

        [Theory]
        [InlineData(0, 0, DirectionEnum.North)]
        [InlineData(1, 2, DirectionEnum.South)]
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

        [Theory]
        [InlineData("fblr")]
        [InlineData("FBLR")]
        public void RoverReceievesCommands(string commands)
        {
            var rover = RoverBuilder
                .ARover()
                .Build();

            rover.ReceiveCommands(commands);

            Assert.True(commands.GetCommands().SequenceEqual(rover.Commands));
        }
    }
}
