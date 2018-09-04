using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class RoverMovementTests
    {
        [Fact]
        public void RoverMovesForwardFacingNorth()
        {
            var initialPosition = new Position(0, 0, DirectionEnum.North);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(0, 1, DirectionEnum.North);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesForwardFacingSouth()
        {
            var initialPosition = new Position(0, 1, DirectionEnum.South);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(0, 0, DirectionEnum.South);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesForwardFacingEast()
        {
            var initialPosition = new Position(0, 0, DirectionEnum.East);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(1, 0, DirectionEnum.East);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesForwardFacingWest()
        {
            var initialPosition = new Position(1, 0, DirectionEnum.West);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(0, 0, DirectionEnum.West);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingNorth()
        {
            var initialPosition = new Position(0, 1, DirectionEnum.North);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(0, 0, DirectionEnum.North);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingSouth()
        {
            var initialPosition = new Position(0, 0, DirectionEnum.South);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(0, 1, DirectionEnum.South);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingEast()
        {
            var initialPosition = new Position(1, 0, DirectionEnum.East);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(0, 0, DirectionEnum.East);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingWest()
        {
            var initialPosition = new Position(0, 0, DirectionEnum.West);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(1, 0, DirectionEnum.West);

            Assert.Equal(destination, rover.Position);
        }
    }
}
