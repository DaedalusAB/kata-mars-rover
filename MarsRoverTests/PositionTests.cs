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
            yield return new object[] { new Position(0, 0, DirectionEnum.East), new Coordinates(1, 0) };
            yield return new object[] { new Position(0, 0, DirectionEnum.North), new Coordinates(0, 1) };
            yield return new object[] { new Position(1, 0, DirectionEnum.West), new Coordinates(0, 0) };
            yield return new object[] { new Position(0, 1, DirectionEnum.South), new Coordinates(0, 0) };
        }

        public static IEnumerable<object[]> CoordinatesBehindCases()
        {
            yield return new object[] { new Position(1, 0, DirectionEnum.East), new Coordinates(0, 0) };
            yield return new object[] { new Position(0, 1, DirectionEnum.North), new Coordinates(0, 0) };
            yield return new object[] { new Position(0, 0, DirectionEnum.West), new Coordinates(1, 0) };
            yield return new object[] { new Position(0, 0, DirectionEnum.South), new Coordinates(0, 1) };
        }
    }
}
