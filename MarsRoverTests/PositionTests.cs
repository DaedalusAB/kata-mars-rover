using System.Collections.Generic;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class PositionTests
    {
        [Fact]
        public void CompareSamePositions()
        {
            var position1 = new Position(1, 1, Direction.EAST);
            var position2 = new Position(1, 1, Direction.EAST);

            Assert.Equal(position2, position1);
        }

        [Fact]
        public void CompareDifferentPositions()
        {
            var position1 = new Position(1, 1, Direction.WEST);
            var position2 = new Position(1, 1, Direction.SOUTH);

            Assert.NotEqual(position2, position1);
        }

        [Theory]
        [MemberData(nameof(CoordinatesInFrontCases))]
        public void GetCoordinatesInFront(Position position, Coordinates coordinatesInFront)
        {
            Assert.True(position.CoordinatesInFront().Equals(coordinatesInFront));
        }

        [Theory]
        [MemberData(nameof(CoordinatesBehindCases))]
        public void GetCoordinatesBehind(Position position, Coordinates coordinatesBehind)
        {
            Assert.True(position.CoordinatesBehind().Equals(coordinatesBehind));
        }

        public static IEnumerable<object[]> CoordinatesInFrontCases()
        {
            yield return new object[] { new Position(0, 0, Direction.EAST), new Coordinates(1, 0) };
            yield return new object[] { new Position(0, 0, Direction.NORTH), new Coordinates(0, 1) };
            yield return new object[] { new Position(1, 0, Direction.WEST), new Coordinates(0, 0) };
            yield return new object[] { new Position(0, 1, Direction.SOUTH), new Coordinates(0, 0) };
        }

        public static IEnumerable<object[]> CoordinatesBehindCases()
        {
            yield return new object[] { new Position(1, 0, Direction.EAST), new Coordinates(0, 0) };
            yield return new object[] { new Position(0, 1, Direction.NORTH), new Coordinates(0, 0) };
            yield return new object[] { new Position(0, 0, Direction.WEST), new Coordinates(1, 0) };
            yield return new object[] { new Position(0, 0, Direction.SOUTH), new Coordinates(0, 1) };
        }
    }
}
