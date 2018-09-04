using System.Collections.Generic;
using MarsRover;
using MarsRover.Positioning;
using Xunit;

namespace MarsRoverTests
{
    public class PositionTests
    {
        [Fact]
        public void CompareSamePositions()
        {
            var position1 = new Position(1, 1, DirectionEnum.East);
            var position2 = new Position(1, 1, DirectionEnum.East);

            Assert.Equal(position2, position1);
        }

        [Fact]
        public void CompareDifferentPositions()
        {
            var position1 = new Position(1, 1, DirectionEnum.West);
            var position2 = new Position(1, 1, DirectionEnum.South);

            Assert.NotEqual(position2, position1);
        }
    }
}
