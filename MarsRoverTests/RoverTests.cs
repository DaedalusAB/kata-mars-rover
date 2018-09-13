using System.Collections.Generic;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {
        private readonly RoverBuilder RoverBuilder = new RoverBuilder();

        [Theory]
        [MemberData(nameof(CreateRoverAtPositionCases))]
        public void CreateRoverAtPosition(Position initialPosition)
        {
            var rover = RoverBuilder
                .AtPosition(initialPosition)
                .Build();

            Assert.Equal(initialPosition, rover.Position);
        }

        public static IEnumerable<object[]> CreateRoverAtPositionCases()
        {
            yield return new object[] {new Position(new Coordinates(0, 0), Direction.North)};
            yield return new object[] { new Position(new Coordinates(1, 2), Direction.West) };
        }
    }
}
